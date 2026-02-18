namespace BiologiaTrainingEgeApp
{
    partial class RegistrationForm
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
            buttonBack = new Button();
            buttonCreate = new Button();
            textBoxLogin = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBoxPassword = new TextBox();
            SuspendLayout();
            // 
            // buttonBack
            // 
            buttonBack.BackColor = Color.Red;
            buttonBack.Font = new Font("Comic Sans MS", 12F, FontStyle.Italic, GraphicsUnit.Point, 204);
            buttonBack.ForeColor = SystemColors.ButtonHighlight;
            buttonBack.Location = new Point(12, 12);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(77, 30);
            buttonBack.TabIndex = 0;
            buttonBack.Text = "Назад";
            buttonBack.UseVisualStyleBackColor = false;
            // 
            // buttonCreate
            // 
            buttonCreate.BackColor = Color.FromArgb(255, 128, 255);
            buttonCreate.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 204);
            buttonCreate.ForeColor = Color.Blue;
            buttonCreate.Location = new Point(347, 332);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(122, 44);
            buttonCreate.TabIndex = 1;
            buttonCreate.Text = "Готово";
            buttonCreate.UseVisualStyleBackColor = false;
            // 
            // textBoxLogin
            // 
            textBoxLogin.BackColor = SystemColors.HotTrack;
            textBoxLogin.Font = new Font("Comic Sans MS", 12F, FontStyle.Italic, GraphicsUnit.Point, 204);
            textBoxLogin.ForeColor = Color.FromArgb(255, 128, 0);
            textBoxLogin.Location = new Point(347, 102);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(163, 30);
            textBoxLogin.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Highlight;
            label1.Font = new Font("Comic Sans MS", 12F, FontStyle.Italic, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(271, 105);
            label1.Name = "label1";
            label1.Size = new Size(63, 23);
            label1.TabIndex = 3;
            label1.Text = "Логин:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Highlight;
            label2.Font = new Font("Comic Sans MS", 12F, FontStyle.Italic, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.FromArgb(255, 128, 0);
            label2.Location = new Point(271, 165);
            label2.Name = "label2";
            label2.Size = new Size(74, 23);
            label2.TabIndex = 5;
            label2.Text = "Пароль:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.BackColor = SystemColors.HotTrack;
            textBoxPassword.Font = new Font("Comic Sans MS", 12F, FontStyle.Italic, GraphicsUnit.Point, 204);
            textBoxPassword.ForeColor = Color.FromArgb(255, 128, 0);
            textBoxPassword.Location = new Point(347, 162);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(163, 30);
            textBoxPassword.TabIndex = 4;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._99px_ru_wallpaper_366170_siluet_volka_stojashego_na_holme_na_fone_jarkogo;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(textBoxPassword);
            Controls.Add(label1);
            Controls.Add(textBoxLogin);
            Controls.Add(buttonCreate);
            Controls.Add(buttonBack);
            Name = "RegistrationForm";
            Text = "RegistrationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonBack;
        private Button buttonCreate;
        private TextBox textBoxLogin;
        private Label label1;
        private Label label2;
        private TextBox textBoxPassword;
    }
}