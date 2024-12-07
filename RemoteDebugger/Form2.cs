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
    public partial class Form2 : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        string viewName;
        public MemoryMappedFile m;
        public MemoryMappedViewStream s;
        public StreamReader t;

        public Form2(string name, string viewname)
        {
            viewName = viewname;
            m = MemoryMappedFile.OpenExisting(viewname);
            s = m.CreateViewStream();
            InitializeComponent();
            Text = name;
        }

        override protected string GetPersistString()
        {
            return viewName;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<string> lines = new List<string>();
            s.Seek(0, SeekOrigin.Begin);
            t = new StreamReader(s,Encoding.ASCII);
            {
                string line;
                while ((line = t.ReadLine()) != null)
                {
                    if (line.Length>0 && line[0] == 0)
                        break;
                    if (line.Length>0 && line[0]!='\0')
                        lines.Add(line);
                }

                string[] sArray = lines.ToArray();
                bool shouldUpdate = false;
                if (sArray.Count() == textBox1.Lines.Count())
                {
                    for (int a = 0; a < sArray.Count(); a++)
                    {
                        if (sArray[a] != textBox1.Lines[a])
                        {
                            //                            textBox1.Lines[a] = sArray[a];
                            shouldUpdate = true;
                            break;
                        }
                    }
                }
                else
                    shouldUpdate = true;
                if (shouldUpdate)
                {
                    textBox1.Lines = lines.ToArray();
                }
            }
        }
    }
}
