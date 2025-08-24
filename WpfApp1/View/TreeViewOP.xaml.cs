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
    /// Логика взаимодействия для TreeViewOP.xaml
    /// </summary>
    public partial class TreeViewOP : Window
    {
        public TreeViewOP()
        {
            var ViewModel = new WpfApp1.ViewModel.TreeViewOPViewModel();            
            DataContext = ViewModel;
            InitializeComponent();
            #region Добавление перемещения
            var win1 = new View.Perem();
            var perem = new Perem1 { Name = $"Вспомогательное время на деталь", window = win1 };
            Detal.Instance.ChtototamsSDetals.Add(perem);
            var vm1 = new ViewModel.PeremViewModel();
            perem.window.DataContext = vm1;
            this.Loaded += (s, e) =>
            {
                win1.Owner = Application.Current.MainWindow;
            };
            #endregion
            #region Добавление нулевого отв
            var win = new View.OtvParams();
            var hole = new Hole { Name = $"Отверстие тип 0", window = win };
            Detal.Instance.ChtototamsSDetals.Add(hole);
            var vm = new ViewModel.OtvParamsViewModel(hole);
            hole.window.DataContext = vm;
            this.Loaded += (s, e) =>
            {
                win.Owner = Application.Current.MainWindow;
            };
            #endregion
            #region Создание окна партдет                       
            var win2 = new View.PartDet();
            var vm2 = new ViewModel.PartDetViewModel();
            win2.DataContext = vm2;
            this.Loaded += (s, e) =>
            {
                win2.Owner = Application.Current.MainWindow;
            };
            if (this.DataContext is WpfApp1.ViewModel.TreeViewOPViewModel dc)
            {
                dc.WinForPartDet = win2;
            }
            #endregion              
        }
        private void Hole_RightClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBlock tb && tb.DataContext is Hole hole && DataContext is TreeViewOPViewModel vm)
            {
                vm.ContMenuForHole(tb,vm);
            }
        }
        private void Oper_RightClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBlock tb && tb.DataContext is Operation Oper && DataContext is TreeViewOPViewModel vm && tb.Tag is Hole hole)
            {
                vm.ContMenuForOper(tb, vm, hole);
            }
        }
        private void TreeViewItem_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DependencyObject clickedElement = e.OriginalSource as DependencyObject;
            TreeViewItem clickedItem = null;

            while (clickedElement != null && clickedItem == null)
            {
                if (clickedElement is TreeViewItem tvi)
                    clickedItem = tvi;
                else
                    clickedElement = VisualTreeHelper.GetParent(clickedElement);
            }
            if (!ReferenceEquals(clickedItem, sender))
            {
                return;
            }
            TreeViewItem item = (TreeViewItem)sender;
            var context = item.DataContext;
            if (DataContext is not TreeViewOPViewModel vm)
                return;
            if (context is Hole hole)
            {
                e.Handled = true;
                vm.OpenWinForHole(hole);
            }
            else if (context is Operation op)
            {
                e.Handled = true;
                vm.OpenWinForOper(op);
            }
            else if (context is Perem1 perem)
            {
                e.Handled = true;
                vm.OpenWinForPerem(perem);
            }
        } // Переназначение двойного клика
    }
}
