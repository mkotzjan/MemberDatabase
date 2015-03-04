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
        public string anniversary { get; set; }
        private Database db;
        private Anniversary an;

        public DataGridViewModel()
        {
            db = new Database();
            an = new Anniversary();
            members = db.content();
            anniversary = an.next(members);
        }
    }
}
