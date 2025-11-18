using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using ZXing;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        private Bitmap loadedImage;
        private bool drawing = false;
        private Point startPoint;
        private Rectangle currentROI = Rectangle.Empty;
        private List<ROI> rois = new List<ROI>();
        private int roiCounter = 0;

        public Form1()
        {
            InitializeComponent();

            // Thuật toán
            comboBoxAlgorithm.Items.AddRange(new string[] { "Barcode", "HSV", "Template Matching" });
            comboBoxAlgorithm.SelectedIndexChanged += ComboBoxAlgorithm_SelectedIndexChanged;

            // Barcode format
            comboBoxBarcodeFormat.Items.AddRange(new string[]
            {
                "AUTO", "CODE_128", "CODE_39", "EAN_13", "EAN_8", "QR_CODE"
            });
            comboBoxBarcodeFormat.SelectedIndex = 0;

            // PictureBox events
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseUp += PictureBox1_MouseUp;
            pictureBox1.Paint += PictureBox1_Paint;

            // ROI selection
            listBoxROI.SelectedIndexChanged += ListBoxROI_SelectedIndexChanged;

            // Ẩn controls barcode mặc định
            comboBoxBarcodeFormat.Visible = false;
            textBoxBarcodeLength.Visible = false;
            btnReadBarcode.Visible = false;
        }

        // Load ảnh
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.png;*.jpg;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                loadedImage = new Bitmap(ofd.FileName);
                pictureBox1.Image = loadedImage;
            }
        }

        // Vẽ ROI
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (loadedImage == null) return;
            drawing = true;
            startPoint = e.Location;
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                int x = Math.Min(startPoint.X, e.X);
                int y = Math.Min(startPoint.Y, e.Y);
                int w = Math.Abs(startPoint.X - e.X);
                int h = Math.Abs(startPoint.Y - e.Y);
                currentROI = new Rectangle(x, y, w, h);
                pictureBox1.Invalidate();
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                drawing = false;
                roiCounter++;
                ROI roi = new ROI
                {
                    id = roiCounter,
                    x = currentROI.X,
                    y = currentROI.Y,
                    w = currentROI.Width,
                    h = currentROI.Height
                };
                rois.Add(roi);
                listBoxROI.Items.Add($"ROI {roi.id}");
                currentROI = Rectangle.Empty;
                pictureBox1.Invalidate();
            }
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (currentROI != Rectangle.Empty)
                e.Graphics.DrawRectangle(Pens.Red, currentROI);

            foreach (var roi in rois)
            {
                e.Graphics.DrawRectangle(Pens.Blue, roi.x, roi.y, roi.w, roi.h);
            }
        }

        // Xóa ROI
        private void btnDeleteROI_Click_1(object sender, EventArgs e)
        {
            if (listBoxROI.SelectedIndex >= 0)
            {
                int index = listBoxROI.SelectedIndex;
                rois.RemoveAt(index);
                listBoxROI.Items.RemoveAt(index);
                pictureBox1.Invalidate();
            }
        }


        // Lưu ROI vào JSON
        private void btnSaveROI_Click_1(object sender, EventArgs e)
        {
            if (rois.Count == 0) return;
            string json = JsonConvert.SerializeObject(rois, Formatting.Indented);
            File.WriteAllText("rois.json", json);
            MessageBox.Show("Đã lưu ROI vào rois.json");
        }

        // Load ROI từ JSON
        private void btnLoadROI_Click_1(object sender, EventArgs e)
        {
            if (!File.Exists("rois.json")) return;
            string json = File.ReadAllText("rois.json");
            rois = JsonConvert.DeserializeObject<List<ROI>>(json);
            listBoxROI.Items.Clear();
            roiCounter = 0;
            foreach (var roi in rois)
            {
                roiCounter = Math.Max(roiCounter, roi.id);
                listBoxROI.Items.Add($"ROI {roi.id}");
            }
            pictureBox1.Invalidate();
        }


        // Thay đổi thuật toán
        private void ComboBoxAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isBarcode = comboBoxAlgorithm.SelectedItem.ToString() == "Barcode";
            comboBoxBarcodeFormat.Visible = isBarcode;
            textBoxBarcodeLength.Visible = isBarcode;
            btnReadBarcode.Visible = isBarcode;
        }

        private void ListBoxROI_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        // Đọc Barcode
        private void btnReadBarcode_Click_1(object sender, EventArgs e)
        {
            if (listBoxROI.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn ROI!");
                return;
            }
            if (comboBoxAlgorithm.SelectedItem?.ToString() != "Barcode")
            {
                MessageBox.Show("Vui lòng chọn thuật toán Barcode!");
                return;
            }

            ROI roi = rois[listBoxROI.SelectedIndex];

            Bitmap roiBmp = new Bitmap(roi.w, roi.h);
            using (Graphics g = Graphics.FromImage(roiBmp))
            {
                g.DrawImage(loadedImage, 0, 0, new Rectangle(roi.x, roi.y, roi.w, roi.h), GraphicsUnit.Pixel);
            }

            BarcodeReader reader = new BarcodeReader();
            if (comboBoxBarcodeFormat.SelectedItem.ToString() != "AUTO")
            {
                reader.Options.PossibleFormats = new List<BarcodeFormat> { MapBarcodeFormat(comboBoxBarcodeFormat.SelectedItem.ToString()) };
            }

            var result = reader.Decode(roiBmp);
            if (result != null)
            {
                // Kiểm tra độ dài nếu nhập
                if (int.TryParse(textBoxBarcodeLength.Text, out int length))
                {
                    if (result.Text.Length != length)
                    {
                        MessageBox.Show($"Barcode đọc được: {result.Text}\n(Không đúng độ dài {length})", "Kết quả Barcode");
                        return;
                    }
                }
                MessageBox.Show($"Barcode đọc được: {result.Text}", "Kết quả Barcode");
            }
            else
            {
                MessageBox.Show("Không đọc được barcode", "Kết quả Barcode");
            }
        }


        private BarcodeFormat MapBarcodeFormat(string format)
        {
            switch (format)
            {
                case "CODE_128":
                    return BarcodeFormat.CODE_128;
                case "CODE_39":
                    return BarcodeFormat.CODE_39;
                case "EAN_13":
                    return BarcodeFormat.EAN_13;
                case "EAN_8":
                    return BarcodeFormat.EAN_8;
                case "QR_CODE":
                    return BarcodeFormat.QR_CODE;
                default:
                    return BarcodeFormat.CODE_128;
            }
        }
    }

    public class ROI
    {
        public int id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int w { get; set; }
        public int h { get; set; }
    }
}
