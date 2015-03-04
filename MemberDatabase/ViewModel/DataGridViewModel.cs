using MemberDatabase.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MemberDatabase.ViewModel
{
    class DataGridViewModel : BaseViewModel
    {
        public List<Member> members { get; set; }
        private string nextAnniversary;
        private Database db;

        public DataGridViewModel()
        {
            db = new Database();
            members = db.content();
            nextAnniversary = "Test";
        }

        public string anniversary
        {
            get
            {
                return nextAnniversary;
            }
            set
            {
                if (nextAnniversary != value)
                {
                    nextAnniversary = value;
                    RaisePropertyChanged("anniversary");
                }
            }
        }
    }
}
