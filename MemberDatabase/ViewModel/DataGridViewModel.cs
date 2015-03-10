namespace MemberDatabase.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Controls;
    using System.Windows.Input;
    using MemberDatabase.Model;

    class DataGridViewModel : BaseViewModel
    {
        public List<Member> members { get; set; }
        public string anniversary { get; set; }
        public string birthday { get; set; }
        
        private Database db;
        private Anniversary an;

        public DataGridViewModel()
        {
            this.db = new Database();
            this.loadDataBase();
            this.editModeChecked = false;
            this.readOnly = true;
        }

        public void loadDataBase()
        {
            this.members = this.db.content();
            this.an = new Anniversary(this.members);
            this.birthday = this.an.nextBirthday();
            this.anniversary = this.an.nextAnniversary();
            this.RaisePropertyChanged("members");
            this.RaisePropertyChanged("anniversary");
            this.RaisePropertyChanged("birthday");
        }


        private ICommand _loadCommand;

        public ICommand loadDatabase {
            get
            {
                if (this._loadCommand == null)
                {
                    this._loadCommand = new RelayCommand(param => this.loadDataBase());
                }
                return this._loadCommand;
            }
        }

        private ICommand _notImplementedCommand;

        public ICommand notImplementedError
        {
            get
            {
                if (this._notImplementedCommand == null)
                {
                    this._notImplementedCommand = new RelayCommand(param => this.notImplemented());
                }
                return this._notImplementedCommand;
            }
        }

        private void notImplemented()
        {
            System.Windows.MessageBox.Show("Noch nicht implementiert!");
        }

        bool _editModeChecked;

        public bool editModeChecked
        {
            get
            {
                return this._editModeChecked;
            }

            set
            {
                if (this._editModeChecked != value)
                {
                    this._editModeChecked = value;
                    this.RaisePropertyChanged("editMode");
                    this.readOnly = !value;
                }
            }
        }

        bool _readOnly;

        public bool readOnly
        {
            get
            {
                return this._readOnly;
            }

            set
            {
                if (this._readOnly != value)
                {
                    this._readOnly = value;
                    this.RaisePropertyChanged("readOnly");
                }
            }
        }
    }
}
