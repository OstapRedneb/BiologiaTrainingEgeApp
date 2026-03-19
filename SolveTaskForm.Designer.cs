namespace BiologiaTrainingEgeApp
{
    partial class SolveTaskForm
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
            flowLayoutPanelTasks = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flowLayoutPanelTasks
            // 
            flowLayoutPanelTasks.AutoScroll = true;
            flowLayoutPanelTasks.Dock = DockStyle.Fill;
            flowLayoutPanelTasks.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelTasks.Location = new Point(0, 0);
            flowLayoutPanelTasks.Name = "flowLayoutPanelTasks";
            flowLayoutPanelTasks.Size = new Size(800, 450);
            flowLayoutPanelTasks.TabIndex = 0;
            flowLayoutPanelTasks.WrapContents = false;
            // 
            // SolveTaskForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flowLayoutPanelTasks);
            Name = "SolveTaskForm";
            Text = "SolveTaskForm";
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelTasks;
    }
}