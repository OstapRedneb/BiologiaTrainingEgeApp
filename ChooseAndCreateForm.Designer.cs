namespace BiologiaTrainingEgeApp
{
    partial class ChooseAndCreateForm
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
            buttonCreateTests = new Button();
            buttonCreateLectures = new Button();
            buttonBack = new Button();
            SuspendLayout();
            // 
            // buttonCreateTests
            // 
            buttonCreateTests.BackColor = Color.Teal;
            buttonCreateTests.Location = new Point(181, 180);
            buttonCreateTests.Name = "buttonCreateTests";
            buttonCreateTests.Size = new Size(166, 72);
            buttonCreateTests.TabIndex = 4;
            buttonCreateTests.Text = "Создать задание";
            buttonCreateTests.UseVisualStyleBackColor = false;
            buttonCreateTests.Click += buttonCreateTests_Click;
            // 
            // buttonCreateLectures
            // 
            buttonCreateLectures.BackColor = Color.Salmon;
            buttonCreateLectures.Location = new Point(453, 180);
            buttonCreateLectures.Name = "buttonCreateLectures";
            buttonCreateLectures.Size = new Size(166, 72);
            buttonCreateLectures.TabIndex = 5;
            buttonCreateLectures.Text = "Создать лекцию";
            buttonCreateLectures.UseVisualStyleBackColor = false;
            buttonCreateLectures.Click += buttonCreateLectures_Click;
            // 
            // buttonBack
            // 
            buttonBack.BackColor = Color.Red;
            buttonBack.Font = new Font("Comic Sans MS", 12F, FontStyle.Italic, GraphicsUnit.Point, 204);
            buttonBack.ForeColor = SystemColors.ButtonHighlight;
            buttonBack.Location = new Point(12, 12);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(77, 30);
            buttonBack.TabIndex = 8;
            buttonBack.Text = "Назад";
            buttonBack.UseVisualStyleBackColor = false;
            buttonBack.Click += buttonBack_Click;
            // 
            // ChooseAndCreateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LimeGreen;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonBack);
            Controls.Add(buttonCreateLectures);
            Controls.Add(buttonCreateTests);
            Name = "ChooseAndCreateForm";
            Text = "Выберите задание";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonCreateTests;
        private Button buttonCreateLectures;
        private Button buttonBack;
    }
}