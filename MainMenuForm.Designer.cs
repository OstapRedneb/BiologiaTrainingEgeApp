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
            buttonExit = new Button();
            buttonAboutUs = new Button();
            buttonRegistration = new Button();
            labelAcount = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // buttonReadLections
            // 
            buttonReadLections.BackColor = Color.FromArgb(128, 255, 255);
            buttonReadLections.Location = new Point(383, 156);
            buttonReadLections.Name = "buttonReadLections";
            buttonReadLections.Size = new Size(148, 64);
            buttonReadLections.TabIndex = 0;
            buttonReadLections.Text = "Читать лекции";
            buttonReadLections.UseVisualStyleBackColor = false;
            buttonReadLections.Click += buttonReadLections_Click;
            // 
            // buttonSolve
            // 
            buttonSolve.BackColor = Color.FromArgb(255, 192, 128);
            buttonSolve.Location = new Point(383, 261);
            buttonSolve.Name = "buttonSolve";
            buttonSolve.Size = new Size(148, 64);
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
            buttonCreateTests.Location = new Point(383, 359);
            buttonCreateTests.Name = "buttonCreateTests";
            buttonCreateTests.Size = new Size(148, 64);
            buttonCreateTests.TabIndex = 3;
            buttonCreateTests.Text = "Создать";
            buttonCreateTests.UseVisualStyleBackColor = false;
            buttonCreateTests.Click += buttonCreateTests_Click;
            // 
            // buttonExit
            // 
            buttonExit.BackColor = Color.Red;
            buttonExit.Location = new Point(383, 452);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(148, 64);
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
            // labelAcount
            // 
            labelAcount.AutoSize = true;
            labelAcount.BackColor = Color.SlateGray;
            labelAcount.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            labelAcount.ForeColor = SystemColors.ButtonHighlight;
            labelAcount.Location = new Point(15, 11);
            labelAcount.Name = "labelAcount";
            labelAcount.Size = new Size(183, 34);
            labelAcount.TabIndex = 8;
            labelAcount.Text = "Нет аккаунта";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Green;
            label1.Font = new Font("Comic Sans MS", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.LawnGreen;
            label1.Image = Properties.Resources._99px_ru_wallpaper_374529_belij_krujevnoj_uzor_v_vide_jagodi_na_zelenom;
            label1.ImageAlign = ContentAlignment.BottomCenter;
            label1.Location = new Point(151, 77);
            label1.Name = "label1";
            label1.Size = new Size(527, 45);
            label1.TabIndex = 9;
            label1.Text = "Подготовка к ЕГЭ по биологии";
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 255, 128);
            BackgroundImage = Properties.Resources._99px_ru_wallpaper_374529_belij_krujevnoj_uzor_v_vide_jagodi_na_zelenom;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(910, 526);
            Controls.Add(label1);
            Controls.Add(labelAcount);
            Controls.Add(buttonRegistration);
            Controls.Add(buttonAboutUs);
            Controls.Add(buttonExit);
            Controls.Add(buttonCreateTests);
            Controls.Add(buttonLogin);
            Controls.Add(buttonSolve);
            Controls.Add(buttonReadLections);
            Name = "MainMenuForm";
            Text = "MainMenu";
            Load += MainMenuForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonReadLections;
        private Button buttonSolve;
        private Button buttonLogin;
        private Button buttonCreateTests;
        private Button buttonExit;
        private Button buttonAboutUs;
        private Button buttonRegistration;
        private Label labelAcount;
        private Label label1;
    }
}
