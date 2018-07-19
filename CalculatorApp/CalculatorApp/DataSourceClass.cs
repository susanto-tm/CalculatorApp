using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CalculatorApp
{
    class DataSourceClass : INotifyPropertyChanged
    {
        private string _text;
        public string LblText {
            get {
                return _text;
            }
            set {
                _text = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LblText"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public DataSourceClass()
        {
        }
    }
}
