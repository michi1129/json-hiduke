using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Globalization;

namespace Hiduke
{
    public partial class Form1 : Form
    {
        private string format_ = "yyyy/MM/dd HH:mm:ss";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime dt = new DateTime(1900, 1, 1);
            long l = DateTimeUtility.DateTimeToUnixTime(dt);
            string s = string.Format("/Date({0})/", l);

            textBox1.Text = dt.ToString(format_);
            textBox2.Text = s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string value = textBox1.Text;
            DateTime outDate;
            bool dateParseResult = DateTime.TryParseExact(value, format_, null, DateTimeStyles.None, out outDate);
            long l = DateTimeUtility.DateTimeToUnixTime(outDate);
            string s = string.Format("/Date({0})/", l);
            textBox2.Text = s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string value = textBox2.Text;
            DateTime dt = DateTimeUtility.JsonFormatToDateTime(value);
            textBox1.Text = dt.ToString(format_);
        }
    }
}
