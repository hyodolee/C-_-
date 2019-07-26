using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreyPhotoShop_LHD
{
    public partial class MainForm : Form
    {
        // 전역변수 선언
        System.Byte[,] inImage, outImage;
        int inH, inW, outH, outW;
        Bitmap bmp;
        string filename = "";
        int sx, sy, ex, ey;

        /// ******************************************************************
        /// 메뉴 클릭 이벤트 함수
        /// ******************************************************************

        private void 열기GreyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        private void 동일영상ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename != "")
                Equal_Image();
            else
                MessageBox.Show("파일을 먼저 여세요.");
        }

        private void 밝게하기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename != "")
                Add_Image();
            else
                MessageBox.Show("파일을 먼저 여세요.");
        }

        private void 이진화2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename != "")
                BW2_Image();
            else
                MessageBox.Show("파일을 먼저 여세요.");
        }

        private void 이진화3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename != "")
                BW3_Image();
            else
                MessageBox.Show("파일을 먼저 여세요.");
        }

        private void 파라볼라캡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename != "")
                ParaCap_Image();
            else
                MessageBox.Show("파일을 먼저 여세요.");
        }

        private void 파라볼라컵ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename != "")
                ParaCup_Image();
            else
                MessageBox.Show("파일을 먼저 여세요.");
        }
        private void 영상미러링상하ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename != "")
                Mirror_UpDown_Image();
            else
                MessageBox.Show("파일을 먼저 여세요.");
        }
        private void 영상축소ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename != "")
                ZoomOut_Image();
            else
                MessageBox.Show("파일을 먼저 여세요.");
        }
        private void 영상확대포워딩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename != "")
                ZoomIn1_Image();
            else
                MessageBox.Show("파일을 먼저 여세요.");
        }
        private void 영상확대백워딩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename != "")
                ZoomIn2_Image();
            else
                MessageBox.Show("파일을 먼저 여세요.");
        }
        private void 영상이동ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename != "")
                Move_Image();
            else
                MessageBox.Show("파일을 먼저 여세요.");
        }
        private void 영상회전ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename != "")
                Rotate_Image();
            else
                MessageBox.Show("파일을 먼저 여세요.");
        }
        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool mouseYN = false;
        private void 영상이동마우스ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mouseYN = true;
        }
        private void Pb_paper_MouseDown(object sender, MouseEventArgs e)
        {
            if (!mouseYN)
                return;
            sx = e.Location.X;
            sy = e.Location.Y;
            Cursor.Current = Cursors.Hand;
        }

        private void Pb_paper_MouseUp(object sender, MouseEventArgs e)
        {
            if (!mouseYN)
                return;
            ex = e.Location.X;
            ey = e.Location.Y;

            outH = inH;
            outW = inW;

            outImage = new System.Byte[0, 0];   //메모리 비우기
            outImage = new System.Byte[outH, outW];

            int xVal = ex - sx;
            int yVal = ex - sx;
            //int addValue = (int)GetFromDialog_Value1("DOUBLE");

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    int newX = i + xVal;
                    int newY = k + yVal;

                    if ((0 <= newX && newX < outH) && (0 <= newY && newY < outW))
                    {
                        outImage[newX, newY] = inImage[i, k];
                    }
                }
            Display();
            mouseYN = false;
            Cursor.Current = Cursors.Default;
        }

        bool keyYN = false;
        int addBrightValue = 0;
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!keyYN)
                return;
            if (e.KeyCode == Keys.Up)
                addBrightValue += 10;
            else if (e.KeyCode == Keys.Down)
                addBrightValue -= 10;
            else if (e.KeyCode == Keys.PageUp)
                addBrightValue += 30;
            else if (e.KeyCode == Keys.PageDown)
                addBrightValue -= 30;
            else if (e.KeyCode == Keys.Escape)
            {
                keyYN = false;
                return;
            }

            outH = inH;
            outW = inW;

            outImage = new System.Byte[0, 0];   //메모리 비우기
            outImage = new System.Byte[outH, outW];

            NumericUpDown numericUpDown1;

            int addValue = addBrightValue;
            //int addValue = (int)GetFromDialog_Value1("DOUBLE");

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    int pixel = inImage[i, k] + addValue;
                    if (pixel > 255)
                        outImage[i, k] = 255;
                    else if (pixel < 0)
                        outImage[i, k] = 0;
                    else
                        outImage[i, k] = (System.Byte)(pixel);
                }
            Display();
        }

        private void 밝게어둡게키보드ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            keyYN = true;
        }

        /// ******************************************************************
        /// 공통 함수 부분
        /// ******************************************************************

        private double GetFromDialog_Value1(string incType)
        {
            double retValue = 0.0;
            Form_Input_Integer1 inpuDialog = new Form_Input_Integer1();
            if (incType == "INTEGER")
            {
                inpuDialog.numericUpDown1.DecimalPlaces = 0;
                inpuDialog.numericUpDown1.Increment = 1M;
            }
            else if (incType == "DOUBLE")
            {
                inpuDialog.numericUpDown1.DecimalPlaces = 1;
                inpuDialog.numericUpDown1.Increment = 0.1M;
            }


            if (inpuDialog.ShowDialog(this) == DialogResult.OK)
            {
                retValue = (int.Parse)(inpuDialog.numericUpDown1.Text);
            }
            inpuDialog.Dispose();

            return retValue;
        }
        private void OpenImage()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "raw";
            ofd.Filter = "RAW FILE(*.raw)|*.raw";
            ofd.ShowDialog();

            if (ofd.FileName.Length > 0)
            {
                foreach (string fname in ofd.FileNames)
                {
                    filename = fname;
                }
                LoadImage(filename);
                Equal_Image();
            }
        }

        private void LoadImage(string fname)
        {
            Int64 fSize = new FileInfo(filename).Length;
            inH = inW = (int)Math.Sqrt(fSize);

            inImage = new System.Byte[inH, inW];

            using (BinaryReader rdr = new BinaryReader(File.Open(fname, FileMode.Open)))
            {
                for (int i = 0; i < inH; i++)
                {
                    for (int k = 0; k < inW; k++)
                    {
                        System.Byte bt = rdr.ReadByte();
                        inImage[i, k] = bt;
                    }
                }
            }
        }

        private void Display()
        {
            bmp = new Bitmap(outH, outW);
            this.Size = new Size(outH + 20, outW + 72);

            Color c;
            int r, g, b;

            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                {
                    r = g = b = outImage[i, k];
                    c = Color.FromArgb(r, g, b);
                    bmp.SetPixel(k, i, c);
                }
            pb_paper.Image = bmp;

            pb_paper.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            pb_paper.Size = new Size(outH, outW);

            //화면이 너무 작으면 메뉴가 안보여요.
            if (outH < 400 || outW < 400)
                this.Size = new Size(400 + 20, 400 + 72);

            //영상의 크기를 상태바에 보이기
            string strSize;
            strSize = "영상크기: " + outH.ToString() + "x" + outW.ToString();
            tool_lable.Text = strSize;
        }

        public MainForm()
        {
            InitializeComponent();
        }

       
        //////////////////////////////////////////////////////
        //      이미지 프로세싱 함수모음
        /////////////////////////////////////////////////////

        private void Equal_Image()
        {
            outH = inH;
            outW = inW;

            outImage = new System.Byte[0, 0];
            outImage = new System.Byte[outH, outW];

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    outImage[i, k] = inImage[i, k];
                }
            Display();
        }

        private void Add_Image()    //영상 덧셈 알고리즘
        {
            outH = inH;
            outW = inW;

            outImage = new System.Byte[0, 0];   //메모리 비우기
            outImage = new System.Byte[outH, outW];

            NumericUpDown numericUpDown1;

            int addValue = (int) GetFromDialog_Value1("INTEGER");
            //int addValue = (int)GetFromDialog_Value1("DOUBLE");

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    int pixel = inImage[i,k] + addValue;
                    if (pixel > 255)
                        outImage[i, k] = 255;
                    else if(pixel < 0)
                        outImage[i, k] = 0;
                    else
                        outImage[i, k] = (System.Byte)(pixel);
                }
            Display();
        }

        private void BW2_Image()
        {
            outH = inH;
            outW = inW;

            outImage = new System.Byte[0, 0];   //메모리 비우기
            outImage = new System.Byte[outH, outW];

            int radix = 0;
            int hap = 0;

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    hap += inImage[i, k];
                }
            radix = hap / (inH * inW);

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    if (inImage[i, k] < radix )

                        outImage[i, k] = 0;
                    else
                        outImage[i, k] = 255;
                }
            Display();
        }

        private void BW3_Image()
        {
            outH = inH;
            outW = inW;

            outImage = new System.Byte[0, 0];   //메모리 비우기
            outImage = new System.Byte[outH, outW];

            int radix = 0;
            //1차원 배열 만드러 놓기.(inH*inW 크기)
            System.Byte[] array1 = new System.Byte[inH * inW];
            //2차원 --> 1차원
            int idx = 0;
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    array1[idx] = inImage[i, k];
                    idx++;
                }
            Array.Sort(array1);

            radix = array1[(inH * inW) / 2];

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    if (inImage[i, k] < radix)

                        outImage[i, k] = 0;
                    else
                        outImage[i, k] = 255;
                }
            Display();
        }

        private void ParaCap_Image()
        {
            outH = inH;
            outW = inW;

            outImage = new System.Byte[0, 0];   //메모리 비우기
            outImage = new System.Byte[outH, outW];

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    outImage[i, k] = (System.Byte)(255 - 255 * Math.Pow(inImage[i,k]/128.0 - 1, 2));
                }
            Display();
        }

        private void ParaCup_Image()
        {
            outH = inH;
            outW = inW;

            outImage = new System.Byte[0, 0];   //메모리 비우기
            outImage = new System.Byte[outH, outW];

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    outImage[i, k] = (System.Byte)(255 * Math.Pow(inImage[i, k] / 128.0 - 1, 2));
                }
            Display();
        }

        private void Mirror_UpDown_Image()
        {
            outH = inH;
            outW = inW;

            outImage = new System.Byte[0, 0];
            outImage = new System.Byte[outH, outW];

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    outImage[(inH -1)-i, k] = inImage[i, k];
                }
            Display();
        }

        private void ZoomOut_Image()
        {
            //축소 배율 입력 받기
            int scale = (int)GetFromDialog_Value1("INTEGER");
            if(scale / 2.0 != scale / 2)
            {
                return;
            }

            outH = (int)(inH / scale);
            outW = (int)(inW / scale);

            outImage = new System.Byte[0, 0];
            outImage = new System.Byte[outH, outW];

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    outImage[i / scale, k / scale] = inImage[i, k];
                }
            Display();
        }

        private void ZoomIn1_Image()    //영상확대 (포워딩) 알고리즘
        {
            //축소 배율 입력 받기
            int scale = (int)GetFromDialog_Value1("INTEGER");
            if (scale / 2.0 != scale / 2)
            {
                return;
            }

            outH = (int)(inH * scale);
            outW = (int)(inW * scale);

            outImage = new System.Byte[0, 0];
            outImage = new System.Byte[outH, outW];

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    outImage[i * scale, k * scale] = inImage[i, k];
                }
            Display();
        }

        private void ZoomIn2_Image()    //영상확대 (백워딩) 알고리즘
        {
            //축소 배율 입력 받기
            int scale = (int)GetFromDialog_Value1("INTEGER");
            if (scale / 2.0 != scale / 2)
            {
                return;
            }

            outH = (int)(inH * scale);
            outW = (int)(inW * scale);

            outImage = new System.Byte[0, 0];
            outImage = new System.Byte[outH, outW];

            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                {
                    outImage[i, k] = inImage[i/scale, k/scale];
                }
            Display();
        }

        private void Move_Image()   //영상 이동 알고리즘
        {
            outH = inH;
            outW = inW;

            outImage = new System.Byte[0, 0];   //메모리 비우기
            outImage = new System.Byte[outH, outW];

            int xVal = (int)GetFromDialog_Value1("INTEGER");
            int yVal = (int)GetFromDialog_Value1("INTEGER");
            //int addValue = (int)GetFromDialog_Value1("DOUBLE");

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    int newX = i + xVal;
                    int newY = k + yVal;

                    if(( 0 <= newX && newX < outH) && (0 <= newY && newY < outW))
                    {
                        outImage[newX, newY] = inImage[i, k];
                    }
                }
            Display();
        }
        private void Rotate_Image()   //영상 이동 알고리즘
        {
            int angle = (int)GetFromDialog_Value1("INTEGER");
            double radin = angle * Math.PI / 180.0;
            outH = inH;
            outW = inW;

            outImage = new System.Byte[0, 0];   //메모리 비우기
            outImage = new System.Byte[outH, outW];

            int CenterH = inH / 2; // 영상의 중심 좌표 CenterW = m_width / 2; // 영상의 중심 좌
            int CenterW = inW / 2; // 영상의 중심 좌표 CenterW = m_width / 2; // 영상의 중심 좌

            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                {
                    int newX = (int)((i - CenterH) * Math.Cos(radin) - (k - CenterW) * Math.Sin(radin) + CenterH);
                    int newY = (int)((i - CenterH) * Math.Sin(radin) + (k - CenterW) * Math.Cos(radin) + CenterW);

                    if ((0 <= newX && newX < outH) && (0 <= newY && newY < outW))
                    {
                        outImage[i, k] = inImage[newX, newY];
                    }
                }
            Display();
        }
    }
}
