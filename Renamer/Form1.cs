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

        public string basePath;
        public string[] filesPath;
        public List<string> arrRename;

        public string google_api_credentials = "";
        private bool isStopBtnPressed = false;
        private int arrHead = 0;

        public MainForm()
        {
            InitializeComponent();

            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.google_application_credentials))
                google_api_credentials = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");
            else
            {
                google_api_credentials = Properties.Settings.Default.google_application_credentials;
            }
            tbConsole.AppendText(String.Format("INFO:: Using google application credentials located at {0}\r\n",
               google_api_credentials));

            if (Properties.Settings.Default.useFilter) rbFilter.Checked = true;
            else rbRaw.Checked = true;

            tbBlacklist.Text = Properties.Settings.Default.blacklist;
        }

        public string trimSpecialChar(string _in)
        {
            while (_in.Length > 0 && !Char.IsLetterOrDigit(_in[0]))
            {
                _in = _in.Remove(0, 1);

            }

            while (_in.Length > 0 && !Char.IsLetterOrDigit(_in[_in.Length - 1]))
            {
                _in = _in.Remove(_in.Length - 1);
            }

            return _in;
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
        /// Given a byte array in the format of BGRA, convert it to <c>System.drawing.Image</c> /
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

        /// <summary>
        /// Given the path to a svs file, read the label image
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
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
                return null;
            }
            return img;
        }

        public String ProcessString(String text)
        {
            // Remove item that contain the words in blacklist

            string[] blacklist = tbBlacklist.Text.Split(',');
            blacklist = (from i in blacklist select i.Trim()).ToArray();
            blacklist = blacklist.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToArray();

            text = Regex.Replace(text, "\n", " ");
            text = Regex.Replace(text, @"[^0-9a-zA-Z\s-_.]", "");
            string[] words = text.Split(' ');
            string[] filtered = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                filtered[i] = trimSpecialChar(words[i]);
                for (int j = 0; j < blacklist.Length; j++)
                {
                    if (words[i].ToLower().Contains(blacklist[j].ToLower()))
                    {
                        filtered[i] = "";
                        break;
                    }
                }
            }

            string result = string.Join("-", filtered.Where(s => !string.IsNullOrEmpty(s)));
            return result;
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
            arrHead = 0;
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
                    tbConsole.AppendText(String.Format("INFO:: Opened folder {0}", fbd.SelectedPath) + Environment.NewLine);
                    tbConsole.AppendText(String.Format("INFO:: {0} files found", num_files) + Environment.NewLine);

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
                    tbConsole.AppendText("INFO:: Set Google api credentials location as " + google_api_credentials + "\r\n");

                    Properties.Settings.Default.google_application_credentials = google_api_credentials;
                    Properties.Settings.Default.Save();
                }

            }
        }

        private void btnRenameAll_Click(object sender, EventArgs e)
        {   
            // reset progress bar
            toolStripProgressBar.Maximum = arrRename.Count;
            toolStripProgressBar.Value = 0;

            // rename loop
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

                File.Move(filesPath[i], newName);
                toolStripProgressBar.Value++;
            }

            tbConsole.AppendText("TASK:: Renaming done\r\n");
            updateDataGrid();
        }

        private void btnRefreash_Click(object sender, EventArgs e)
        {
            // Reload folder
            arrHead = 0;
            updateDataGrid();
            tbConsole.AppendText("TASK:: Refreashed\r\n");
        }

        private async void btnRunAPI_Click(object sender, EventArgs e)
        {
            /* Run google api */

            Vision.ImageAnnotatorClient _client;

            try
            {
                _client = new Vision.ImageAnnotatorClientBuilder
                {
                    CredentialsPath = google_api_credentials
                }.Build();
            }
            catch
            {
                try
                {
                    _client = new Vision.ImageAnnotatorClientBuilder
                    {
                        CredentialsPath = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS")
                    }.Build();
                }
                catch
                {
                    MessageBox.Show("ERROR:: Probably something wrong with google API credentials, try to reset it");
                    tbConsole.AppendText("ERROR:: Task end due to error\r\n");
                    return;
                }
            }

            isStopBtnPressed = false;
            bool useFilter = rbFilter.Checked;

            tbConsole.AppendText($"INFO:: Running Google vision API, process text using {(useFilter? "filter method": "raw method")} ...\r\n");
            toolStripProgressBar.Maximum = filesPath.Length;
            toolStripProgressBar.Value = 0;

            for (int i = arrHead; i < filesPath.Length; i++)
            {
                if (isStopBtnPressed)
                {
                    toolStripProgressBar.Value = toolStripProgressBar.Maximum;
                    tbConsole.AppendText("ALERT:: Task terminated due to user interuption\r\n");
                    return;
                }
                if (Path.GetExtension(filesPath[i]) != ".svs") continue;

                Image temp = GetImage(filesPath[i]);
                if (temp is null) continue;

                //byte[] temp_arr = ImageToByteArray(temp);
                // run google vision api
                var image = Vision.Image.FromBytes(ImageToByteArray(temp));
                var imageContext = new Vision.ImageContext();
                imageContext.LanguageHints.Add("en");
                var task = _client.DetectDocumentTextAsync(image, imageContext);
                var item = await task;

                // Format and save result
                if (useFilter) arrRename[i] = ProcessString(item.Text);
                else
                {
                    string w = Regex.Replace(item.Text, "\n", " ");
                    w = Regex.Replace(w, @"[^0-9a-zA-Z\s_-.]", "");
                    w = Regex.Replace(w, " ", "-");
                    w = trimSpecialChar(w);
                    arrRename[i] = w;
                }
                dgRename.Rows[i].Cells[1].Value = arrRename[i];
                toolStripProgressBar.Value = i;
                arrHead = i;
            }

            arrHead = 0;
            toolStripProgressBar.Value = toolStripProgressBar.Maximum;
            tbConsole.AppendText("TASK:: Run google api done\r\n");
        }


        private void dgRename_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /* On cell value change, update the arrRename array */

            int row = e.RowIndex;
            int col = e.ColumnIndex;

            if (row < 0|| row > dgRename.RowCount - 1 || col != 1) return;
            else
            {
                if (dgRename.Rows[row].Cells[col].Value is null) arrRename[row] = "";
                else { arrRename[row] = dgRename.Rows[row].Cells[col].Value.ToString(); };
            }
        }
        

        private void dgRename_CellClick(object sender, DataGridViewCellEventArgs e)
        {   
            /* Get and display the label image */

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
        }

        private void btnStopAPI_Click(object sender, EventArgs e)
        {   
            /* Stop the run_api function */

            isStopBtnPressed = true;
        }

        private void tbBlacklist_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.blacklist = tbBlacklist.Text;
            Properties.Settings.Default.Save();
        }

        private void rbRaw_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRaw.Checked) Properties.Settings.Default.useFilter = false;
            else Properties.Settings.Default.useFilter = true;

            Properties.Settings.Default.Save();
        }

    }
}
