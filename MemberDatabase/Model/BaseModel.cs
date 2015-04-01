namespace MemberDatabase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class BaseModel : INotifyPropertyChanged
    {
        public void RaisePropertyChanged(string prop)
        {
            if (this.PropertyChanged != null) { this.PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
