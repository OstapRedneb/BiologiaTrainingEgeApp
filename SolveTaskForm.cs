using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BiologiaTrainingEgeApp.Classes;
using BiologiaTrainingEgeApp.Enums;
using BiologiaTrainingEgeApp.Storages;

namespace BiologiaTrainingEgeApp
{
    public partial class SolveTaskForm : Form
    {
        private List<TaskData>? _selectedTasks;
        private List<TextBox> _answerTextBoxes; // для сбора ответов пользователя

        public SolveTaskForm()
        {
            InitializeComponent();
            _answerTextBoxes = new List<TextBox>();
            LoadTasks();
        }

        /// <summary>
        /// Загружает задания на основе выбранного количества из SolveInfoForm.TasksQuantity
        /// </summary>
        private void LoadTasks()
        {
            int[] quantities = SolveInfoForm.TasksQuantity;
            if (quantities == null || quantities.Length != 28)
            {
                MessageBox.Show("Ошибка: не задано количество заданий.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            List<TaskData>? allTasks = TaskStorage.GetAll();

            // Группируем по номеру задания
            var tasksByNumber = allTasks.GroupBy(t => t.Number).ToDictionary(g => g.Key, g => g.ToList());

            _selectedTasks = new List<TaskData>();
            Random rnd = new Random();

            for (int number = 1; number <= 28; number++)
            {
                int requiredCount = quantities[number - 1];
                if (requiredCount <= 0) continue;

                if (tasksByNumber.TryGetValue(number, out List<TaskData>? tasksOfNumber))
                {
                    // Перемешиваем и берём нужное количество (если меньше – берём все)
                    List<TaskData>? shuffled = tasksOfNumber.OrderBy(x => rnd.Next()).ToList();
                    List<TaskData>? taken = shuffled.Take(requiredCount).ToList();
                    _selectedTasks.AddRange(taken);
                }
            }

            // Сортируем по номеру задания для порядка на форме
            _selectedTasks = _selectedTasks.OrderBy(t => t.Number).ToList();

            // Очищаем FlowLayoutPanel перед добавлением (на случай повторной загрузки)
            flowLayoutPanelTasks.Controls.Clear();

            // Создаём панели для каждого задания
            foreach (var task in _selectedTasks)
            {
                var panel = CreateTaskPanel(task);
                flowLayoutPanelTasks.Controls.Add(panel);
            }

            // Добавляем кнопку "Завершить работу" в конец
            Button btnFinish = new Button
            {
                Text = "Завершить работу",
                AutoSize = true,
                Margin = new Padding(10)
            };
            btnFinish.Click += BtnFinish_Click;
            flowLayoutPanelTasks.Controls.Add(btnFinish);
        }

        /// <summary>
        /// Создаёт панель для одного задания
        /// </summary>
        private Panel CreateTaskPanel(TaskData task)
        {
            Panel panel = new Panel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10),
                Padding = new Padding(10),
                Width = flowLayoutPanelTasks.ClientSize.Width - 40 // отступы
            };

            int currentY = 10;

            // Заголовок: номер задания и автор
            Label lblHeader = new Label
            {
                Text = $"Задание №{task.Number} (автор: {task.Author})",
                Font = new Font("Arial", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, currentY)
            };
            panel.Controls.Add(lblHeader);
            currentY = lblHeader.Bottom + 10;

            // Текст вопроса
            Label lblQuestion = new Label
            {
                Text = task.QuestionText,
                AutoSize = true,
                MaximumSize = new Size(panel.Width - 40, 0),
                Location = new Point(10, currentY)
            };
            panel.Controls.Add(lblQuestion);
            currentY = lblQuestion.Bottom + 10;

            // Блоки (текст, изображения, таблицы)
            if (task.Blocks != null && task.Blocks.Count > 0)
            {
                // Внутренняя панель для блоков (FlowLayout для вертикального расположения)
                FlowLayoutPanel blocksPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Location = new Point(10, currentY),
                    Width = panel.Width - 40
                };

                foreach (var block in task.Blocks.OrderBy(b => b.OrderIndex))
                {
                    Control blockControl = CreateBlockControl(block, blocksPanel.Width);
                    if (blockControl != null)
                    {
                        blocksPanel.Controls.Add(blockControl);
                    }
                }

                panel.Controls.Add(blocksPanel);
                currentY = blocksPanel.Bottom + 10;
            }

            // Подпись "Ответ:"
            Label lblAnswerPrompt = new Label
            {
                Text = "Ответ:",
                AutoSize = true,
                Location = new Point(10, currentY)
            };
            panel.Controls.Add(lblAnswerPrompt);
            currentY = lblAnswerPrompt.Bottom + 5;

