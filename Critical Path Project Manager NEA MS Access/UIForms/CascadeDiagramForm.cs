using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Critical_Path_Project_Manager_NEA_MS_Access.UIForms
{
    public partial class CascadeDiagramForm : Form
    {
        private Dictionary<string, TaskNode> tasks;
        private List<string> sortedTaskNames;
        // Spacings and lengths
        private const int
            minTasksLengthScaleFactor = 50, 
            tasksWidth = 30,
            tasksVerticalSpacing = 20,
            tasksLeftMargin = 50,
            tasksTopMargin = 50,
            scaleLabelY = tasksTopMargin / 2;
            
        // Text font
        private Font font = new Font("Segoe UI", 9, FontStyle.Regular);

        // Pens
        private Pen
            taskPen = new Pen(Color.Black),
            floatPen = new Pen(Color.Black),
            scalePen = new Pen(Color.DarkGray);


        // Colours
        private Brush 
            criticalTasksColour = Brushes.IndianRed,
            nonCriticalTasksColour = Brushes.AliceBlue,
            independentFloatColour = Brushes.LightGray,
            interferingFloatColour = Brushes.Gray,
            fontColour = Brushes.Black;

       

        internal CascadeDiagramForm(List<string> sortedTaskNames, Dictionary<string, TaskNode> tasks)
        {
            InitializeComponent();
            this.tasks = tasks;
            this.sortedTaskNames = sortedTaskNames;
            floatPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            scalePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.AutoScroll = false;
        }

        private void drawKeyRectangle(Graphics g, int x, int y, int length, string text, Brush fillColour, Pen borderPen)
        {
            g.FillRectangle(fillColour, x, y, length, tasksWidth);
            g.DrawRectangle(borderPen, x, y, length, tasksWidth);
            int[] centredTextXY = centreStringInRectangleXY(g, text, x, y, length, tasksWidth);
            g.DrawString(text, font, fontColour, centredTextXY[0], centredTextXY[1]);
        }

        private void drawKey(Graphics g)
        {
            // Critical Task Key
            drawKeyRectangle(g, 20, 50, 150, "Critical Task", criticalTasksColour, taskPen);

            // Non Critical Task Key
            drawKeyRectangle(g, 20, 150, 150, "Non Critical Task", nonCriticalTasksColour, taskPen);

            // Independent Float Key
            drawKeyRectangle(g, 20, 250, 150, "Independent Float", independentFloatColour, floatPen);

            // Interfering Float Key
            drawKeyRectangle(g, 20, 350, 150, "Interfering Float", interferingFloatColour, floatPen);
        }

        // To add scrolling of graphics, created parent panel and larger child panel. This allows parent panel to scroll
        // which happens when a small parent contains a larger control, without messing up rendering
        private void drawCascadeDiagram(Graphics g)
        {
            int criticalPathRowY = tasksTopMargin;
            int nonCriticalTaskCount = 0;
            int totalDuration = tasks["End"].getEarliestStartTime(); // Duration of the project is EOS of dummy End node
            int dynamicTasksLengthScaleFactor = 1000 / totalDuration; // Suggests a scale factor such that the entire project will be roughly 1000 pixels
            int tasksLengthScaleFactor = Math.Max(dynamicTasksLengthScaleFactor, minTasksLengthScaleFactor); // Ensure project will either be roughly 1000 pixels long or more

            // Draw the scale
            
            // Calculate dimensions of diagram

            // Count how many rows there will be
            int rowCount = 1; // Initialised to 1 to account for critical path row
            foreach (TaskNode task in tasks.Values)
            {
                if (task.getTotalFloat() != 0) // If task is not critical, and so therefore will be on it's own row
                {
                    rowCount++;
                }
            }
            int diagramHeight = tasksTopMargin + rowCount * (tasksVerticalSpacing + tasksWidth);
            // Calculate the length
            int diagramLength = tasksLeftMargin + totalDuration * tasksLengthScaleFactor + tasksLengthScaleFactor / 2; // Adding half task unit margin on the end

            // Set size of child panel to be size of parent panel or larger (with larger being bounding the diagram)
            int panelLength = Math.Max(diagramLength, ParentPanel.Size.Width - 2); // - 2 to prevent auto scroll from triggering when child is set to exactly parent size, so child is set to 2 pixels smaller
            int panelHeight = Math.Max(diagramHeight, ParentPanel.Size.Height - 2);
            ChildCascadeDiagramPanel.Size = new System.Drawing.Size(panelLength, panelHeight);

            // Draw scale lines and time labels
            for (int t = 0; t <= ChildCascadeDiagramPanel.Size.Width / tasksLengthScaleFactor; t++)
            {
                int lineX = tasksLeftMargin + t * tasksLengthScaleFactor;
                int lineY = tasksTopMargin - 10; // Leave space for labels
                int lineLength = ChildCascadeDiagramPanel.Size.Height;
                g.DrawLine(scalePen, lineX, lineY, lineX, lineLength);

                // Centre the label 
                string label = t.ToString();
                int labelX = lineX - (int)g.MeasureString(label, font).Width / 2;
                int labelY = scaleLabelY - (int)g.MeasureString(label, font).Height / 2;
                g.DrawString(label, font, fontColour, labelX, labelY);
            }


            // Draw the tasks and floats
            for (int i = 0; i < sortedTaskNames.Count; i++) {

                // Retrieve task data
                TaskNode currentTask = tasks[sortedTaskNames[i]];
                string name = currentTask.getName();
                if (name == "Start" || name == "End") continue; // Skip the dummy Start and End nodes
                int duration = currentTask.getDuration();
                int earliestStartTime = currentTask.getEarliestStartTime();
                bool critical = currentTask.getTotalFloat() == 0; // If a task has no float, meaning it cannot be moved without delaying the project, it is critical
                int independentFloat = currentTask.getIndependentFloat();
                int interferingFloat = currentTask.getInterferingFloat();

                // Calculate position of each task rectangle and how long it will be
                // Then draw it
                int taskX = tasksLeftMargin + earliestStartTime * tasksLengthScaleFactor;
                int taskY;
                // If critical, it will be in the top critical row
                if (critical)
                {
                    taskY = criticalPathRowY;
                } 
                else
                {
                    // If not critical, each non critical task will be under
                    taskY = tasksTopMargin + tasksWidth * (nonCriticalTaskCount + 1) + tasksVerticalSpacing * (nonCriticalTaskCount + 1); // nonCriticalTaskCount + 1 as that will be how many rows are above (+1 from Critical Path Row)
                    nonCriticalTaskCount++;
                }
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

                // Truncate name and add ellipsis if it is too long
                name = truncateStringToFitRectangle(g, name, length);


                // Then draw it
                int[] centredNameXY = centreStringInRectangleXY(g, name, taskX, taskY, length, tasksWidth); // Start position of text for it to be centred
                g.DrawString(name, font, fontColour, centredNameXY[0], centredNameXY[1]);
            }
            
        }

        private string truncateStringToFitRectangle(Graphics g, string text, int rectLength)
        {
            string truncatedText = text;
            float textLength = g.MeasureString(text, font).Width;

            if (textLength >= rectLength)
            {
                float ellipsisLength = g.MeasureString("...", font).Width;
                int charsToRemove = 0;
                for (int i = text.Length - 1; i >= 0; i--)
                {
                    float truncatedTextLength = g.MeasureString(truncatedText, font).Width;
                    if (truncatedTextLength + ellipsisLength < rectLength)
                    {
                        break;
                    }
                    charsToRemove++;
                    truncatedText = text.Substring(0, text.Length - charsToRemove);
                }
                return truncatedText + "...";
            }
            return text;
        }

        // Calculate start position of text so it is centred
        private int[] centreStringInRectangleXY(Graphics g, string text, int rectX, int rectY, int rectLength, int rectWidth) 
        {
            int textX = rectX + rectLength / 2 - (int)g.MeasureString(text, font).Width / 2;
            int textY = rectY + rectWidth / 2 - (int)g.MeasureString(text, font).Height / 2;
            return new int[] { textX, textY };
        }
        private void ChildCascadeDiagramPanel_Paint(object sender, PaintEventArgs e)
        {
            drawCascadeDiagram(e.Graphics);
        }

        private void KeyPanel_Paint(object sender, PaintEventArgs e)
        {
            drawKey(e.Graphics);
        }

        // Prevent the key text box from getting focussed upon load
        private void KeyTextBox_Enter(object sender, EventArgs e)
        {
            ParentPanel.Focus();
        }
    }
}
