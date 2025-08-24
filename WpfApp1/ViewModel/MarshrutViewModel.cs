using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Helpers;
using WpfApp1.Helpers.ВсякаяХуйня;
using System.Windows.Input;
using System.Diagnostics;
using WpfApp1.ViewModel.OperaciiViewModel;

namespace WpfApp1.ViewModel
{
    public class MarshrutViewModel : INotifyPropertyChanged
    {
        #region OnPropertyChenged
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        #endregion
        #region Коллекции для комбобоксов
        private ObservableCollection<NamedItem> _shers;
        public ObservableCollection<NamedItem> Shers
        {
            get => _shers;
            set
            {
                _shers = value;
                OnPropertyChanged(nameof(Shers));
            }
        }
        private ObservableCollection<int> _kvals;
        public ObservableCollection<int> Kvals
        {
            get => _kvals;
            set
            {
                _kvals = value;
            }
        }
        #endregion
        #region Выбранные параметры
        private NamedItem _sher;
        public NamedItem Sher
        {
            get => _sher;
            set
            {
                _sher = value;
                OnPropertyChanged(nameof(Sher));
                if (_sher?.Text == "Rz 80 - 40")
                {
                    Kvals = new ObservableCollection<int> { 13, 12 };
                }
                else if (_sher?.Text == "Rz 40 - 20")
                {
                    Kvals = new ObservableCollection<int> { 12, 11 };
                }
                else if (_sher?.Text == "Ra 5,0 - 3,2")
                {
                    Kvals = new ObservableCollection<int> { 8 };
                    Kval = Kvals.ElementAtOrDefault(1);
                }
                else if (_sher?.Text == "Ra 2,5 - 1,6")
                {
                    Kvals = new ObservableCollection<int> { 11, 8, 7 };
                }
                else if (_sher?.Text == "Ra 1,25 - 0,8")
                {
                    Kvals = new ObservableCollection<int> { 8, 7 };
                }
                else
                {
                    Kvals = null;
                }
                OnPropertyChanged(nameof(Kvals));
            }
        }

