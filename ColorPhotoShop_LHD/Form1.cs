using GreyPhotoShop_LHD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorPhotoShop_LHD
{
    public partial class MainForm : Form
    {
        //전역변수
        System.Byte[,] inImageR, inImageG, inImageB, outImageR, outImageG, outImageB;
        int inH, inW, outH, outW;
        Bitmap bmp;
        string filename = "";

        /// ******************************************************************
        /// 메뉴 클릭 이벤트 함수
        /// ******************************************************************

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "raw";
            ofd.Filter = "Color FILE(*.png;*.jpg;*.bmp;*.tif;)|*.png;*.jpg;*.bmp;*.tif";
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

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename == "")
                Equal_Image();

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "jpg";
            sfd.Filter = "JPG File(*.jpg)|*.jpg";
            sfd.ShowDialog();
            String savefilename = "";
            if (sfd.FileName.Length > 0)
            {
                foreach (string fname in sfd.FileNames)
                {
                    savefilename = fname; // 만약 여러개 선택시 마지막 것만 사용.
                }
                bmp.Save(savefilename, ImageFormat.Jpeg);
                MessageBox.Show(savefilename + "(으)로 저장됨");
            }
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void 어둡게하기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename != "")
                Subtract_Image();
            else
                MessageBox.Show("파일을 먼저 여세요.");
        }

        private void 곱셈ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Multiplication_Image();
        }

        private void 영상나눗셈ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Division_Image();
        }

        private void 영상ANDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            And_Image();
        }

        private void 영상ORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Or_Image();
        }

        private void 영상XORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Xor_Image();
        }

        private void 영상NOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Not_Image();
        }

        private void 감마ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gamma_Image();
        }

        private void 이진화ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename != "")
                BW1_Image();
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

        private void 이진화3ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (filename != "")
                BW3_Image();
            else
                MessageBox.Show("파일을 먼저 여세요.");
        }
        private void 반전ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename != "")
                Negative_Image();
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
            Mirror_UpDown_Image();
        }

        private void 영상미러링좌우ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mirror_LeftRight_Image();
        }
        private void 영상미러링대칭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mirror_Symmetry_Image();
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

        private void 영상회전포워딩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rotate_Forwarding_Image();
        }

        private void 영상회전백워딩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rotate_Backwarding_Image();
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
                if (incType == "INTEGER")
                    retValue = (int.Parse)(inpuDialog.numericUpDown1.Text);
                else if (incType == "DOUBLE")
                    retValue = (double.Parse)(inpuDialog.numericUpDown1.Text);
            }
            inpuDialog.Dispose();

            return retValue;
        }

        private void LoadImage(string fname)
        {
            //파일 열기 및 파일 크기 확인
            bmp = new Bitmap(fname);
            inW = bmp.Width;
            inH = bmp.Height;
            inImageR = inImageG = inImageB = null;
            inImageR = new System.Byte[inH, inW];
            inImageG = new System.Byte[inH, inW];
            inImageB = new System.Byte[inH, inW];
            //파일(비트맵) -> 메모리로 데이터 로딩
            for(int i=0; i<inH; i++)
                for(int k=0; k<inW; k++)
                {
                    Color c = bmp.GetPixel(i, k);
                    inImageR[i, k] = (System.Byte)c.R;
                    inImageG[i, k] = (System.Byte)c.G;
                    inImageB[i, k] = (System.Byte)c.B;
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
                    r = outImageR[i, k];
                    g = outImageG[i, k];
                    b = outImageB[i, k];
                    c = Color.FromArgb(r, g, b);
                    bmp.SetPixel(i, k, c);
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
            toolStripStatusLabel1.Text = strSize;
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

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    outImageR[i, k] = inImageR[i, k];
                    outImageG[i, k] = inImageG[i, k];
                    outImageB[i, k] = inImageB[i, k];
                }
            Display();
        }

        private void Add_Image()    //영상 덧셈 알고리즘
        {
            outH = inH;
            outW = inW;

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            NumericUpDown numericUpDown1;

            int addValue = (int)GetFromDialog_Value1("INTEGER");
            //int addValue = (int)GetFromDialog_Value1("DOUBLE");

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    int pixel = inImageR[i, k] + addValue;
                    if (pixel > 255)
                        outImageR[i, k] = 255;
                    else if (pixel < 0)
                        outImageR[i, k] = 0;
                    else
                        outImageR[i, k] = (System.Byte)(pixel);

                    pixel = inImageG[i, k] + addValue;
                    if (pixel > 255)
                        outImageG[i, k] = 255;
                    else if (pixel < 0)
                        outImageG[i, k] = 0;
                    else
                        outImageG[i, k] = (System.Byte)(pixel);

                    pixel = inImageB[i, k] + addValue;
                    if (pixel > 255)
                        outImageB[i, k] = 255;
                    else if (pixel < 0)
                        outImageB[i, k] = 0;
                    else
                        outImageB[i, k] = (System.Byte)(pixel);
                }
            Display();
        }

        private void Subtract_Image()    //영상 뺄셈 알고리즘
        {
            outH = inH;
            outW = inW;

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            int subtractValue = (int)GetFromDialog_Value1("INTEGER");
            //int addValue = (int)GetFromDialog_Value1("DOUBLE");

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    int pixel = inImageR[i, k] - subtractValue;
                    if (pixel < 0)
                        outImageR[i, k] = 0;
                    else if (pixel < 0)
                        outImageR[i, k] = 0;
                    else
                        outImageR[i, k] = (System.Byte)(pixel);

                    pixel = inImageG[i, k] - subtractValue;
                    if (pixel < 0)
                        outImageG[i, k] = 0;
                    else if (pixel < 0)
                        outImageG[i, k] = 0;
                    else
                        outImageG[i, k] = (System.Byte)(pixel);

                    pixel = inImageB[i, k] - subtractValue;
                    if (pixel < 0)
                        outImageB[i, k] = 0;
                    else if (pixel < 0)
                        outImageB[i, k] = 0;
                    else
                        outImageB[i, k] = (System.Byte)(pixel);
                }
            Display();
        }

        private void Multiplication_Image()    //영상 뺄셈 알고리즘
        {
            outH = inH;
            outW = inW;

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            int value = (int)GetFromDialog_Value1("INTEGER");
            //int addValue = (int)GetFromDialog_Value1("DOUBLE");

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    int pixel = inImageR[i, k] * value;
                    if (pixel < 0)
                        outImageR[i, k] = 0;
                    else if (pixel > 255)
                        outImageR[i, k] = 255;
                    else
                        outImageR[i, k] = (System.Byte)(pixel);

                    pixel = inImageG[i, k] * value;
                    if (pixel < 0)
                        outImageG[i, k] = 0;
                    else if (pixel > 255)
                        outImageG[i, k] = 255;
                    else
                        outImageG[i, k] = (System.Byte)(pixel);

                    pixel = inImageB[i, k] * value;
                    if (pixel < 0)
                        outImageB[i, k] = 0;
                    else if (pixel > 255)
                        outImageB[i, k] = 255;
                    else
                        outImageB[i, k] = (System.Byte)(pixel);
                }
            Display();
        }

        private void Division_Image()    //영상 뺄셈 알고리즘
        {
            outH = inH;
            outW = inW;

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            int value = (int)GetFromDialog_Value1("INTEGER");
            //int addValue = (int)GetFromDialog_Value1("DOUBLE");

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    int pixel = inImageR[i, k] / value;
                    if (pixel < 0)
                        outImageR[i, k] = 0;
                    else if (pixel > 255)
                        outImageR[i, k] = 255;
                    else
                        outImageR[i, k] = (System.Byte)(pixel);

                    pixel = inImageG[i, k] / value;
                    if (pixel < 0)
                        outImageG[i, k] = 0;
                    else if (pixel > 255)
                        outImageG[i, k] = 255;
                    else
                        outImageG[i, k] = (System.Byte)(pixel);

                    pixel = inImageB[i, k] / value;
                    if (pixel < 0)
                        outImageB[i, k] = 0;
                    else if (pixel > 255)
                        outImageB[i, k] = 255;
                    else
                        outImageB[i, k] = (System.Byte)(pixel);
                }
            Display();
        }

        private void And_Image()
        {
            outH = inH;
            outW = inW;

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            int value = (int)GetFromDialog_Value1("INTEGER");
            //int addValue = (int)GetFromDialog_Value1("DOUBLE");

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    int pixel = inImageR[i, k] & value;
                    if (pixel < 0)
                        outImageR[i, k] = 0;
                    else if (pixel > 255)
                        outImageR[i, k] = 255;
                    else
                        outImageR[i, k] = (System.Byte)(pixel);

                    pixel = inImageG[i, k] & value;
                    if (pixel < 0)
                        outImageG[i, k] = 0;
                    else if (pixel > 255)
                        outImageG[i, k] = 255;
                    else
                        outImageG[i, k] = (System.Byte)(pixel);

                    pixel = inImageB[i, k] & value;
                    if (pixel < 0)
                        outImageB[i, k] = 0;
                    else if (pixel > 255)
                        outImageB[i, k] = 255;
                    else
                        outImageB[i, k] = (System.Byte)(pixel);
                }
            Display();
        }

        private void Or_Image()
        {
            outH = inH;
            outW = inW;

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            int value = (int)GetFromDialog_Value1("INTEGER");
            //int addValue = (int)GetFromDialog_Value1("DOUBLE");

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    int pixel = inImageR[i, k] | value;
                    if (pixel < 0)
                        outImageR[i, k] = 0;
                    else if (pixel > 255)
                        outImageR[i, k] = 255;
                    else
                        outImageR[i, k] = (System.Byte)(pixel);

                    pixel = inImageG[i, k] | value;
                    if (pixel < 0)
                        outImageG[i, k] = 0;
                    else if (pixel > 255)
                        outImageG[i, k] = 255;
                    else
                        outImageG[i, k] = (System.Byte)(pixel);

                    pixel = inImageB[i, k] | value;
                    if (pixel < 0)
                        outImageB[i, k] = 0;
                    else if (pixel > 255)
                        outImageB[i, k] = 255;
                    else
                        outImageB[i, k] = (System.Byte)(pixel);
                }
            Display();
        }

        private void Xor_Image()
        {
            outH = inH;
            outW = inW;

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            int value = (int)GetFromDialog_Value1("INTEGER");
            //int addValue = (int)GetFromDialog_Value1("DOUBLE");

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    int pixel = inImageR[i, k] ^ value;
                    if (pixel < 0)
                        outImageR[i, k] = 0;
                    else if (pixel > 255)
                        outImageR[i, k] = 255;
                    else
                        outImageR[i, k] = (System.Byte)(pixel);

                    pixel = inImageG[i, k] ^ value;
                    if (pixel < 0)
                        outImageG[i, k] = 0;
                    else if (pixel > 255)
                        outImageG[i, k] = 255;
                    else
                        outImageG[i, k] = (System.Byte)(pixel);

                    pixel = inImageB[i, k] ^ value;
                    if (pixel < 0)
                        outImageB[i, k] = 0;
                    else if (pixel > 255)
                        outImageB[i, k] = 255;
                    else
                        outImageB[i, k] = (System.Byte)(pixel);
                }
            Display();
        }

        private void Not_Image()
        {
            outH = inH;
            outW = inW;

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    int pixel = ~inImageR[i, k];
                    outImageR[i, k] = (System.Byte)(pixel);

                    pixel = ~inImageG[i, k];
                    outImageG[i, k] = (System.Byte)(pixel);

                    pixel = ~inImageB[i, k];
                    outImageB[i, k] = (System.Byte)(pixel);
                }
            Display();
        }

        private void Gamma_Image()
        {
            outH = inH;
            outW = inW;

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            double value = (double)GetFromDialog_Value1("DOUBLE");

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    double pixelR = Math.Pow(inImageR[i, k], 1 / value);
                    if (pixelR < 0)
                        outImageR[i, k] = 0;
                    else if (pixelR > 255)
                        outImageR[i, k] = 255;
                    else
                        outImageR[i, k] = (System.Byte)(pixelR);

                    double pixelG = Math.Pow(inImageG[i, k], 1 / value);
                    if (pixelG < 0)
                        outImageG[i, k] = 0;
                    else if (pixelG > 255)
                        outImageG[i, k] = 255;
                    else
                        outImageG[i, k] = (System.Byte)(pixelG);

                    double pixelB = Math.Pow(inImageB[i, k], 1 / value);
                    if (pixelB < 0)
                        outImageB[i, k] = 0;
                    else if (pixelB > 255)
                        outImageB[i, k] = 255;
                    else
                        outImageB[i, k] = (System.Byte)(pixelB);
                }
            Display();
        }

        private void BW1_Image()
        {
            outH = inH;
            outW = inW;

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            int midValue = (int)GetFromDialog_Value1("INTEGER");

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    if (inImageR[i, k] < midValue)

                        outImageR[i, k] = 0;
                    else
                        outImageR[i, k] = 255;

                    if (inImageG[i, k] < midValue)

                        outImageG[i, k] = 0;
                    else
                        outImageG[i, k] = 255;

                    if (inImageB[i, k] < midValue)

                        outImageB[i, k] = 0;
                    else
                        outImageB[i, k] = 255;
                }
            Display();
        }

        private void BW2_Image()
        {
            outH = inH;
            outW = inW;

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            int Rradix = 0;
            int Gradix = 0;
            int Bradix = 0;
            int Rhap = 0;
            int Ghap = 0;
            int Bhap = 0;

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    Rhap += inImageR[i, k];
                    Ghap += inImageG[i, k];
                    Bhap += inImageB[i, k];
                }
            Rradix = Rhap / (inH * inW);
            Gradix = Ghap / (inH * inW);
            Bradix = Bhap / (inH * inW);

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    if (inImageR[i, k] < Rradix)

                        outImageR[i, k] = 0;
                    else
                        outImageR[i, k] = 255;

                    if (inImageG[i, k] < Gradix)

                        outImageG[i, k] = 0;
                    else
                        outImageG[i, k] = 255;

                    if (inImageB[i, k] < Bradix)

                        outImageB[i, k] = 0;
                    else
                        outImageB[i, k] = 255;
                }
            Display();
        }

        private void BW3_Image()
        {
            outH = inH;
            outW = inW;

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            int Rradix = 0;
            int Gradix = 0;
            int Bradix = 0;
            //1차원 배열 만드러 놓기.(inH*inW 크기)
            System.Byte[] arrayR = new System.Byte[inH * inW];
            System.Byte[] arrayG = new System.Byte[inH * inW];
            System.Byte[] arrayB = new System.Byte[inH * inW];
            //2차원 --> 1차원
            int idx = 0;
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    arrayR[idx] = inImageR[i, k];
                    arrayG[idx] = inImageG[i, k];
                    arrayB[idx] = inImageB[i, k];
                    idx++;
                }
            Array.Sort(arrayR);
            Array.Sort(arrayG);
            Array.Sort(arrayB);

            Rradix = arrayR[(inH * inW) / 2];
            Gradix = arrayG[(inH * inW) / 2];
            Bradix = arrayB[(inH * inW) / 2];

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    if (inImageR[i, k] < Rradix)

                        outImageR[i, k] = 0;
                    else
                        outImageR[i, k] = 255;

                    if (inImageG[i, k] < Gradix)

                        outImageG[i, k] = 0;
                    else
                        outImageG[i, k] = 255;

                    if (inImageB[i, k] < Bradix)

                        outImageB[i, k] = 0;
                    else
                        outImageB[i, k] = 255;
                }
            Display();
        }

        private void Negative_Image()
        {
            outH = inH;
            outW = inW;

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    int pixel = 255 - inImageR[i, k];
                    if (pixel < 0)
                        outImageR[i, k] = 0;
                    else if (pixel > 255)
                        outImageR[i, k] = 255;
                    else
                        outImageR[i, k] = (System.Byte)(pixel);

                    pixel = 255 - inImageG[i, k];
                    if (pixel < 0)
                        outImageG[i, k] = 0;
                    else if (pixel > 255)
                        outImageG[i, k] = 255;
                    else
                        outImageG[i, k] = (System.Byte)(pixel);

                    pixel = 255 - inImageB[i, k];
                    if (pixel < 0)
                        outImageB[i, k] = 0;
                    else if (pixel > 255)
                        outImageB[i, k] = 255;
                    else
                        outImageB[i, k] = (System.Byte)(pixel);
                }
            Display();
        }

        private void ParaCap_Image()
        {
            outH = inH;
            outW = inW;

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    outImageR[i, k] = (System.Byte)(255 - 255 * Math.Pow(inImageR[i, k] / 128.0 - 1, 2));
                    outImageG[i, k] = (System.Byte)(255 - 255 * Math.Pow(inImageG[i, k] / 128.0 - 1, 2));
                    outImageB[i, k] = (System.Byte)(255 - 255 * Math.Pow(inImageB[i, k] / 128.0 - 1, 2));
                }
            Display();
        }

        private void ParaCup_Image()
        {
            outH = inH;
            outW = inW;

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    outImageR[i, k] = (System.Byte)(255 * Math.Pow(inImageR[i, k] / 128.0 - 1, 2));
                    outImageG[i, k] = (System.Byte)(255 * Math.Pow(inImageG[i, k] / 128.0 - 1, 2));
                    outImageB[i, k] = (System.Byte)(255 * Math.Pow(inImageB[i, k] / 128.0 - 1, 2));
                }
            Display();
        }

        private void Mirror_UpDown_Image()
        {
            outH = inH;
            outW = inW;

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    outImageR[i, (inW - 1) - k] = inImageR[i, k];
                    outImageG[i, (inW - 1) - k] = inImageG[i, k];
                    outImageB[i, (inW - 1) - k] = inImageB[i, k];
                }
            Display();
        }

        private void Mirror_LeftRight_Image()
        {
            outH = inH;
            outW = inW;

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    outImageR[(inH - 1) - i,  k] = inImageR[i, k];
                    outImageG[(inH - 1) - i,  k] = inImageG[i, k];
                    outImageB[(inH - 1) - i,  k] = inImageB[i, k];
                }
            Display();
        }

        private void Mirror_Symmetry_Image()
        {
            outH = inH;
            outW = inW;

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    outImageR[(inH - 1) - i, (inW - 1) - k] = inImageR[i, k];
                    outImageG[(inH - 1) - i, (inW - 1) - k] = inImageG[i, k];
                    outImageB[(inH - 1) - i, (inW - 1) - k] = inImageB[i, k];
                }
            Display();
        }

        private void ZoomOut_Image()
        {
            //축소 배율 입력 받기
            int scale = (int)GetFromDialog_Value1("INTEGER");
            if (scale / 2.0 != scale / 2)
            {
                return;
            }

            outH = (int)(inH / scale);
            outW = (int)(inW / scale);

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    outImageR[i / scale, k / scale] = inImageR[i, k];
                    outImageG[i / scale, k / scale] = inImageG[i, k];
                    outImageB[i / scale, k / scale] = inImageB[i, k];
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

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    outImageR[i * scale, k * scale] = inImageR[i, k];
                    outImageG[i * scale, k * scale] = inImageG[i, k];
                    outImageB[i * scale, k * scale] = inImageB[i, k];
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

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                {
                    outImageR[i, k] = inImageR[i / scale, k / scale];
                    outImageG[i, k] = inImageG[i / scale, k / scale];
                    outImageB[i, k] = inImageB[i / scale, k / scale];
                }
            Display();
        }

        private void Move_Image()   //영상 이동 알고리즘
        {
            outH = inH;
            outW = inW;

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            int xVal = (int)GetFromDialog_Value1("INTEGER");
            int yVal = (int)GetFromDialog_Value1("INTEGER");
            //int addValue = (int)GetFromDialog_Value1("DOUBLE");

            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                {
                    int newX = i + xVal;
                    int newY = k + yVal;

                    if ((0 <= newX && newX < outH) && (0 <= newY && newY < outW))
                    {
                        outImageR[newX, newY] = inImageR[i, k];
                        outImageG[newX, newY] = inImageG[i, k];
                        outImageB[newX, newY] = inImageB[i, k];
                    }
                }
            Display();
        }

        private void Rotate_Forwarding_Image()
        {
            int angle = (int)GetFromDialog_Value1("INTEGER");
            double radin = angle * Math.PI / 180.0;
            outH = inH;
            outW = inW;

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            int CenterH = inH / 2; // 영상의 중심 좌표 CenterW = m_width / 2; // 영상의 중심 좌
            int CenterW = inW / 2; // 영상의 중심 좌표 CenterW = m_width / 2; // 영상의 중심 좌

            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                {
                    int newX = (int)((i - CenterH) * Math.Cos(radin) - (k - CenterW) * Math.Sin(radin) + CenterH);
                    int newY = (int)((i - CenterH) * Math.Sin(radin) + (k - CenterW) * Math.Cos(radin) + CenterW);

                    if ((0 <= newX && newX < outH) && (0 <= newY && newY < outW))
                    {
                        outImageR[newX, newY] = inImageR[i, k];
                        outImageG[newX, newY] = inImageG[i, k];
                        outImageB[newX, newY] = inImageB[i, k];
                    }
                }
            Display();
        }

        private void Rotate_Backwarding_Image()
        {
            int angle = (int)GetFromDialog_Value1("INTEGER");
            double radin = (angle * -1) * Math.PI / 180.0;
            outH = inH;
            outW = inW;

            outImageR = new System.Byte[0, 0];
            outImageG = new System.Byte[0, 0];
            outImageB = new System.Byte[0, 0];
            outImageR = new System.Byte[outH, outW];
            outImageG = new System.Byte[outH, outW];
            outImageB = new System.Byte[outH, outW];

            int CenterH = inH / 2; // 영상의 중심 좌표 CenterW = m_width / 2; // 영상의 중심 좌
            int CenterW = inW / 2; // 영상의 중심 좌표 CenterW = m_width / 2; // 영상의 중심 좌

            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                {
                    int newX = (int)((i - CenterH) * Math.Cos(radin) - (k - CenterW) * Math.Sin(radin) + CenterH);
                    int newY = (int)((i - CenterH) * Math.Sin(radin) + (k - CenterW) * Math.Cos(radin) + CenterW);

                    if ((0 <= newX && newX < outH) && (0 <= newY && newY < outW))
                    {
                        outImageR[i, k] = inImageR[newX, newY];
                        outImageG[i, k] = inImageG[newX, newY];
                        outImageB[i, k] = inImageB[newX, newY];
                    }
                }
            Display();
        }
    }
}
