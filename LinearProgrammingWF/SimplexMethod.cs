using System;
using System.Collections.Generic;
using System.Globalization;

namespace LinearProgrammingWF
{
    public class SimplexMethod
    {
        //Двухмерная матрица дробей 
        private Fraction[,] fractions;

        //Конструкторы
        public SimplexMethod(int rows, int cols)
        {
            this.fractions = new Fraction[rows, cols];
        }
        public SimplexMethod(Fraction[,] fractions)
        {
            this.fractions = fractions;
        }
        public SimplexMethod(String str)
        {
            try
            {
                List<String> rowsStr = new List<String>(str.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries));
                List<String>[] rows = new List<String>[rowsStr.Count];
                for (int i = 0; i < rowsStr.Count; i++)
                {
                    rows[i] = new List<String>(rowsStr[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                }
                Fraction[,] fractions = new Fraction[rowsStr.Count, rows[0].Count];

                for (int i = 0; i < rowsStr.Count; i++)
                    for (int j = 0; j < rows[0].Count; j++)
                    {
                        String text = rows[i][j];
                        int k = 0;
                        bool doubleString = false;
                        //Если true, то ввод в формате десятичных дробей, иначе - обыкновенные
                        foreach (char letter in text)
                        {
                            if (letter == '/')
                                k++;
                            if (letter == ',')
                            {
                                k++;
                                doubleString = true;
                            }
                        }
                        if (k > 1)
                            throw new Exception("Неправильный входной формат строки");
                        if (doubleString)
                        {
                            NumberFormatInfo formatProvider = new NumberFormatInfo();
                            fractions[i, j] = new Fraction(Convert.ToDouble(text, formatProvider));
                        }
                        else
                        {
                            int numerator = Convert.ToInt32(text.Split('/')[0]);
                            int denominator = 1;
                            if (text.Split('/').Length > 1)
                                denominator = Convert.ToInt32(text.Split('/')[1]);
                            fractions[i, j] = new Fraction(numerator, denominator);
                        }
                    }
                for (int i = 0; i < fractions.GetLength(0) - 1; i++)
                    if (fractions[i, fractions.GetLength(1) - 1] < 0)
                        throw new Exception("Не должно быть отрицательных b");
                this.fractions = fractions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Получить число строк
        public int GetNumberOfRows()
        {
            return this.fractions.GetLength(0);
        }
        //Получить число столбцов
        public int GetNumberOfColumns()
        {
            return this.fractions.GetLength(1);
        }
        //Получить значение в ячейке с указанными индексами
        public Fraction GetValue(int row, int column)
        {
            if ((row > -1) && (row < fractions.GetLength(0)) && (column > -1) && (column < fractions.GetLength(1)))
                return fractions[row, column];
            else
                return null;
        }
        //Сделать копию матрицы
        public SimplexMethod Copy()
        {
            int rows = this.GetNumberOfRows();
            int cols = this.GetNumberOfColumns();
            Fraction[,] copy = new Fraction[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    copy[i, j] = this.fractions[i, j];
            return new SimplexMethod(copy);
        }
        //Проверить матрицу на ненулевость
        public bool isEmpty()
        {
            for (int i = 0; i < this.fractions.GetLength(0); i++)
                for (int j = 0; j < this.fractions.GetLength(1); j++)
                    if (this.fractions[i, j] != 0)
                        return false;
            return true;
        }
        //Проверить решение на допустимость 
        public bool IsAlowed()
        {
            //Все b>=0
            for (int i = 0; i < this.fractions.GetLength(0) - 1; i++)
                if (this.fractions[i, this.fractions.GetLength(1) - 1] < 0)
                    return false;
            //В столбец с отрицательным значением в функции есть хотя бы один положительный
            for (int j = 0; j < this.fractions.GetLength(1) - 1; j++)
            {
                bool havePositive = false;
                for (int i = 0; i < this.fractions.GetLength(0) - 1; i++)
                    if (this.fractions[i, j] > 0)
                        havePositive = true;
                if ((havePositive == false) && (this.fractions[this.fractions.GetLength(0) - 1, j] < 0))
                    return false;
            }

            return true;
        }

        //Проверить является ли ответом
        public bool IsAnswer()
        {
            if (!this.IsAlowed())
                return false;
            for (int j = 0; j < this.fractions.GetLength(1) - 1; j++)
                if (this.fractions[this.fractions.GetLength(0) - 1, j] < 0)
                    return false;
            return true;
        }
        //Проверить столбец на принадлежность к базису
        public bool IsBasisCol(int col)
        {
            if (col >= this.fractions.GetLength(1))
                return false;
            int k = 0;
            for (int i = 0; i < this.fractions.GetLength(0); i++)
                if (this.fractions[i, col] != null)
                    if (this.fractions[i, col] != 0)
                        k++;
            if (k == 1)
            {
                k = 0;
                for (int i = 0; i < this.fractions.GetLength(0) - 1; i++)
                    if (this.fractions[i, col] != null)
                        if (this.fractions[i, col] == 1)
                            k++;
                if (k == 1)
                    return true;
            }
            return false;
        }
        //Получить индекс базисного столбца для строки
        public int getIndexOfBasis(int row)
        {
            int index = -1;
            for (int j = 0; j < this.fractions.GetLength(1) - 1; j++)
                if (this.GetValue(row, j) != 0)
                {
                    index = j;
                    for (int i = 0; i < this.fractions.GetLength(0); i++)
                        if ((this.GetValue(i, j) != 0) && (i != row))
                        {
                            index = -1;
                            break;
                        }
                    if (index != -1)
                        return index;
                }
            return index;
        }
        //Получить представление "xk" для строки
        public String ToStringBasis(int row)
        {
            if (row == this.fractions.GetLength(0) - 1)
                return "f";
            int basis = getIndexOfBasis(row);
            if (basis != -1)
                return "x" + (basis + 1).ToString();
            else
                return "";
        }
        //Проверить является ли элемент допустимым элементом в базис
        public bool IsPossibleElement(int row, int col)
        {
            int rows = this.fractions.GetLength(0);
            int cols = this.fractions.GetLength(1);
            if ((this.fractions[rows - 1, col] >= 0) || (this.fractions[row, col] <= 0))
                return false;
            Fraction minB = null;
            for (int i = 0; i < rows - 1; i++)
            {
                if (this.fractions[i, col] > 0)
                    if (minB == null)
                    {
                        minB = this.fractions[i, cols - 1] / this.fractions[i, col];
                    }
                    else if (this.fractions[i, cols - 1] / this.fractions[i, col] < minB)
                        minB = this.fractions[i, cols - 1] / this.fractions[i, col];

            }
            return this.fractions[row, cols - 1] / this.fractions[row, col] == minB;
        }
        //Проверить является ли элемент допустимым элементом в базис
        public bool IsPossibleElementArtificial(int row, int col, int addCols)
        {
            int rows = this.fractions.GetLength(0);
            int cols = this.fractions.GetLength(1);
            if ((this.fractions[rows - 1, col] >= 0) || (this.fractions[row, col] <= 0))
                return false;
            Fraction minB = null;
            for (int i = 0; i < rows - 1; i++)
            {
                if (this.fractions[i, col] > 0)
                    if (minB == null)
                    {
                        minB = this.fractions[i, cols - 1] / this.fractions[i, col];
                    }
                    else if (this.fractions[i, cols - 1] / this.fractions[i, col] < minB)
                        minB = this.fractions[i, cols - 1] / this.fractions[i, col];
            }
            if (this.getIndexOfBasis(row) < this.fractions.GetLength(1) - 1 - addCols)
                return false;
            return this.fractions[row, cols - 1] / this.fractions[row, col] == minB;
        }
        /*Выполнить переход симплекс-метода согласно выбранному элементу Ars.
        (1) Xr <-> Xs
        (2) Asr(k+1) = 1/Ars(k)
        (3) rowS(k+1) = rowR(k) * 1/Ars(k)
        (4) colR(k+1) = -colS(k) * 1/Ars(k)
        (5) rowI(k+1) = rowI(k) - Ais(k)*rowS(k+1) i!=s */
        public SimplexMethod Transform(int s, int r)
        {
            Fraction targetElement = this.fractions[s, r];
            SimplexMethod res = this.Copy();
            for (int j = 0; j < fractions.GetLength(1); j++)
                res.fractions[s, j] /= targetElement;
            for (int i = 0; i < fractions.GetLength(0); i++)
            {
                Fraction k = res.fractions[i, r];
                if (i != s)
                    for (int j = 0; j < fractions.GetLength(1); j++)
                        res.fractions[i, j] -= k * res.fractions[s, j];
            }
            return res;
        }
        //Удалить строку по индексу
        public SimplexMethod RemoveRow(int row)
        {
            SimplexMethod res = new SimplexMethod(this.fractions.GetLength(0) - 1, this.fractions.GetLength(1));
            for (int i = 0; i < res.GetNumberOfRows(); i++)
                for (int j = 0; j < res.GetNumberOfColumns(); j++)
                    if (i < row)
                        res.fractions[i, j] = this.fractions[i, j];
                    else
                        res.fractions[i, j] = this.fractions[i + 1, j];
            return res;
        }
        //Удалить столбец по индексу
        public SimplexMethod RemoveColumn(int column)
        {
            SimplexMethod res = new SimplexMethod(this.fractions.GetLength(0), this.fractions.GetLength(1) - 1);
            for (int i = 0; i < res.GetNumberOfRows(); i++)
                for (int j = 0; j < res.GetNumberOfColumns(); j++)
                    if (j < column)
                        res.fractions[i, j] = this.fractions[i, j];
                    else
                        res.fractions[i, j] = this.fractions[i, j + 1];
            return res;
        }
        //Перейти к искусственному базису
        public SimplexMethod ToArtificialBasis()
        {
            int rows = this.fractions.GetLength(0);
            int cols = this.fractions.GetLength(1);
            SimplexMethod matrixArtificial = new SimplexMethod(rows, cols + rows - 1);
            //Заполняем столбцы исх. переменных 
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols - 1; j++)
                    matrixArtificial.fractions[i, j] = this.fractions[i, j];
            //Заполяем столбцы доб. переменных
            for (int i = 0; i < matrixArtificial.fractions.GetLength(0); i++)
                for (int j = cols - 1; j < matrixArtificial.fractions.GetLength(1) - 1; j++)
                    if (j - cols + 1 != i)
                    {
                        matrixArtificial.fractions[i, j] = new Fraction(0);
                    }
                    else
                        matrixArtificial.fractions[i, j] = new Fraction(1);
            //Заполняем b-столбец
            for (int i = 0; i < rows; i++)
                matrixArtificial.fractions[i, matrixArtificial.fractions.GetLength(1) - 1] = this.fractions[i, cols - 1];
            //Заполняем нолями f-строку
            for (int j = 0; j < matrixArtificial.fractions.GetLength(1); j++)
                matrixArtificial.fractions[matrixArtificial.fractions.GetLength(0) - 1, j] = new Fraction(0);
            //Считаем f-строку
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                    matrixArtificial.fractions[matrixArtificial.fractions.GetLength(0) - 1, j] -= this.fractions[i, j];
                matrixArtificial.fractions[matrixArtificial.fractions.GetLength(0) - 1, matrixArtificial.fractions.GetLength(1) - 1] -= this.fractions[i, cols - 1];
            }
            return matrixArtificial;
        }
        //Перейти к изначальной функции от функции искусственного базиса
        public SimplexMethod FromArtFuncToTrue(Fraction[] func)
        {
            SimplexMethod res = this.Copy();
            for (int j = 0; j < res.fractions.GetLength(1); j++)
                res.fractions[res.fractions.GetLength(0) - 1, j] = new Fraction(0);
            for (int j = 0; j < func.Length; j++)
            {
                if (this.IsBasisCol(j))
                {
                    int s = 0;
                    while (this.fractions[s, j] == 0)
                        s++;
                    if (this.getIndexOfBasis(s) == j)
                    {
                        for (int r = 0; r < func.Length; r++)
                            if (!((this.IsBasisCol(r) && (this.getIndexOfBasis(s) == r))) || (r == this.fractions.GetLength(1) - 1))
                                res.fractions[res.fractions.GetLength(0) - 1, r] -= res.fractions[s, r] * func[j];
                    }
                    else
                        res.fractions[res.fractions.GetLength(0) - 1, j] += func[j];
                }
                else
                    res.fractions[res.fractions.GetLength(0) - 1, j] += func[j];
            }

            return res;
        }
        //Перейти от минимума к максимуму 
        public SimplexMethod FromMinToMax()
        {
            SimplexMethod matrixMax = this.Copy();
            for (int j = 0; j < matrixMax.fractions.GetLength(1); j++)
                matrixMax.fractions[matrixMax.fractions.GetLength(0) - 1, j] *= -1;
            return matrixMax;
        }
        //Исключить лин. зависимые строки
        public SimplexMethod RemoveDependent()
        {
            SimplexMethod res = this.Copy();
            SimplexMethod checkMatrix = this.Copy();
            checkMatrix = checkMatrix.RemoveRow(checkMatrix.fractions.GetLength(0) - 1);
            for (int i = 0; i < checkMatrix.fractions.GetLength(0); i++)
            {
                for (int j = 0; j < checkMatrix.fractions.GetLength(1); j++)
                    if (checkMatrix.fractions[i, j] != 0)
                    {
                        checkMatrix = checkMatrix.Transform(i, j);
                        break;
                    }
            }
            for (int i = 0; i < checkMatrix.fractions.GetLength(0); i++)
            {
                bool rowOfZeroes = true;
                for (int j = 0; j < checkMatrix.fractions.GetLength(1); j++)
                    if (checkMatrix.fractions[i, j] != 0)
                    {
                        rowOfZeroes = false;
                        break;
                    }
                if (rowOfZeroes)
                {
                    checkMatrix = checkMatrix.RemoveRow(i);
                    res = res.RemoveRow(i);
                    i--;
                }
            }
            return res;
        }
        //Получить ранг матрицы
        public int GetRang()
        {
            if (this.isEmpty())
                return 0;
            SimplexMethod res = this.Copy();
            res = res.RemoveDependent();
            return res.fractions.GetLength(0) - 1;
        }
        //Получить строчное представление матрицы (обыкновенные дроби)
        override
        public String ToString()
        {
            String res = "";
            for (int i = 0; i < this.fractions.GetLength(0); i++)
            {
                for (int j = 0; j < this.fractions.GetLength(1); j++)
                {
                    res += this.fractions[i, j].ToString() + " ";
                }
                res += "\n";
            }
            return res;
        }
        //Получить строчное представление матрицы (десятичные дроби)
        public String ToDoubleString()
        {
            String res = "";
            for (int i = 0; i < this.fractions.GetLength(0); i++)
            {
                for (int j = 0; j < this.fractions.GetLength(1); j++)
                {
                    res += this.fractions[i, j].ToStringDouble() + " ";
                }
                res += "\n";
            }
            return res;
        }
        //Получить ответ в виде строки
        public String Answer(bool min, bool defaultFractions)
        {
            int rows = this.fractions.GetLength(0);
            int cols = this.fractions.GetLength(1);
            bool correct = true;
            for (int i = 0; i < rows - 1; i++)
                if (this.fractions[i, cols - 1] < 0)
                    correct = false;
            if (correct)
            {
                String answer = "x = (";
                for (int j = 0; j < cols - 1; j++)
                {
                    if (this.IsBasisCol(j))
                    {
                        int i = 0;
                        while (this.fractions[i, j] == 0)
                            i++;
                        if (this.getIndexOfBasis(i) == j)
                        {
                            if (defaultFractions)
                                answer += this.fractions[i, cols - 1].ToString() + "; ";
                            else
                                answer += this.fractions[i, cols - 1].ToStringDouble() + "; ";
                        }
                        else
                            answer += "0; ";
                    }
                    else
                        answer += "0; ";
                }
                answer = answer.Remove(answer.Length - 2);
                if (min)
                    if (defaultFractions)
                        answer += "); f* = " + (new Fraction(-1) * this.fractions[rows - 1, cols - 1]).ToString();
                    else
                        answer += "); f* = " + (new Fraction(-1) * this.fractions[rows - 1, cols - 1]).ToStringDouble();
                else
                    if (defaultFractions)
                    answer += "); f* = " + (this.fractions[rows - 1, cols - 1]).ToString();
                else
                    answer += "); f* = " + (this.fractions[rows - 1, cols - 1]).ToStringDouble();
                return answer;
            }
            else
                return ("-");
        }
    }
}
