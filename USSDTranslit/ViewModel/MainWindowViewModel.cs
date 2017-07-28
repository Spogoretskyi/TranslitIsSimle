using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;

namespace USSDTranslit.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        TranslitDictionary _dictionary = new TranslitDictionary();

        Input _text = new Input();

        private RelayCommand _clearCommand;
        public RelayCommand ClearCommand
        {
            get { return _clearCommand = _clearCommand ?? new RelayCommand(Clear); }
            set { _clearCommand = value; }
        }
        public string RUS
        {
            get
            {
                return  _text.InRus;
            }
            set
            {
                if (_text.InRus == value)
                    return;
                _text.InRus = value;
                OnPropertyChanged("");
            }
        }
        public string UA
        {
            get
            {
                return _text.InUA;
            }
            set
            {
                if (_text.InUA == value)
                    return;
                _text.InUA = value;
                OnPropertyChanged("");
            }
        }
        public string TrRUS
        {
            get
            {
                return TranslitRU(RUS);
            }
            set
            {
                if (_text.InRusEn == value)
                    return;
                _text.InRusEn = value;
                OnPropertyChanged("RUS");
            }
        }
        public string TrUA
        {
            get
            {
                return TranslitUA(UA);
            }
            set
            {
                if (_text.InRusEn == value)
                    return;
                _text.InRusEn = value;
                OnPropertyChanged("UA");
            }
        }
        public string LabelRUS
        {
            get
            {
                return Convert.ToString(RUS.Length);
            }
        }

        public string LabelRUSTr
        {
            get
            {
                return Convert.ToString(TrRUS.Length);
            }
        }
        public string LabelUA
        {
            get
            {
                return Convert.ToString(UA.Length);
            }
        }

        public string LabelUATr
        {
            get
            {
                return Convert.ToString(TrUA.Length);
            }
        }
        private string TranslitRU(string str)
        {
                StringBuilder sb = new StringBuilder();
                foreach (char word in str)
                {
                    sb.Append(_dictionary.ToTranslitRu(Convert.ToString(word)));
                }
                return Convert.ToString(sb);
        }
        private string TranslitUA(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char word in str)
            {
                sb.Append(_dictionary.ToTranslitUA(Convert.ToString(word)));
            }
            return Convert.ToString(sb);
        }

        public void Clear(object param)
        {
            RUS = "";
            TrRUS = "";
            UA = "";
            TrUA = "";
        }
    }
}
