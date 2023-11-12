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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CascadeDiagramForm));
            this.ParentPanel = new System.Windows.Forms.Panel();
            this.ChildCascadeDiagramPanel = new System.Windows.Forms.Panel();
            this.KeyPanel = new System.Windows.Forms.Panel();
            this.KeyGroupBox = new System.Windows.Forms.GroupBox();
            this.KeyTextBox = new System.Windows.Forms.TextBox();
            this.ParentPanel.SuspendLayout();
            this.KeyGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ParentPanel
            // 
            this.ParentPanel.AutoScroll = true;
            this.ParentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ParentPanel.Controls.Add(this.ChildCascadeDiagramPanel);
            this.ParentPanel.Location = new System.Drawing.Point(592, 21);
            this.ParentPanel.Name = "ParentPanel";
            this.ParentPanel.Size = new System.Drawing.Size(1187, 565);
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
            // KeyPanel
            // 
            this.KeyPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.KeyPanel.Location = new System.Drawing.Point(16, 28);
            this.KeyPanel.Name = "KeyPanel";
            this.KeyPanel.Size = new System.Drawing.Size(226, 455);
            this.KeyPanel.TabIndex = 1;
            this.KeyPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.KeyPanel_Paint);
            // 
            // KeyGroupBox
            // 
            this.KeyGroupBox.Controls.Add(this.KeyTextBox);
            this.KeyGroupBox.Controls.Add(this.KeyPanel);
            this.KeyGroupBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyGroupBox.Location = new System.Drawing.Point(21, 53);
            this.KeyGroupBox.Name = "KeyGroupBox";
            this.KeyGroupBox.Size = new System.Drawing.Size(547, 496);
            this.KeyGroupBox.TabIndex = 2;
            this.KeyGroupBox.TabStop = false;
            this.KeyGroupBox.Text = "Key";
            // 
            // KeyTextBox
            // 
            this.KeyTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyTextBox.Location = new System.Drawing.Point(248, 28);
            this.KeyTextBox.Multiline = true;
            this.KeyTextBox.Name = "KeyTextBox";
            this.KeyTextBox.ReadOnly = true;
            this.KeyTextBox.Size = new System.Drawing.Size(287, 455);
            this.KeyTextBox.TabIndex = 2;
            this.KeyTextBox.Text = resources.GetString("KeyTextBox.Text");
            this.KeyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.KeyTextBox.Enter += new System.EventHandler(this.KeyTextBox_Enter);
            // 
            // CascadeDiagramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(2000, 2000);
            this.ClientSize = new System.Drawing.Size(1813, 620);
            this.Controls.Add(this.KeyGroupBox);
            this.Controls.Add(this.ParentPanel);
            this.Name = "CascadeDiagramForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cascade Diagram";
            this.ParentPanel.ResumeLayout(false);
            this.KeyGroupBox.ResumeLayout(false);
            this.KeyGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ParentPanel;
        private System.Windows.Forms.Panel ChildCascadeDiagramPanel;
        private System.Windows.Forms.Panel KeyPanel;
        private System.Windows.Forms.GroupBox KeyGroupBox;
        private System.Windows.Forms.TextBox KeyTextBox;
    }
}