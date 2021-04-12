using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STRIALG_BACKTRACK
{
    public partial class SizePicker : Form
    {
        public int Result { get; private set; }

        void Do()
        {
            Result = (int)SizeBox.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        public SizePicker(string Header, string Instruction, int min, int max)
        {
            InitializeComponent();

            Text = Header;
            InstructionLabel.Text = Instruction;

            SizeBox.Minimum = min;
            SizeBox.Maximum = max;

            DoneButton.Click += (o, e) => Do();
        }
    }
}
