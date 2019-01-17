using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Model;
using PicDB.ViewModel;

namespace PicDB.ViewModel
{
    class PictureViewModel : IPictureViewModel
    {
        private BusinessLayer _bl = new BusinessLayer(DALFactory.CreateDAL()); 
        private ICommand _command1;
        private ICommand _command2;
        public PictureModel Picture { get; private set; }

        public PictureViewModel () {}
        public PictureViewModel (PictureModel picture)
        {
            Picture = picture;
            IPTC = new IPTCViewModel((IPTCModel)Picture.IPTC);
            EXIF = new EXIFViewModel((EXIFModel)Picture.EXIF);
            Camera = new CameraViewModel((CameraModel)Picture.Camera);
        }

        /// <summary>
        /// Database primary key
        /// </summary>
        public int ID => Picture.ID;

        /// <summary>
        /// Name of the file
        /// </summary>
        public string FileName => Picture.FileName;

        /// <summary>
        /// Full file path, used to load the image
        /// </summary>
        public string FilePath => ImageManager.Instance.FilePath + "/" + FileName;

        /// <summary>
        /// The line below the Picture. Format: {IPTC.Headline|FileName} (by {Photographer|IPTC.ByLine}).
        /// </summary>
        public string DisplayName => Picture.FileName+" (by "+ Photographer.FirstName + " " + Photographer.LastName + ")";

        /// <summary>
        /// The IPTC ViewModel
        /// </summary>
        public IIPTCViewModel IPTC { get; set; }

        /// <summary>
        /// The EXIF ViewModel
        /// </summary>
        public IEXIFViewModel EXIF { get; set; }

        /// <summary>
        /// The Photographer ViewModel
        /// </summary>
        public IPhotographerViewModel Photographer => new PhotographerViewModel((PhotographerModel) _bl.SelectSetPhotographer(Picture));

        /// <summary>
        /// The Camera ViewModel
        /// </summary>
        public ICameraViewModel Camera { get; set; }

        /// <summary>
        /// Command to edit IPTC data
        /// </summary>
        public ICommand EditIPTC_command
        {
            get
            {
                return _command1 ?? (_command1 = new RelayCommand(() => EditIPTC(), true));
            }
        }

        private void EditIPTC()
        {
            _bl.EditIPTC(Picture);
        }

        /// <summary>
        /// Command to create a report
        /// </summary>
        public ICommand NewReport_command
        {
            get { return _command2 ?? (_command2 = new RelayCommand(() => NewReport(), true)); }
        }

        private void NewReport()
        {
            _bl.NewReport(Picture);
        }
    }
}
