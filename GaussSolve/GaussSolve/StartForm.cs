using System.Diagnostics;

namespace GaussSolve
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void GoToBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void authorsBtn_Click(object sender, EventArgs e)
        {
            string msg = "Мы - ученики 9б класса АКЛ имени Ю. В. Кондратюка. Программа была написана под руководством Т. В. Клековкиной.\n\n";
            msg += "Наши контакты:\n";
            msg += "Машкин Николай +7(951)-362-3466 kolyabetmen231006@gmail.com\n";
            msg += "Жданов Роман +7(905)-935-1131 rzh@ngs.ru";
            MessageBox.Show(msg, "Об авторах");
        }

        private void intructionsBtn_Click(object sender, EventArgs e)
        {
            string msg = " На главном экране можно посмотреть информацию об авторах, о методе Гаусса и перейти в калькулятор. Также здесь присутствует кнопка выхода из программы.\n\n";
            msg += "Ввод матрицы:\n";
            msg += "* Для начала введите используемые переменные в соответствующее поле. Можно использовать буквы латинского алфавита, запятую и знак пробела.\n";
            msg += "По мере ввода переменных, будет доступно определенное количество полей для ввода уравнений.\n\n";
            msg += "* Следующим шагом будет ввод уравнений в доступные для этого поля.\n";
            msg += "Программа поддерживает только уравнения вида: ax + by + cz... = k, где x, y, z ... - переменные, введенные ранее; a, b, c, k... - коэффициенты.\n";
            msg += "(Возможен ввод без знаков пробела, а также знак \"-\". Порядок переменных не имеет значения. Следует заполнить все доступные поля для ввода уравнений.)\n\n";
            msg += "* После ввода уравнений нужно нажать на кнопку \"Решить\" в левом нижнем углу окна, тогда в поле \"Ответы\" появятся ответы на систему введенных уравнений.\n";
            msg += "Полное решение системы уравнений с комментариями можно найти в разделе \"Подробно\".\n";
            MessageBox.Show(msg, "Инструкции");
        }

        private void HotToBtn_Click(object sender, EventArgs e)
        {
            string msg = " В данной программе для решения систем используется метод Гаусса.\n\n";
            msg += " Для его реализации требуется матрица коэффициентов, и вектор ответов.\n\n";
            msg += " Вся суть метода заключается в приведении матрицы к треугольному виду и обратной подстановке переменных в уравнения.\n\n";
            msg += " Более подробно о методе Гаусса можно узнать в документе далее.\n\n";
            msg += " Вы хотите открыть файл?";
            var result = MessageBox.Show(msg, "О методе", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                var p = new Process
                {
                    StartInfo = new ProcessStartInfo(@"doc.docx") { UseShellExecute = true }
                };
                p.Start();
            }
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
