using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteDebugger
{
    public partial class ButtonBar : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public MemoryMappedFile m;
        public MemoryMappedViewStream s;
        public BinaryWriter t;

        public ButtonBar(string viewname)
        {
            m = MemoryMappedFile.OpenExisting(viewname);
            s = m.CreateViewStream();
            t = new BinaryWriter(s);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // pause
            s.Seek(0, SeekOrigin.Begin);
            t.Write((byte)0);
            t.Write((byte)0xFF);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // step
            s.Seek(0, SeekOrigin.Begin);
            t.Write((byte)2);
            t.Write((byte)0xFF);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // play
            s.Seek(0, SeekOrigin.Begin);
            t.Write((byte)1);
            t.Write((byte)0xFF);
        }

        private void ButtonBar_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // frame step
            s.Seek(0, SeekOrigin.Begin);
            t.Write((byte)4);
            t.Write((byte)0xFF);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // step over
            s.Seek(0, SeekOrigin.Begin);
            t.Write((byte)3);
            t.Write((byte)0xFF);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            t.Seek(0, SeekOrigin.Begin);
            t.Write((byte)5);
            t.Write((byte)0xFF);
        }
    }
}
