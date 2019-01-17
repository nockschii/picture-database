using BIF.SWE2.Interfaces.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace PicDB.ViewModel
{
    class PictureListViewModel : ViewModel, IPictureListViewModel
    {
        private IEnumerable<IPictureViewModel> list;
        private BusinessLayer _bl = new BusinessLayer(DALFactory.CreateDAL());
        private ICommand _command;

        public PictureListViewModel(List<IPictureViewModel> lst)
        {
            List = lst;
            CurrentPicture = List.First();
            Count = List.Count();
            CurrentIndex = CurrentPicture.ID;
            CurrentPictureAsString = CurrentPicture.FileName;
        }

        public PictureListViewModel() { }

        /// <summary>
        /// Current PictureViewModel
        /// </summary>
        public IPictureViewModel CurrentPicture { get; set; }

        /// <summary>
        /// List with all PictureViewModels
        /// </summary>
        public IEnumerable<IPictureViewModel> List
        {
            get => list;
            set
            {
                if (list != value)
                {
                    list = value;
                    OnPropertyChanged("List");
                }
            }
        }

        /// <summary>
        /// Previous Picture
        /// </summary>
        public IEnumerable<IPictureViewModel> PrevPictures { get; }

        /// <summary>
        /// Next Picture
        /// </summary>
        public IEnumerable<IPictureViewModel> NextPictures { get; }

        /// <summary>
        /// Count of all pictures in List
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// 
        /// </summary>
        public int CurrentIndex { get; }

        /// <summary>
        /// Filename of current picture in a string
        /// </summary>
        public string CurrentPictureAsString { get; }

        /// <summary>
        /// Command for all Tags
        /// </summary>
        public ICommand AllTags_command
        {
            get { return _command ?? (_command = new RelayCommand(() => AllTags(), true)); }
        }

        private void AllTags()
        {
            _bl.AllTagsReport(List);
        }
    }
}
