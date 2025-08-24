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
using System.Windows.Shapes;
using WpfApp1.Helpers.ВсякаяХуйня;
using System.ComponentModel;
using WpfApp1.ViewModel;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для OtvParams.xaml
    /// </summary>
    public partial class OtvParams : Window
    {
        public OtvParams()
        {
            InitializeComponent(); //Датаконтекст задается в TreeViewOPViewModel
        }
        //protected void Closing(CancelEventArgs e)
        //{

        //}

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            if (this.DataContext is OtvParamsViewModel vm)
            {
                vm._wind.Close();
            }
            this.Hide();
        }
    }
}
