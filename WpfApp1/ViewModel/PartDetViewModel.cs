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
    internal class PartDetViewModel : INotifyPropertyChanged
    {
        #region OnPropertyChenged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public double[][][] vrrMassiv = new double[][][]
        {
            new double [][]
            {
                new double [] {8, 10, 12, 14, 16},
                new double [] {10, 12, 14, 16, 18},
                new double [] {13, 15, 17, 19, 21},
                new double [] {15, 18, 19, 21, 23},
                new double [] {17, 20, 22, 23, 25},
                new double [] {20, 22, 23, 26, 28},
                new double [] {22, 23, 25, 28, 31},
                new double [] {25, 27, 30, 32, 35},
            },
            new double [][]
            {
                new double [] {6, 7, 10, 12, 14},
                new double [] {8, 10, 12, 14, 16},
                new double [] {8, 10, 12, 14, 16},
                new double [] {10, 12, 14, 16, 18},
                new double [] {12, 14, 16, 18, 20},
                new double [] {12, 14, 16, 18, 20},
                new double [] {14, 16, 18, 20, 22},
                new double [] {15, 18, 20, 22, 25},
            },
        };
        private NamedItemForPartDet _dopRabSelectedFromSpis;
        public NamedItemForPartDet DopRabSelectedFromSpis
        {
            get { return _dopRabSelectedFromSpis; }
            set 
            { 
                _dopRabSelectedFromSpis = value;
            }
        }
        private NamedItemForPartDet _dopRabSelectedFromCollection;
        public NamedItemForPartDet DopRabSelectedFromCollection
        {
            get { return _dopRabSelectedFromCollection; }
            set
            {
                _dopRabSelectedFromCollection = value;
            }
        }
        private ObservableCollection<NamedItemForPartDet> _collectionDopRab;
        public ObservableCollection<NamedItemForPartDet> CollectionSpisDopRab
        {
            get { return _collectionDopRab; }
            set 
            { 
                _collectionDopRab = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(VrPart));
            }
        }
        public double vrSpisDopRab()
        {
            double sum = 0;
            if (CollectionSpisDopRab != null)
            {
                foreach ( var Chtoto in CollectionSpisDopRab)
                {
                    sum += Chtoto.VremRab[SelectedNaibDiamIndex];
                }
            }
            return sum;
        }

        private ObservableCollection<NamedItemForPartDet> _spisDopRab;
        public ObservableCollection<NamedItemForPartDet> SpisDopRab
        { 
            get { return _spisDopRab; }
            set { _spisDopRab = value; }
        }
        private NamedItem _selectedZamUstPrisp;
        public NamedItem SelectedZamUstPrisp 
        {
            get
            {
                return _selectedZamUstPrisp;
            }
            set
            {
                _selectedZamUstPrisp = value;
                OnPropertyChanged(nameof(VrPart));
            }
        }
        private ObservableCollection<NamedItem> _zamUstPrisp;
        public ObservableCollection<NamedItem> ZamUstPrisp
        {
            get
            {
                return _zamUstPrisp;
            }
            set
            {
                _zamUstPrisp = value;
            }
        }
        private int _selectedNaibDiam;
        public int SelectedNaibDiam 
        {
            get
            {
                return _selectedNaibDiam;
            }
            set
            {
                _selectedNaibDiam = value;
                OnPropertyChanged(nameof(VrPart));
                if (_selectedNaibDiam !=  0)
                {
                    SpisDopRab.Clear();
                    if (_selectedNaibDiam ==12)
                    {
                        SelectedNaibDiamIndex =0;
                        SpisDopRab.Add(new NamedItemForPartDet { Text = "Установить и снять тиски или патрон" , VremRab = new double[] {1.5, 2.0, 2.0, 2.5, 3.0 } });
                        SpisDopRab.Add(new NamedItemForPartDet { Text = "Установить и снять упор", VremRab = new double[] { 0.8, 1.0, 1.0, 1.2, 1.2 } });
                        SpisDopRab.Add(new NamedItemForPartDet { Text = "Повернуть стол на угол", VremRab = new double[] { 2.0, 2.0, 2.0, 2.0, 2.0 } });
                    }
                    else if (_selectedNaibDiam == 25 )
                    {
                        SelectedNaibDiamIndex = 1;
                        SpisDopRab.Add(new NamedItemForPartDet { Text = "Установить и снять тиски или патрон", VremRab = new double[] { 1.5, 2.0, 2.0, 2.5, 3.0 } });
                        SpisDopRab.Add(new NamedItemForPartDet { Text = "Установить и снять упор" , VremRab = new double[] { 0.8, 1.0, 1.0, 1.2, 1.2 } });
                        SpisDopRab.Add(new NamedItemForPartDet { Text = "Повернуть стол на угол" , VremRab = new double[] { 2.0, 2.0, 2.0, 2.0, 2.0 } });
                        SpisDopRab.Add(new NamedItemForPartDet { Text = "Установить и снять доп. стол" , VremRab = new double[] { 0.0, 4.0, 4.0, 5.0, 5.0 } });
                    }
                    else if (_selectedNaibDiam == 35)
                    {
                        SelectedNaibDiamIndex = 2;
                        SpisDopRab.Add(new NamedItemForPartDet { Text = "Установить и снять тиски или патрон" , VremRab = new double[] { 1.5, 2.0, 2.0, 2.5, 3.0 } });
                        SpisDopRab.Add(new NamedItemForPartDet { Text = "Установить и снять упор"  , VremRab = new double[] { 0.8, 1.0, 1.0, 1.2, 1.2 } });
                        SpisDopRab.Add(new NamedItemForPartDet { Text = "Повернуть стол на угол" , VremRab = new double[] { 2.0, 2.0, 2.0, 2.0, 2.0 } });
                        SpisDopRab.Add(new NamedItemForPartDet { Text = "Установить и снять доп. стол" , VremRab = new double[] { 0.0, 4.0, 4.0, 5.0, 5.0 } });
                    }
                    else if (_selectedNaibDiam ==50)
                    {
                        SelectedNaibDiamIndex = 3;
                        SpisDopRab.Add(new NamedItemForPartDet { Text = "Установить и снять тиски или патрон" , VremRab = new double[] { 1.5, 2.0, 2.0, 2.5, 3.0 } });
                        SpisDopRab.Add(new NamedItemForPartDet { Text = "Установить и снять упор" , VremRab = new double[] { 0.8, 1.0, 1.0, 1.2, 1.2 } });
                        SpisDopRab.Add(new NamedItemForPartDet { Text = "Повернуть стол на угол" , VremRab = new double[] { 2.0, 2.0, 2.0, 2.0, 2.0 } });
                        SpisDopRab.Add(new NamedItemForPartDet { Text = "Установить и снять доп. стол" , VremRab = new double[] { 0.0, 4.0, 4.0, 5.0, 5.0 } });
                        SpisDopRab.Add(new NamedItemForPartDet { Text = "Установить и снять многошпиндельную головку" , VremRab = new double[] { 0.0, 0.0, 0.0, 25.0, 25.0 } });
                        SpisDopRab.Add(new NamedItemForPartDet { Text = "Подготовить яму для работы" , VremRab = new double[] { 0.0, 0.0, 0.0, 3.0, 3.0 } });
                    }
                    else if (_selectedNaibDiam == 80)
                    {
                        SelectedNaibDiamIndex = 4;
                        SpisDopRab.Add(new NamedItemForPartDet { Text = "Установить и снять тиски или патрон", VremRab = new double[] { 1.5, 2.0, 2.0, 2.5, 3.0 } });
                        SpisDopRab.Add(new NamedItemForPartDet { Text = "Установить и снять упор", VremRab = new double[] {0.8, 1.0, 1.0, 1.2, 1.2} });
                        SpisDopRab.Add(new NamedItemForPartDet { Text = "Повернуть стол на угол", VremRab = new double[] { 2.0, 2.0, 2.0, 2.0, 2.0 } });
                        SpisDopRab.Add(new NamedItemForPartDet { Text = "Установить и снять доп. стол", VremRab = new double[] { 0.0, 4.0, 4.0, 5.0, 5.0 } });
                        SpisDopRab.Add(new NamedItemForPartDet { Text = "Установить и снять многошпиндельную головку", VremRab = new double[] {0.0, 0.0, 0.0, 25.0, 25.0 } });
                        SpisDopRab.Add(new NamedItemForPartDet { Text = "Подготовить яму для работы", VremRab = new double[] { 0.0, 0.0, 0.0, 3.0, 3.0 } });
                    }
                }
            }
        }
        public int SelectedNaibDiamIndex;
        private ObservableCollection<int> _naibDiams;
        public ObservableCollection<int> NaibDiams
        {
            get
            {
                return _naibDiams;
            }
            set
            {
                _naibDiams = value;
            }
        }
        private NamedItem _kolVoInstrSelected;
        public NamedItem KolVoInstrSelected
        { 
            get
            {
                return _kolVoInstrSelected;
            }
            set
            {
                _kolVoInstrSelected = value;
                OnPropertyChanged(nameof(VrPart));
            }
        }
        private ObservableCollection<NamedItem> _kolVoInstrs;
        public ObservableCollection<NamedItem> KolVoInstrs
        {
            get => _kolVoInstrs;
            set
            {
                _kolVoInstrs = value;
                OnPropertyChanged();
            }
        }
        private NamedItem _slozh;
        public NamedItem Slozh 
        { 
            get
            {
                return _slozh;
            }
            set
            {
                _slozh = value;
                if (Slozh?.Text == "Простая")
                {
                    KolVoInstrs = new ObservableCollection<NamedItem>
                    {
                        new NamedItem{ Text = "1-3" },
                        new NamedItem{ Text = "4-6" },
                    };
                }
                else if (Slozh?.Text == "Средней сложности")
                {
                    KolVoInstrs = new ObservableCollection<NamedItem>
                    {
                        new NamedItem{ Text = "2-4" },
                        new NamedItem{ Text = "5-7" },
                        new NamedItem{ Text = "8-10" },
                    };
                }
                else if (Slozh?.Text == "Сложная")
                {
                    KolVoInstrs = new ObservableCollection<NamedItem>
                    {
                        new NamedItem{ Text = "3-5" },
                        new NamedItem{ Text = "6-8" },
                        new NamedItem{ Text = "9-12" },
                    };
                }
                KolVoInstrSelected = KolVoInstrs[0];
                OnPropertyChanged();
                OnPropertyChanged(nameof(KolVoInstrs));
                OnPropertyChanged(nameof(KolVoInstrSelected));
            }
        }
        private ObservableCollection<NamedItem> _slozhs;
        public ObservableCollection<NamedItem> Slozhs
        {
            get => _slozhs;
            set
            {
                _slozhs = value;
                OnPropertyChanged();
            }
        }
        private int _kolvoDet;
        public int KolvoDet
        {
            get
            {
               return _kolvoDet;
            }
            set
            {
                _kolvoDet = value;
                OnPropertyChanged(nameof(VrPart));
            }
        }
        private double _vrDet;
        public double VrDet
        {
            get
            {
                double sum = 0;
                if (_kolvoDet > 0)
                {
                Debug.WriteLine("вызвалась хуйня");
                    foreach (ChtototamsSDetal cht in Detal.Instance.ChtototamsSDetals)
                    {
                        if (cht is Hole h && h.window.DataContext is OtvParamsViewModel otvpvm)
                        {
                            sum += otvpvm._vrVsego;
                        }
                        if (cht is Perem1 p && p.window.DataContext is PeremViewModel Peremvm)
                        {

                        }
                    }
                }
                return sum ;
            }
            set
            {
                _vrDet = value;
                OnPropertyChanged(nameof(VrPart));
            }
        }
        private double _vrPart;
        public double VrPart
        {
            get
            {

                double sum;
                if (VrDet != 0 && KolvoDet > 0  && IndexZamUstPrisp() >= 0 && IndexKolvoIntrs() >= 0 && SelectedNaibDiamIndex >= 0)
                {
                    sum = VrDet * KolvoDet + vrrMassiv[IndexZamUstPrisp()][IndexKolvoIntrs()][SelectedNaibDiamIndex] + vrSpisDopRab();
                    return sum;
                }
                else return 0;
            }
            set
            {
                _vrPart = value;    
                OnPropertyChanged();
            }
        }
        public int IndexKolvoIntrs()
        {
            if (KolVoInstrSelected.Text != null)
            {
                switch (KolVoInstrSelected.Text)
                {
                    case "1-3":
                        return 0;
                        break;
                    case "4-6":
                        return 1;
                        break;
                    case "2-4":
                        return 2;
                        break;
                    case "5-7":
                        return 3;
                        break;
                    case "8-10":
                        return 4;
                        break;
                    case "3-5":
                        return 5;
                        break;
                    case "6-8":
                        return 6;
                        break;
                    case "9-12":
                        return 7;
                        break;
                    default: return -1;
                }
            }
            else return -1;
        }
        public int IndexZamUstPrisp()
        {
            if (SelectedZamUstPrisp.Text == "С заменой")
                return 0;
            else if (SelectedZamUstPrisp.Text == "Без замены")
                return 1;
            else return -1;
        }
        public PartDetViewModel()
        {
            CollectionSpisDopRab = new ObservableCollection<NamedItemForPartDet> { };
            SpisDopRab = new ObservableCollection<NamedItemForPartDet> { };
            Slozhs = new ObservableCollection<NamedItem>
            {
                new NamedItem{ Text = "Простая" },
                new NamedItem{ Text = "Средней сложности" },
                new NamedItem{ Text = "Сложная" },
            };
            Slozh = Slozhs[0];
            NaibDiams = new ObservableCollection<int> {12,25,35,50,80} ;
            SelectedNaibDiam = NaibDiams[0];
            ZamUstPrisp = new ObservableCollection<NamedItem>
            {
                new NamedItem{ Text = "С заменой" },
                new NamedItem{ Text = "Без замены" },
            };
            SelectedZamUstPrisp = ZamUstPrisp[0];
            KolvoDet = 1;
            Detal.Instance.ChtototamsSDetals.CollectionChanged += (s, e) =>
            {
                if (e.NewItems != null)
                {
                    OtvParamsViewModel.VrVsegoChanged += (s2, e2) =>
                    {
                        OnPropertyChanged(nameof(VrDet));
                    };                                        
                }
            };
            OtvParamsViewModel.VrVsegoChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(VrDet));
            };

        }
    }
}
