using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Model;

namespace PicDB.ViewModel
{
    class EXIFViewModel : IEXIFViewModel
    {
        private EXIFModel _exifMdl = new EXIFModel();

        public EXIFViewModel() { }
        public EXIFViewModel(EXIFModel exifm)
        {
            _exifMdl = exifm;
            Make = _exifMdl.Make;
            FNumber = _exifMdl.FNumber;
            ExposureTime = _exifMdl.ExposureTime;
            ISOValue = _exifMdl.ISOValue;
            Flash = _exifMdl.Flash;
            ExposureProgram = _exifMdl.ExposureProgram.ToString();
        }

        /// <summary>
        /// Name of camera
        /// </summary>
        public string Make { get; set; }

        /// <summary>
        /// Aperture number
        /// </summary>
        public decimal FNumber { get; set; }

        /// <summary>
        /// Exposure time
        /// </summary>
        public decimal ExposureTime { get; set; }

        /// <summary>
        /// ISO value
        /// </summary>
        public decimal ISOValue { get; set; }

        /// <summary>
        /// Flash yes/no
        /// </summary>
        public bool Flash { get; set; }

        /// <summary>
        /// The Exposure Program as string
        /// </summary>
        public string ExposureProgram { get; set; }

        /// <summary>
        /// The Exposure Program as image resource
        /// </summary>
        public string ExposureProgramResource => _exifMdl.ExposureProgram.ToString();

        /// <summary>
        /// Gets or sets a optional camera view model
        /// </summary>
        public ICameraViewModel Camera { get; set; }

        /// <summary>
        /// Returns a ISO rating if a camera is set.
        /// </summary>
        public ISORatings ISORating
        {
            get
            {
                if(_exifMdl.ISOValue == 200 || _exifMdl.ISOValue == 400)
                {
                  return ISORatings.Good;
                }

                if(_exifMdl.ISOValue == 800)
                {
                    return ISORatings.Acceptable;
                }

                if(_exifMdl.ISOValue == 1600)
                {
                    return ISORatings.Noisey;
                }
                return ISORatings.NotDefined;
            }
        }

        /// <summary>
        /// Returns a image resource of a ISO rating if a camera is set.
        /// </summary>
        public string ISORatingResource => throw new NotImplementedException();
    }
}
