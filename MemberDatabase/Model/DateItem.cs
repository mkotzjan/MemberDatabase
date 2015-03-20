using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberDatabase.Model
{
    public class DateItem : INotifyPropertyChanged
    {
        private int ident;
        private int memberIdent;
        private DateTime? dateTime;
        private string dateInfo;

        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged(string prop)
        {
            if (this.PropertyChanged != null) { this.PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }

        public DateTime? date
        {
            get
            {
                return dateTime;
            }

            set
            {
                if (value != dateTime)
                {
                    dateTime = value;
                    RaisePropertyChanged("date");
                }
            }
        }

        public string information
        {
            get
            {
                return dateInfo;
            }

            set
            {
                if (value != dateInfo)
                {
                    dateInfo = value;
                    RaisePropertyChanged("information");
                }
            }
        }

        public DateItem()
        {
            date = null;
            information = string.Empty;
        }
    }
}
