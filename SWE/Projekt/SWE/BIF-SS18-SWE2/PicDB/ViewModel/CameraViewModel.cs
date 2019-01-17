using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Model;

namespace PicDB.ViewModel
{
    class CameraViewModel : ICameraViewModel
    {
        private CameraModel _camMdl;
        public CameraViewModel () {}
        public CameraViewModel (CameraModel CamMdl)
        {
            _camMdl = CamMdl;
        }

        /// <summary>
        /// Database primary key
        /// </summary>
        public int ID => throw new NotImplementedException();

        /// <summary>
        /// Name of the producer
        /// </summary>
        public string Producer { get => _camMdl.Producer; set => _camMdl.Producer = value; }

        /// <summary>
        /// Name of camera
        /// </summary>
        public string Make { get => _camMdl.Make; set => _camMdl.Make = value; }

        /// <summary>
        /// Optional: date, when the camera was bought
        /// </summary>
        public DateTime? BoughtOn { get => _camMdl.BoughtOn; set => _camMdl.BoughtOn = value; }

        /// <summary>
        /// Notes
        /// </summary>
        public string Notes { get => _camMdl.Notes; set => _camMdl.Notes = value; }

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
                if (!IsValidMake || !IsValidProducer || !IsValidBoughtOn) return false;
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
                if (!IsValidMake || !IsValidProducer || !IsValidBoughtOn) return "Make, Producer or BoughtOn is not valid!";
                return "";
            }
        }

        /// <summary>
        /// returns true if the producer name is valid
        /// </summary>
        public bool IsValidProducer
        {
            get
            {
                if (_camMdl.Producer == String.Empty || _camMdl.Producer == null) return false;
                return true;
            }
        }

        /// <summary>
        /// returns true if the make is valid
        /// </summary>
        public bool IsValidMake
        {
            get
            {
                if (_camMdl.Make == String.Empty || _camMdl.Make == null) return false;
                return true;
            }
        }

        /// <summary>
        /// returns true if the "bought on" date is valid
        /// </summary>
        public bool IsValidBoughtOn
        {
            get
            {
                if (_camMdl.BoughtOn > DateTime.Today) return false;
                return true;
            }
        }

        /// <summary>
        /// Max ISO Value for good results. 0 means "not defined"
        /// </summary>
        public decimal ISOLimitGood { get => _camMdl.ISOLimitGood; set => _camMdl.ISOLimitGood = value; }

        /// <summary>
        /// Max ISO Value for acceptable results. 0 means "not defined"
        /// </summary>
        public decimal ISOLimitAcceptable { get => _camMdl.ISOLimitAcceptable; set => _camMdl.ISOLimitAcceptable = value; }

        /// <summary>
        /// Translates a given ISO value to a ISO rating
        /// </summary>
        /// <param name="iso"></param>
        /// <returns></returns>
        public ISORatings TranslateISORating(decimal iso)
        {
            throw new NotImplementedException();
        }
    }
}
