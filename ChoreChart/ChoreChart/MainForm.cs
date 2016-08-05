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
            CheckBox[] isDoneCheckBox = new CheckBox[myChoreBoard.size];

            Size labelSize = 
                new Size(
                    (int)(this.Size.Width * .25f),
                    (int)(this.Size.Height / myChoreBoard.size)
                );
                

            for (int i = 0; i < myChoreBoard.size; i++)
            {
                //Residents Labels
                //Text
                Rlabels[i] = new Label();
                Rlabels[i].Text = myChoreBoard.Residents[i];
                Rlabels[i].TextAlign = ContentAlignment.MiddleCenter;

                ////location/Size
                Rlabels[i].Location =
                    new Point(
                       0,
                        (this.Size.Height - 75) / myChoreBoard.size * i
                    );
                Rlabels[i].Size = labelSize;

                //Style
                Rlabels[i].BorderStyle = BorderStyle.FixedSingle;
                Rlabels[i].Padding = new Padding(15);
                Rlabels[i].Margin = new Padding(15);

                //Chore Labels
                //Text
                Clabels[i] = new Label();
                Clabels[i].Text = myChoreBoard.Chores[i];
                Clabels[i].TextAlign = ContentAlignment.MiddleCenter;
                
                //location/Size
                Clabels[i].Location = 
                    new Point(
                        labelSize.Width,
                        (this.Size.Height - 75) / myChoreBoard.size * i
                    );
                Clabels[i].Size = labelSize;
                
                //Style
                Clabels[i].BorderStyle = BorderStyle.FixedSingle;
                Clabels[i].Padding = new Padding(15);
                Clabels[i].Margin = new Padding(15);

                //isDoneCheckBox
                isDoneCheckBox[i] = new CheckBox();
                isDoneCheckBox[i].Appearance = Appearance.Button;
                isDoneCheckBox[i].Checked = false;

                //Location/size
                isDoneCheckBox[i].Location =
                    new Point(
                        labelSize.Width * 2,
                        (this.Size.Height - 75) / myChoreBoard.size * i
                    );
                isDoneCheckBox[i].Size = labelSize;
            }

            for (int i = 0; i < myChoreBoard.size; i++)
            {
                this.Controls.Add(Rlabels[i]);
                this.Controls.Add(Clabels[i]);
                this.Controls.Add(isDoneCheckBox[i]);
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
