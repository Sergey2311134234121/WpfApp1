using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using WpfApp1.Helpers.ВсякаяХуйня;

namespace WpfApp1.View.Operacii
{
    /// <summary>
    /// Логика взаимодействия для Sverl.xaml
    /// </summary>
    public partial class Sverl : Window
    {
        public static string TipWin = "OperWin";
        public Sverl()
        {
            InitializeComponent(); // Датаконтекст в обработчике кликов контекстного меню в тривью ContMenuForHole, хуйня, обработчик кликов.
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
