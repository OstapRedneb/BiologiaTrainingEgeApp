namespace BiologiaTrainingEgeApp
{
    partial class MainMenuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(344, 52);
            button1.Name = "button1";
            button1.Size = new Size(166, 72);
            button1.TabIndex = 0;
            button1.Text = "Читать лекции";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(344, 152);
            button2.Name = "button2";
            button2.Size = new Size(166, 72);
            button2.TabIndex = 1;
            button2.Text = "Решать задания";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(751, 12);
            button3.Name = "button3";
            button3.Size = new Size(147, 54);
            button3.TabIndex = 2;
            button3.Text = "Войти в аккаунт";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(344, 244);
            button4.Name = "button4";
            button4.Size = new Size(166, 72);
            button4.TabIndex = 3;
            button4.Text = "Создать задания для учеников";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(344, 339);
            button5.Name = "button5";
            button5.Size = new Size(166, 72);
            button5.TabIndex = 4;
            button5.Text = "Панель администратора";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(344, 433);
            button6.Name = "button6";
            button6.Size = new Size(166, 72);
            button6.TabIndex = 5;
            button6.Text = "Выход";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(12, 451);
            button7.Name = "button7";
            button7.Size = new Size(124, 54);
            button7.TabIndex = 6;
            button7.Text = "О нас";
            button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(751, 84);
            button8.Name = "button8";
            button8.Size = new Size(147, 54);
            button8.TabIndex = 7;
            button8.Text = "Зарегестрироваться";
            button8.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 526);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "MainMenu";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
    }
}
