using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Helpers.ВсякаяХуйня;

namespace WpfApp1.ViewModel.OperaciiViewModel
{
    internal class RazvKonViewModel : OperViewModelBase
    {
        public override double MaxGlub
        {
            get => _maxGlub;      
        }
        public override double VR
        {
            get
            {
                if (SelectedMat == null || SelectedMatInstr == null || Diam == 0 || SelectedGlubStr == null || Oper.GlubRez == 0 || Kval ==0)
                    return 0;
                else
                {
                    var _model = WpfApp1.Model.RazvKonModelFactory.Create(SelectedMat.Text, SelectedMatInstr.Text, Diam, SelectedGlubStr, Kval, Oper.GlubRez);
                    _vr = _model.Vremya() * ItogKoef * KoefOtv * KoefTipOtv + DopVremPoGluhOtv;
                    Oper.Vr = _vr;
                    OnPropertyChanged(nameof(ViewModel.OtvParamsViewModel.VrEd));
                    return _vr;
                }
            }
        }
        public override NamedItem SelectedMat
        {
            get => _selectedMat;
            set
            {
                if (_selectedMat != value)
                {
                    _selectedMat = value;
                    OnPropertyChanged(nameof(SelectedMat));
                    if (_selectedMat?.Text == "Чугун")
                    {
                        NameditemMatsInstrs = new ObservableCollection<NamedItem>
                        {
                            new NamedItem { Text = "Р6М5"},
                        };
                    }
                    else if (_selectedMat?.Text == "Сталь углеродистая")
                    {
                        NameditemMatsInstrs = new ObservableCollection<NamedItem>
                        {
                            new NamedItem { Text = "Р6М5"},
                            new NamedItem { Text = "T15K6"}
                        };
                    }
                    else if (_selectedMat?.Text == "Сталь коррозионностойкая")
                    {
                        NameditemMatsInstrs = new ObservableCollection<NamedItem>
                        {
                            new NamedItem { Text = "Нет данных по материалу"}
                        };
                    }
                    else if (_selectedMat?.Text == "Алюминиевые сплавы")
                    {
                        NameditemMatsInstrs = new ObservableCollection<NamedItem>
                        {
                            new NamedItem { Text = "Нет данных по материалу"}
                        };
                    }
                    else if (_selectedMat?.Text == "Медные сплавы")
                    {
                        NameditemMatsInstrs = new ObservableCollection<NamedItem>
                        {
                            new NamedItem { Text = "Нет данных по материалу"}
                        };
                    }
                    else
                    {
                        NameditemMatsInstrs = null;
                    }
                    SelectedMatInstr = NameditemMatsInstrs[0];
                    OnPropertyChanged(nameof(NameditemMatsInstrs));
                    OnPropertyChanged(nameof(VR));
                    UpdataeForDataGrid();

                }
            }
        }
        protected override void UpdataeForDataGrid()
        {
            ObservableCollection<UslStr> list;
            if (_selectedMatInstr?.Text == "Р6М5" & _selectedMat?.Text == "Чугун")
            {
                list = new ObservableCollection<UslStr>
                {
                    UslStr.CreateUslStr("Твердость чугуна HB", 0, ("до 220", 1), ("от 220", 1.1)),
                    UslStr.CreateUslStr("Марки материала режущего инструмента", 0, ("Р6М5", 1), ("Р6К5, Р6М3, Р10К5Ф5", 0.85)),
                };
            }
            else if (_selectedMatInstr?.Text == "T15K6" & _selectedMat?.Text == "Сталь углеродистая")
            {
                list = new ObservableCollection<UslStr>
                {
                    UslStr.CreateUslStr("Группы обрабатываемой стали", 0, ("углеродистые обычного и высокого качества, HB любая", 1), ("Углеродистые, хромистые, никелиевые, хромникелиевые, HB до 170", 0.9), ("Углеродистые, хромистые, никелиевые, хромникелиевые, HB 170...210", 1), ("Углеродистые, хромистые, никелиевые, хромникелиевые, HB от 210", 1.1), ("Марганцовистые, хромомарганцовистые, хромомолибденовые и близкие к ним, HB до 170", 1), ("Марганцовистые, хромомарганцовистые, хромомолибденовые и близкие к ним, HB 170...210", 1.1), ("Марганцовистые, хромомарганцовистые, хромомолибденовые и близкие к ним, HB от 210", 1.2)),
                    UslStr.CreateUslStr("Марки материала режущего инструмента", 0, ("T15K6", 1), ("T30K4", 0.75)),
                };
            }
            else
            {
                list = new ObservableCollection<UslStr> { };
            }
            ForDataGrid = list;
            OnPropertyChanged(nameof(ForDataGrid));
        }
        public ObservableCollection<int> Kvals { get; set; }
        private int _kval;
        public int Kval
        {
            get => _kval;
            set
            {
                _kval = value;
                OnPropertyChanged(nameof(VR));
            }
        }
        private string _selectedGlubStr;
        public string SelectedGlubStr 
        {
            get => _selectedGlubStr;
            set
            {
                _selectedGlubStr = value;
                OnPropertyChanged(nameof(VR));
            }
        }
        public string[] GlubStrs { get; set; }
        public RazvKonViewModel(Hole hole, Operation oper, int i) : base(hole, oper)
        {
            Kvals = new ObservableCollection<int> { 8, 7 };
            Kval = Kvals[i];
            GlubStrs = new string[] { "1 : 3", "1 : 5", "1 : 7", "1 : 10", "1 : 15", "1 : 20", "1 : 30", "1 : 50"};
            SelectedGlubStr = GlubStrs[0];
        }
    }
}
