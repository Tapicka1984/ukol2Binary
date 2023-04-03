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

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream tok = new FileStream("text.dat", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter zapis = new BinaryWriter(tok);
            zapis.Write(textBox1.Text);

            FileStream tok2 = new FileStream("sport.dat", FileMode.Open, FileAccess.Read);
            BinaryReader cteni = new BinaryReader(tok);
            string text = "";
            cteni.BaseStream.Position = 0;
            while (cteni.BaseStream.Position < cteni.BaseStream.Length)
            {
                text = cteni.ReadString();
            }
            if (text.Contains('!'))
            {
                text.Replace('.', '!');
            }
            FileStream tok3 = new FileStream("textOprav.dat", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter zapis2 = new BinaryWriter(tok);
            zapis2.Write(text);

            FileStream tok4 = new FileStream("textOprav.dat", FileMode.Open, FileAccess.Read);
            BinaryReader cteni2 = new BinaryReader(tok);
            label1.Text = cteni2.ReadString();
        }
    }
}
