using System;
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

namespace WpfApp1.ViewModel.OperaciiViewModel
{
    public abstract class OperViewModelBase : INotifyPropertyChanged
    {
        #region OnPropertyChenged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region Коллекции
        public ObservableCollection<NamedItem> _nameditemMatsInstrs;
        public ObservableCollection<NamedItem> NameditemMatsInstrs // коллекция материалов инструмента в зависимости от материала детали
        {
            get => _nameditemMatsInstrs;
            set
            {
                _nameditemMatsInstrs = value;
            }
        }
        private ObservableCollection<UslStr> _forDataGrid;
        public ObservableCollection<UslStr> ForDataGrid 
        {
            get => _forDataGrid;
            set
            {
                _forDataGrid = value;
                OnPropertyChanged(nameof(VR));
            }
        } // коллекция строк для датагрида. Задается  в UpdataeForDataGrid в наследниках
        #endregion
        #region ВыбранныеХарактеристики
        protected NamedItem _selectedMat;
        public abstract NamedItem SelectedMat { get; set; } // сюда передается выбранный материал из тривью
        protected NamedItem _selectedMatInstr;
        public NamedItem SelectedMatInstr
        {

            get => _selectedMatInstr;
            set
            {
                if (_selectedMat != value)
                {
                    _selectedMatInstr = value;
                    OnPropertyChanged(nameof(SelectedMatInstr));
                    UpdataeForDataGrid();
                    OnPropertyChanged(nameof(VR));
                }
            }
        } // выбранный материал инструмента
        protected NamedItem _selectedTipOtverst;
        public NamedItem SelectedTipOtverst
        {
            get => _selectedTipOtverst;
            set
            {
                _selectedTipOtverst = value;
                if (_selectedTipOtverst != null)
                {
                    if (SelectedTipOtverst.Text == "Глухое")
                    {
                        KoefTipOtv = 1.1;
                        DopVremPoGluhOtv = 0.2;
                    }
                    else if (SelectedTipOtverst.Text == "Сквозное")
                    {
                        KoefTipOtv = 1;
                        DopVremPoGluhOtv = 0;
                    }
                }
                OnPropertyChanged(nameof(SelectedTipOtverst));
                OnPropertyChanged(nameof(KoefTipOtv));
                OnPropertyChanged(nameof(DopVremPoGluhOtv));
                OnPropertyChanged(nameof(VR));
            }
        }    // Сюда передается тип отверстия (глухое или сквозное) из окна отверстия
        #endregion
        #region ЧисловыеПеременные
        private double _diam;
        public double Diam
        {
            get => _diam;
            set
            {
                _diam = value;
                OnPropertyChanged(nameof(Diam));
                OnPropertyChanged(nameof(ContextForLabel));
                UpdataeForDataGrid();
                OnPropertyChanged(nameof(VR));
            }
        }
        private double _glub;
        public double Glub
        {
            get => _glub;
            set
            {
                _glub = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(VR));
            }
        }
        private int _kolvoOtv;
        public int KolvoOtv
        {
            get => _kolvoOtv;
            set
            {
                _kolvoOtv = value;
                if (KolvoOtv > 0 && KolvoOtv <= 3)
                {
                    KoefOtv = 1;
                }
                else if (KolvoOtv > 3 && KolvoOtv <= 10)
                {
                    KoefOtv = 0.9;
                }
                else if (KolvoOtv > 10)
                {
                    KoefOtv = 0.85;
                }
                OnPropertyChanged(nameof(KolvoOtv));
                OnPropertyChanged(nameof(KoefOtv));
            }
        }     // количество отверстий одного типа (Влияет на коэффициент)
        protected double _vr;
        public abstract double VR { get; }
        protected double _maxGlub;
        public abstract double MaxGlub { get; }
        private double _itogKoef;
        public double ItogKoef
        {
            get
            {
                if (ForDataGrid != null)
                {
                    double n = 1;
                    foreach (var item in ForDataGrid)
                    {
                        n *= item.SelectedUslParams.Koef;
                    }
                    return n;
                }
                else
                    return 1;
            }
            set
            {
                _itogKoef = value;
                OnPropertyChanged(nameof(VR));
            }
        }
        public double DopVremPoGluhOtv;        // Доп время для выверки глубины глухого отверстия
        private double _koefTipOtv;
        public double KoefTipOtv
        {
            get => _koefTipOtv;
            set
            {
                _koefTipOtv = value;
                OnPropertyChanged();
            }
        }
        private double _koefOtv;
        public double KoefOtv
        {
            get => _koefOtv;
            set
            {
                _koefOtv = value;
                OnPropertyChanged();
            }
        }  // Коэф по количеству отверстий одного типа
        #endregion
        #region Команды
        public void raschVr()
        {
            OnPropertyChanged(nameof(VR));
        }  // просто обновляет VR при изменении вводных
        public ICommand Rasch { get; }
        public ICommand MyClickCommand { get; }
        #endregion
        #region Разное
        protected abstract void UpdataeForDataGrid();
        public Hole Hole;
        public Operation Oper { get; set; }
        public event PropertyChangedEventHandler ForDataGridChanged;
        private string _contextForLabel;
        public string ContextForLabel 
        { 
            get
            {
                if (MaxGlub > 0)
                {
                    return $"Глубина обработки \n (макс.{MaxGlub}мм)";
                }
                else
                    return "Глубина обработки \n (макс. 300 мм)";
            }
        }
        #endregion
        public OperViewModelBase(Hole hole, Operation oper)
        {
            Hole = hole;
            Oper = oper;
            SelectedTipOtverst = Hole.TipOtv;
            Rasch = new RelayCommand(o => raschVr());
            Detal.SelectedMatChanged += (s, e) =>
            {
                SelectedMat = Detal.Instance.SelectedMat;
            };
            SelectedMat = Detal.Instance.SelectedMat;
            Hole.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(Hole.TipOtv))
                    SelectedTipOtverst = Hole.TipOtv;
            };
            SelectedTipOtverst = Hole.TipOtv;
            Hole.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(Hole.KolvoOtv))
                {
                    KolvoOtv = Hole.KolvoOtv;
                }
            };
            KolvoOtv = Hole.KolvoOtv;
            Hole.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(Hole.GlubObsh))
                    Glub = Hole.GlubObsh;
            };
            Glub = Hole.GlubObsh;
            SelectedMatInstr = NameditemMatsInstrs[0];
        }
    }
}
