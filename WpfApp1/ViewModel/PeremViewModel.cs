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
    internal class PeremViewModel : INotifyPropertyChanged
    {
        #region OnPropertyChenged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        private double _vrPerem;
        public double VRPerem
        {
            get
            {
                if (Massa!=0 && SelectedSposUst!= null && SelectedHaractViv != null)
                _vrPerem = SelectedSposUst.VremRab[SelectedHaractVivIndex()][MassaIndex()];
                return _vrPerem;
            }
            set
            {
                _vrPerem = value;
                OnPropertyChanged();
            }
        }
        private int MassaIndex()
        {
            double[] Massiv1 = new double[] { 0.3, 1, 3, 5, 10, 20 };
            double[] Massiv2 = new double[] { 30, 50, 100, 200, 400, 800, 1500, 3000 };
            if (Massa > 0 && Massa <= 20)
            {
                for (int i = 0; i <= Massiv1.Length; i++)
                {
                    if (Massa <= Massiv1[i])
                    {
                        return i;
                    }
                }
                return -1;
            }
            else if (Massa > 20 && Massa <= 3000)
            {
                for (int i = 0; i <= Massiv2.Length; i++)
                {
                    if (Massa <= Massiv2[i])
                    {
                        return i;
                    }                   
                }
                return -1;
            }
            else
                return -1;
        }
        private int SelectedHaractVivIndex()
        {
            if (SelectedHaractViv == SelectedSposUst.Text1[0])
            {
                return 0;
            }
            else if (SelectedHaractViv == SelectedSposUst.Text1[1])
            {
                return 1;
            }
            else
                return -1;
        }
        private double _massa;
        public double Massa
        {
            get 
            {
                return _massa;
            }
            set
            {
                _massa = value;
                OnPropertyChanged();
                if (_massa != 0)
                {
                    if (_massa > 0 && _massa <= 20)
                    {
                        SposUst = new ObservableCollection<NamedItemForPerem>
                        {
                            new NamedItemForPerem { Text = "На столе (плите) с креп. пневматическим прихватом", Text1 = new string[] {"Без выверки"}, VremRab = new double [][]{ new double[] {0.23, 0.32, 0.43, 0.48, 0.58, 0.69 } } },
                            new NamedItemForPerem { Text = "На столе (плите) с креп. болтами и планками" ,Text1 = new string[] {"Без выверки", "С выверкой"}, VremRab = new double [][]{ new double[] {0.76, 0.80, 1.1, 1.2, 1.4, 1.7 }, new double[] { 1.3, 1.5, 2.0, 2.3, 2.7, 3.3 } } },
                            new NamedItemForPerem { Text = "На столе установленным под углом с креп. болтами и планками" , Text1 = new string[] {"Обработанная", "Необработанная"}, VremRab = new double [][]{ new double[] { 1.1, 1.6, 2.2, 2.4, 2.7, 3.1 }, new double[] { 1.6, 2.3, 2.9, 3.3, 3.8, 4.1 } } },
                            new NamedItemForPerem { Text = "Сбоку стола на опоре с креп. болтами и планками" , Text1 = new string[] {"С выверкой в одной плоскости", "С выверкой в двух плоскостях"}, VremRab = new double [][]{ new double[] { 0.00, 0.00, 1.7, 2.1, 2.6, 3.3 }, new double[] { 0.00, 0.00, 2.3, 2.6, 3.2, 3.9 } } },
                            new NamedItemForPerem { Text = "Сбоку стола на весу с креп. болтами и планками" , Text1 = new string[] {"С выверкой в одной плоскости", "С выверкой в двух плоскостях"}, VremRab = new double [][]{ new double[] { 0.00, 0.00, 2.5, 2.9, 3.5, 4.3 }, new double[] {0.00, 0.00, 2.9, 3.4, 4.1, 5.0 } } },
                            new NamedItemForPerem { Text = "На столе (плите) по упору без креп." , Text1 = new string[] {"Без выверки", "С выверкой"}, VremRab = new double [][]{ new double[] {0.12, 0.19, 0.27, 0.33, 0.41, 0.53 }, new double[] {0.24, 0.37, 0.55, 0.65, 0.83, 1.07 } }},
                            new NamedItemForPerem { Text = "В самоцентрирующем патроне с креплением кулачками" , Text1 = new string[] {"Без выверки"}, VremRab = new double [][]{ new double[] {0.23, 0.36, 0.55, 0.65, 0.85, 1.09 } } },
                            new NamedItemForPerem { Text = "В универсальном скальчатом кондуктре с пневматическим креплением" , Text1 = new string[] {"Без выверки"}, VremRab = new double [][]{ new double[] {0.16, 0.24, 0.34, 0.39, 0.49, 0.61 } } },
                            new NamedItemForPerem { Text = "В универсальном скальчатом кондуктре с ручным креплением" , Text1 = new string[] {"Без выверки"}, VremRab = new double [][]{  new double[] { 0.25, 0.39 ,0.55, 0.65, 0.85, 1.09} } },
                            new NamedItemForPerem { Text = "В тисках с креплением винтом" , Text1 = new string[] {"Без выверки", "С выверкой в одной плоскости"}, VremRab = new double [][]{ new double[] {0.33, 0.44, 0.57, 0.64, 0.76, 0.89 }, new double[] {0.65, 0.87, 1.1, 1.3, 1.5, 1.8 } } },
                            new NamedItemForPerem { Text = "В тисках с креплением эксцентриком" , Text1 = new string[] {"Без выверки", "С выверкой"}, VremRab = new double [][]{ new double[] {0.23, 0.33, 0.46, 0.53, 0.65, 0.81 }, new double[] {0.46, 0.65, 0.92, 1.1, 1.3, 1.6 } } },
                            new NamedItemForPerem { Text = "В тисках с креплением пневмогидравлическим цилиндром" , Text1 = new string[] {"Без выверки" }, VremRab = new double [][]{ new double[] {0.2, 0.27, 0.38, 0.41, 0.55, 0.59  } } },
                        };
                    }
                    else if(_massa <= 3000 && _massa > 20)
                    {
                        SposUst = new ObservableCollection<NamedItemForPerem>
                        {
                            new NamedItemForPerem { Text = "На столе (плите) с креп. пневматическим прихватом" , Text1 = new string[] {"-"}, VremRab = new double [][]{ new double[] { 3.6, 3.9, 4.6, 5.2, 6.0, 6.8, 7.7, 8.8} } },
                            new NamedItemForPerem { Text = "На столе (плите) с креп. болтами и планками" , Text1 = new string[] {"Без выверки", "С выверкой"}, VremRab = new double [][]{ new double[] { 4.5, 5.2, 6.0, 6.9, 7.9, 9.4, 10.7, 12.5}, new double[] { 7.8, 8.8, 10.0, 12.0 , 14.0, 16.4, 18.5, 21.8} } },
                            new NamedItemForPerem { Text = "На столе установленным под углом с креп. болтами и планками" , Text1 = new string[] {"Без выверки", "С выверкой"}, VremRab = new double [][]{ new double[] {5.8, 6.8, 8.5, 10.9, 0.00, 0.00, 0.00, 0.00 }, new double[] {8.2, 9.3, 12.0, 14.7, 0.00, 0.00, 0.00, 0.00 } } },
                            new NamedItemForPerem { Text = "Сбоку стола на опоре с креп. болтами и планками" , Text1 = new string[] {"С выверкой в одной плоскости", "С выверкой в двух плоскостях"}, VremRab = new double [][]{ new double[] { 8.0, 8.9, 10, 11.7, 13.3, 15.2, 17.0, 19.4}, new double[] {8.6, 9.6, 11.0, 12.9, 14.9, 17.2, 19.6, 22.9 } } },
                            new NamedItemForPerem { Text = "Сбоку стола на весу с креп. болтами и планками" , Text1 = new string[] {"С выверкой в одной плоскости", "С выверкой в двух плоскостях"}, VremRab = new double [][]{ new double[] {9.9, 10.0, 11.4, 12.4, 13.5, 14.6, 15.8, 0.00 }, new double[] {11.8, 12.5, 13.4, 14.4, 15.4, 16.5, 17.5, 0.00 } } },
                            new NamedItemForPerem { Text = "На столе (плите) по упору без креп." , Text1 = new string[] {"Без выверки", "С выверкой"}, VremRab = new double [][]{ new double[] { 3.3, 3.6, 4.2, 4.8, 5.5, 6.3, 7.0, 8.0}, new double[] { 4.4, 4.8, 5.6, 6.4, 7.3, 8.4, 9.6, 11.0 } } },
                            new NamedItemForPerem { Text = "В самоцентрирующем патроне с креплением кулачками" , Text1 = new string[] {"Без выверки"}, VremRab = new double [][]{ new double[] {4.2, 4.6, 5.0, 5.4, 6.0, 0.00, 0.00, 0.00 }} },
                            new NamedItemForPerem { Text = "В яме с креплением болтами и планками" , Text1 = new string[] {"Без выверки", "С выверкой"}, VremRab = new double [][]{ new double[] { 0.00, 0.00, 0.00, 8.2, 9.7, 11.7, 13.7, 16.4}, new double[] {0.00, 0.00, 0.00, 9.7, 11.7, 14.0, 16.4, 19.6 } } },
                        };
                    }
                    OnPropertyChanged(nameof(VRPerem));
                }    
            }
        }
        private string _selectedHaractViv;
        public string SelectedHaractViv
        {
            get
            {
                return _selectedHaractViv;
            }
            set
            {
                _selectedHaractViv = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(VRPerem));
            }
        }

        private NamedItemForPerem _selectedSposUst;
        public NamedItemForPerem SelectedSposUst
        {
            get
            {
                return _selectedSposUst;
            }
            set
            {
                _selectedSposUst = value;
                SelectedHaractViv = _selectedSposUst.Text1[0];
                OnPropertyChanged();
                OnPropertyChanged(nameof(VRPerem));
            }
        }
        private ObservableCollection<NamedItemForPerem> _sposUst;
        public ObservableCollection<NamedItemForPerem> SposUst
        {
            get { return _sposUst; }
            set 
            { 
                _sposUst = value;
                if (_sposUst != null)
                {
                    SelectedSposUst = _sposUst[0];
                }
                OnPropertyChanged();
            }
        }
        public PeremViewModel()
        {
            SposUst = null;            
        }
    }
}
