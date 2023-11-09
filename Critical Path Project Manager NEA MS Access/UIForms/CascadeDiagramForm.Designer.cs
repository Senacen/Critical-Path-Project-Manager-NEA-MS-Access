namespace Critical_Path_Project_Manager_NEA_MS_Access.UIForms
{
    partial class CascadeDiagramForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ParentPanel = new System.Windows.Forms.Panel();
            this.ChildCascadeDiagramPanel = new System.Windows.Forms.Panel();
            this.ParentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ParentPanel
            // 
            this.ParentPanel.AutoScroll = true;
            this.ParentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ParentPanel.Controls.Add(this.ChildCascadeDiagramPanel);
            this.ParentPanel.Location = new System.Drawing.Point(385, 12);
            this.ParentPanel.Name = "ParentPanel";
            this.ParentPanel.Size = new System.Drawing.Size(1187, 915);
            this.ParentPanel.TabIndex = 0;
            // 
            // ChildCascadeDiagramPanel
            // 
            this.ChildCascadeDiagramPanel.BackColor = System.Drawing.SystemColors.Control;
            this.ChildCascadeDiagramPanel.Location = new System.Drawing.Point(0, 0);
            this.ChildCascadeDiagramPanel.Name = "ChildCascadeDiagramPanel";
            this.ChildCascadeDiagramPanel.Size = new System.Drawing.Size(2076, 2034);
            this.ChildCascadeDiagramPanel.TabIndex = 0;
            this.ChildCascadeDiagramPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ChildCascadeDiagramPanel_Paint);
            // 
            // CascadeDiagramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScrollMinSize = new System.Drawing.Size(2000, 2000);
            this.ClientSize = new System.Drawing.Size(1615, 980);
            this.Controls.Add(this.ParentPanel);
            this.Name = "CascadeDiagramForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cascade Diagram";
            this.ParentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ParentPanel;
        private System.Windows.Forms.Panel ChildCascadeDiagramPanel;
    }
}