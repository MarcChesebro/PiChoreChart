using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChoreChart
{
    public partial class MainForm : Form
    {
        private ChoreBoard myChoreBoard;

        private ListBox lstBox = new ListBox();

        public MainForm()
        {
            myChoreBoard = new ChoreBoard(this, 
                new List<string>(){"chore1","chore2","chore3","chore4"}, 
                new List<string>(){"r1", "r2", "r3", "r4"}, 
                new List<bool>(){false, false, false, false}
                );

            InitializeComponent();
            
        }

        public void UpdateVisual()
        {

            this.Controls.Clear();

            Label[] Rlabels = new Label[myChoreBoard.size];
            Label[] Clabels = new Label[myChoreBoard.size];
            Label[] Dlabels = new Label[myChoreBoard.size];

            for (int i = 0; i < myChoreBoard.size; i++)
            {
                Rlabels[i] = new Label();
                Rlabels[i].Text = myChoreBoard.Residents[i];
                Rlabels[i].Location = new Point(100, this.Size.Height / myChoreBoard.size * i);
                Rlabels[i].Size = new Size((int)(this.Size.Width * .33f), (int)(this.Size.Height / myChoreBoard.size));
                Rlabels[i].BorderStyle = BorderStyle.FixedSingle;
                Rlabels[i].Padding = new Padding(15);
                Rlabels[i].Margin = new Padding(15);
            }

            for (int i = 0; i < myChoreBoard.size; i++)
            {
                this.Controls.Add(Rlabels[i]);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateVisual();
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            UpdateVisual();
        }
    }
}
