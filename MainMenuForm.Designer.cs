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
            buttonReadLections = new Button();
            buttonSolve = new Button();
            buttonLogin = new Button();
            buttonCreateTests = new Button();
            buttonAdmin = new Button();
            buttonExit = new Button();
            buttonAboutUs = new Button();
            buttonRegistration = new Button();
            SuspendLayout();
            // 
            // buttonReadLections
            // 
            buttonReadLections.BackColor = Color.FromArgb(128, 255, 255);
            buttonReadLections.Location = new Point(359, 26);
            buttonReadLections.Name = "buttonReadLections";
            buttonReadLections.Size = new Size(166, 72);
            buttonReadLections.TabIndex = 0;
            buttonReadLections.Text = "Читать лекции";
            buttonReadLections.UseVisualStyleBackColor = false;
            buttonReadLections.Click += buttonReadLections_Click;
            // 
            // buttonSolve
            // 
            buttonSolve.BackColor = Color.FromArgb(255, 192, 128);
            buttonSolve.Location = new Point(359, 126);
            buttonSolve.Name = "buttonSolve";
            buttonSolve.Size = new Size(166, 72);
            buttonSolve.TabIndex = 1;
            buttonSolve.Text = "Решать задания";
            buttonSolve.UseVisualStyleBackColor = false;
            buttonSolve.Click += buttonSolve_Click;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.FromArgb(255, 255, 128);
            buttonLogin.Location = new Point(751, 12);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(147, 54);
            buttonLogin.TabIndex = 2;
            buttonLogin.Text = "Войти в аккаунт";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // buttonCreateTests
            // 
            buttonCreateTests.BackColor = Color.FromArgb(255, 128, 255);
            buttonCreateTests.Location = new Point(359, 218);
            buttonCreateTests.Name = "buttonCreateTests";
            buttonCreateTests.Size = new Size(166, 72);
            buttonCreateTests.TabIndex = 3;
            buttonCreateTests.Text = "Создать задания для учеников";
            buttonCreateTests.UseVisualStyleBackColor = false;
            buttonCreateTests.Click += buttonCreateTests_Click;
            // 
            // buttonAdmin
            // 
            buttonAdmin.BackColor = Color.FromArgb(255, 128, 128);
            buttonAdmin.Location = new Point(359, 313);
            buttonAdmin.Name = "buttonAdmin";
            buttonAdmin.Size = new Size(166, 72);
            buttonAdmin.TabIndex = 4;
            buttonAdmin.Text = "Панель администратора";
            buttonAdmin.UseVisualStyleBackColor = false;
            buttonAdmin.Click += buttonAdmin_Click;
            // 
            // buttonExit
            // 
            buttonExit.BackColor = Color.Red;
            buttonExit.Location = new Point(359, 407);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(166, 72);
            buttonExit.TabIndex = 5;
            buttonExit.Text = "Выход";
            buttonExit.UseVisualStyleBackColor = false;
            buttonExit.Click += buttonExit_Click;
            // 
            // buttonAboutUs
            // 
            buttonAboutUs.BackColor = Color.FromArgb(128, 128, 255);
            buttonAboutUs.Location = new Point(12, 451);
            buttonAboutUs.Name = "buttonAboutUs";
            buttonAboutUs.Size = new Size(124, 54);
            buttonAboutUs.TabIndex = 6;
            buttonAboutUs.Text = "О нас";
            buttonAboutUs.UseVisualStyleBackColor = false;
            buttonAboutUs.Click += buttonAboutUs_Click;
            // 
            // buttonRegistration
            // 
            buttonRegistration.BackColor = Color.FromArgb(255, 255, 128);
            buttonRegistration.Location = new Point(751, 81);
            buttonRegistration.Name = "buttonRegistration";
            buttonRegistration.Size = new Size(147, 54);
            buttonRegistration.TabIndex = 7;
            buttonRegistration.Text = "Зарегестрироваться";
            buttonRegistration.UseVisualStyleBackColor = false;
            buttonRegistration.Click += buttonRegistration_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 255, 128);
            ClientSize = new Size(910, 526);
            Controls.Add(buttonRegistration);
            Controls.Add(buttonAboutUs);
            Controls.Add(buttonExit);
            Controls.Add(buttonAdmin);
            Controls.Add(buttonCreateTests);
            Controls.Add(buttonLogin);
            Controls.Add(buttonSolve);
            Controls.Add(buttonReadLections);
            Name = "MainMenuForm";
            Text = "MainMenu";
            Load += MainMenuForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button buttonReadLections;
        private Button buttonSolve;
        private Button buttonLogin;
        private Button buttonCreateTests;
        private Button buttonAdmin;
        private Button buttonExit;
        private Button buttonAboutUs;
        private Button buttonRegistration;
    }
}
