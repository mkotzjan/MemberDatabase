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
        public ObservableCollection<Member> members { get; set; }
        public DataGridViewModel()
        {
            members = new ObservableCollection<Member>()
            { 
                new Member { firstName = "Max", lastName = "Mustermann", birthday = 12345, accession = 54321, active = true},
                new Member { firstName = "Max", lastName = "Mustermann", birthday = 12345, accession = 54321, active = true},
                new Member { firstName = "Max", lastName = "Mustermann", birthday = 12345, accession = 54321, active = true},
                new Member { firstName = "Max", lastName = "Mustermann", birthday = 12345, accession = 54321, active = true}
            };
        }
    }
}
