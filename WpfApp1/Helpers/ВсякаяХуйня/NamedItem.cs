using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1.Helpers.ВсякаяХуйня
{
    public class NamedItem
    {
        public string Text { get; set; }
        public override string ToString() => Text;
        public NamedItem()
        {

        }
    }
    public class NamedItemForPerem
    {
        public string Text { get; set; }
        public override string ToString() => Text;
        public string[] Text1 { get; set; }
        public double[][] VremRab { get; set; }
        public NamedItemForPerem()
        {
            
        }
    }
    public class NamedItemForPartDet
    {
        public string Text { get; set; }
        public override string ToString() => Text;
        public double [] VremRab { get; set; }

        public NamedItemForPartDet()
        {

        }
    }
    public class NamedItemPlus : INotifyPropertyChanged
    {
        #region OnPropertyChenged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        
        public string Text { get; set; }
        public override string ToString() => Text;
        private double _koef;
        public double Koef 
        {
            get => _koef;
            set
            {
                _koef = value;
                OnPropertyChanged();
            }
        }
    }
    public class UslStr : INotifyPropertyChanged
    {
        #region OnPropertyChenged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
        public ObservableCollection<NamedItemPlus> UslParams { get; set; }
        public NamedItem UslName { get; set; }
        private NamedItemPlus _selectedUslParams;
        public NamedItemPlus SelectedUslParams 
        {
            get => _selectedUslParams;
            set
            {
                _selectedUslParams = value;
                OnPropertyChanged(nameof(SelectedUslParams));
            }
        }
        public static UslStr CreateUslStr(String name, int Index, params (string Text, double Koef)[] options)
        {
            List<NamedItemPlus> list = options
                .Select(o => new NamedItemPlus { Text = o.Text, Koef = o.Koef })
                .ToList();
            return new UslStr
            {
                UslName = new NamedItem { Text = name },
                UslParams = new ObservableCollection<NamedItemPlus>(list),
                SelectedUslParams = list.ElementAtOrDefault(Index),
            };
        } // Фабрика строк для датагрида
    }    
}