        private int _kval;
        public int Kval
        {
            get => _kval;
            set
            {
                _kval = value;
                OnPropertyChanged(nameof(Kval));
            }
        }
        private double _diam;
        public double Diam
        {
            get => _diam;
            set
            {
                _diam = value;
                OnPropertyChanged(nameof(Diam));
            }
        } 
        #endregion
        #region Методы для добавления операций для построения маршрута
        private void sverl()
        {
            var win = new View.Operacii.Sverl();
            var Oper = new Operation { Name = "Сверление", window = win, IndexPoMarshrutu = 1 };
            Hole.Operations.Add(Oper);
            var vm = new ViewModel.OperaciiViewModel.SverlViewModel(Hole, Oper);
            win.DataContext = vm;
            win.Owner = Application.Current.MainWindow;
        }
        public void rassverl()
        {
            var win = new View.Operacii.Rassverl();
            var Oper = new Operation { Name = "Рассверливание", window = win, IndexPoMarshrutu = 2 };
            Hole.Operations.Add(Oper);
            var vm = new ViewModel.OperaciiViewModel.RassverlViewModel(Hole, Oper);
            win.DataContext = vm;
            win.Owner = Application.Current.MainWindow;
        }
        private void zenk(string name, int Index, int kval)
        {
            var win = new View.Operacii.Zenker();
            var Oper = new Operation { Name = name, window = win, IndexPoMarshrutu = Index };
            Hole.Operations.Add(Oper);
            var vm = new ViewModel.OperaciiViewModel.ZenkerViewModel(Hole, Oper, kval);
            win.DataContext = vm;
            win.Owner = Application.Current.MainWindow;
        }
        private void razv(string name, int Index, int i)
        {
            var win = new View.Operacii.Razv();
            var Oper = new Operation { Name = name, window = win, IndexPoMarshrutu = Index };
            Hole.Operations.Add(Oper);
            var vm = new ViewModel.OperaciiViewModel.RazvViewModel(Hole, Oper,i);
            win.DataContext = vm;
            win.Owner = Application.Current.MainWindow;
        }
        #endregion
        #region Разное
        public Hole Hole { get; set; }
        public ICommand command { get; set; }
        bool Bool = false;
        #endregion
        public ICommand delmarshrut { get; set; }
        public void delMarshr()
        {
            var opers = new ObservableCollection<Operation>();
            foreach (Operation op in Hole.Operations)
            {
                if (op.IndexPoMarshrutu > 0)
                {
                    opers.Add(op);
                    //Hole.Operations.Remove(op);
                }
            }
            foreach (Operation op in opers)
            {
                Hole.Operations.Remove(op);
            }
            if (Bool == true)
            {
                Bool = false;
            }
            if (Hole.window.DataContext is OtvParamsViewModel Otvvm)
            {
                Otvvm.VrEd = 0;
                Otvvm.VrVsego = 0;
            }
        }
        public void Marshruts()
        {
            #region Определение индексов параметров для подбора глубин резания
            int[] Diams = new int[] { 4, 6, 8, 10, 12, 16, 20, 25, 30, 40, 50, 60, 70, 80};
            int DiamIndex()
            {
                for (int i = 0; i < Diams.Length; i++)
                {
                    if (Diam < Diams[i])
                    {
                        return i;
                    }
                }

                return -1;
            }
            int KvalIndex()
            {
                if (Kval == 7)
                    return 0;
                else if (Kval == 8)
                    return 1;
                else return 2;
            }
            #endregion
            var key = (Kval, Sher.Text);
            int sum = 0;
            foreach (Operation op in Hole.Operations)
            {               
                if (Bool == true && op.IndexPoMarshrutu != 0)
                {
                    sum += 1;
                }
            }
            if (sum == 0)
            {
                Bool = false;
            }
            if (Bool == false)
            {
                #region Подбор операций
                if (Diam > 0 && Diam <= 10)
                {
                    switch (key)
                    {
                        case (13, "Rz 80 - 40"):
                            sverl();
                            break;
                        case (12, "Rz 80 - 40"):
                            {
                                if (Detal.Instance.SelectedMat.Text == "Чугун")
                                {
                                    sverl();
                                    zenk("Зенкерование чистовое", 2, 0);
                                    break;
                                }
                                else
                                {
                                    sverl();
                                    break;
                                }
                                break;
                            }
                        case (12, "Rz 40 - 20"):
                            sverl();
                            zenk("Зенкерование чистовое", 2, 0);
                            break;
                        case (11, "Rz 40 - 20"):
                            sverl();
                            zenk("Зенкерование чистовое", 2, 1);
                            break;
                        case (11, "Ra 2,5 - 1,6"):
                            sverl();
                            zenk("Зенкерование чистовое", 2, 1);
                            break;
                        case (8, "Ra 5,0 - 3,2"):
                            sverl();
                            razv("Развертывание", 2, 0);
                            break;
                        case (8, "Ra 2,5 - 1,6"):
                            sverl();
                            razv("Развертывание", 2, 0);
                            break;
                        case (8, "Ra 1,25 - 0,8"):
                            sverl();
                            razv("Развертывание чистовое", 2, 0);
                            break;
                        case (7, "Ra 2,5 - 1,6"):
                            sverl();
                            razv("Развертывание чистовое", 2, 1);
                            break;
                        case (7, "Ra 1,25 - 0,8"):
                            sverl();
                            razv("Развертывание чистовое", 2, 1);
                            break;
                    }
                }
                else if (Diam > 10 && Diam <= 30)
                {
                    switch (key)
                    {
                        case (13, "Rz 80 - 40"):
                            sverl();
                            break;
                        case (12, "Rz 80 - 40"):
                            sverl();
                            zenk("Зенкерование чистовое", 2, 0);
                            break;
                        case (12, "Rz 40 - 20"):
                            sverl();
                            zenk("Зенкерование чистовое", 2, 0);
                            break;
                        case (11, "Rz 40 - 20"):
                            sverl();
                            zenk("Зенкерование чистовое", 2, 1);
                            break;
                        case (11, "Ra 2,5 - 1,6"):
                            sverl();
                            zenk("Зенкерование чистовое", 2, 1);
                            break;
                        case (8, "Ra 5,0 - 3,2"):
                            sverl();
                            zenk("Зенкерование", 2, 0);
                            razv("Развертывание", 3, 0);
                            break;
                        case (8, "Ra 2,5 - 1,6"):
                            sverl();
                            zenk("Зенкерование", 2, 0);
                            razv("Развертывание", 3, 0);
                            break;
                        case (8, "Ra 1,25 - 0,8"):
                            sverl();
                            zenk("Зенкерование", 2, 0);
                            razv("Развертывание", 3, 0);
                            razv("Развертывание чистовое", 4, 0);
                            break;
                        case (7, "Ra 2,5 - 1,6"):
                            sverl();
                            zenk("Зенкерование", 2, 0);
                            razv("Развертывание", 3, 0);
                            razv("Развертывание чистовое", 4, 1);
                            break;
                        case (7, "Ra 1,25 - 0,8"):
                            sverl();
                            zenk("Зенкерование", 2, 0);
                            razv("Развертывание", 3, 0);
                            razv("Развертывание чистовое", 4, 1);
                            break;
                    }
                }
                else if (Diam > 30 && Diam <= 50)
                {
                    switch (key)
                    {
                        case (13, "Rz 80 - 40"):
                            sverl();
                            rassverl();
                            break;
                        case (12, "Rz 80 - 40"):
                            {
                                if (Detal.Instance.SelectedMat.Text == "Чугун")
                                {
                                    sverl();
                                    rassverl();
                                    zenk("Зенкерование чистовое", 3, 0);
                                    break;
                                }
                                else
                                    sverl();
                                rassverl();
                                break;
                                break;
                            }
                        case (12, "Rz 40 - 20"):
                            sverl();
                            rassverl();
                            zenk("Зенкерование чистовое", 3, 0);
                            break;
                        case (11, "Rz 40 - 20"):
                            sverl();
                            rassverl();
                            zenk("Зенкерование чистовое", 3, 1);
                            break;
                        case (11, "Ra 2,5 - 1,6"):
                            sverl();
                            rassverl();
                            zenk("Зенкерование чистовое", 3, 1);
                            break;
                        case (8, "Ra 5,0 - 3,2"):
                            sverl();
                            rassverl();
                            zenk("Зенкерование", 3, 0);
                            razv("Развертывание", 4, 0);
                            break;
                        case (8, "Ra 2,5 - 1,6"):
                            sverl();
                            rassverl();
                            zenk("Зенкерование", 3, 0);
                            razv("Развертывание чистовое", 4, 0);
                            break;
                        case (8, "Ra 1,25 - 0,8"):
                            sverl();
                            rassverl();
                            zenk("Зенкерование", 3, 0);
                            razv("Развертывание", 4, 0);
                            razv("Развертывание чистовое", 5, 0);
                            break;
                        case (7, "Ra 2,5 - 1,6"):
                            sverl();
                            rassverl();
                            zenk("Зенкерование", 3, 0);
                            razv("Развертывание", 4, 0);
                            razv("Развертывание чистовое", 5, 1);
                            break;
                        case (7, "Ra 1,25 - 0,8"):
                            sverl();
                            rassverl();
                            zenk("Зенкерование", 3, 0);
                            razv("Развертывание", 4, 0);
                            razv("Развертывание чистовое", 5, 1);
                            break;
                    }
                }
                else if (Diam > 50 && Diam <= 80)
                {
                    switch (key)
                    {
                        case (13, "Rz 80 - 40"):
                            zenk("Зенкерование", 1, 0);
                            zenk("Зенкерование чистовое", 2, 0);
                            break;
                        case (12, "Rz 80 - 40"):
                            zenk("Зенкерование", 1, 0);
                            zenk("Зенкерование чистовое", 2, 0);
                            break;
                        case (12, "Rz 40 - 20"):
                            zenk("Зенкерование", 1, 0);
                            zenk("Зенкерование чистовое", 2, 0);
                            break;
                        case (11, "Rz 40 - 20"):
                            zenk("Зенкерование", 1, 0);
                            zenk("Зенкерование чистовое", 2, 1);
                            break;
                        case (11, "Ra 2,5 - 1,6"):
                            zenk("Зенкерование", 1, 0);
                            zenk("Зенкерование чистовое", 2, 1);
                            break;
                        case (8, "Ra 5,0 - 3,2"):
                            zenk("Зенкерование", 1, 0);
                            zenk("Зенкерование чистовое", 2, 1);
                            razv("Развертывание", 3, 0);
                            razv("Развертывание чистовое", 4, 0);
                            break;
                        case (8, "Ra 2,5 - 1,6"):
                            zenk("Зенкерование", 1, 0);
                            zenk("Зенкерование чистовое", 2, 1);
                            razv("Развертывание", 3, 0);
                            razv("Развертывание чистовое", 4, 0);
                            break;
                        case (8, "Ra 1,25 - 0,8"):
                            zenk("Зенкерование", 1, 0);
                            zenk("Зенкерование чистовое", 2, 1);
                            razv("Развертывание", 3, 0);
                            razv("Развертывание чистовое", 4, 0);
                            break;
                        case (7, "Ra 2,5 - 1,6"):
                            zenk("Зенкерование", 1, 0);
                            zenk("Зенкерование чистовое", 2, 1);
                            razv("Развертывание", 3, 0);
                            razv("Развертывание чистовое", 4, 1);
                            break;
                        case (7, "Ra 1,25 - 0,8"):
                            zenk("Зенкерование", 1, 0);
                            zenk("Зенкерование чистовое", 2, 1);
                            razv("Развертывание", 3, 0);
                            razv("Развертывание чистовое", 4, 1);
                            break;
                    }
                }
                #endregion
                #region Подбор глубины резания и диаметров 
                var maxOp = Hole.Operations.OrderByDescending(op => op.IndexPoMarshrutu).FirstOrDefault();
                double DiamOp = Diam;
                for (int i = maxOp.IndexPoMarshrutu; i > 0; i--)
                {
                    var op = Hole.Operations.FirstOrDefault(o => o.IndexPoMarshrutu == i);
                    if (op.Name == "Развертывание чистовое")
                    {
                        if (op.window.DataContext is OperViewModelBase baseVm)
                        {
                            baseVm.Diam = DiamOp;
                        }
                        double[] RazvChistGlubsRez = new double[] { 0.05, 0.1, 0.1, 0.02, 0.025, 0.025, 0.03, 0.03, 0.04, 0.035, 0.04, 0.04, 0.05, 0.05 };
                        op.GlubRez = RazvChistGlubsRez[DiamIndex()];
                        DiamOp -= op.GlubRez;
                    }
                    else if (op.Name == "Развертывание")
                    {
                        if (op.window.DataContext is OperViewModelBase baseVm)
                        {
                            baseVm.Diam = DiamOp;
                        }
                        double[] RazvGlubRez = new double[] { 0.05, 0.05, 0.1, 0.1, 0.1, 0.1, 0.08, 0.1, 0.08, 0.05, 0.08, 0.05, 0.09, 0.06, 0.09, 0.06, 0.08, 0.06, 0.11, 0.07, 0.11, 0.07, 0.21, 0.21, 0.2, 0.2, 0.2, 0.2 };
                        op.GlubRez = RazvGlubRez[DiamIndex() * 2 + KvalIndex()];
                        DiamOp -= op.GlubRez;
                    }
                    else if (op.Name == "Зенкерование чистовое")
                    {
                        if (op.window.DataContext is OperViewModelBase baseVm)
                        {
                            baseVm.Diam = DiamOp;
                        }
                        if (Diam <= 50)
                        {
                            double[] ZenkChistGlubRez = new double[] { 0.05, 0.1, 0.15, 0.15, 0.65, 0.88, 1.25, 1.25, 1.25, 1.5, 2 };
                            op.GlubRez = ZenkChistGlubRez[DiamIndex()];
                            DiamOp -= op.GlubRez;
                        }
                        else if (Diam > 50)
                        {
                            double[] ZenkChistGlubRez = new double[] { 0.5, 0.7, 1.0, 0.5, 0.7, 1.0, 0.5, 0.7, 1.0 };
                            op.GlubRez = ZenkChistGlubRez[(DiamIndex() - 11) * 3 + KvalIndex()];
                            DiamOp -= op.GlubRez;
                        }
                    }
                    else if (op.Name == "Зенкерование")
                    {
                        if (op.window.DataContext is OperViewModelBase baseVm)
                        {
                            baseVm.Diam = DiamOp;
                        }
                        if (Diam <= 50)
                        {
                            double[] ZenkGlubRez = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0.4, 0.45, 0.4, 0.45, 0.88, 0.94, 0.88, 0.94, 0.87, 0.94, 0.86, 0.92, 0.85, 0.93 };
                            op.GlubRez = ZenkGlubRez[DiamIndex() * 2 + KvalIndex()];
                            DiamOp -= op.GlubRez;
                        }
                        else if (Diam > 50)
                        {
                            double[] ZenkChistGlubRez = new double[] { 4.5, 4.3, 4.0, 4.5, 4.3, 4.0, 4.5, 4.3, 4.0 };
                            op.GlubRez = ZenkChistGlubRez[(DiamIndex() - 11) * 3 + KvalIndex()];
                            DiamOp -= op.GlubRez;
                        }
                    }
                    else if (op.Name == "Рассверливание")
                    {
                        if (op.window.DataContext is OperViewModelBase baseVm)
                        {
                            baseVm.Diam = DiamOp;
                        }
                        op.GlubRez = DiamOp - 25;
                    }
                    else if (op.Name == "Сверление")
                    {
                        if (op.window.DataContext is OperViewModelBase baseVm)
                        {
                            if (DiamIndex() > 8)
                            {
                                baseVm.Diam = 25;
                            }
                            else
                            {
                                baseVm.Diam = DiamOp;
                            }
                        }

                    }
                }
                #endregion


                Bool = true;
            }
            else
                MessageBox.Show("Небходимо удалить предыдущий маршрут");
        } // Нужно сделать изменение маршрута при изменении материала( при измениение с чугуна на другой и наоборот), добавить удаление маршрута и добавить маршрут при отлитом отверстии( от 30 до 80 )
        public MarshrutViewModel(Hole hole)
        {
            Shers = new ObservableCollection<NamedItem>
            {
                new NamedItem {Text = "Rz 80 - 40"},
                new NamedItem {Text = "Rz 40 - 20"},
                new NamedItem {Text = "Ra 5,0 - 3,2"},
                new NamedItem {Text = "Ra 2,5 - 1,6"},
                new NamedItem {Text = "Ra 1,25 - 0,8"}
            };
            Hole = hole;
            command = new RelayCommand(o => Marshruts());
            delmarshrut = new RelayCommand(o => delMarshr());
        }      
    }
}
