namespace MemberDatabase.Model
{
    using System;
    using System.Collections.Generic;
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

        public bool Search(string key)
        {
            if (key == string.Empty)
            {
                return true;
            }
            
            if (key != string.Empty)
            {
                if (this.firstName.Contains(key) || this.lastName.Contains(key) || Convert.ToDateTime(this.birthday).ToString("dd'.'MM'.'yyyy").Contains(key) || Convert.ToDateTime(this.accession).ToString("dd'.'MM'.'yyyy").Contains(key))
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
            Member member = new Member { firstName = _firstName, lastName = _lastName, birthday = _birthday, accession = _accession, active = _active };
            member.setID(_id);
            return member;
        }
    }
}
