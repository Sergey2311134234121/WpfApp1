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
using WpfApp1.ViewModel.OperaciiViewModel;

namespace WpfApp1.ViewModel
{
    internal class OtvParamsViewModel : INotifyPropertyChanged
    {
        #region OnPropertyChenged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public double chtota = 300;
        private double _maxGlub;
        public double MaxGlub
        {
            get
            {
                foreach (var Oper in Hole.Operations)
                {
                    if (Oper.MaxGlub > 0 & chtota > Oper.MaxGlub)
                    {
                        chtota = Oper.MaxGlub;
                    }
                }
                return chtota;
            }
        }
        public string ContextForLabel
        {
            get
            {
                if (MaxGlub > 0)
                {
                    return $"Глубина обработки \n(Для всех операций)\n (макс.{MaxGlub}мм)";
                }
                else
                    return "Глубина обработки \n(Для всех операций)\n (макс. 300 мм)";
            }
        }
        public Hole Hole { get; set; }
        public ObservableCollection<NamedItem> Tips { get; set; }
        private NamedItem _tip;
        public NamedItem Tip
        {
            get => _tip;
            set
            {
                _tip = value;
                Hole.TipOtv = value;    
            }
        }
        private int _kolvoOtv;
        public int KolvoOtv
        {
            get => _kolvoOtv;
            set
            {
                _kolvoOtv = value;
                Hole.KolvoOtv = value;
                OnPropertyChanged(nameof(VrVsego));
                foreach(Operation op in Hole.Operations)
                {
                    if (op.window.DataContext is OperViewModelBase opVM)
                    {
                        opVM.raschVr();
                    }
                }
            }
        }
        private double _vrEd;
        public double VrEd
        {
            get
            {
                return _vrEd;
            }
            set
            {
                _vrEd = value;
                Debug.WriteLine($"_vrEd{_vrEd}");
                OnPropertyChanged();
                OnPropertyChanged(nameof(VrVsego));
            }
        }     
        public double _vrVsego;
        public double VrVsego
        {
            get
            {
                var sum = VrEd * KolvoOtv;
                VrVsego = sum;  
                return sum;
            }
            set
            {
                _vrVsego = value;
                VrVsegoChanged?.Invoke(null, EventArgs.Empty);
                Debug.WriteLine($"VrVsego{_vrVsego}");
            }
        }
        public static event EventHandler? VrVsegoChanged;
        public Window _wind;
        public OtvParamsViewModel(Hole hole)
        {
            Hole = hole;    
            Tips = new ObservableCollection<NamedItem> 
            {
                new NamedItem {Text = "Глухое"},
                new NamedItem {Text = "Сквозное"}
            };
            Hole.Operations.CollectionChanged += (s, e) =>
            {
                if (e.NewItems != null)
                {                  
                    Operation.VrChanged += (s2, e2) =>
                    {
                        VrEd = 0;
                        foreach (Operation op in Hole.Operations)
                        {
                            VrEd += op.Vr;
                        }
                        OnPropertyChanged(nameof(VrEd));
                    };
                    Operation.MaxGlubChanged += (s3, e3) =>
                    {
                        OnPropertyChanged(nameof(ContextForLabel));
                    };
                }
            };
            OpenMarsh = new RelayCommand(o => OpMarsh());
            KolvoOtv = 1;
            var win = new View.Marshrut();
            var vm = new ViewModel.MarshrutViewModel(Hole);
            win.DataContext = vm;
            Application.Current.MainWindow.Loaded += (s, e) =>
            {
                win.Owner = Application.Current.MainWindow;
            };
            _wind = win;
            Tip = Tips[1];
        }
        public ICommand OpenMarsh { get; set; }
        public void OpMarsh()
        {
            _wind.Show();
        }
    }
}
