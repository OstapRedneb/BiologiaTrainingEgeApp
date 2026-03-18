namespace BiologiaTrainingEgeApp
{
    partial class CreateTaskForm
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            buttonSaveTask = new Button();
            buttonAddTable = new Button();
            buttonAddImage = new Button();
            buttonAddText = new Button();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(800, 450);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.WrapContents = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.RosyBrown;
            panel1.Controls.Add(buttonSaveTask);
            panel1.Controls.Add(buttonAddTable);
            panel1.Controls.Add(buttonAddImage);
            panel1.Controls.Add(buttonAddText);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(797, 39);
            panel1.TabIndex = 4;
            // 
            // buttonSaveTask
            // 
            buttonSaveTask.BackColor = Color.Red;
            buttonSaveTask.Font = new Font("Comic Sans MS", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            buttonSaveTask.ForeColor = SystemColors.AppWorkspace;
            buttonSaveTask.Location = new Point(616, 3);
            buttonSaveTask.Name = "buttonSaveTask";
            buttonSaveTask.Size = new Size(178, 33);
            buttonSaveTask.TabIndex = 3;
            buttonSaveTask.Text = "Сохранить задание";
            buttonSaveTask.UseVisualStyleBackColor = false;
            buttonSaveTask.Click += buttonSaveTask_Click;
            // 
            // buttonAddTable
            // 
            buttonAddTable.BackColor = Color.Chocolate;
            buttonAddTable.Font = new Font("Comic Sans MS", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            buttonAddTable.Location = new Point(334, 3);
            buttonAddTable.Name = "buttonAddTable";
            buttonAddTable.Size = new Size(166, 33);
            buttonAddTable.TabIndex = 2;
            buttonAddTable.Text = "Добавить таблицу";
            buttonAddTable.UseVisualStyleBackColor = false;
            buttonAddTable.Click += buttonAddTable_Click;
            // 
            // buttonAddImage
            // 
            buttonAddImage.BackColor = Color.Aquamarine;
            buttonAddImage.Font = new Font("Comic Sans MS", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            buttonAddImage.Location = new Point(162, 3);
            buttonAddImage.Name = "buttonAddImage";
            buttonAddImage.Size = new Size(166, 33);
            buttonAddImage.TabIndex = 1;
            buttonAddImage.Text = "Добавить картинку";
            buttonAddImage.UseVisualStyleBackColor = false;
            buttonAddImage.Click += buttonAddImage_Click;
            // 
            // buttonAddText
            // 
            buttonAddText.BackColor = Color.YellowGreen;
            buttonAddText.Font = new Font("Comic Sans MS", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            buttonAddText.Location = new Point(3, 3);
            buttonAddText.Name = "buttonAddText";
            buttonAddText.Size = new Size(153, 33);
            buttonAddText.TabIndex = 0;
            buttonAddText.Text = "Добавить текст";
            buttonAddText.UseVisualStyleBackColor = false;
            buttonAddText.Click += buttonAddText_Click;
            // 
            // CreateTaskForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flowLayoutPanel1);
            Name = "CreateTaskForm";
            Text = "CreateTaskForm";
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private Button buttonSaveTask;
        private Button buttonAddTable;
        private Button buttonAddImage;
        private Button buttonAddText;
    }
}