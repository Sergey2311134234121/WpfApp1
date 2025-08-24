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
using WpfApp1.ViewModel;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для PartDet.xaml
    /// </summary>
    public partial class PartDet : Window
    {
        public PartDet()
        {
            InitializeComponent();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.DataContext is PartDetViewModel pdvm)
            {
                pdvm.CollectionSpisDopRab.Add( new NamedItemForPartDet { Text = pdvm.DopRabSelectedFromSpis.Text , VremRab = pdvm.DopRabSelectedFromSpis.VremRab });
            }
        }

        private void ListBox_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            if (this.DataContext is PartDetViewModel pdvm)
            {
                pdvm.CollectionSpisDopRab.Remove(pdvm.DopRabSelectedFromCollection);
            }
        }

       
    }
}
