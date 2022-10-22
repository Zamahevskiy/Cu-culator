using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            char[] numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f'};
            string chis = Chis.Text;
            chis = chis.ToLower();
            int k;
            int c;
            k = Convert.ToInt32(from.Text);
            c = Convert.ToInt32(_in.Text);
            if (chis != "" && from.Text != "" && _in.Text != "")
            {
                k = Convert.ToInt32(from.Text);
                c = Convert.ToInt32(_in.Text);
                if (!(k > 1 && k < 17 && c > 1 && c < 17))
                {
                    MessageBox.Show("Неверная система счисления! Введите число от 2 до 16.");
                    return;
                };
                for (int i = 0; i < chis.Length; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        if (chis[i] == numbers[j])
                        {
                            if (j > (k - 1))
                            {
                                MessageBox.Show("Число не соответствует системе счисления.");
                                return;
                            }
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }

            int chis_10 = 0;
            int st = 0;
            for (int i = chis.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < 16; j++)
                {
                    if (chis[i] == numbers[j])
                    {
                        chis_10 += (int)(j * Math.Pow(k, st));
                        st++;
                        break;
                    }
                }
            }
            string res = "";
            while(chis_10!=0)
            {
                res = numbers[chis_10 % c].ToString() + res;
                chis_10 = chis_10 / c;
            }
            result.Content = "Результат: " + res.ToUpper();
        }
    }
}
