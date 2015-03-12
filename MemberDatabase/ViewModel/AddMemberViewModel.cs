// <copyright file="AddMemberViewModel.cs" company="ChaosBelcebub">
//     Copyright (c) ChaosBelcebub. All rights reserved.
// </copyright>

namespace MemberDatabase.ViewModel
{
    using MemberDatabase.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    /// <summary>
    /// Class AddMemberViewModel.
    /// Used for AddMemberView.
    /// </summary>
    class AddMemberViewModel : BaseViewModel
    {
        // Private variables for displayed fields
        private string firstNameP;
        private string lastNameP;
        private DateTime? birthdayP;
        private DateTime? accessionP;
        private bool activeP;

        private ICommand saveCommandP;

        /// <summary>
        /// String firstName. Contains the first name of the new member.
        /// </summary>
        public string firstName
        {
            get
            {
                return firstNameP;
            }

            set
            {
                if (firstNameP != value)
                {
                    firstNameP = value;
                    RaisePropertyChanged("firstName");
                }
            }
        }

        /// <summary>
        /// String lastName. Contains the last name of the new member.
        /// </summary>
        public string lastName
        {
            get
            {
                return lastNameP;
            }

            set
            {
                if (lastNameP != value)
                {
                    lastNameP = value;
                    RaisePropertyChanged("lastName");
                }
            }
        }

        public string birthday
        {
            get
            {
                if (birthdayP == null)
                {
                    return string.Empty;
                }
                return Convert.ToDateTime(birthdayP).ToString("dd'.'MM'.'yyyy");
            }

            set
            {
                if (birthdayP != Convert.ToDateTime(value));
                {
                    birthdayP = Convert.ToDateTime(value);
                    RaisePropertyChanged("birthday");
                }
            }
        }

        public string accession
        {
            get
            {
                if (accessionP == null)
                {
                    return string.Empty;
                }
                return Convert.ToDateTime(accessionP).ToString("dd'.'MM'.'yyyy");
            }

            set
            {
                if (accessionP != Convert.ToDateTime(value));
                {
                    accessionP = Convert.ToDateTime(value);
                    RaisePropertyChanged("accession");
                }
            }
        }

        public bool active
        {
            get
            {
                return activeP;
            }

            set
            {
                if (activeP != value)
                {
                    activeP = value;
                    RaisePropertyChanged("active");
                }
            }
        }

        public ICommand saveCommand
        {
            get
            {
                if (this.saveCommandP == null)
                {
                    this.saveCommandP = new RelayCommand(param => this.saveMember());
                }
                return this.saveCommandP;
            }
        }

        private void saveMember()
        {
            System.Windows.MessageBox.Show("Mitglied: " + firstName + ", " + lastName);
        }

        /// <summary>
        /// Initializes a new instance of the AddMemberViewModel class
        /// </summary>
        public AddMemberViewModel()
        {
            firstNameP = string.Empty;
            lastNameP = string.Empty;
            activeP = true;
        }
    }
}
