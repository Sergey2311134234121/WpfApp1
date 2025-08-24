using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Helpers.ВсякаяХуйня;

namespace WpfApp1.ViewModel.OperaciiViewModel
{
    internal class RezbViewModel : OperViewModelBase
    {
        public override double MaxGlub
        {
            get
            {
                if (SelectedMat == null || SelectedMatInstr == null || Diam == 0)
                    return 0;
                else
                {
                    var _model = WpfApp1.Model.RezbModelFactory.Create(SelectedMat.Text, Glub, SelectedNomDiam, StepRez);
                    _maxGlub = _model.MaxGlub();
                    Oper.MaxGlub = _maxGlub;
                    return _maxGlub;
                }
            }
        }
        public override double VR
        {
            get
            {
                if (SelectedMat == null || Glub == 0 || SelectedNomDiam == 0 || StepRez == 0)
                    return 0;
                else
                {
                    var _model = WpfApp1.Model.RezbModelFactory.Create(SelectedMat.Text, Glub, SelectedNomDiam, StepRez);
                    _vr = _model.Vremya() * ItogKoef * KoefOtv * KoefTipOtv + DopVremPoGluhOtv;
                    Oper.Vr = _vr;
                    OnPropertyChanged(nameof(ViewModel.OtvParamsViewModel.VrEd));
                    return _vr;
                }
            }
        }
        public ObservableCollection<int> NomDiams { get; set; }
        private int _selectedNomDiam;
        public int SelectedNomDiam
        {
            get => _selectedNomDiam;
            set
            {
                _selectedNomDiam = value;
                OnPropertyChanged();
                if (_selectedNomDiam == 4)
                {
                    StepRezs = new ObservableCollection<double> { 0.7 };                       
                }
                else if (_selectedNomDiam == 5)
                {
                    StepRezs = new ObservableCollection<double> { 0.8 };                     
                }
                else if (_selectedNomDiam == 6)
                {
                    StepRezs = new ObservableCollection<double> { 1 };
                }
                else if (_selectedNomDiam == 8)
                {
                    StepRezs = new ObservableCollection<double> { 1.25 };
                }
                else if (_selectedNomDiam == 10)
                {
                    StepRezs = new ObservableCollection<double> { 1.5 };
                }
                else if (_selectedNomDiam == 12)
                {
                    StepRezs = new ObservableCollection<double> { 1.75, 1.5, 1.25 };
                }
                else if (_selectedNomDiam == 16)
                {
                    StepRezs = new ObservableCollection<double> { 2, 1.5 };
                }
                else if (_selectedNomDiam == 20)
                {
                    StepRezs = new ObservableCollection<double> { 2.5, 2, 1.5 };
                }
                else if (_selectedNomDiam == 24)
                {
                    StepRezs = new ObservableCollection<double> { 3, 2, 1.5 };
                }
                else if (_selectedNomDiam == 30)
                {
                    StepRezs = new ObservableCollection<double> { 3.5, 2, 1.5 };
                }
                else if (_selectedNomDiam == 36)
                {
                    StepRezs = new ObservableCollection<double> { 4, 3, 2 };
                }
                else if (_selectedNomDiam == 42)
                {
                    StepRezs = new ObservableCollection<double> { 3, 2 };
                }
                else if (_selectedNomDiam == 48)
                {
                    StepRezs = new ObservableCollection<double> { 3, 2 };
                }
                else
                {
                    NameditemMatsInstrs = null;
                }
                StepRez = StepRezs[0];
                OnPropertyChanged(nameof(StepRezs));
                OnPropertyChanged(nameof(VR));
            }
        }
        private ObservableCollection<double> _stepRezs;
        public ObservableCollection<double> StepRezs 
        {
            get => _stepRezs;
            set
            {
                _stepRezs = value;
                OnPropertyChanged();
            }
        }
        private double _stepRez;
        public double StepRez
        {
            get => _stepRez;
            set
            {
                _stepRez = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(VR));
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
                };
            }
            else if (_selectedMatInstr?.Text == "Р6М5" & _selectedMat?.Text == "Сталь углеродистая")
            {
                list = new ObservableCollection<UslStr>
                {
                    UslStr.CreateUslStr("Группы обрабатываемой стали", 0, ("углеродистые обычного и высокого качества, HB любая", 1), ("Углеродистые, хромистые, никелиевые, хромникелиевые, HB до 170", 0.9), ("Углеродистые, хромистые, никелиевые, хромникелиевые, HB 170...210", 1), ("Углеродистые, хромистые, никелиевые, хромникелиевые, HB от 210", 1.1), ("Марганцовистые, хромомарганцовистые, хромомолибденовые и близкие к ним, HB до 170", 1), ("Марганцовистые, хромомарганцовистые, хромомолибденовые и близкие к ним, HB 170...210", 1.1), ("Марганцовистые, хромомарганцовистые, хромомолибденовые и близкие к ним, HB от 210", 1.2)),
                    UslStr.CreateUslStr("Марки материала режущего инструмента", 0, ("Р6М5", 1), ("Р6К5, Р6М3, Р10К5Ф5", 0.85)),
                };
            }
            else
            {
                list = new ObservableCollection<UslStr> { };
            }
            ForDataGrid = list;
            OnPropertyChanged(nameof(ForDataGrid));
        }
        public RezbViewModel(Hole hole, Operation oper, int i) : base(hole, oper)
        {
            NomDiams = new ObservableCollection<int>
            { 4, 5, 6, 8, 10, 12, 16, 20, 24, 30, 36, 42, 48};
            SelectedNomDiam = NomDiams[0];
        }
    }
}