            // Поле для ввода ответа
            TextBox txtAnswer = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Width = panel.Width - 40,
                Height = 80,
                Location = new Point(10, currentY)
            };
            panel.Controls.Add(txtAnswer);
            _answerTextBoxes.Add(txtAnswer); // сохраняем ссылку для сбора ответов

            // Сохраняем задание в теге панели (пригодится при сборе результатов)
            panel.Tag = task;

            return panel;
        }

        /// <summary>
        /// Создаёт элемент управления для отображения блока (текст, картинка, таблица)
        /// </summary>
        private Control CreateBlockControl(TaskBlock block, int containerWidth)
        {
            switch (block.Type)
            {
                case BlockType.Text:
                    var textBlock = block as TextBlock;
                    if (textBlock != null)
                    {
                        Label lbl = new Label
                        {
                            Text = textBlock.Content,
                            AutoSize = true,
                            MaximumSize = new Size(containerWidth - 20, 0)
                        };
                        return lbl;
                    }
                    break;

                case BlockType.Image:
                    var imgBlock = block as ImageBlock;
                    if (imgBlock != null)
                    {
                        PictureBox pb = new PictureBox
                        {
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Width = containerWidth - 20,
                            Height = 200 // фиксированная высота; при необходимости можно подбирать
                        };
                        if (imgBlock.ImageData != null && imgBlock.ImageData.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imgBlock.ImageData))
                            {
                                pb.Image = Image.FromStream(ms);
                            }
                        }
                        else if (!string.IsNullOrEmpty(imgBlock.ImagePath) && File.Exists(imgBlock.ImagePath))
                        {
                            pb.ImageLocation = imgBlock.ImagePath;
                        }
                        return pb;
                    }
                    break;

                case BlockType.Table:
                    var tableBlock = block as TableBlock;
                    if (tableBlock != null && tableBlock.Columns.Count > 0)
                    {
                        DataGridView dgv = new DataGridView
                        {
                            Width = containerWidth - 20,
                            ReadOnly = true,
                            AllowUserToAddRows = false,
                            AllowUserToDeleteRows = false,
                            AllowUserToResizeColumns = false,
                            AllowUserToResizeRows = false,
                            RowHeadersVisible = false,
                            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                        };

                        // Добавляем колонки
                        foreach (var col in tableBlock.Columns)
                        {
                            dgv.Columns.Add(col.DataPropertyName ?? "", col.Name);
                            if (col.Width > 0)
                                dgv.Columns[dgv.Columns.Count - 1].Width = col.Width;
                        }

                        // Добавляем строки
                        foreach (var row in tableBlock.Rows)
                        {
                            if (row.Cells.Count == dgv.Columns.Count)
                            {
                                dgv.Rows.Add(row.Cells.ToArray());
                                if (row.Height > 0)
                                    dgv.Rows[dgv.Rows.Count - 1].Height = row.Height;
                            }
                        }

                        // Вычисляем высоту таблицы, чтобы она не создавала скролл внутри себя
                        int totalHeight = dgv.ColumnHeadersHeight;
                        foreach (DataGridViewRow row in dgv.Rows)
                            totalHeight += row.Height;
                        dgv.Height = totalHeight + 2; // небольшая погрешность

                        return dgv;
                    }
                    break;
            }
            return null;
        }

        /// <summary>
        /// Обработчик кнопки завершения – собирает ответы и передаёт в форму результатов
        /// </summary>
        private void BtnFinish_Click(object sender, EventArgs e)
        {
            // Проверяем, что количество ответов совпадает с количеством заданий
            if (_answerTextBoxes.Count != _selectedTasks.Count)
            {
                MessageBox.Show("Ошибка при сборе ответов. Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Формируем список результатов
            var results = new List<UserAnswerResult>();
            for (int i = 0; i < _selectedTasks.Count; i++)
            {
                var task = _selectedTasks[i];
                var userAnswer = _answerTextBoxes[i].Text;

                // Простейшее сравнение (регистронезависимое)
                bool isCorrect = string.Equals(userAnswer?.Trim(), task.Answer?.Trim(), StringComparison.OrdinalIgnoreCase);

                results.Add(new UserAnswerResult
                {
                    TaskNumber = task.Number,
                    Question = task.QuestionText,
                    CorrectAnswer = task.Answer,
                    UserAnswer = userAnswer,
                    IsCorrect = isCorrect
                });
            }

            // TODO: Здесь открыть новую форму с результатами, передав results
            // Например:
            // ResultForm resultForm = new ResultForm(results);
            // resultForm.ShowDialog();

            // Закрыть текущую форму (по желанию)
            // this.Close();
        }

        // Обработчик изменения размера формы – обновляем ширину панелей заданий
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            foreach (Control control in flowLayoutPanelTasks.Controls)
            {
                if (control is Panel taskPanel)
                {
                    taskPanel.Width = flowLayoutPanelTasks.ClientSize.Width - 40;
                }
            }
        }
    }
}
