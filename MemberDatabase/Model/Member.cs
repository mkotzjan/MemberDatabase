namespace MemberDatabase.Model
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a member
    /// </summary>
    public class Member : INotifyPropertyChanged
    {
        int _id;

        public void setID(int id)
        {
            this._id = id;
        }

        public int getID()
        {
            return this._id;
        }
        string _firstName;
        /// <summary>
        /// Gets or sets the firstname.
        /// </summary>
        public string firstName
        {
            get
            {
                return this._firstName;
            }
            set
            {
                if (this._firstName != value)
                {
                    this._firstName = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }

        string _lastName;
        /// <summary>
        /// Gets or sets the lastname.
        /// </summary>
        public string lastName
        {
            get
            {
                return this._lastName;
            }
            set
            {
                if (this._lastName != value)
                {
                    this._lastName = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }

        DateTime? _birthday;
        /// <summary>
        /// Gets or sets the birthday.
        /// </summary>
        public DateTime? birthday
        {
            get
            {
                return this._birthday;
            }
            set
            {
                if (this._birthday != value)
                {
                    this._birthday = value;
                    this.RaisePropertyChanged("Birthday");
                }
            }
        }

        DateTime? _accession;
        /// <summary>
        /// Gets or sets the accession day.
        /// </summary>
        public DateTime? accession
        {
            get
            {
                return this._accession;
            }
            set
            {
                if (this._accession != value)
                {
                    this._accession = value;
                    this.RaisePropertyChanged("Accession");
                }
            }
        }

        int _group;

        /// <summary>
        /// Gets or sets the integer value of the group.
        /// </summary>
        public int group
        {
            get
            {
                return this._group;
            }

            set
            {
                if (value != this._group)
                {
                    this._group = value;
                    this.RaisePropertyChanged("group");
                }
            }
        }

        bool _active;
        /// <summary>
        /// Gets or sets the active state.
        /// </summary>
        public bool active
        {
            get
            {
                return this._active;
            }
            set
            {
                if (this._active != value)
                {
                    this._active = value;
                    this.RaisePropertyChanged("Active");
                }
            }
        }

        string _email;

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string email
        {
            get
            {
                return this._email;
            }

            set
            {
                if (value != this._email)
                {
                    this._email = value;
                    this.RaisePropertyChanged("email");
                }
            }
        }

        string _adress;

        public string adress
        {
            get
            {
                return this._adress;
            }

            set
            {
                if (value != this._adress)
                {
                    this._adress = value;
                    this.RaisePropertyChanged("adress");
                }
            }
        }

        ObservableCollection<DateItem> _exam;

        /// <summary>
        /// Gets or sets the exam list.
        /// </summary>
        public ObservableCollection<DateItem> exam
        {
            get
            {
                return this._exam;
            }

            set
            {
                if (value != this._exam)
                {
                    this._exam = value;
                    this.RaisePropertyChanged("exam");
                }
            }
        }

        ObservableCollection<DateItem> _seminar;

        /// <summary>
        /// Gets or sets the seminar list.
        /// </summary>
        public ObservableCollection<DateItem> seminar
        {
            get
            {
                return this._seminar;
            }

            set
            {
                if (value != this._seminar)
                {
                    this._seminar = value;
                    RaisePropertyChanged("seminar");
                }
            }
        }

        public bool Search(string key)
        {
            if (key == string.Empty)
            {
                return true;
            }
            
            if (key != string.Empty)
            {
                key = key.ToLower();
                if (this.birthday != null && Convert.ToDateTime(this.birthday).ToString("dd'.'MM'.'yyyy").ToLower().Contains(key))
                {
                    return true;
                }
                else if (this.accession != null && Convert.ToDateTime(this.accession).ToString("dd'.'MM'.'yyyy").ToLower().Contains(key))
                {
                    return true;
                }
                else if (this.firstName.ToLower().Contains(key) || this.lastName.ToLower().Contains(key))
                {
                    return true;
                }
            }
            return false;
        }

        void RaisePropertyChanged(string prop)
        {
            if (this.PropertyChanged != null) { this.PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public Member Clone()
        {
            Member member = new Member { firstName = this._firstName, lastName = this._lastName, birthday = this._birthday, accession = this._accession, active = this._active, group = this._group, email = this._email, adress = this._adress, exam = this._exam, seminar = this._seminar };
            member.setID(_id);
            return member;
        }
    }
}
