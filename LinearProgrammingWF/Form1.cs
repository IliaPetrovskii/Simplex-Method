using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LinearProgrammingWF
{
    public partial class Form1 : Form
    {
        int numberOfVariable = 3; //Число переменных
        int numberOfBounded = 3; //Число ограничений
        int maxNumberOfVariable = 16; //Макс. число переменных
        int maxNumberOfBounded = 16; //Макс. число ограничений
        int step = -1; //Номер текущего шага решения
        int addCols = 0; //Число дополнительных переменных
        int basisVariables = 0; //Число базисных переменных
        Fraction[] function; //Функция для оптимизации
        List<SimplexMethod> simplexMatrixList = new List<SimplexMethod>(); //Хранимые матрицы
        bool finalStep = false; //Флаг окончания алгоритма
        public Form1()
        {
            InitializeComponent();
            FractionTypeComboBox.SelectedIndex = 0;
            MethodChooseComboBox.SelectedIndex = 0;
            MinMaxComboBox.SelectedIndex = 0;
            StepTextBox.Text = "Шаг - Ввод данных";
            for (int i = 0; i < numberOfBounded + 1; i++)
                SimplexMatrix.Rows.Add();
            SimplexMatrix.Rows[3].Cells[0].Value = "f";
            FillSMatrixZero();
        }
        //Заполнить матрицу нолями
        private void FillSMatrixZero()
        {
            for (int i = 0; i < numberOfBounded + 1; i++)
                for (int j = 1; j < numberOfVariable + 2; j++)
                {
                    SimplexMatrix.Rows[i].Cells[j].Value = "0";
                }
        }
        //Сохранить вводимую матрицу
        private void SaveMatrix()
        {
            Fraction[,] startMatrix = new Fraction[numberOfBounded + 1, numberOfVariable + 1];
            for (int i = 0; i < numberOfBounded + 1; i++)
                for (int j = 1; j < numberOfVariable + 2; j++)
                {
                    String value = SimplexMatrix.Rows[i].Cells[j].Value.ToString();
                    //Если true, то ввод в виде десятичной дроби, иначе - обыкновенной
                    bool useDoubleInput = false;
                    foreach (char letter in value)
                    {
                        if (letter == ',')
                        {
                            useDoubleInput = true;
                        }
                    }
                    if (useDoubleInput)
                    {
                        String text = SimplexMatrix.Rows[i].Cells[j].Value.ToString();
                        NumberFormatInfo formatProvider = new NumberFormatInfo();
                        startMatrix[i, j - 1] = new Fraction(Convert.ToDouble(text, formatProvider));
                    }
                    else
                    {
                        String text = SimplexMatrix.Rows[i].Cells[j].Value.ToString();
                        int numerator = Convert.ToInt32(text.Split('/')[0]);
                        int denominator = 1;
                        if (text.Split('/').Length > 1)
                            denominator = Convert.ToInt32(text.Split('/')[1]);
                        startMatrix[i, j - 1] = new Fraction(numerator, denominator);
                    }
                }
            simplexMatrixList.Add(new SimplexMethod(startMatrix));
            ShowBasis();
        }
        //Вывести на экран базис текущей матрицы
        private void ShowBasis()
        {
            if (step != -1)
                for (int i = 0; i < numberOfBounded + 1; i++)
                    SimplexMatrix.Rows[i].Cells[0].Value = simplexMatrixList[step].ToStringBasis(i);
            else
            {
                for (int i = 0; i < numberOfBounded; i++)
                    SimplexMatrix.Rows[i].Cells[0].Value = " ";
                SimplexMatrix.Rows[SimplexMatrix.Rows.Count - 1].Cells[0].Value = "f";
            }
        }
        //Загрузить матрицу из списка по номеру текущего шага
        private void LoadMatrix()
        {
            bool fractionType;
            if (FractionTypeComboBox.Text == "Обыкновенные")
                fractionType = true;
            else
                fractionType = false;
            NumberOfVariablesTextBox.Text = (numberOfVariable = simplexMatrixList[step].GetNumberOfColumns() - 1).ToString();
            NumberOfBoundedTextBox.Text = (simplexMatrixList[step].GetNumberOfRows() - 1).ToString();
            for (int i = 0; i < numberOfBounded + 1; i++)
                for (int j = 0; j < numberOfVariable + 1; j++)
                {
                    if (fractionType)
                        SimplexMatrix.Rows[i].Cells[j + 1].Value = simplexMatrixList[step].GetValue(i, j).ToString();
                    else
                        SimplexMatrix.Rows[i].Cells[j + 1].Value = simplexMatrixList[step].GetValue(i, j).ToStringDouble();
                }
        }
        //Показать все столбцы
        private void ShowAllCols()
        {
            for (int j = 0; j < numberOfVariable + 2; j++)
                SimplexMatrix.Columns[j].Visible = true;
        }
        //Найти возможные элементы в базис
        private bool FindPossibleElements()
        {
            bool flagVisible = true;
            bool flagNoBasis = true;
            for (int j = 0; j < numberOfVariable + 1; j++)
            {
                for (int i = 0; i < numberOfBounded + 1; i++)
                {
                    bool isPossibleElement;
                    if ((MethodChooseComboBox.Text == "Искуственный базис") && (step <= addCols))
                        isPossibleElement = simplexMatrixList[step].IsPossibleElementArtificial(i, j, addCols);
                    else
                        isPossibleElement = simplexMatrixList[step].IsPossibleElement(i, j);
                    if ((i == numberOfBounded) || (j == numberOfVariable))
                        isPossibleElement = false;
                    if (isPossibleElement)
                    {
                        SimplexMatrix.Rows[i].Cells[j + 1].Style.BackColor = Color.GreenYellow;
                        SimplexMatrix.Rows[i].Cells[j + 1].Style.ForeColor = Color.Goldenrod;
                        SimplexMatrix.Rows[i].Cells[j + 1].Style.SelectionBackColor = Color.Maroon;
                        SimplexMatrix.Rows[i].Cells[j + 1].Style.SelectionForeColor = Color.Silver;
                        if (flagVisible)
                        {
                            if (SimplexMatrix.Rows[i].Cells[j + 1].Visible)
                            {
                                flagVisible = false;
                            }
                        }
                        flagNoBasis = false;
                    }
                    else
                    {
                        SimplexMatrix.Rows[i].Cells[j + 1].Style.SelectionBackColor = Color.White;
                        SimplexMatrix.Rows[i].Cells[j + 1].Style.SelectionForeColor = Color.Black;
                    }
                }

            }
            bool select = true;
            for (int i = 0; i < SimplexMatrix.Rows.Count; i++)
                for (int j = 1; j < SimplexMatrix.Columns.Count - 1; j++)
                    if ((SimplexMatrix.Rows[i].Cells[j].Style.BackColor == Color.GreenYellow) && (select))
                    {
                        SimplexMatrix.Rows[i].Cells[j].Selected = true;
                        select = false;
                    }
            if (flagNoBasis)
                return false;
            else
                return true;
        }
        //Очищает выборку возможных элементов в базис
        private void ClearPossibleElements()
        {
            for (int i = 0; i < numberOfBounded + 1; i++)
                for (int j = 0; j < numberOfVariable + 1; j++)
                {
                    SimplexMatrix.Rows[i].Cells[j + 1].Style.BackColor = Color.White;
                    SimplexMatrix.Rows[i].Cells[j + 1].Style.SelectionForeColor = Color.White;
                    SimplexMatrix.Rows[i].Cells[j + 1].Style.ForeColor = Color.Black;
                    SimplexMatrix.Rows[i].Cells[j + 1].Style.SelectionBackColor = Color.Empty;
                }
        }
        //Начать решение
        private bool SolutionStart()
        {
            addCols = 0;
            ShowAllCols();
            ClearPossibleElements();
            step = 0;
            SaveMatrix();
            SimplexMethod res = simplexMatrixList[simplexMatrixList.Count - 1].Copy();
            if (res.isEmpty())
            {
                step = -1;
                return false;
            }
            res = res.RemoveDependent();
            if (MinMaxComboBox.Text == "Максимум")
                res = res.FromMinToMax();
            function = new Fraction[res.GetNumberOfColumns()];
            for (int i = 0; i < res.GetNumberOfColumns(); i++)
                function[i] = res.GetValue(res.GetNumberOfRows() - 1, i);
            if (MethodChooseComboBox.Text == "Симплекс")
            {

                basisVariables = simplexMatrixList[0].GetRang();
                int k = 0;
                for (int v = 0; v < basisVariables; v++)
                {
                    //res = res.Transform(v, v); Пробор в тупую
                    Fraction min = null;
                    for (int j = 0; j < res.GetNumberOfColumns() - 1; j++)
                    {
                        bool flagPositive = false;
                        for(int i=0; i < res.GetNumberOfRows()-1; i++)
                            if ((res.GetValue(i, j) > 0) && !res.IsBasisCol(j) && (res.getIndexOfBasis(i) == -1))
                                flagPositive = true;
                        Fraction element = res.GetValue(res.GetNumberOfRows() - 1, j);
                        if ((min == null) && (element < 0) && flagPositive)
                            min = element;
                        if ((min != null) && (element < min) && flagPositive)
                            min = element;
                    }
                    for (int j = 0; j < res.GetNumberOfColumns() - 1; j++)
                    {
                        if (min == null)
                            break;
                        for (int i = 0; i < res.GetNumberOfRows() - 1; i++)
                        {
                            if (res.IsPossibleElement(i, j) && (res.GetValue(res.GetNumberOfRows() - 1, j) == min))
                            {
                                res = res.Transform(i, j);
                                k++;
                            }
                        }
                    }
                }
                //Костыль
                if (k != basisVariables)
                {
                    for (int i = 0; i < res.GetNumberOfRows() - 1; i++)
                        for (int j = 0; j < res.GetNumberOfColumns() - 1; j++)
                        {
                            if ((res.GetValue(i, j) > 0) && !res.IsBasisCol(j) && (res.getIndexOfBasis(i) == -1))
                                res = res.Transform(i, j);
                        }
                }
            }
            if (MethodChooseComboBox.Text == "Искуственный базис")
                res = res.ToArtificialBasis();
            simplexMatrixList.Add(res);
            step = 1;
            if (MethodChooseComboBox.Text == "Искуственный базис")
                addCols = simplexMatrixList[1].GetNumberOfColumns() - simplexMatrixList[0].GetNumberOfColumns();
            LoadMatrix();
            ResetButton.Text = "К вводу";
            StepTextBox.Text = "Шаг - " + step.ToString();
            BanChange();
            ShowBasis();
            FindPossibleElements();
            finalStep = res.IsAnswer();
            if (finalStep)
                SolutionEnd();
            if (!res.IsAlowed())
            {
                finalStep = true;
                SolutionEnd();
                AnswerTextBox.Text = "Нет решений";
            }
            return true;
        }
        //След. шаг решения
        private void SolutionNextStep()
        {
            if (finalStep)
                return;
            if ((SimplexMatrix.CurrentCell != null) && (SimplexMatrix.CurrentCell.OwningColumn.Index >= 0) && (SimplexMatrix.CurrentCell.OwningRow.Index >= 0))
                if (SimplexMatrix.CurrentCell.Style.SelectionBackColor != Color.White)
                {
                    ShowAllCols();
                    ClearPossibleElements();
                    SimplexMethod res = simplexMatrixList[simplexMatrixList.Count - 1].Copy();
                    res = res.Transform(SimplexMatrix.CurrentCell.OwningRow.Index, SimplexMatrix.CurrentCell.OwningColumn.Index - 1);
                    if ((step == addCols) && (MethodChooseComboBox.Text == "Искуственный базис"))
                    {
                        int numberOfColumns = res.GetNumberOfColumns();
                        for (int j = numberOfColumns - addCols - 1; j < numberOfColumns - 1; j++)
                        {
                            res = res.RemoveColumn(j);
                            j--;
                            numberOfColumns--;
                        }
                        addCols = 0;
                        res = res.FromArtFuncToTrue(function);
                    }
                    simplexMatrixList.Add(res);
                    step++;
                    LoadMatrix();
                    ShowBasis();
                    StepTextBox.Text = "Шаг - " + step.ToString();
                    FindPossibleElements();
                    finalStep = res.IsAnswer();
                    if (finalStep)
                        SolutionEnd();
                    if (!res.IsAlowed())
                    {
                        finalStep = true;
                        SolutionEnd();
                        AnswerTextBox.Text = "Нет решений";
                    }
                }
        }
        //Шаг назад
        private void SolutionPrevStep()
        {
            AnswerTextBox.Text = "";
            SolveButton.Text = "Решить";
            finalStep = false;
            if (step == -1)
                SolutionCancel();
            else
            {
                if ((addCols == 0) && (MethodChooseComboBox.Text == "Искуственный базис") && (step <= 1 + simplexMatrixList[1].GetNumberOfColumns() - simplexMatrixList[0].GetNumberOfColumns()))
                    addCols = simplexMatrixList[1].GetNumberOfColumns() - simplexMatrixList[0].GetNumberOfColumns();
                ShowAllCols();
                ClearPossibleElements();
                simplexMatrixList.RemoveAt(simplexMatrixList.Count - 1);
                step--;
                LoadMatrix();
                FindPossibleElements();
                StepTextBox.Text = "Шаг - " + step.ToString();
                ShowBasis();
            }
        }
        //Откат к вводу
        private void SolutionCancel()
        {
            AnswerTextBox.Text = "";
            SolveButton.Text = "Решить";
            finalStep = false;
            ShowAllCols();
            ClearPossibleElements();
            if (step == -1)
            {
                FillSMatrixZero();
                ShowBasis();
            }
            else
            {
                step = 0;
                LoadMatrix();
                step = -1;
                simplexMatrixList.RemoveAt(simplexMatrixList.Count - 1);
                StepTextBox.Text = "Шаг - Ввод данных";
                ResetButton.Text = "Очистить";
            }
            simplexMatrixList.Clear();
            AllowChange();
            ShowBasis();
        }
        //Конец решения и вывод ответа
        private void SolutionEnd()
        {
            if (addCols != 0)
            {
                AnswerTextBox.Text = "Нет решений";
            }
            else
                AnswerTextBox.Text = simplexMatrixList[simplexMatrixList.Count - 1].Answer(MinMaxComboBox.Text == "Минимум", FractionTypeComboBox.Text == "Обыкновенные");
            StepTextBox.Text = "Шаг - Ответ:";
        }
        //Разрешить ввод/изменение 
        private void AllowChange()
        {
            NumberOfVariablesTextBox.Enabled = true;
            NumberOfBoundedTextBox.Enabled = true;
            FractionTypeComboBox.Enabled = true;
            PlusNumberOfVariablesButton.Enabled = true;
            PlusNumberOfBoundedButton.Enabled = true;
            MinusNumberOfVariablesButton.Enabled = true;
            MinusNumberOfBoundedButton.Enabled = true;
            MinMaxComboBox.Enabled = true;
            MethodChooseComboBox.Enabled = true;
            for (int j = 1; j < numberOfVariable + 2; j++)
                SimplexMatrix.Columns[j].ReadOnly = false;
        }
        //Заблокировать ввод/изменение
        private void BanChange()
        {
            NumberOfVariablesTextBox.Enabled = false;
            NumberOfBoundedTextBox.Enabled = false;
            FractionTypeComboBox.Enabled = false;
            PlusNumberOfVariablesButton.Enabled = false;
            PlusNumberOfBoundedButton.Enabled = false;
            MinusNumberOfVariablesButton.Enabled = false;
            MinusNumberOfBoundedButton.Enabled = false;
            MinMaxComboBox.Enabled = false;
            MethodChooseComboBox.Enabled = false;
            for (int j = 1; j < numberOfVariable + 2; j++)
                SimplexMatrix.Columns[j].ReadOnly = true;
        }
        //Справка
        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа позволяет решать задачу линейного программирования симплекс методом и методом искусственного базиса\n" +
                            "Присутствует возможность ввода размерности задачи в канонической форме с помощью соотвествующих кнопок и таблицы.\n" +
                            "Размерность не более 16*16. Размер выбирается с помощью соответствующих кнопок + и -\n" +
                            "Есть возможность сохранения введённой задачи в файл и загрузка её из файла\n" +
                            "Есть пошаговый(шаги вперед и назад) и автоматический режимы\n" +
                            "Есть выбор, что нужно искать: минимум или максимум\n" +
                            "Возможность работы как с десятичными, так и с обыкновенными дробями",
                            "Справка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button1);
        }
        //Увеличить число переменных на 1
        private void PlusNumberOfVariablesButton_Click(object sender, EventArgs e)
        {
            if (numberOfVariable < maxNumberOfVariable)
                numberOfVariable++;
            NumberOfVariablesTextBox.Text = numberOfVariable.ToString();
        }
        //Уменьшить число переменных на 1
        private void MinusNumberOfVariablesButton_Click(object sender, EventArgs e)
        {
            if (numberOfVariable > 1)
                numberOfVariable--;
            NumberOfVariablesTextBox.Text = numberOfVariable.ToString();
        }
        //Увеличить число ограничений на 1
        private void PlusNumberOfBoundedButton_Click(object sender, EventArgs e)
        {
            if (numberOfBounded < maxNumberOfBounded)
                numberOfBounded++;
            NumberOfBoundedTextBox.Text = numberOfBounded.ToString();
        }
        //Уменьшить число ограничений на 1
        private void MinusNumberOfBoundedButton_Click(object sender, EventArgs e)
        {
            if (numberOfBounded > 1)
                numberOfBounded--;
            NumberOfBoundedTextBox.Text = numberOfBounded.ToString();
        }
        //Сохранить матрицу в файл
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String path = null;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    path = dialog.FileName;
                    using (FileStream fs = File.Create(path))
                    {
                        step++;
                        SaveMatrix();
                        byte[] info;
                        if (FractionTypeComboBox.Text == "Обыкновенные")
                            info = new UTF8Encoding(true).GetBytes(simplexMatrixList[0].ToString());
                        else
                            info = new UTF8Encoding(true).GetBytes(simplexMatrixList[0].ToDoubleString());
                        simplexMatrixList.RemoveAt(simplexMatrixList.Count - 1);
                        step--;
                        fs.Write(info, 0, info.Length);
                        ShowBasis();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                            ex.ToString(),
                            "Ошибка!!!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);
                }
            }
        }
        //Загрузить матрицу из файла
        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SolutionCancel();
            addCols = 0;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    String res = File.ReadAllText(dialog.FileName);
                    simplexMatrixList.Clear();
                    simplexMatrixList.Add(new SimplexMethod(res));
                    step = 0;
                    LoadMatrix();
                    step = -1;
                    simplexMatrixList.RemoveAt(simplexMatrixList.Count - 1);
                    ShowAllCols();
                    AllowChange();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                           ex.ToString(),
                           "Ошибка!!!",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error,
                           MessageBoxDefaultButton.Button1);
                }
            }
        }
        //Кнопка очистить
        private void ResetButton_Click(object sender, EventArgs e)
        {
            SolutionCancel();
        }
        //Кнопка шаг назад
        private void PreviousButton_Click(object sender, EventArgs e)
        {
            finalStep = false;
            if (step <= 1)
                SolutionCancel();
            else
            {
                SolutionPrevStep();
            }
        }
        //Кнопка шаг вперед
        private void NextButton_Click(object sender, EventArgs e)
        {
            if (step == -1)
                SolutionStart();
            else
            {
                SolutionNextStep();
            }
        }
        //Кнопка решить
        private void SolveButton_Click(object sender, EventArgs e)
        {
            if (step == -1)
            {
                if (SolutionStart())
                    while (!finalStep)
                        SolutionNextStep();
            }
            else
                while (!finalStep)
                    SolutionNextStep();
        }
        //Изменение числа переменных
        private void NumberOfVariablesTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(NumberOfVariablesTextBox.Text) > maxNumberOfVariable)
                    NumberOfVariablesTextBox.Text = maxNumberOfVariable.ToString();
                if (Int32.Parse(NumberOfVariablesTextBox.Text) < 1)
                    NumberOfVariablesTextBox.Text = 1.ToString();
            }
            catch
            {
                return;
            }
            String[] bCol = new String[numberOfBounded + 1];
            for (int i = 0; i < numberOfBounded + 1; i++)
                bCol[i] = SimplexMatrix.Rows[i].Cells[SimplexMatrix.Columns.Count - 1].Value.ToString();
            try
            {
                numberOfVariable = Int32.Parse(NumberOfVariablesTextBox.Text);
                if (numberOfVariable < 1)
                    numberOfVariable = 1;
                SimplexMatrix.Columns.RemoveAt(SimplexMatrix.Columns.Count - 1);

            }
            catch
            {
                if (NumberOfVariablesTextBox.Text.Length > 1)
                {
                    NumberOfVariablesTextBox.Text = numberOfVariable.ToString();
                    NumberOfVariablesTextBox.SelectionStart = NumberOfVariablesTextBox.Text.Length;
                }
            }
            while (SimplexMatrix.Columns.Count - 1 != numberOfVariable)
            {
                if (SimplexMatrix.Columns.Count - 1 < numberOfVariable)
                {
                    String name = "x" + (SimplexMatrix.Columns.Count).ToString();
                    SimplexMatrix.Columns.Add(name, name);
                    SimplexMatrix.Columns[SimplexMatrix.Columns.Count - 1].Width = 50;
                    SimplexMatrix.Columns[SimplexMatrix.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
                    int col = SimplexMatrix.Columns.Count - 1;
                    if (col != 0)
                        for (int i = 0; i < numberOfBounded + 1; i++)
                            SimplexMatrix.Rows[i].Cells[col].Value = '0';
                    else
                    {
                        for (int i = 0; i < numberOfBounded; i++)
                            SimplexMatrix.Rows[i].Cells[0].Value = " ";
                        SimplexMatrix.Rows[SimplexMatrix.Rows.Count - 1].Cells[0].Value = "f";
                    }
                }
                else
                {
                    SimplexMatrix.Columns.RemoveAt(SimplexMatrix.Columns.Count - 1);
                }
            }
            SimplexMatrix.Columns.Add("b", "b");
            SimplexMatrix.Columns[SimplexMatrix.Columns.Count - 1].Width = 50;
            SimplexMatrix.Columns[SimplexMatrix.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
            for (int i = 0; i < numberOfBounded + 1; i++)
                SimplexMatrix.Rows[i].Cells[SimplexMatrix.Columns.Count - 1].Value = bCol[i];
            if ((SimplexMatrix.Rows.Count > 0) && (SimplexMatrix.Columns.Count > 0))
                if (SimplexMatrix.Rows[0].Cells[0].Value != null)
                    if (SimplexMatrix.Rows[0].Cells[0].Value.ToString() == "0")
                        SimplexMatrix.Rows[0].Cells[0].Value = " ";
        }
        //Изменение числа ограничений
        private void NumberOfBoundedTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(NumberOfBoundedTextBox.Text) > maxNumberOfBounded)
                    NumberOfBoundedTextBox.Text = maxNumberOfBounded.ToString();
                if (Int32.Parse(NumberOfBoundedTextBox.Text) < 1)
                    NumberOfBoundedTextBox.Text = 1.ToString();
            }
            catch
            {
                return;
            }
            String[] FColumn = new String[numberOfVariable + 2];
            for (int i = 1; i < numberOfVariable + 2; i++)
                FColumn[i] = SimplexMatrix.Rows[SimplexMatrix.Rows.Count - 1].Cells[i].Value.ToString();
            try
            {
                numberOfBounded = Int32.Parse(NumberOfBoundedTextBox.Text);
                if (numberOfBounded < 1)
                    numberOfBounded = 1;
                SimplexMatrix.Rows.RemoveAt(SimplexMatrix.Rows.Count - 1);
            }
            catch
            {
                if (NumberOfBoundedTextBox.Text.Length > 1)
                {
                    NumberOfBoundedTextBox.Text = numberOfBounded.ToString();
                    NumberOfBoundedTextBox.SelectionStart = NumberOfBoundedTextBox.Text.Length;
                }
            }
            while (SimplexMatrix.Rows.Count != numberOfBounded)
            {
                if (SimplexMatrix.Rows.Count < numberOfBounded)
                {
                    SimplexMatrix.Rows.Add();
                    for (int j = 1; j < numberOfVariable + 2; j++)
                        SimplexMatrix.Rows[SimplexMatrix.Rows.Count - 1].Cells[j].Value = '0';
                }
                else
                    SimplexMatrix.Rows.RemoveAt(SimplexMatrix.Rows.Count - 1);
            }
            SimplexMatrix.Rows.Add();
            for (int i = 1; i < numberOfVariable + 2; i++)
                SimplexMatrix.Rows[SimplexMatrix.Rows.Count - 1].Cells[i].Value = FColumn[i];
            SimplexMatrix.Rows[SimplexMatrix.Rows.Count - 1].Cells[0].Value = "f";
            if ((SimplexMatrix.Rows.Count > 0) && (SimplexMatrix.Columns.Count > 0))
                if (SimplexMatrix.Rows[0].Cells[0].Value != null)
                    if (SimplexMatrix.Rows[0].Cells[0].Value.ToString() == "0")
                        SimplexMatrix.Rows[0].Cells[0].Value = " ";
        }
        //Блокировать выбор не возможного элемента в базис
        private void SimplexMatrix_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SimplexMatrix.SelectedCells[0].Style.SelectionBackColor == Color.White)
                SimplexMatrix.SelectedCells[0].Selected = false;
        }
        //Контролировать значение в матрице
        private void SimplexMatrix_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (SimplexMatrix.CurrentCell != null)
                if ((SimplexMatrix.CurrentCell.Value == null))
                    SimplexMatrix.CurrentCell.Value = '0';
                else
                    if (SimplexMatrix.CurrentCell.OwningColumn.Index != 0)
                {
                    if ((SimplexMatrix.CurrentCell.Value == null) || (SimplexMatrix.CurrentCell.Value.ToString() == ""))
                        SimplexMatrix.CurrentCell.Value = '0';
                    else
                    {
                        if (!new Regex(@"^-?[0-9]\d*((,|/)\d+)?$").IsMatch(SimplexMatrix.CurrentCell.Value.ToString()))
                            SimplexMatrix.CurrentCell.Value = '0';
                        if (SimplexMatrix.CurrentCell.Value.ToString() != "")
                        {
                            if ((SimplexMatrix.CurrentCell.ColumnIndex == SimplexMatrix.ColumnCount - 1) && (SimplexMatrix.CurrentCell.RowIndex != numberOfBounded))
                            {
                                if (new Regex(@"^-[0-9]\d*((,|/)\d+)?$").IsMatch(SimplexMatrix.CurrentCell.Value.ToString()))
                                    SimplexMatrix.CurrentCell.Value = '0';
                            }
                        }
                        else
                            SimplexMatrix.CurrentCell.Value = '0';
                    }

                }
        }
    }
}
