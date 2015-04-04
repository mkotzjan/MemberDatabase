// <copyright file="AddMemberViewModel.cs" company="ChaosBelcebub">
//     Copyright (c) ChaosBelcebub. All rights reserved.
// </copyright>

namespace MemberDatabase.ViewModel
{
    using MemberDatabase.Model;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
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
        private bool activeP = true;
        private string emailP;
        private ObservableCollection<DateItem> examListP;
        private ObservableCollection<DateItem> seminarListP;
        private int selectedGroupP;
        private string addressP;

        private ICommand saveCommandP;
        private ICommand addCommandP;
        private ICommand clearCommandP;
        private ICommand addExamDateP;
        private ICommand addSeminarDateP;
        private ICommand deleteExamCommandP;
        private ICommand deleteSeminarCommandP;
        private Database db;

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

        public DateTime? birthday
        {
            get
            {
                return birthdayP;
            }

            set
            {
                if (birthdayP != value)
                {
                    birthdayP = value;
                    RaisePropertyChanged("birthday");
                }
            }
        }

        public DateTime? accession
        {
            get
            {
                return accessionP;
            }

            set
            {
                if (accessionP != value)
                {
                    accessionP = value;
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

        public string email
        {
            get
            {
                return emailP;
            }

            set
            {
                if (emailP != value)
                {
                    emailP = value;
                    RaisePropertyChanged("email");
                }
            }
        }

        public ICommand addCommand
        {
            get
            {
                if (this.addCommandP == null)
                {
                    this.addCommandP = new RelayCommand(param => this.addMember());
                }
                return this.addCommandP;
            }
        }

        public ICommand addExamDate
        {
            get
            {
                if (this.addExamDateP == null)
                {
                    this.addExamDateP = new RelayCommand(param => this.addExam());
                }
                return this.addExamDateP;
            }
        }

        public ICommand addSeminarDate
        {
            get
            {
                if (this.addSeminarDateP == null)
                {
                    this.addSeminarDateP = new RelayCommand(param => this.addSeminar());
                }
                return this.addSeminarDateP;
            }
        }

        public ICommand deleteExamCommand
        {
            get
            {
                if (this.deleteExamCommandP == null)
	            {
		            this.deleteExamCommandP = new RelayCommand(deleteExam);
	            }
                return deleteExamCommandP;
            }
        }

        public ICommand deleteSeminarCommand
        {
            get
            {
                if (this.deleteSeminarCommandP == null)
                {
                    this.deleteSeminarCommandP = new RelayCommand(deleteSeminar);
                }
                return deleteSeminarCommandP;
            }
        }

        private void deleteExam(object dateItem)
        {
            DateItem dateItemClicked = dateItem as DateItem;
            if (this.examListP.Count > 1)
            {
                this.examListP.Remove(dateItemClicked);
            }
            else
            {
                this.examListP[0] = new DateItem();
            }
        }

        public void deleteSeminar(object dateItem)
        {
            DateItem dateItemClicked = dateItem as DateItem;
            if (this.seminarListP.Count > 1)
            {
                this.seminarListP.Remove(dateItemClicked);
            }
            else
            {
                this.seminarListP[0] = new DateItem();
            }
        }

        public ObservableCollection<DateItem> exam
        {
            get
            {
                return examListP;
            }

            set
            {
                if (value != examListP)
                {
                    examListP = value;
                    RaisePropertyChanged("exam");
                }
            }
        }

        public ObservableCollection<DateItem> seminar
        {
            get
            {
                return seminarListP;
            }

            set
            {
                if (value != seminarListP)
                {
                    seminarListP = value;
                    RaisePropertyChanged("seminar");
                }
            }
        }

        public int selected
        {
            get
            {
                return selectedGroupP;
            }

            set
            {
                if (value != selectedGroupP)
                {
                    selectedGroupP = value;
                    RaisePropertyChanged("selected");
                }
            }
        }

        public string address
        {
            get
            {
                return addressP;
            }

            set
            {
                if (value != addressP)
                {
                    addressP = value;
                    RaisePropertyChanged("address");
                }
            }
        }

        private void addMember()
        {
            Member member = new Member { firstName = firstNameP, lastName = lastNameP, birthday = birthdayP, accession = accessionP, active = activeP, group = selectedGroupP, email = emailP, adress = addressP, exam = examListP, seminar = seminarListP };
            db.add(member);
        }

        private void addExam()
        {
            if (examListP[examListP.Count - 1].date != null)
            {
                examListP.Add(new DateItem());
                RaisePropertyChanged("exam");
            }
        }

        private void addSeminar()
        {
            if (seminarListP[seminarListP.Count - 1].date != null)
            {
                seminarListP.Add(new DateItem());
                RaisePropertyChanged("seminar");
            }
        }

        /// <summary>
        /// Initializes a new instance of the AddMemberViewModel class
        /// </summary>
        public AddMemberViewModel()
        {
            db = new Database();

            firstName = string.Empty;
            lastName = string.Empty;
            active = true;
            email = string.Empty;
            address = string.Empty;
            exam = new ObservableCollection<DateItem>();
            exam.Add(new DateItem());
            seminar = new ObservableCollection<DateItem>();
            seminar.Add(new DateItem());
            selected = 0;
        }
    }
}
