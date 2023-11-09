using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Critical_Path_Project_Manager_NEA_MS_Access.UIForms
{
    public partial class CascadeDiagramForm : Form
    {
        private Dictionary<string, TaskNode> tasks;
        internal CascadeDiagramForm(List<string> sortedTaskNames, Dictionary<string, TaskNode> tasks)
        {
            InitializeComponent();
            this.tasks = tasks;
            this.AutoScroll = false;
        }

        private void DrawCascadeDiagram(Graphics g)
        {
            
            g.FillRectangle(Brushes.Blue, 50, 50, 100, 20);

            g.FillRectangle(Brushes.Red, 50, 1000, 100, 20);
        }


        private void CascadeDiagramForm_Load(object sender, EventArgs e)
        {

        }

        private void ChildCascadeDiagramPanel_Paint(object sender, PaintEventArgs e)
        {
            DrawCascadeDiagram(e.Graphics);
        }
    }
}
