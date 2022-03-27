using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OpenSlideNET;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Vision = Google.Cloud.Vision.V1;
using System.Text.RegularExpressions;

namespace Renamer
{
    public partial class MainForm : Form
    {

        public string[] filesPath;
        public List<string> arrRename;
        public string google_api_credentials;
        public string basePath;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Resize image
        /// </summary>
        /// <param name="imgToResize"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        /// <summary>
        /// Given a byte array in the format of bgra, convert it to <c>System.drawing.Image</c> /
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Image ImageFromRawBgraArray(byte[] arr, int width, int height)
        {
            var output = new Bitmap(width, height);
            var rect = new Rectangle(0, 0, width, height);
            var bmpData = output.LockBits(rect,
                ImageLockMode.ReadWrite, output.PixelFormat);
            var ptr = bmpData.Scan0;
            Marshal.Copy(arr, 0, ptr, arr.Length);
            output.UnlockBits(bmpData);
            return output;
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, ImageFormat.Bmp);
                return ms.ToArray();
            }
        }

        public Image GetImage(string path)
        {

            Image img;
            byte[] temp;
            try
            {
                using (OpenSlideImage image = OpenSlideImage.Open(path))
                {
                    var haha = new OpenSlideImage.ImageDimensions();
                    temp = image.ReadAssociatedImage("label", out haha);
                    img = ImageFromRawBgraArray(temp, (int)haha.Width, (int)haha.Height);
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }

            }
            catch
            {
                tbConsole.AppendText($"ERROR:: Failed reading slide\r\n");
                lbStatus.Text = "Failed opening label image";
                return null;

            }
            return img;
        }

        public String ProcessResult(String result)
        {
            result = Regex.Replace(result, "\n", " ");
            string[] subs = result.Split(' ');
            string haha = string.Join("-", subs);
            return Regex.Replace(haha, @"[^0-9a-zA-Z\._-]", ""); ;
        }

        private void updateDataGrid(bool clean_rename_cache = true)
        {
            dgRename.Rows.Clear();
            if (basePath is null) return;
            filesPath = Directory.GetFiles(basePath);
            if (clean_rename_cache)
            {
                arrRename = new List<String>();
                for (int i = 0; i < filesPath.Length; i++) arrRename.Add("");
            }
            for (int i = 0; i < filesPath.Length; i++)
            {
                dgRename.Rows.Add(Path.GetFileName(filesPath[i]), arrRename[i]);
                dgRename.Rows[i].HeaderCell.Value = String.Format("{0}", i + 1);
            }
        }

        private void toolStripbtnOpenFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    filesPath = Directory.GetFiles(fbd.SelectedPath);
                    arrRename = new List<String>();
                    int num_files = filesPath.Length;

                    basePath = fbd.SelectedPath;
                    toolStripLbPathInfo.Text = "Current location: " + fbd.SelectedPath;
                    tbConsole.AppendText(String.Format("Opened folder {0}", fbd.SelectedPath) + Environment.NewLine);
                    tbConsole.AppendText(String.Format("{0} files found", num_files) + Environment.NewLine);

                    for (int i = 0; i < filesPath.Length; i++)
                    {
                        arrRename.Add("");
                    }

                }

            }

            updateDataGrid();

        }

        private void toolStripbtnOpenAuth_Click(object sender, EventArgs e)
        {
            using (var fbd = new OpenFileDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.FileName))
                {
                    google_api_credentials = fbd.FileName;
                    tbConsole.AppendText("Set Google api credentials location as " + google_api_credentials + "\r\n");
                }

            }
        }

        private void btnRenameAll_Click(object sender, EventArgs e)
        {
            toolStripProgressBar.Maximum = arrRename.Count;
            toolStripProgressBar.Value = 0;
            for (int i = 0; i < filesPath.Length; i++)
            {
                if (arrRename[i] == "") continue;
                String temp = Path.Join(basePath, arrRename[i]);
                String newName = temp;
                newName = Path.GetExtension(newName) == "" ? newName + ".svs" : newName;

                Func<int, int> find_digit = x => x.ToString().Length > 3 ? 0 : 3 - x.ToString().Length;

                int counter = 2;
                while (filesPath[i].ToUpper() != newName.ToUpper() && File.Exists(newName))
                {
                    String extension = Path.GetExtension(temp) == "" ? ".svs" : Path.GetExtension(temp);
                    newName = Path.ChangeExtension(temp, null) + $"_{new String('0', find_digit(counter))}{counter}"
                                + extension;
                    counter++;
                }
                //tbConsole.AppendText($"from {filesPath[i]} to {newName}\r\n");
                File.Move(filesPath[i], newName);
                toolStripProgressBar.Value++;
            }
            lbStatus.Text = "Rename sucessfully\n";

            updateDataGrid();
        }

        private void btnRefreash_Click(object sender, EventArgs e)
        {
            updateDataGrid();
            tbConsole.AppendText("Refreshed\r\n");
            lbStatus.Text = "Refreash sucessfully\n";
        }

        private async void btnRunAPI_Click(object sender, EventArgs e)
        {
            if (google_api_credentials is null)
            {
                MessageBox.Show("No Google api credentials is specificed");
                return;
            }

            tbConsole.AppendText("Running Google vision API ...\r\n");
            toolStripProgressBar.Maximum = filesPath.Length;
            toolStripProgressBar.Value = 0;

            Vision.ImageAnnotatorClient client = null;
            try
            {
                client = new Vision.ImageAnnotatorClientBuilder
                {
                    CredentialsPath = google_api_credentials
                }.Build();
            }
            catch
            {
                MessageBox.Show("Probably something wrong with your credentials, try to reset it");
                tbConsole.AppendText("Task end due to error\r\n");
                return;
            }
            //var image = Vision.Image.FromBytes(ImageToByteArray())

            for (int i = 0; i < filesPath.Length; i++)
            {
                if (Path.GetExtension(filesPath[i]) != ".svs") continue;
                Image temp = GetImage(filesPath[i]);
                if (temp is null) continue;
                byte[] temp_arr = ImageToByteArray(temp);
                var image = Vision.Image.FromBytes(temp_arr);
                var imageContext = new Vision.ImageContext();
                imageContext.LanguageHints.Add("en");
                var task = client.DetectDocumentTextAsync(image, imageContext);
                var item = await task;
                arrRename[i] = ProcessResult(item.Text);
                dgRename.Rows[i].Cells[1].Value = arrRename[i];
                toolStripProgressBar.Value++;
                //updateDataGrid(false);
            }
            toolStripProgressBar.Value = toolStripProgressBar.Maximum;

            tbConsole.AppendText("done\r\n");
        }


        private void dgRename_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            String v = "null";
            String oldV = "null";

            if (row == -1 || col == -1) return;
            if (row >= 0 && row < dgRename.RowCount)
            {
                if (dgRename.Rows[row].Cells[col].Value is null) v = "";
                else { v = dgRename.Rows[row].Cells[col].Value.ToString(); };
                oldV = arrRename[row];
                arrRename[row] = v;
            }
        }
        ///
        private void dgRename_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.RowIndex > filesPath.Length - 1) return;
            if (Path.GetExtension(filesPath[e.RowIndex]) != ".svs") return;

            Image img = GetImage(filesPath[e.RowIndex]);
            if (img is null) return;

            int w = lbImage.Width;
            int h = lbImage.Height;

            int i = img.Width;
            int j = img.Height;

            int new_w = (int)((float)i / (float)Math.Max(i, j) * (float)w);
            int new_h = (int)((float)j / (float)Math.Max(i, j) * (float)h);

            img = resizeImage(img, new Size(new_w, new_h));
            lbImage.Image = img;

            lbStatus.Text = "Opened label image";
        }

    }
}
