namespace GaussSolve
{
    public partial class Calculator : Form
    {
        public string Vars = "";
        public Calculator()
        {
            Application.Run(new StartForm());
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            TopMost = true;
        }

        private void varsBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ','
            || e.KeyChar == (char)Keys.Back
            || e.KeyChar == (char)Keys.Space
            || (e.KeyChar + 0 >= 97) && (e.KeyChar + 0 <= 122)) return;
            e.Handled = true;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)e.KeyChar == (Char)Keys.Enter)
            {
                ActiveControl = tabControl1.Controls.Find($"textBox{(int)Char.GetNumericValue(ActiveControl.Name[7]) + 1}", true)[0];
            }
            //e.Handled = true;
        }

        private void varsBox_TextChanged(object sender, EventArgs e)
        {
            string origin = varsBox.Text;

            string txt = origin.Replace(",", "").Replace(" ", "");
            int len = txt.Length;
            Vars = txt;
            ansBox.Size = new Size(ansBox.Size.Width, Math.Min(22 + (len - 1) * 18, 184));

            CheckSame(txt, len);

            if (Vars.Length > 10) TextBoxesEnable(false);
            warnTxt.Enabled = Vars.Length > 10;
        }

        private void CheckSame(string txt, int len)
        {
            foreach (Control control in this.tabPage1.Controls)
            {
                if (control is not TextBox) continue;
                if (control.Name == "varsBox") continue;
                control.Enabled = len >= Convert.ToInt16(control.Name[7..]);
            }

            var set = new HashSet<int>();
            foreach (var item in txt)
                if (!set.Add(item))
                    TextBoxesEnable(false);

            #region Reserv
            /*
            p = true;
            for (int i = 0; i<txt.Length-1; i++)
                for (int j = i + 1; j < txt.Length; j++ ) 
                    if (txt[i] == txt[j]) p = false;
            */
            #endregion
        }

        private void TextBoxesEnable(bool v)
        {
            foreach (Control control in this.tabPage1.Controls)
            {
                if (control is not TextBox) continue;
                if (control.Name == "varsBox") continue;
                control.Enabled = v;
            }
        }

        private void solveBtn_Click(object sender, EventArgs e)
        {
            TextBoxesEnable(false);
            ansBox.Items.Clear();
            docBox.Items.Clear();

            string[] temp = GetDATA();
            Array.Reverse(temp);
            Parser parser = new Parser(temp, Vars);

            coeffData data = parser.Parse();
            float[][] coeffs = data.coeffs;
            float[] free_coeffs = data.free_coeffs;

            DocPrintLine("Исходная система:");
            Print(coeffs, free_coeffs, null);
            DocPrintLine("Решаем:");

            string[] answers = Solve(coeffs, free_coeffs) ?? Array.Empty<string>();

            foreach (var item in answers)
                ansBox.Items.Add(item);

            varsBox_TextChanged(sender, e);
        }

        private string[] GetDATA()
        {
            string[] data = new string[10];
            int i = 0;
            foreach (Control control in this.tabPage1.Controls)
            {
                if (control is not TextBox) continue;
                if (control.Name == "varsBox") continue;
                data[i] = control.Text;
                i++;
            }
            return data;
        }

        #region Gauss

        void Print(float[][] A, float[] B, int[]? selected)
        {
            for (int row = 0; row < B.Length; row++)
            {
                DocPrintLine("(");
                for (int col = 0; col < A[row].Length; col++)
                {
                    DocPrint(string.Format("{0,7:f2}", A[row][col]));
                    if (selected == null || selected[0] != row || selected[1] != col)
                        DocPrint(" ");
                    else
                        DocPrint("<");
                }
                DocPrint(string.Format(" |{0,7:f2})", B[row]));
            }
            DocPrintLine();
        }

        void DocPrint(string txt)
        {
            docBox.Items[docBox.Items.Count - 1] += txt;
        }

        void DocPrintLine(string txt = "")
        {
            docBox.Items.Add(txt);
        }


        // --- перемена местами двух строк системы
        void SwapRows(float[][] A, float[] B, int row1, int row2)
        {
            (A[row2], A[row1]) = (A[row1], A[row2]);
            (B[row2], B[row1]) = (B[row1], B[row2]);
        }

        // --- деление строки системы на число
        void DivideRow(float[][] A, float[] B, int row, float divider)
        {
            for (int i = 0; i < A[0].Length; i++)
            {
                A[row][i] /= divider;
            }
            B[row] /= divider;
        }

        // --- сложение строки системы с другой строкой, умноженной на число
        void CombineRows(float[][] A, float[] B, int row, int source_row, float weight)
        {
            for (int i = 0; i < A[0].Length; i++)
            {
                A[row][i] += A[source_row][i] * weight;
            }
            B[row] += B[source_row] * weight;
        }

        // --- решение системы методом Гаусса (приведением к треугольному виду)
        string[]? Solve(float[][] A, float[] B)
        {
            int column = 0;
            while (column < B.Length)
            {
                DocPrintLine($"Ищем максимальный по модулю элемент в {column + 1}-м столбце:");
                int current_row = -1;
                for (int r = column; r < A.Length; r++)
                {
                    if (current_row == -1 || Math.Abs(A[r][column]) > Math.Abs(A[current_row][column]))
                        current_row = r;
                }
                if (current_row == -1)
                {
                    DocPrintLine("решений нет");
                    return null;
                }
                Print(A, B, new int[] { current_row, column });

                if (current_row != column)
                {
                    DocPrintLine("Переставляем строку с найденным элементом повыше:");
                    SwapRows(A, B, current_row, column);
                    Print(A, B, new int[] { column, column });
                }
                DocPrintLine("Нормализуем строку с найденным элементом:");
                DivideRow(A, B, column, A[column][column]);
                Print(A, B, new int[] { column, column });
                DocPrintLine("Обрабатываем нижележащие строки:");
                for (int r = column + 1; r < A.Length; r++)
                    CombineRows(A, B, r, column, -A[r][column]);
                Print(A, B, new int[] { column, column });
                column++;
            }
            DocPrintLine("Матрица приведена к треугольному виду, считаем решение");
            float[] X = new float[B.Length];

            for (int i = B.Length - 1; i > -1; i--)
            {
                List<float> T = new();

                var x = X[(i + 1)..];
                var a = A[i][(i + 1)..];

                for (int k = 0; k < x.Length; k++)
                    T.Add(x[k] * a[k]);

                X[i] = B[i] - T.ToArray().Sum();
            }

            string[] answers = new string[Vars.Length];
            for (int i = 0; i < X.Length; i++)
            {
                DocPrintLine($"{Vars[i]} = "); answers[i] = $"{Vars[i]} = ";
                DocPrint(string.Format("{0,8:f2}", X[i])); answers[i] += string.Format("{0,13:f2}", X[i]);
            }
            return answers;
        }

        #endregion
    }
}