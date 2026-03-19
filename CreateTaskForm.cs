using BiologiaTrainingEgeApp.Classes;
using BiologiaTrainingEgeApp.MainUserInfo;
using BiologiaTrainingEgeApp.Storages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiologiaTrainingEgeApp
{
    public partial class CreateTaskForm : Form
    {
        private TaskData currentTask;

        public CreateTaskForm()
        {
            InitializeComponent();
            currentTask = new TaskData();
        }

        private void buttonAddText_Click(object sender, EventArgs e)
        {
            // Панель-обертка для блока (увеличим высоту до 130, чтобы поместились элементы)
            Panel panel = new Panel
            {
                Height = 130,
                Width = flowLayoutPanel1.ClientSize.Width - 20,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            // Верхняя панель для CheckBox и кнопки удаления
            Panel topPanel = new Panel
            {
                Height = 30,
                Width = panel.Width - 10,
                Location = new Point(5, 5),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            // Флажок "Сделать вопросом"
            CheckBox chkIsQuestion = new CheckBox
            {
                Text = "Сделать вопросом",
                Location = new Point(0, 5),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            // Кнопка удаления блока
            Button btnDelete = new Button
            {
                Text = "X",
                Location = new Point(topPanel.Width - 50, 0),
                Size = new Size(45, 25),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Tag = panel
            };
            btnDelete.Click += (s, args) => flowLayoutPanel1.Controls.Remove(panel);

            topPanel.Controls.Add(chkIsQuestion);
            topPanel.Controls.Add(btnDelete);

            // Текстовое поле (располагается ниже topPanel)
            TextBox textBox = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Location = new Point(5, 40),
                Width = panel.Width - 10,
                Height = panel.Height - 50,
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom
            };

            panel.Controls.Add(topPanel);
            panel.Controls.Add(textBox);
            flowLayoutPanel1.Controls.Add(panel);
        }

        public void buttonAddImage_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.OfType<PictureBox>().Count() > 1)
            {
                MessageBox.Show("В тексте уже есть изображение.\nВы должны уалть уже имеющуюся панель с изображением для добавления нового.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Panel panel = new Panel
            {
                Height = 200,
                Width = flowLayoutPanel1.ClientSize.Width - 20,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            // Кнопка выбора изображения
            Button btnSelectImage = new Button
            {
                Text = "Выбрать изображение...",
                Location = new Point(5, 5),
                Size = new Size(150, 30)
            };

            PictureBox pictureBox = new PictureBox
            {
                Location = new Point(5, 40),
                SizeMode = PictureBoxSizeMode.Zoom,
                Width = panel.Width - 60,
                Height = panel.Height - 50,
                BorderStyle = BorderStyle.FixedSingle,
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom
            };

            btnSelectImage.Click += (s, args) =>
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // Загружаем изображение через FileStream, чтобы не блокировать файл
                            using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                            {
                                pictureBox.Image = Image.FromStream(fs);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            };

            // Кнопка удаления
            Button btnDelete = new Button
            {
                Text = "X",
                Location = new Point(panel.Width - 50, 5),
                Size = new Size(45, 25),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Tag = panel
            };
            btnDelete.Click += (s, args) => flowLayoutPanel1.Controls.Remove(panel);

            panel.Controls.Add(btnSelectImage);
            panel.Controls.Add(pictureBox);
            panel.Controls.Add(btnDelete);
            flowLayoutPanel1.Controls.Add(panel);
        }

        public void buttonAddTable_Click(object sender, EventArgs e)
        {
            Panel panel = new Panel
            {
                Height = 350,
                Width = flowLayoutPanel1.ClientSize.Width - 20,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            // Создаем DataGridView
            DataGridView dgv = new DataGridView
            {
                Location = new Point(5, 40),
                Width = panel.Width - 10,
                Height = panel.Height - 70,
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom,
                AllowUserToAddRows = true,
                AllowUserToDeleteRows = true,
                AllowUserToResizeColumns = true,
                AllowUserToResizeRows = true,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
            };

            // Добавляем начальные столбцы (обязательно!)
            dgv.Columns.Add("Column1", "Столбец 1");
            dgv.Columns.Add("Column2", "Столбец 2");

            // Добавляем начальные строки
            dgv.Rows.Add("", "");
            dgv.Rows.Add("", "");

            // Панель с кнопками управления
            Panel toolPanel = new Panel
            {
                Location = new Point(5, 5),
                Height = 30,
                Width = panel.Width - 60,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            // Кнопка добавления строки
            Button btnAddRow = new Button
            {
                Text = "+ Строка",
                Location = new Point(0, 0),
                Size = new Size(80, 25)
            };
            btnAddRow.Click += (s, args) =>
            {
                try
                {
                    // Проверяем, есть ли столбцы
                    if (dgv.Columns.Count == 0)
                    {
                        MessageBox.Show("Сначала добавьте хотя бы один столбец!",
                            "Невозможно добавить строку",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    // Создаем массив пустых значений для новой строки
                    object[] emptyRow = new object[dgv.Columns.Count];
                    for (int i = 0; i < emptyRow.Length; i++)
                    {
                        emptyRow[i] = "";
                    }

                    dgv.Rows.Add(emptyRow);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении строки: {ex.Message}",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            };

            // Кнопка удаления последней строки
            Button btnRemoveRow = new Button
            {
                Text = "- Строка",
                Location = new Point(85, 0),
                Size = new Size(80, 25)
            };
            btnRemoveRow.Click += (s, args) =>
            {
                try
                {
                    if (dgv.Rows.Count > 0)
                    {
                        int lastRowIndex = dgv.Rows.Count - 1;

                        if (!dgv.Rows[lastRowIndex].IsNewRow)
                        {
                            dgv.Rows.RemoveAt(lastRowIndex);
                        }
                        else if (dgv.Rows.Count > 1)
                        {
                            dgv.Rows.RemoveAt(lastRowIndex - 1);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении строки: {ex.Message}",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            };

            // Кнопка добавления столбца
            Button btnAddColumn = new Button
            {
                Text = "+ Столбец",
                Location = new Point(170, 0),
                Size = new Size(80, 25)
            };
            btnAddColumn.Click += (s, args) =>
            {
                try
                {
                    int newColumnIndex = dgv.Columns.Count;
                    string columnName = $"Столбец {newColumnIndex + 1}";
                    dgv.Columns.Add($"Column{newColumnIndex + 1}", columnName);

                    // Заполняем новые ячейки в существующих строках
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            row.Cells[newColumnIndex].Value = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении столбца: {ex.Message}",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            };

            // Кнопка удаления последнего столбца
            Button btnRemoveColumn = new Button
            {
                Text = "- Столбец",
                Location = new Point(255, 0),
                Size = new Size(80, 25)
            };
            btnRemoveColumn.Click += (s, args) =>
            {
                try
                {
                    if (dgv.Columns.Count > 0)
                    {
                        dgv.Columns.RemoveAt(dgv.Columns.Count - 1);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении столбца: {ex.Message}",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            };

            // Кнопка авторазмера
            Button btnAutoSize = new Button
            {
                Text = "Авторазмер",
                Location = new Point(340, 0),
                Size = new Size(80, 25)
            };
            btnAutoSize.Click += (s, args) =>
            {
                try
                {
                    if (dgv.Columns.Count > 0)
                    {
                        dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                        dgv.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при авторазмере: {ex.Message}",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            };

            toolPanel.Controls.AddRange(new Control[] {
                btnAddRow, btnRemoveRow, btnAddColumn, btnRemoveColumn, btnAutoSize
            });

            // Кнопка удаления блока
            Button btnDelete = new Button
            {
                Text = "X",
                Location = new Point(panel.Width - 50, 5),
                Size = new Size(45, 25),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Tag = panel
            };
            btnDelete.Click += (s, args) => flowLayoutPanel1.Controls.Remove(panel);

            panel.Controls.Add(toolPanel);
            panel.Controls.Add(dgv);
            panel.Controls.Add(btnDelete);
            flowLayoutPanel1.Controls.Add(panel);
        }

        public void buttonSaveTask_Click(object sender, EventArgs e)
        {
            try
            {
                // Собираем данные
                TaskData taskData = CollectTaskData();

                // Проверяем, что задание не пустое и что номер верный
                if (1 <= taskData.Number && taskData.Number <= 28 &&
                    string.IsNullOrWhiteSpace(taskData.QuestionText) &&
                    taskData.Blocks.Count == 0)
                {
                    DialogResult result = MessageBox.Show(
                        "Задание пустое или имеет ошибки в номере задания. Всё равно сохранить?",
                        "Подтверждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                        return;
                }

                TaskStorage.Add(taskData);

                MessageBox.Show(
                    "Задание успешно сохранено!",
                    "Сохранение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                new MainMenuForm().Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка при сохранении: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Метод для сбора данных с формы
        private TaskData CollectTaskData()
        {
            TaskData taskData = new TaskData();

            // Собираем номер и ответ
            taskData.Number = GetCorrectNumer();
            taskData.Answer = GetCorrectAnswer();
            taskData.Author = UserInfo.User?.Login ?? "Аноним";
            taskData.ModifiedDate = DateTime.Now;

            // ---------- Поиск панели с вопросом ----------
            Panel questionPanel = null;
            foreach (Panel panel in flowLayoutPanel1.Controls.OfType<Panel>())
            {
                // Ищем чекбокс рекурсивно по всем вложенным контролам
                if (GetAllControls(panel).OfType<CheckBox>().Any(cb => cb.Checked))
                {
                    questionPanel = panel;
                    break;
                }
            }

            if (questionPanel != null)
            {
                // Текст вопроса находится в TextBox, лежащем непосредственно в панели
                TextBox tb = questionPanel.Controls.OfType<TextBox>().FirstOrDefault();
                taskData.QuestionText = tb?.Text ?? "";
            }
            else
            {
                MessageBox.Show("Вы не указали вопрос\n" +
                    "Подсказка: для этого создайте (или выберите уже существующий текст) и отметьте\n" +
                    "Галочку на пункте \"Сделать вопросом\"", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw new Exception("Не указан вопрос задания");
            }

            // ---------- Сбор остальных блоков (исключая панель вопроса) ----------
            int orderIndex = 0;
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Panel blockPanel)
                {
                    // Пропускаем панель, которая уже использована как вопрос
                    if (GetAllControls(blockPanel).OfType<CheckBox>().Any(cb => cb.Checked))
                        continue;

                    TaskBlock block = CreateBlockFromPanel(blockPanel, orderIndex++);
                    if (block != null)
                        taskData.Blocks.Add(block);
                }
            }

            return taskData;
        }

        // Метод для создания блока из панели
        private TaskBlock CreateBlockFromPanel(Panel panel, int orderIndex)
        {
            // Определяем тип блока по наличию дочерних контролов
            if (HasTextBox(panel))
            {
                return CreateTextBlock(panel, orderIndex);
            }
            else if (HasPictureBox(panel))
            {
                return CreateImageBlock(panel, orderIndex);
            }
            else if (HasDataGridView(panel))
            {
                return CreateTableBlock(panel, orderIndex);
            }

            return null;
        }

        // Проверка наличия TextBox в панели
        private bool HasTextBox(Panel panel)
        {
            return panel.Controls.OfType<TextBox>().Any();
        }

        // Создание текстового блока
        private TextBlock CreateTextBlock(Panel panel, int orderIndex)
        {
            TextBlock textBlock = new TextBlock
            {
                OrderIndex = orderIndex
            };

            TextBox textBox = panel.Controls.OfType<TextBox>().FirstOrDefault();
            if (textBox != null)
            {
                textBlock.Content = textBox.Text;
                // Здесь можно добавить сохранение шрифта, если нужно
            }

            return textBlock;
        }

        // Проверка наличия PictureBox в панели
        private bool HasPictureBox(Panel panel)
        {
            return panel.Controls.OfType<PictureBox>().Any();
        }

        // Создание блока с изображением
        private ImageBlock CreateImageBlock(Panel panel, int orderIndex)
        {
            ImageBlock imageBlock = new ImageBlock
            {
                OrderIndex = orderIndex
            };

            // Ищем PictureBox в панели
            PictureBox pictureBox = panel.Controls.OfType<PictureBox>().FirstOrDefault();
            if (pictureBox != null && pictureBox.Image != null)
            {
                // Конвертируем изображение в массив байтов
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox.Image.Save(ms, pictureBox.Image.RawFormat);
                    imageBlock.ImageData = ms.ToArray();
                }

                imageBlock.ImageSize = pictureBox.Image.Size;
                imageBlock.ImageName = "image_" + DateTime.Now.Ticks.ToString() + ".jpg";
            }
            else if (pictureBox != null && !string.IsNullOrEmpty(pictureBox.ImageLocation))
            {
                // Если изображение загружено из файла по пути
                imageBlock.ImagePath = pictureBox.ImageLocation;
                imageBlock.ImageName = System.IO.Path.GetFileName(pictureBox.ImageLocation);
            }

            return imageBlock;
        }

        // Проверка наличия DataGridView в панели
        private bool HasDataGridView(Panel panel)
        {
            return panel.Controls.OfType<DataGridView>().Any();
        }

        // Создание блока с таблицей
        private TableBlock CreateTableBlock(Panel panel, int orderIndex)
        {
            TableBlock tableBlock = new TableBlock
            {
                OrderIndex = orderIndex
            };

            // Ищем DataGridView в панели
            DataGridView dgv = panel.Controls.OfType<DataGridView>().FirstOrDefault();
            if (dgv != null)
            {
                // Сохраняем колонки
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    tableBlock.Columns.Add(new TableColumn
                    {
                        Name = column.HeaderText,
                        Width = column.Width,
                        DataPropertyName = column.DataPropertyName
                    });
                }

                // Сохраняем строки (кроме новой строки)
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        TableRow tableRow = new TableRow
                        {
                            Height = row.Height,
                            Cells = new List<string>()
                        };

                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            tableRow.Cells.Add(cell.Value?.ToString() ?? "");
                        }

                        tableBlock.Rows.Add(tableRow);
                    }
                }

                tableBlock.RowCount = tableBlock.Rows.Count;
                tableBlock.ColumnCount = tableBlock.Columns.Count;
            }

            return tableBlock;
        }

        private int GetCorrectNumer() 
        {
            while (true)
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Какой это номер задания?", "Номер задания");
                if (int.TryParse(input, out int number) && 1 <= number && number <= 28)
                    return number;
                MessageBox.Show("Некорректный номер задания\nВы должны ввести номер от 1 до 28", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GetCorrectAnswer() 
        {
            while (true)
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Какой ответ на это задание?", "Ответ на задание");

                DialogResult result = MessageBox.Show("Вы уверенны в своём ответе?" +
                    "\n(Если не уверенны и хотите переписать, то нажмите НЕТ)", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes && !string.IsNullOrWhiteSpace(input))
                    return input;
            }
        }
        private IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                yield return control;
                foreach (Control child in GetAllControls(control))
                    yield return child;
            }
        }
    }
}
