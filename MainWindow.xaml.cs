using System;
using System.Windows;

namespace FactorialApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Обработчик для очистки placeholder текста
            InputTextBox.GotFocus += (s, e) =>
            {
                if (InputTextBox.Text == "Введите число")
                    InputTextBox.Text = "";
            };

            InputTextBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(InputTextBox.Text))
                    InputTextBox.Text = "Введите число";
            };
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            string input = InputTextBox.Text.Trim();  // Точка останова 1

            // Проверка на пустой ввод
            if (string.IsNullOrEmpty(input) || input == "Введите число")
            {
                ResultTextBlock.Text = "Ошибка: Введите число!";
                return;
            }

            int number;
            // Использование TryParse
            if (!int.TryParse(input, out number))  // Точка останова 2
            {
                ResultTextBlock.Text = "Ошибка: Некорректный ввод!";
                return;
            }

            // Проверка на отрицательное число
            if (number < 0)
            {
                ResultTextBlock.Text = "Ошибка: Число должно быть неотрицательным!";
                return;
            }

            // Проверка на слишком большое число 
            if (number > 20)
            {
                ResultTextBlock.Text = "Ошибка: Число слишком большое! Максимум 20.";
                return;
            }

            try
            {
                long factorial = CalculateFactorial(number);  // Точка останова 3
                ResultTextBlock.Text = $"Факториал {number}! = {factorial}";
            }
            catch (OverflowException)
            {
                ResultTextBlock.Text = "Ошибка: Переполнение при вычислении!";
            }
            }

        private long CalculateFactorial(int n)
        {
            // Учет случая, когда число равно 0
            if (n == 0)  // Точка останова 4
                return 1;

            long result = 1;
            for (int i = 1; i <= n; i++)  // Точка останова 5
            {
                // Обработка переполнения
                checked
                {
                    result *= i;
                }
            }
            return result;
        }
    }
}