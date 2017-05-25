using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public class BooleanPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public BooleanPropertyChanged(Boolean b)
        {
            _WindowIsShown = b;
        }
        private Boolean _WindowIsShown;
        public Boolean WindowIsShown
        {
            get
            {
                return _WindowIsShown;
            }

            set
            {
                    this._WindowIsShown = value;
                    NotifyPropertyChanged(nameof(WindowIsShown));
             }

        }
        public void NotifyPropertyChanged(string parameter)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(parameter));
            }
        }
    }
}
