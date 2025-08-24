using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WpfApp1.Helpers;
using WpfApp1.Helpers.ВсякаяХуйня;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using WpfApp1.View;
using WpfApp1.ViewModel.OperaciiViewModel;

namespace WpfApp1.ViewModel
{
    internal class TreeViewOPViewModel : INotifyPropertyChanged
    {
        #region OnPropertyChenged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region Выбранные параметры
        private NamedItem _selectedMat;
        public NamedItem SelectedMat
        {
            get => _selectedMat;
            set
            {
                if (_selectedMat != value)
                {
                    _selectedMat = value;
                    detal.SelectedMat = value;
                    OnPropertyChanged();
                }
            }
        }
        public static Detal detal;
        #endregion
        #region Коллекции
        private ObservableCollection<NamedItem> _mats;
        public ObservableCollection<NamedItem> Mats
        {
            get => _mats;
            set
            {
                _mats = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ChtototamsSDetal> ChtototamsSDetals
        {
            get => detal.ChtototamsSDetals;
            set
            {
                detal.ChtototamsSDetals = value;
                //TreeViewItem.IsExpanded = true;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Detal> Detals { get; set; } = new ObservableCollection<Detal>() { Detal.Instance };
        #endregion
        #region Всякие войды (Тут основная залупа)
        public void OpenWinForHole(Hole hole) //Вызов окна редактирования выбранного отверстия
        {
            foreach (var item in detal.ChtototamsSDetals)
            {
                item.window.Close();
                if (item is Hole h)
                {
                    foreach (Operation op in h.Operations)
                    {
                        op.window.Close();
                    }
                }
            }
            hole.window.Show();
        }
        public void OpenWinForPerem(Perem1 perem) //Вызов окна редактирования выбранного отверстия
        {
            foreach (var item in detal.ChtototamsSDetals)
            {
                item.window.Close();
                if (item is Hole h)
                {
                    foreach (Operation op in h.Operations)
                    {
                        op.window.Close();
                    }
                }
            }
            perem.window.Show();
        }
        public void OpenWinForOper(Operation op)
        {
            foreach (Perem1 perem in detal.ChtototamsSDetals.OfType<Perem1>())
            {
                perem.window.Close();
            }
            foreach (Hole hole in detal.ChtototamsSDetals.OfType<Hole>())
            {
                hole.window.Close();
                foreach (Operation oper in hole.Operations)
                {
                    oper.window.Close();
                }
            }
            op.window.Show();
            if (op.window.DataContext is OperViewModelBase opVMB)
            {
                opVMB.Hole.window.Show();
            }
        } // Открытие окна операции. Выбор окна в ContMenuForHole, хуйня, обработчик кликов. Потом переебать обработчики
        public void ContMenuForHole(UIElement target, TreeViewOPViewModel vm) //Набивка ContextMenu для отверстий
        {
            ContextMenu menu = new ContextMenu();
            #region Хуйня с контекстменю для доб опер 
                MenuItem DobOper = new MenuItem { Header = "Добавить операцию" };
                #region Операции
                    MenuItem OpSverl = new MenuItem { Header = "Сверление" };
                    MenuItem OpRassverl = new MenuItem { Header = "Рассверливание" };
                    MenuItem OpZenker = new MenuItem { Header = "Зенкерование" };
                    MenuItem OpRazv = new MenuItem { Header = "Развертывание" };
                    MenuItem OpRazvKon = new MenuItem { Header = "Развертывание коническое" };
                    MenuItem OpRezb = new MenuItem { Header = "Нарезание резьбы" };
                #endregion
            menu.Items.Add(DobOper);
                #region Добавление операций
                    DobOper.Items.Add(OpSverl);
                    DobOper.Items.Add(OpRassverl);
                    DobOper.Items.Add(OpZenker);
                    DobOper.Items.Add(OpRazv);
                    DobOper.Items.Add(OpRazvKon);
                    DobOper.Items.Add(OpRezb);
                #endregion
                #region Обработчики кликов по операциям (Создание операций и привязка окон и вьюмоделов)
                    OpSverl.Click += (s, args) =>
                       {
                           if ((target as FrameworkElement)?.DataContext is Hole hole)
                           {
                               var win = new View.Operacii.Sverl();
                               var Oper = new Operation { Name = "Сверление", window = win };
                               hole.Operations.Add(Oper);
                               var vm = new ViewModel.OperaciiViewModel.SverlViewModel(hole,Oper);                   
                               win.DataContext = vm;
                               win.Owner = Application.Current.MainWindow;
                           }
                       };
                    OpRassverl.Click += (s, args) =>
                    {
                        if ((target as FrameworkElement)?.DataContext is Hole hole)
                        {
                            var win = new View.Operacii.Rassverl();
                            var Oper = new Operation { Name = "Рассверливание", window = win };
                            hole.Operations.Add(Oper);
                            var vm = new ViewModel.OperaciiViewModel.RassverlViewModel(hole, Oper);
                            win.DataContext = vm;
                            win.Owner = Application.Current.MainWindow;
                        }
                    }; 
                    OpZenker.Click += (s, args) =>
                    {
                        if ((target as FrameworkElement)?.DataContext is Hole hole)
                        {
                            var win = new View.Operacii.Zenker();
                            var Oper = new Operation { Name = "Зенкерование", window = win };
                            hole.Operations.Add(Oper);
                            var vm = new ViewModel.OperaciiViewModel.ZenkerViewModel(hole, Oper, 0);
                            win.DataContext = vm;
                            win.Owner = Application.Current.MainWindow;
                        }
                    }; 
                    OpRazv.Click += (s, args) =>
                    {
                        if ((target as FrameworkElement)?.DataContext is Hole hole)
                        {
                            var win = new View.Operacii.Razv();
                            var Oper = new Operation { Name = "Развертывание", window = win };
                            hole.Operations.Add(Oper);
                            var vm = new ViewModel.OperaciiViewModel.RazvViewModel(hole, Oper,0);
                            win.DataContext = vm;
                            win.Owner = Application.Current.MainWindow;
                        }
                    };
                    OpRazvKon.Click += (s, args) =>
                    {
                        if ((target as FrameworkElement)?.DataContext is Hole hole)
                        {
                            var win = new View.Operacii.RazvKon();
                            var Oper = new Operation { Name = "Развертывание коническое", window = win };
                            hole.Operations.Add(Oper);
                            var vm = new ViewModel.OperaciiViewModel.RazvKonViewModel(hole, Oper, 0);
                            win.DataContext = vm;
                            win.Owner = Application.Current.MainWindow;
                        }
                    };
                    OpRezb.Click += (s, args) =>
                    {
                        if ((target as FrameworkElement)?.DataContext is Hole hole)
                        {
                            var win = new View.Operacii.Rezb();
                            var Oper = new Operation { Name = "Нарезание резьбы", window = win };
                            hole.Operations.Add(Oper);
                            var vm = new ViewModel.OperaciiViewModel.RezbViewModel(hole, Oper, 0);
                            win.DataContext = vm;
                            win.Owner = Application.Current.MainWindow;
                        }
                    };
            #endregion
            #endregion
            #region Удаление отверстия
            MenuItem DelHole = new MenuItem { Header = "Удалить" };
                menu.Items.Add(DelHole);
                DelHole.Click += (s, args) =>
                {
                    if ((target as FrameworkElement)?.DataContext is Hole hole)
                    {
                        vm.ChtototamsSDetals.Remove(hole);
                    }
                };
            #endregion

            menu.PlacementTarget = target;
            menu.Placement = System.Windows.Controls.Primitives.PlacementMode.MousePoint;
            menu.IsOpen = true;
        }
        public void ContMenuForOper(UIElement target, TreeViewOPViewModel vm, Hole hole)  //Набивка ContextMenu для операций
        {
            ContextMenu menu = new ContextMenu();
            #region Удаление операции
                MenuItem DelOper = new MenuItem { Header = "Удалить" };
                menu.Items.Add(DelOper);
                DelOper.Click += (s, args) =>
                {
                    if ((target as FrameworkElement)?.DataContext is Operation Oper)
                    {
                        hole.Operations.Remove(Oper);
                    }
                };
            #endregion

            menu.PlacementTarget = target;
            menu.Placement = System.Windows.Controls.Primitives.PlacementMode.MousePoint;
            menu.IsOpen = true;
        }
        public void DobHole()
        {
            Helpers.ВсякаяХуйня.Detal.Instance.Otverstiya++;
            var win = new View.OtvParams();
            var hole = new Hole { Name = $"Отверстие тип {Detal.Instance.Otverstiya}", window = win };
            detal.ChtototamsSDetals.Add(hole);
            var vm = new ViewModel.OtvParamsViewModel(hole);
            hole.window.DataContext = vm;
            win.Owner = Application.Current.MainWindow;
        } // +1 к счетчику отверстий, создание отверстия окна для него и вьюмодела 
        public void OpenWinForPerem()
        {
            foreach (Perem1 perem in detal.ChtototamsSDetals.OfType<Perem1>())
            {
                perem.window.Close();
            }
            foreach (Hole hole in detal.ChtototamsSDetals.OfType<Hole>())
            {
                hole.window.Close();
                foreach (Operation oper in hole.Operations)
                {
                    oper.window.Close();
                }
            }
            WinForPartDet.Show();
        }
        #endregion
        #region Разное
        public ICommand OpenPartDet { get; }
        public ICommand command { get; }
        public Window WinForPartDet;
        #endregion
        public TreeViewOPViewModel()   // конструктор
        {
            detal = Detal.Instance;
            Mats = new ObservableCollection<NamedItem>   
            {
                new NamedItem{ Text = "Чугун" },
                new NamedItem{ Text = "Сталь углеродистая" },
                new NamedItem{ Text = "Сталь коррозионностойкая" },
                new NamedItem{ Text = "Алюминиевые сплавы" },
                new NamedItem{ Text = "Медные сплавы" },
            };// Заполнение коллекции материалов детали
            command = new RelayCommand(o => DobHole());
            OpenPartDet = new RelayCommand(o => OpenWinForPerem()); 
            ChtototamsSDetals = new ObservableCollection<ChtototamsSDetal> { }; // Создание коллекции отверстий
            SelectedMat = Mats[0];
        }        
    }
}
