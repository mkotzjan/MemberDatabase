using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberDatabase.Model
{
    /// <summary>
    /// Represents a member
    /// </summary>
    public class Member : INotifyPropertyChanged
    {
        string _firstName;
        /// <summary>
        /// Gets or sets the firstname.
        /// </summary>
        public string firstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    RaisePropertyChanged("FirstName");
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
                return _lastName;
            }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    RaisePropertyChanged("LastName");
                }
            }
        }

        int? _birthday;
        /// <summary>
        /// Gets or sets the birthday.
        /// </summary>
        public int? birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                if (_birthday != value)
                {
                    _birthday = value;
                    RaisePropertyChanged("Birthday");
                }
            }
        }

        int? _accession;
        /// <summary>
        /// Gets or sets the accession day.
        /// </summary>
        public int? accession
        {
            get
            {
                return _accession;
            }
            set
            {
                if (_accession != value)
                {
                    _accession = value;
                    RaisePropertyChanged("Accession");
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
                return _active;
            }
            set
            {
                if (_active != value)
                {
                    _active = value;
                    RaisePropertyChanged("Active");
                }
            }
        }

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
