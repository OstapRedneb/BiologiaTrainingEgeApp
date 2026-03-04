using BiologiaTrainingEgeApp.Classes;
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
        public CreateTaskForm()
        {
            InitializeComponent();
        }

        private void buttonAddText_Click(object sender, EventArgs e)
        {
            //панель-обертка для блока
            Panel panel = new Panel
            {
                Height = 100,
                Width = flowLayoutPanel1.ClientSize.Width - 20, // с учетом скролла
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            // Текстовое поле
            TextBox textBox = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Location = new Point(5, 5),
                Width = panel.Width - 60,
                Height = panel.Height - 10,
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom
            };

            // Кнопка удаления блока
            Button btnDelete = new Button
            {
                Text = "X",
                Location = new Point(panel.Width - 50, 5),
                Size = new Size(45, 25),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Tag = panel // чтобы знать, какую панель удалять
            };
            btnDelete.Click += (s, args) => flowLayoutPanel1.Controls.Remove(panel);

            panel.Controls.Add(textBox);
            panel.Controls.Add(btnDelete);
            flowLayoutPanel1.Controls.Add(panel);
        }

        private void buttonAddImage_Click(object sender, EventArgs e)
        {
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
                        pictureBox.ImageLocation = ofd.FileName; // загружаем из файла
                                                                 // Можно также загрузить изображение в PictureBox.Image для хранения в памяти
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

        private void buttonAddTable_Click(object sender, EventArgs e)
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

        private void buttonSaveTask_Click(object sender, EventArgs e)
        {
            try
            {
                // Собираем данные
                TaskData taskData = CollectTaskData();

                // Проверяем, что задание не пустое
                if (string.IsNullOrWhiteSpace(taskData.TaskTitle) &&
                    string.IsNullOrWhiteSpace(taskData.QuestionText) &&
                    taskData.Blocks.Count == 0)
                {
                    DialogResult result = MessageBox.Show(
                        "Задание пустое. Всё равно сохранить?",
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
        private TaskData currentTask;

        public TaskCreationForm()
        {
            InitializeComponent();
            currentTask = new TaskData();
        }

        // Метод для сбора данных с формы
        private TaskData CollectTaskData()
        {
            TaskData taskData = new TaskData();

            // Собираем основную информацию
            taskData.TaskTitle = textBoxTitle.Text; // предположим, у вас есть TextBox для названия
            taskData.QuestionText = textBoxQuestion.Text; // TextBox для вопроса
            taskData.ModifiedDate = DateTime.Now;

            int orderIndex = 0;

            // Проходим по всем панелям в FlowLayoutPanel
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Panel blockPanel)
                {
                    // Определяем тип блока и создаем соответствующий объект
                    TaskBlock block = CreateBlockFromPanel(blockPanel, orderIndex++);
                    if (block != null)
                    {
                        taskData.Blocks.Add(block);
                    }
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

            // Ищем TextBox в панели
            TextBox textBox = panel.Controls.OfType<TextBox>().FirstOrDefault();
            if (textBox != null)
            {
                textBlock.Content = textBox.Text;
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
    }
}
