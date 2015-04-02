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
using System.ComponentModel;
    using System.Windows.Data;

    class DataGridViewModel : BaseViewModel
    {
        private MemberList membersP;
        private ICollectionView memberViewP;
        private DateList examP;
        private DateList seminarP;
        private ICollectionView examViewP;
        private ICollectionView seminarViewP;
        private List<string> anniversaryP;
        private List<string> birthdayP;
        private List<string> anniversaryTooltipP;
        private List<string> birthdayTooltipP;
        private string searchKey;
        private int selectedIndex;
        private bool groupByGroups;
        private Database db;
        private Anniversary an;
        private Tuple<MemberList, DateList, DateList> importedContent;

        public MemberList members
        { 
            get
            {
                return membersP;
            }
            
            set
            {
                if (value != membersP)
                {
                    membersP = value;
                    RaisePropertyChanged("members");
                    memberView = CollectionViewSource.GetDefaultView(members);
                }
            }
        }

        public DateList exam
        {
            get
            {
                return examP;
            }

            set
            {
                if (value != examP)
                {
                    examP = value;
                    RaisePropertyChanged("exam");
                    examView = CollectionViewSource.GetDefaultView(exam);
                }
            }
        }

        public DateList seminar
        {
            get
            {
                return seminarP;
            }

            set
            {
                if (value != seminarP)
                {
                    seminarP = value;
                    RaisePropertyChanged("seminar");
                    seminarView = CollectionViewSource.GetDefaultView(seminar);
                }
            }
        }
        public List<string> anniversary
        { 
            get
            {
                return anniversaryP;
            }

            set
            {
                if (value != anniversaryP)
                {
                    anniversaryP = value;
                    RaisePropertyChanged("anniversary");
                }
            }
        }
        public List<string> birthday
        {
            get
            {
                return birthdayP;
            }

            set
            {
                if (value != birthdayP)
                {
                    birthdayP = value;
                    RaisePropertyChanged("birthday");
                }
            }
        }
        public List<string> anniversaryTooltip
        {
            get
            {
                return anniversaryTooltipP;
            }

            set
            {
                if (value != anniversaryTooltipP)
                {
                    anniversaryTooltipP = value;
                    RaisePropertyChanged("anniversaryTooltip");
                }
            }
        }
        public List<string> birthdayTooltip
        {
            get
            {
                return birthdayTooltipP;
            }

            set
            {
                if (value != birthdayTooltipP)
                {
                    birthdayTooltipP = value;
                    RaisePropertyChanged("birthdayTooltip");
                }
            }
        }

        public string search
        {
            get
            {
                return searchKey;
            }

            set
            {
                if (value != searchKey)
                {
                    searchKey = value;
                    RaisePropertyChanged("search");
                    searchDataGrid(searchKey);
                    group();
                }
            }
        }

        public int selected
        {
            get
            {
                return selectedIndex;
            }

            set
            {
                if (value != selectedIndex)
                {
                    selectedIndex = value;
                    RaisePropertyChanged("selected");
                    filterDataGrid(selectedIndex);
                    group();
                }
            }
        }

        private void filterDataGrid(int selectedIndex)
        {
            if (memberView != null)
            {
                if (selectedIndex == 0)
	            {
		            memberView.Filter = null;
                    this.groupByGroups = true;
	            }
                else if (selectedIndex == 1)
	            {
                    memberView.Filter = new Predicate<object>(x => ((Member)x).group == 0);
                    this.groupByGroups = false;
	            }
                else
                {
                    memberView.Filter = new Predicate<object>(x => ((Member)x).group == 1);
                    this.groupByGroups = false;
                }
            }
        }

        public ICollectionView memberView
        {
            get
            {
                return memberViewP;
            }
            set
            {
                if (value != memberViewP)
                {
                    memberViewP = value;
                    RaisePropertyChanged("memberView");
                }
            }
        }

        public ICollectionView examView
        {
            get
            {
                return examViewP;
            }
            set
            {
                if (value != examViewP)
                {
                    examViewP = value;
                    RaisePropertyChanged("examView");
                }
            }
        }

        public ICollectionView seminarView
        {
            get
            {
                return seminarViewP;
            }
            set
            {
                if (value != seminarViewP)
                {
                    seminarViewP = value;
                    RaisePropertyChanged("seminarView");
                }
            }
        }

        public DataGridViewModel()
        {
            this.db = new Database();
            this.membersP = new MemberList();
            this.groupByGroups = true;
            this.loadDataBase();
            this.editModeChecked = false;
            this.readOnly = true;
        }

        public void loadDataBase()
        {
            search = string.Empty;
            importedContent = this.db.content();
            this.members = this.importedContent.Item1;
            this.exam = this.importedContent.Item2;
            memberView = CollectionViewSource.GetDefaultView(members);
            group();
            List<Member> memberCopy = new List<Member>();
            foreach (Member member in members)
	        {
		        memberCopy.Add(member.Clone());
	        }
            this.an = new Anniversary(memberCopy);
            this.birthday = this.an.nextBirthday().Item1;
            this.birthdayTooltip = this.an.nextBirthday().Item2;
            this.anniversary = this.an.nextAnniversary().Item1;
            this.anniversaryTooltip = this.an.nextAnniversary().Item2;
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

        private void group()
        {
            if (memberView != null)
            {
                memberView.GroupDescriptions.Clear();
            }
            else
            {
                return;
            }

            if (memberView.CanGroup == true)
            {
                memberView.GroupDescriptions.Add(new PropertyGroupDescription("active"));
                if (this.groupByGroups == true)
                {
                    memberView.GroupDescriptions.Add(new PropertyGroupDescription("group"));
                }
            }
        }

        private void searchDataGrid(string key)
        {
            if (memberView != null)
            {
                memberView.Filter = new Predicate<object>(x => ((Member)x).Search(key) == true);
            }
        }

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
