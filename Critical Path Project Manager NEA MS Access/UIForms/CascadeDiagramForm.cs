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
        private List<string> sortedTaskNames;
        // Spacings and lengths
        private const int
            tasksLengthScaleFactor = 50,
            tasksWidth = 30,
            tasksVerticalSpacing = 20,
            tasksLeftMargin = 50;
        // Text font
        private Font font = new Font("Segoe UI", 9, FontStyle.Regular);
        // Task outlines
        private Pen 
            taskPen = new Pen(Color.Black),
            floatPen = new Pen(Color.Black);
        // Task colours
        private Brush 
            criticalTasksColour = Brushes.Aqua,
            nonCriticalTasksColour = Brushes.AliceBlue,
            independentFloatColour = Brushes.LightGray,
            interferingFloatColour = Brushes.Gray;

            
 
        internal CascadeDiagramForm(List<string> sortedTaskNames, Dictionary<string, TaskNode> tasks)
        {
            InitializeComponent();
            this.tasks = tasks;
            this.sortedTaskNames = sortedTaskNames;
            floatPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.AutoScroll = false;
        }

        // To add scrolling of graphics, created parent panel and larger child panel. This allows parent panel to scroll
        // which happens when a small parent contains a larger control, without messing up rendering
        private void DrawCascadeDiagram(Graphics g)
        {
            for (int i = 0; i < sortedTaskNames.Count; i++) {

                // Retrieve task data
                TaskNode currentTask = tasks[sortedTaskNames[i]];
                string name = currentTask.getName();
                if (name == "Start" || name == "End") continue; // Skip the dummy start and end nodes
                int duration = currentTask.getDuration();
                int earliestStartTime = currentTask.getEarliestStartTime();
                bool critical = currentTask.getTotalFloat() == 0; // If a task has no float, meaning it cannot be moved without delaying the project, it is critical
                int independentFloat = currentTask.getIndependentFloat();
                int interferingFloat = currentTask.getInterferingFloat();

                // Calculate position of each task rectangle and how long it will be
                // Then draw it
                int taskX = tasksLeftMargin + earliestStartTime * tasksLengthScaleFactor;
                int taskY = tasksVerticalSpacing * i + tasksWidth * i;
                int length = duration * tasksLengthScaleFactor;
                // Fill done first otherwise top and left of border gets covered
                g.FillRectangle((critical ? criticalTasksColour : nonCriticalTasksColour), taskX, taskY, length, tasksWidth);
                g.DrawRectangle(taskPen, taskX, taskY, length, tasksWidth);

                // Calculate position of each float rectange and how long it will be 
                // Then draw it

                // Independent Float
                int independentFloatX = taskX + length;
                int independentFloatY = taskY;
                int independentFloatLength = independentFloat * tasksLengthScaleFactor;
                g.FillRectangle(independentFloatColour, independentFloatX, independentFloatY, independentFloatLength, tasksWidth);
                g.DrawRectangle(floatPen, independentFloatX, independentFloatY, independentFloatLength, tasksWidth);

                //Interfering Float
                int interferingFloatX = independentFloatX + independentFloatLength;
                int interferingFloatY = taskY;
                int interferingFloatLength = interferingFloat * tasksLengthScaleFactor;
                g.FillRectangle(interferingFloatColour, interferingFloatX, interferingFloatY, interferingFloatLength, tasksWidth);
                g.DrawRectangle(floatPen, interferingFloatX, interferingFloatY, interferingFloatLength, tasksWidth);

                // Calculate start position of each name so it is centred
                // Then draw it
                int textX = taskX + length / 2 - (int)g.MeasureString(name, font).Width / 2;
                int textY = taskY + tasksWidth / 2 - (int)g.MeasureString(name, font).Height / 2;
                g.DrawString(name, font, Brushes.Black, textX, textY);
            }
            
        }


        private void ChildCascadeDiagramPanel_Paint(object sender, PaintEventArgs e)
        {
            DrawCascadeDiagram(e.Graphics);
        }
    }
}
