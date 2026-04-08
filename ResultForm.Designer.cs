namespace BiologiaTrainingEgeApp
{
    partial class ResultForm
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
            dataGridViewResults = new DataGridView();
            buttonFinish = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewResults
            // 
            dataGridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResults.Dock = DockStyle.Fill;
            dataGridViewResults.Location = new Point(0, 0);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.Size = new Size(800, 450);
            dataGridViewResults.TabIndex = 0;
            // 
            // buttonFinish
            // 
            buttonFinish.BackColor = SystemColors.ActiveCaption;
            buttonFinish.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonFinish.ForeColor = Color.FromArgb(64, 64, 0);
            buttonFinish.Location = new Point(702, 413);
            buttonFinish.Name = "buttonFinish";
            buttonFinish.Size = new Size(98, 37);
            buttonFinish.TabIndex = 1;
            buttonFinish.Text = "Завершить";
            buttonFinish.UseVisualStyleBackColor = false;
            buttonFinish.Click += buttonFinish_Click;
            // 
            // ResultForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonFinish);
            Controls.Add(dataGridViewResults);
            Name = "ResultForm";
            Text = "Результаты";
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewResults;
        private Button buttonFinish;
    }
}