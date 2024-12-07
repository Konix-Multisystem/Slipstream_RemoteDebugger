using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace RemoteDebugger
{
    public partial class Form1 : Form
    {
        DockPanel dockPanel;
        ButtonBar myButtonBar;
        Form2 myRegisters;
        Form2 myDisassm;
        Form2 myASIC;
        Form2 myDSP;
        Form2 myDSPRegisters;

        public Form1()
        {
            InitializeComponent();

            this.IsMdiContainer = true;
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(this.dockPanel);

            myButtonBar = new ButtonBar("Slip_Control");
            myRegisters = new Form2("Registers", "Slip_Registers");
            myDisassm = new Form2("Disassembly", "Slip_Disassm");
            myASIC = new Form2("ASIC", "Slip_ASIC");
            myDSP = new Form2("DSP", "Slip_DSP");
            myDSPRegisters = new Form2("DSP Registers", "Slip_DSPReg");
            if (File.Exists("layout.xml"))
            {
                dockPanel.LoadFromXml("layout.xml",DelegateHandler);
            }
            else
            {
                myButtonBar.Show(this.dockPanel, DockState.DockTop);
                myRegisters.Show(this.dockPanel, DockState.Document);
                myDisassm.Show(this.dockPanel, DockState.Document);
                myASIC.Show(this.dockPanel, DockState.Document);
                myDSP.Show(this.dockPanel, DockState.Document);
                myDSPRegisters.Show(this.dockPanel, DockState.Document);
            }
        }

        public IDockContent DelegateHandler(string name)
        {
            switch (name)
            {
                case "RemoteDebugger.ButtonBar":
                    return myButtonBar;
                case "Slip_Registers":
                    return myRegisters;
                case "Slip_ASIC":
                    return myASIC;
                case "Slip_Disassm":
                    return myDisassm;
                case "Slip_DSP":
                    return myDSP;
                case "Slip_DSPReg":
                    return myDSPRegisters;
                default:
                    break;
            }
            return null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            dockPanel.SaveAsXml("layout.xml");
        }
    }
}
