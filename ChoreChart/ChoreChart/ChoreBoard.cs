using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoreChart
{
    class ChoreBoard
    {
        public List<String> Chores { get; set; }
        public List<String> Residents { get; set; }
        public List<bool> isDone { get; set; }
        public int size { get; set; }

        private MainForm Form;

        public ChoreBoard(MainForm Form)
        {
            this.Form = Form;
            Chores = new List<String>();
            Residents = new List<String>();
            isDone = new List<bool>();
            size = 0;
        }

        public ChoreBoard(MainForm Form, List<String> Chores, List<String> Residents, List<bool> isDone)
        {
            this.Form = Form;
            this.Chores = Chores;
            this.Residents = Residents;
            this.isDone = isDone;
            this.size = Chores.Count;
        }

        private void UpdateForm()
        {
            Form.UpdateVisual();
        }
    }
}
