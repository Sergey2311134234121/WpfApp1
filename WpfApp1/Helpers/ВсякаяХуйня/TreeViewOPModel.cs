using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using WpfApp1.ViewModel.OperaciiViewModel;
using System.Windows.Data;

namespace WpfApp1.Helpers.ВсякаяХуйня
{
    public abstract class ChtototamsSDetal
    {
        public Window window;
    }
    public class VspmOper : INotifyPropertyChanged
    {
        #region OnPropertyChenged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
    public class Operation : INotifyPropertyChanged
    {
        #region OnPropertyChenged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public Window window;
        private double _vr;
        public double Vr
        {
            get => _vr;
            set
            {
                _vr = value;
                VrChanged?.Invoke(null, EventArgs.Empty);
                OnPropertyChanged();
            }
        }
        public static event EventHandler VrChanged;
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public int IndexPoMarshrutu { get; set; }
        private double _glubRez;
        public double GlubRez
        {
            get => _glubRez;
            set
            {
                _glubRez = value;
                OnPropertyChanged();
                if (window.DataContext is OperViewModelBase opVMB)
                    OnPropertyChanged(nameof(opVMB.VR));
            }
        }
        private double _maxGlub;
        public double MaxGlub 
        {
            get => _maxGlub;
            set
            {
                _maxGlub = value;
                OnPropertyChanged();
                MaxGlubChanged?.Invoke(null, EventArgs.Empty);
            }
        }
        public static event EventHandler MaxGlubChanged;
    }
    public class Hole : ChtototamsSDetal, INotifyPropertyChanged
    {
        #region OnPropertyChenged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        private int _kolvoOtv;
        public int KolvoOtv
        {
            get => _kolvoOtv;
            set
            {
                _kolvoOtv = value;
                OnPropertyChanged(nameof(KolvoOtv));
            }
        }
        public string Name { get; set; }
        private double _vrEd;
        public double VREd { get; set; }
        private NamedItem _tipOtv;
        public NamedItem TipOtv
        {
            get => _tipOtv;
            set
            {
                _tipOtv = value;
                OnPropertyChanged(nameof(TipOtv));
            }
        }
        private double _glubObsh;
        public double GlubObsh
        {
            get => _glubObsh;
            set
            {
                _glubObsh = value;
                GlubObshChanged?.Invoke(null, EventArgs.Empty);
                OnPropertyChanged(nameof(GlubObsh));
            }
        }
        public static event EventHandler? GlubObshChanged;
        public ObservableCollection<Operation> Operations { get; set; } = new();
    }
    public class Detal : INotifyPropertyChanged
    {
        #region OnPropertyChenged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        private static Detal _instance;
        public static Detal Instance => _instance ??= new Detal();
        private Detal()
        {

        }
        public ObservableCollection<ChtototamsSDetal> ChtototamsSDetals { get; set; } = new();
        private NamedItem _selectedMat;
        public NamedItem SelectedMat
        {
            get => _selectedMat;
            set
            {
                _selectedMat = value;
                SelectedMatChanged?.Invoke(null, EventArgs.Empty);
            }
        }
        private int _otverstiya;
        public int Otverstiya
        {
            get => _otverstiya;
            set
            {
                _otverstiya = value;
            }
        }
        public static event EventHandler? SelectedMatChanged;
    }
    public class Perem1 : ChtototamsSDetal, INotifyPropertyChanged
    {
        #region OnPropertyChenged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public string Name { get; set; }
        public double VrPerem { get; set; }
        public ObservableCollection<VspmOper> VspmOpers { get; set; } = new();
    }
}
