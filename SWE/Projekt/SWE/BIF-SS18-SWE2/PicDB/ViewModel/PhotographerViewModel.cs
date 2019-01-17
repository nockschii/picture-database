using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Model;

namespace PicDB.ViewModel
{
    class PhotographerViewModel : IPhotographerViewModel
    {
        private BusinessLayer _bl = new BusinessLayer(DALFactory.CreateDAL());
        private ICommand _command;

        public PhotographerModel Photographer { get; private set; } = new PhotographerModel();

        public PhotographerViewModel() {}

        public PhotographerViewModel(PhotographerModel photographer)
        {
            Photographer = photographer;
        }

        /// <summary>
        /// First and last name of photographer
        /// </summary>
        public string FullName => FirstName + " " + LastName;

        /// <summary>
        /// Database primary key
        /// </summary>
        public int ID => Photographer.ID;

        /// <summary>
        /// Firstname, including middle name
        /// </summary>
        public string FirstName { get => Photographer.FirstName; set => Photographer.FirstName = value; }

        /// <summary>
        /// Lastname
        /// </summary>
        public string LastName { get =>Photographer.LastName; set => Photographer.LastName = value; }

        /// <summary>
        /// Birthday
        /// </summary>
        public DateTime? BirthDay { get => Photographer.BirthDay; set => Photographer.BirthDay = value; }

        /// <summary>
        /// Notes
        /// </summary>
        public string Notes { get => Photographer.Notes; set => Photographer.Notes = value; }

        /// <summary>
        /// Returns the number of Pictures
        /// </summary>
        public int NumberOfPictures => throw new NotImplementedException();

        /// <summary>
        /// Returns true, if the model is valid
        /// </summary>
        public bool IsValid
        {
            get
            {
                if (!IsValidBirthDay || !IsValidLastName) return false;
                return true;
            }
        }

        /// <summary>
        /// Returns a summary of validation errors
        /// </summary>
        public string ValidationSummary
        {
            get
            {
                if (!IsValid) return "Birthday/Lastname of Photographer not valid!";
                return "";
            }
        }

        /// <summary>
        /// returns true if the last name is valid
        /// </summary>
        public bool IsValidLastName
        {
            get
            {
                if (Photographer.LastName == String.Empty || Photographer.LastName == null) return false;
                return true;
            }
        }

        /// <summary>
        /// returns true if the birthday is valid
        /// </summary>
        public bool IsValidBirthDay
        {
            get
            {
                if (Photographer.BirthDay > DateTime.Today) return false;
                return true;
            }
        }

        /// <summary>
        /// Command for editing photographer information
        /// </summary>
        public ICommand EditPhotographer_command
        {
            get
            {
                return _command ?? (_command = new RelayCommand(() => EditPhotographer(), true));
            }
        }

        private void EditPhotographer()
        {
            _bl.EditPhotographer(Photographer);
        }
    }
}
