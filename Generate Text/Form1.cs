using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generate_Text
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            textBox1.BorderStyle = BorderStyle.None;


            this.FormBorderStyle = FormBorderStyle.None;
            this.Load += new EventHandler(Form1_Load);


            int cornerRadius = 30; // نصف قطر الزوايا (يمكنك تعديله حسب رغبتك)
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            // تحديد الشكل المستطيل ذو الحواف الدائرية
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(this.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(this.Width - cornerRadius, this.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(0, this.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseAllFigures();

            // تعيين الشكل للفورم
            this.Region = new Region(path);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        void GenrateText(int A , int Z , int Length , bool Mix = false) 
        {

            Random rnd = new Random();
            string Text = "";

            if (!Mix)
            {
                for (int i = 0; i < Length; i++)
                {
                    Text += Convert.ToChar(rnd.Next(A, Z)).ToString();
                }
            }
            else
            {
                for (int i = 0; i < Length; i++)
                {
                    Text += Convert.ToChar(rnd.Next(33, 122)).ToString();
                }

            }

            textBox1.Text = Text;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (CapitalLetter.Checked)
            {
                GenrateText(65 , 90 , Convert.ToInt32(numericUpDown1.Value));
            }
        }

        bool CapitalLatter = false;

        private void CapitalLetter_Click(object sender, EventArgs e)
        {
            CapitalLatter = true;
        }
        private void SmallLetter_Click(object sender, EventArgs e)
        {
            CapitalLatter = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Focus();
        }

        private void textBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Red, 0, textBox1.Height - 1, textBox1.Width, textBox1.Height - 1);
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        void CheackLetterCapitalOrSmall () 
        {
            if (CapitalLatter)
                GenrateText(65, 90, Convert.ToInt32(numericUpDown1.Value));
            else
                GenrateText(97, 122, Convert.ToInt32(numericUpDown1.Value));
        
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (radioButton4.Checked)
                GenrateText(48, 57, Convert.ToInt32(numericUpDown1.Value));
            else if (radioButton2.Checked)
                GenrateText(33, 47, Convert.ToInt32(numericUpDown1.Value));
            else if (radioButton3.Checked)
                GenrateText(0, 0, Convert.ToInt32(numericUpDown1.Value), true);
            else if (radioButton1.Checked)
                CheackLetterCapitalOrSmall();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Clipboard.SetText(textBox1.Text);

            }
            else
            {
                MessageBox.Show("TextBox is Empty Please Input Value", "Input Value",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
