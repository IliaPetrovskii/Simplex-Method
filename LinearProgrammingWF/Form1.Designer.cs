using System.Drawing;

namespace LinearProgrammingWF
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        public override System.Drawing.Size MinimumSize { get; set; } = new Size(990, 490);

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SimplexMatrix = new System.Windows.Forms.DataGridView();
            this.F = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.b = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlusNumberOfVariablesButton = new System.Windows.Forms.Button();
            this.NumberOfVariablesTextBox = new System.Windows.Forms.TextBox();
            this.MinusNumberOfVariablesButton = new System.Windows.Forms.Button();
            this.NumberOfVariablesLable = new System.Windows.Forms.Label();
            this.PlusNumberOfBoundedButton = new System.Windows.Forms.Button();
            this.MinusNumberOfBoundedButton = new System.Windows.Forms.Button();
            this.NumberOfBoundedTextBox = new System.Windows.Forms.TextBox();
            this.NumberOfBoundedLabel = new System.Windows.Forms.Label();
            this.SolveButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.MinMaxComboBox = new System.Windows.Forms.ComboBox();
            this.MinMaxLabel = new System.Windows.Forms.Label();
            this.SolveChooseLabel = new System.Windows.Forms.Label();
            this.FractionTypeLabel = new System.Windows.Forms.Label();
            this.MethodChooseComboBox = new System.Windows.Forms.ComboBox();
            this.FractionTypeComboBox = new System.Windows.Forms.ComboBox();
            this.NextButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.MyMenu = new System.Windows.Forms.MenuStrip();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Author = new System.Windows.Forms.Label();
            this.AnswerTextBox = new System.Windows.Forms.TextBox();
            this.StepTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SimplexMatrix)).BeginInit();
            this.MyMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // SimplexMatrix
            // 
            this.SimplexMatrix.AllowUserToAddRows = false;
            this.SimplexMatrix.AllowUserToDeleteRows = false;
            this.SimplexMatrix.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SimplexMatrix.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.SimplexMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SimplexMatrix.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.SimplexMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SimplexMatrix.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.F,
            this.x1,
            this.x2,
            this.x3,
            this.b});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SimplexMatrix.DefaultCellStyle = dataGridViewCellStyle3;
            this.SimplexMatrix.Location = new System.Drawing.Point(361, 75);
            this.SimplexMatrix.Margin = new System.Windows.Forms.Padding(2);
            this.SimplexMatrix.MultiSelect = false;
            this.SimplexMatrix.Name = "SimplexMatrix";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SimplexMatrix.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.SimplexMatrix.RowHeadersVisible = false;
            this.SimplexMatrix.RowHeadersWidth = 51;
            this.SimplexMatrix.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.SimplexMatrix.Size = new System.Drawing.Size(514, 375);
            this.SimplexMatrix.TabIndex = 0;
            this.SimplexMatrix.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SimplexMatrix_CellContentClick);
            this.SimplexMatrix.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.SimplexMatrix_CellValueChanged);
            // 
            // F
            // 
            this.F.FillWeight = 20F;
            this.F.HeaderText = "";
            this.F.Name = "F";
            this.F.ReadOnly = true;
            this.F.Width = 25;
            // 
            // x1
            // 
            this.x1.HeaderText = "x1";
            this.x1.Name = "x1";
            this.x1.Width = 35;
            // 
            // x2
            // 
            this.x2.HeaderText = "x2";
            this.x2.Name = "x2";
            this.x2.Width = 35;
            // 
            // x3
            // 
            this.x3.HeaderText = "x3";
            this.x3.Name = "x3";
            this.x3.Width = 35;
            // 
            // b
            // 
            this.b.HeaderText = "b";
            this.b.Name = "b";
            this.b.Width = 35;
            // 
            // PlusNumberOfVariablesButton
            // 
            this.PlusNumberOfVariablesButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.PlusNumberOfVariablesButton.Location = new System.Drawing.Point(263, 232);
            this.PlusNumberOfVariablesButton.Margin = new System.Windows.Forms.Padding(2);
            this.PlusNumberOfVariablesButton.Name = "PlusNumberOfVariablesButton";
            this.PlusNumberOfVariablesButton.Size = new System.Drawing.Size(35, 28);
            this.PlusNumberOfVariablesButton.TabIndex = 2;
            this.PlusNumberOfVariablesButton.Text = "+";
            this.PlusNumberOfVariablesButton.UseVisualStyleBackColor = true;
            this.PlusNumberOfVariablesButton.Click += new System.EventHandler(this.PlusNumberOfVariablesButton_Click);
            // 
            // NumberOfVariablesTextBox
            // 
            this.NumberOfVariablesTextBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.NumberOfVariablesTextBox.Location = new System.Drawing.Point(193, 231);
            this.NumberOfVariablesTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.NumberOfVariablesTextBox.Name = "NumberOfVariablesTextBox";
            this.NumberOfVariablesTextBox.Size = new System.Drawing.Size(66, 29);
            this.NumberOfVariablesTextBox.TabIndex = 3;
            this.NumberOfVariablesTextBox.Text = "3";
            this.NumberOfVariablesTextBox.TextChanged += new System.EventHandler(this.NumberOfVariablesTextBox_TextChanged);
            // 
            // MinusNumberOfVariablesButton
            // 
            this.MinusNumberOfVariablesButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.MinusNumberOfVariablesButton.Location = new System.Drawing.Point(302, 232);
            this.MinusNumberOfVariablesButton.Margin = new System.Windows.Forms.Padding(2);
            this.MinusNumberOfVariablesButton.Name = "MinusNumberOfVariablesButton";
            this.MinusNumberOfVariablesButton.Size = new System.Drawing.Size(35, 29);
            this.MinusNumberOfVariablesButton.TabIndex = 2;
            this.MinusNumberOfVariablesButton.Text = "-";
            this.MinusNumberOfVariablesButton.UseVisualStyleBackColor = true;
            this.MinusNumberOfVariablesButton.Click += new System.EventHandler(this.MinusNumberOfVariablesButton_Click);
            // 
            // NumberOfVariablesLable
            // 
            this.NumberOfVariablesLable.AutoSize = true;
            this.NumberOfVariablesLable.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.NumberOfVariablesLable.Location = new System.Drawing.Point(11, 232);
            this.NumberOfVariablesLable.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NumberOfVariablesLable.Name = "NumberOfVariablesLable";
            this.NumberOfVariablesLable.Size = new System.Drawing.Size(147, 21);
            this.NumberOfVariablesLable.TabIndex = 4;
            this.NumberOfVariablesLable.Text = "Число переменных";
            // 
            // PlusNumberOfBoundedButton
            // 
            this.PlusNumberOfBoundedButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.PlusNumberOfBoundedButton.Location = new System.Drawing.Point(263, 268);
            this.PlusNumberOfBoundedButton.Margin = new System.Windows.Forms.Padding(2);
            this.PlusNumberOfBoundedButton.Name = "PlusNumberOfBoundedButton";
            this.PlusNumberOfBoundedButton.Size = new System.Drawing.Size(35, 26);
            this.PlusNumberOfBoundedButton.TabIndex = 2;
            this.PlusNumberOfBoundedButton.Text = "+";
            this.PlusNumberOfBoundedButton.UseVisualStyleBackColor = true;
            this.PlusNumberOfBoundedButton.Click += new System.EventHandler(this.PlusNumberOfBoundedButton_Click);
            // 
            // MinusNumberOfBoundedButton
            // 
            this.MinusNumberOfBoundedButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.MinusNumberOfBoundedButton.Location = new System.Drawing.Point(302, 269);
            this.MinusNumberOfBoundedButton.Margin = new System.Windows.Forms.Padding(2);
            this.MinusNumberOfBoundedButton.Name = "MinusNumberOfBoundedButton";
            this.MinusNumberOfBoundedButton.Size = new System.Drawing.Size(35, 26);
            this.MinusNumberOfBoundedButton.TabIndex = 2;
            this.MinusNumberOfBoundedButton.Text = "-";
            this.MinusNumberOfBoundedButton.UseVisualStyleBackColor = true;
            this.MinusNumberOfBoundedButton.Click += new System.EventHandler(this.MinusNumberOfBoundedButton_Click);
            // 
            // NumberOfBoundedTextBox
            // 
            this.NumberOfBoundedTextBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.NumberOfBoundedTextBox.Location = new System.Drawing.Point(193, 266);
            this.NumberOfBoundedTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.NumberOfBoundedTextBox.Name = "NumberOfBoundedTextBox";
            this.NumberOfBoundedTextBox.Size = new System.Drawing.Size(66, 29);
            this.NumberOfBoundedTextBox.TabIndex = 3;
            this.NumberOfBoundedTextBox.Text = "3";
            this.NumberOfBoundedTextBox.TextChanged += new System.EventHandler(this.NumberOfBoundedTextBox_TextChanged);
            // 
            // NumberOfBoundedLabel
            // 
            this.NumberOfBoundedLabel.AutoSize = true;
            this.NumberOfBoundedLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.NumberOfBoundedLabel.Location = new System.Drawing.Point(11, 269);
            this.NumberOfBoundedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NumberOfBoundedLabel.Name = "NumberOfBoundedLabel";
            this.NumberOfBoundedLabel.Size = new System.Drawing.Size(152, 21);
            this.NumberOfBoundedLabel.TabIndex = 4;
            this.NumberOfBoundedLabel.Text = "Число ограничений";
            // 
            // SolveButton
            // 
            this.SolveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SolveButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SolveButton.Location = new System.Drawing.Point(762, 30);
            this.SolveButton.Margin = new System.Windows.Forms.Padding(2);
            this.SolveButton.Name = "SolveButton";
            this.SolveButton.Size = new System.Drawing.Size(96, 41);
            this.SolveButton.TabIndex = 6;
            this.SolveButton.Text = "Решить";
            this.SolveButton.UseVisualStyleBackColor = true;
            this.SolveButton.Click += new System.EventHandler(this.SolveButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ResetButton.Font = new System.Drawing.Font("Segoe UI", 13.25F);
            this.ResetButton.Location = new System.Drawing.Point(375, 31);
            this.ResetButton.Margin = new System.Windows.Forms.Padding(2);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(96, 41);
            this.ResetButton.TabIndex = 7;
            this.ResetButton.Text = "Очистить";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // MinMaxComboBox
            // 
            this.MinMaxComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MinMaxComboBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.MinMaxComboBox.FormattingEnabled = true;
            this.MinMaxComboBox.Items.AddRange(new object[] {
            "Минимум",
            "Максимум"});
            this.MinMaxComboBox.Location = new System.Drawing.Point(143, 107);
            this.MinMaxComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.MinMaxComboBox.Name = "MinMaxComboBox";
            this.MinMaxComboBox.Size = new System.Drawing.Size(194, 29);
            this.MinMaxComboBox.TabIndex = 9;
            // 
            // MinMaxLabel
            // 
            this.MinMaxLabel.AutoSize = true;
            this.MinMaxLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.MinMaxLabel.Location = new System.Drawing.Point(11, 107);
            this.MinMaxLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MinMaxLabel.Name = "MinMaxLabel";
            this.MinMaxLabel.Size = new System.Drawing.Size(82, 21);
            this.MinMaxLabel.TabIndex = 10;
            this.MinMaxLabel.Text = "Задача на";
            // 
            // SolveChooseLabel
            // 
            this.SolveChooseLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SolveChooseLabel.AutoSize = true;
            this.SolveChooseLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.SolveChooseLabel.Location = new System.Drawing.Point(11, 42);
            this.SolveChooseLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SolveChooseLabel.Name = "SolveChooseLabel";
            this.SolveChooseLabel.Size = new System.Drawing.Size(128, 21);
            this.SolveChooseLabel.TabIndex = 11;
            this.SolveChooseLabel.Text = "Метод решения:";
            // 
            // FractionTypeLabel
            // 
            this.FractionTypeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FractionTypeLabel.AutoSize = true;
            this.FractionTypeLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.FractionTypeLabel.Location = new System.Drawing.Point(13, 174);
            this.FractionTypeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FractionTypeLabel.Name = "FractionTypeLabel";
            this.FractionTypeLabel.Size = new System.Drawing.Size(97, 21);
            this.FractionTypeLabel.TabIndex = 11;
            this.FractionTypeLabel.Text = "Вид дробей:";
            // 
            // MethodChooseComboBox
            // 
            this.MethodChooseComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MethodChooseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MethodChooseComboBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.MethodChooseComboBox.FormattingEnabled = true;
            this.MethodChooseComboBox.Items.AddRange(new object[] {
            "Симплекс",
            "Искуственный базис"});
            this.MethodChooseComboBox.Location = new System.Drawing.Point(143, 42);
            this.MethodChooseComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.MethodChooseComboBox.Name = "MethodChooseComboBox";
            this.MethodChooseComboBox.Size = new System.Drawing.Size(194, 29);
            this.MethodChooseComboBox.TabIndex = 12;
            // 
            // FractionTypeComboBox
            // 
            this.FractionTypeComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FractionTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FractionTypeComboBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.FractionTypeComboBox.FormattingEnabled = true;
            this.FractionTypeComboBox.Items.AddRange(new object[] {
            "Обыкновенные",
            "Десятичные"});
            this.FractionTypeComboBox.Location = new System.Drawing.Point(144, 174);
            this.FractionTypeComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.FractionTypeComboBox.Name = "FractionTypeComboBox";
            this.FractionTypeComboBox.Size = new System.Drawing.Size(193, 29);
            this.FractionTypeComboBox.TabIndex = 13;
            // 
            // NextButton
            // 
            this.NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NextButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.NextButton.Location = new System.Drawing.Point(638, 40);
            this.NextButton.Margin = new System.Windows.Forms.Padding(2);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(95, 25);
            this.NextButton.TabIndex = 6;
            this.NextButton.Text = "Шаг вперед";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PreviousButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.PreviousButton.Location = new System.Drawing.Point(508, 40);
            this.PreviousButton.Margin = new System.Windows.Forms.Padding(2);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(95, 25);
            this.PreviousButton.TabIndex = 7;
            this.PreviousButton.Text = "Шаг назад";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // MyMenu
            // 
            this.MyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveToolStripMenuItem,
            this.LoadToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.MyMenu.Location = new System.Drawing.Point(0, 0);
            this.MyMenu.Name = "MyMenu";
            this.MyMenu.Size = new System.Drawing.Size(884, 24);
            this.MyMenu.TabIndex = 14;
            this.MyMenu.Text = "menuStrip1";
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.SaveToolStripMenuItem.Text = "Сохранить в файл";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // LoadToolStripMenuItem
            // 
            this.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem";
            this.LoadToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.LoadToolStripMenuItem.Text = "Загрузить из файла";
            this.LoadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.HelpToolStripMenuItem.Text = "Справка";
            this.HelpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // Author
            // 
            this.Author.AutoSize = true;
            this.Author.Location = new System.Drawing.Point(50, 437);
            this.Author.Name = "Author";
            this.Author.Size = new System.Drawing.Size(248, 13);
            this.Author.TabIndex = 15;
            this.Author.Text = "Выполнил: Петровский Илья Андреевич ИВТ31";
            // 
            // AnswerTextBox
            // 
            this.AnswerTextBox.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.AnswerTextBox.Location = new System.Drawing.Point(17, 383);
            this.AnswerTextBox.Name = "AnswerTextBox";
            this.AnswerTextBox.ReadOnly = true;
            this.AnswerTextBox.Size = new System.Drawing.Size(320, 32);
            this.AnswerTextBox.TabIndex = 16;
            // 
            // StepTextBox
            // 
            this.StepTextBox.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.StepTextBox.Location = new System.Drawing.Point(53, 322);
            this.StepTextBox.Name = "StepTextBox";
            this.StepTextBox.ReadOnly = true;
            this.StepTextBox.Size = new System.Drawing.Size(245, 39);
            this.StepTextBox.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.StepTextBox);
            this.Controls.Add(this.AnswerTextBox);
            this.Controls.Add(this.Author);
            this.Controls.Add(this.FractionTypeComboBox);
            this.Controls.Add(this.MethodChooseComboBox);
            this.Controls.Add(this.MinMaxLabel);
            this.Controls.Add(this.FractionTypeLabel);
            this.Controls.Add(this.SolveChooseLabel);
            this.Controls.Add(this.MinMaxComboBox);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.SolveButton);
            this.Controls.Add(this.NumberOfBoundedLabel);
            this.Controls.Add(this.NumberOfBoundedTextBox);
            this.Controls.Add(this.NumberOfVariablesLable);
            this.Controls.Add(this.MinusNumberOfBoundedButton);
            this.Controls.Add(this.NumberOfVariablesTextBox);
            this.Controls.Add(this.PlusNumberOfBoundedButton);
            this.Controls.Add(this.MinusNumberOfVariablesButton);
            this.Controls.Add(this.PlusNumberOfVariablesButton);
            this.Controls.Add(this.SimplexMatrix);
            this.Controls.Add(this.MyMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MyMenu;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "LP";
            ((System.ComponentModel.ISupportInitialize)(this.SimplexMatrix)).EndInit();
            this.MyMenu.ResumeLayout(false);
            this.MyMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView SimplexMatrix;
        private System.Windows.Forms.Button PlusNumberOfVariablesButton;
        private System.Windows.Forms.TextBox NumberOfVariablesTextBox;
        private System.Windows.Forms.Button MinusNumberOfVariablesButton;
        private System.Windows.Forms.Label NumberOfVariablesLable;
        private System.Windows.Forms.Button PlusNumberOfBoundedButton;
        private System.Windows.Forms.Button MinusNumberOfBoundedButton;
        private System.Windows.Forms.TextBox NumberOfBoundedTextBox;
        private System.Windows.Forms.Label NumberOfBoundedLabel;
        private System.Windows.Forms.Button SolveButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.ComboBox MinMaxComboBox;
        private System.Windows.Forms.Label MinMaxLabel;
        private System.Windows.Forms.Label SolveChooseLabel;
        private System.Windows.Forms.Label FractionTypeLabel;
        private System.Windows.Forms.ComboBox MethodChooseComboBox;
        private System.Windows.Forms.ComboBox FractionTypeComboBox;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.MenuStrip MyMenu;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.Label Author;
        private System.Windows.Forms.TextBox AnswerTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn F;
        private System.Windows.Forms.DataGridViewTextBoxColumn x1;
        private System.Windows.Forms.DataGridViewTextBoxColumn x2;
        private System.Windows.Forms.DataGridViewTextBoxColumn x3;
        private System.Windows.Forms.DataGridViewTextBoxColumn b;
        private System.Windows.Forms.TextBox StepTextBox;
    }
}

