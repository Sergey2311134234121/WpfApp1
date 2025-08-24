using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Helpers.ВсякаяХуйня;

namespace WpfApp1.ViewModel.OperaciiViewModel
{
    public class RassverlViewModel : OperViewModelBase
    {
        public override double MaxGlub
        {
            get
            {
                if (SelectedMat == null || SelectedMatInstr == null || Diam == 0 )
                    return 0;
                else
                {
                    var _model = WpfApp1.Model.RassverlModelFactory.Create(SelectedMat.Text, SelectedMatInstr.Text, Diam, Glub, Oper.GlubRez);
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
                if (SelectedMat == null || SelectedMatInstr == null || Diam == 0 || Glub == 0)
                    return 0;
                else
                {
                    var _model = WpfApp1.Model.RassverlModelFactory.Create(SelectedMat.Text, SelectedMatInstr.Text, Diam, Glub, Oper.GlubRez);
                    _vr = _model.Vremya() * ItogKoef * KoefOtv * KoefTipOtv + DopVremPoGluhOtv;
                    Oper.Vr = _vr;
                    Debug.WriteLine(Oper.Vr);
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
                            new NamedItem { Text = "Р6М5"}
                        };
                    }
                    else if (_selectedMat?.Text == "Сталь коррозионностойкая")
                    {
                        NameditemMatsInstrs = new ObservableCollection<NamedItem>
                        {
                            new NamedItem { Text = "Р6М5"}
                        };
                    }
                    else if (_selectedMat?.Text == "Алюминиевые сплавы")
                    {
                        NameditemMatsInstrs = new ObservableCollection<NamedItem>
                        {
                            new NamedItem { Text = "Р6М5"}
                        };
                    }
                    else if (_selectedMat?.Text == "Медные сплавы")
                    {
                        NameditemMatsInstrs = new ObservableCollection<NamedItem>
                        {
                            new NamedItem { Text = "Р6М5"}
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
                if (Diam > 12)
                {
                    list.Add(UslStr.CreateUslStr("Условия жесткости при сверлении отверстия", 0, ("Деталь и система крепления жесткие", 1), ("Тонкостенная деталь и система крепления не жесткие", 1.2)));
                }
            }
            else if (_selectedMatInstr?.Text == "Р6М5" & _selectedMat?.Text == "Сталь углеродистая")
            {
                list = new ObservableCollection<UslStr>
                {
                    UslStr.CreateUslStr("Группы обрабатываемой стали", 0, ("углеродистые обычного и высокого качества, HB любая", 1), ("Углеродистые, хромистые, никелиевые, хромникелиевые, HB до 170", 0.9), ("Углеродистые, хромистые, никелиевые, хромникелиевые, HB 170...210", 1), ("Углеродистые, хромистые, никелиевые, хромникелиевые, HB от 210", 1.1), ("Марганцовистые, хромомарганцовистые, хромомолибденовые и близкие к ним, HB до 170", 1), ("Марганцовистые, хромомарганцовистые, хромомолибденовые и близкие к ним, HB 170...210", 1.1), ("Марганцовистые, хромомарганцовистые, хромомолибденовые и близкие к ним, HB от 210", 1.2)),
                    UslStr.CreateUslStr("Марки материала режущего инструмента", 0, ("Р6М5", 1), ("Р6К5, Р6М3, Р10К5Ф5", 0.85)),
                    UslStr.CreateUslStr("Нанесения износостойких покрытий", 3, ("Покрытие", 0.85), ("После первой заточки", 0.9),("После второй заточки", 0.85),("Без покрытия", 1)),
                };
                if (Diam > 12)
                {
                    list.Add(UslStr.CreateUslStr("Условия жесткости при сверлении отверстия", 0, ("Деталь и система крепления жесткие", 1), ("Тонкостенная деталь и система крепления не жесткие", 1.2)));
                }
            }
            else if (_selectedMatInstr?.Text == "Р6М5" & _selectedMat?.Text == "Сталь коррозионностойкая")
            {
                list = new ObservableCollection<UslStr>
                {
                    UslStr.CreateUslStr("Группа обрабатываемой стали", 0, ("12Х18Н9Т, 09Х16Н4Б, 14X17H2, 09X15H8Ю,07X16H4", 1.0), ("12Х13, 25Х13Н2", 0.71), ("20Х13", 0.77), ("30Х13", 0.83), ("12Х21М5Т", 1.17)),
                    UslStr.CreateUslStr("Марки материала режущего инструмента", 0, ("Р6М5", 1.0), ("Р6К5, Р6МЗ, Р10К5Ф5", 0.85)),
                    UslStr.CreateUslStr("Нанесения износостойких покрытий", 3, ("Покрытие", 0.85), ("После первой заточки", 0.90), ("После второй заточки", 0.95), ("(без покрытия)", 1.0)),

                };
                if (Diam > 12)
                {
                    list.Add(UslStr.CreateUslStr("Условия жесткости при сверлении отверстия", 0, ("Деталь и система крепления жесткие", 1), ("Тонкостенная деталь и система крепления не жесткие", 1.2)));
                }
            }
            else if (_selectedMatInstr?.Text == "Р6М5" & _selectedMat?.Text == "Алюминиевые сплавы")
            {
                list = new ObservableCollection<UslStr>
                {
                    UslStr.CreateUslStr("Марка материала", 0, ("Д6, Д16, Д16Т", 1.0), ("АМг", 0.7), ("АК4, АК6, АК9, АЛ19, Б95", 0.9), ("АЛ5, АЛ4", 1.1)),
                    UslStr.CreateUslStr("Марки материала режущего инструмента", 0, ("Р6М5", 1.0), ("Р6К5, Р6МЗ, Р10К5Ф5", 0.85)),

                };
                if (Diam > 12)
                {
                    list.Add(UslStr.CreateUslStr("Условия жесткости при сверлении отверстия", 0, ("Деталь и система крепления жесткие", 1), ("Тонкостенная деталь и система крепления не жесткие", 1.2)));
                }
            }
            else if (_selectedMatInstr?.Text == "Р6М5" & _selectedMat?.Text == "Медные сплавы")
            {
                list = new ObservableCollection<UslStr>
                {
                    UslStr.CreateUslStr("Твёрдость медного сплава, НВ", 0, ("до 140", 1.0), ("свыше 140", 1.2)),
                    UslStr.CreateUslStr("Марки материала режущего инструмента", 0, ("Р6М5", 1.0), ("Р6К5, Р6МЗ, Р10К5Ф5", 0.85)),

                };
                if (Diam > 12)
                {
                    list.Add(UslStr.CreateUslStr("Условия жесткости при сверлении отверстия", 0, ("Деталь и система крепления жесткие", 1), ("Тонкостенная деталь и система крепления не жесткие", 1.2)));
                }
            }
            else
            {
                list = new ObservableCollection<UslStr> { };
            }
            ForDataGrid = list;
            OnPropertyChanged(nameof(ForDataGrid));
        }
        public RassverlViewModel(Hole hole, Operation oper) : base(hole, oper)
        {

        }
    }
}
