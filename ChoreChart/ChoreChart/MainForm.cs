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
                new List<string>(){"Laundry","Garbage","Vacuum","Sweep"}, 
                new List<string>(){"Marc", "Zach", "Jake", "Joe"}, 
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
            Button rotateButton = new Button();
            Button closeButton = new Button();

            Size labelSize = 
                new Size(
                    (int)(this.Size.Width * .25f),
                    (int)(this.Size.Height / myChoreBoard.size)
                );
            Size buttonSize =
                new Size(
                    (int)(this.Size.Width / 8),
                    (int)(this.Size.Height / myChoreBoard.size )
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

                //funtionallity/style
                //default
                isDoneCheckBox[i].BackgroundImage = Images.Images[1];
                isDoneCheckBox[i].BackgroundImageLayout = ImageLayout.Stretch;

                isDoneCheckBox[i].CheckedChanged += (s, e) =>
                {
                    CheckBox checkBox = s as CheckBox;
                    if (checkBox.Checked)
                    {
                        checkBox.BackgroundImage = Images.Images[0];
                    }
                    else
                    {
                        checkBox.BackgroundImage = Images.Images[1];
                    }
                };
            }

            for (int i = 0; i < myChoreBoard.size; i++)
            {
                this.Controls.Add(Rlabels[i]);
                this.Controls.Add(Clabels[i]);
                this.Controls.Add(isDoneCheckBox[i]);
            }

            //buttons
            //location and size
            rotateButton.Location =
                    new Point(
                        labelSize.Width * 3,
                        ((this.Size.Height - 75) / 3) - buttonSize.Width / 2
                    );

            closeButton.Location =
                new Point(
                    labelSize.Width * 3,
                    (this.Size.Height - 75) / 3 * 2 - buttonSize.Width / 2
                );

            rotateButton.Size = buttonSize;
            closeButton.Size = buttonSize;

            //style
            rotateButton.Text = "Rotate";
            closeButton.Text = "Close";

            //Funtionality
            rotateButton.Click += (s, e) => 
            {
                myChoreBoard.rotateChores();
                UpdateVisual();
            };
            
            closeButton.Click += (s, e) =>
            {
                this.Close();
            }; 

            this.Controls.Add(rotateButton);
            this.Controls.Add(closeButton);

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
