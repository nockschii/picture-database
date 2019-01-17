using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Model;
using System.Collections.Generic;
using System.Windows.Input;
using log4net;
using System.Reflection;

namespace PicDB.ViewModel
{
    class MainWindowViewModel : IMainWindowViewModel
    {
        private BusinessLayer _bl;
        private ICommand _command1;
        private ICommand _command2;
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        public MainWindowViewModel()
        {
            logger.Error("Testing MWVM message");
            _bl = new BusinessLayer(DALFactory.CreateDAL());
            List<PictureModel> PMList = (List<PictureModel>) _bl.GetPictures();
            List<IPictureViewModel> PVMList = new List<IPictureViewModel>();

            foreach (var item in PMList)
            {
                PVMList.Add(new PictureViewModel(item));
            }

            List = new PictureListViewModel(PVMList);
            CurrentPicture = List.CurrentPicture;
            Search = new SearchViewModel(List);
            PhotographerList = new PhotographerListViewModel();
            CurrentPhotographer = PhotographerList.CurrentPhotographer;
        }

        /// <summary>
        /// ViewModel with a list of all photographers
        /// </summary>
        public IPhotographerListViewModel PhotographerList { get; set; }

        /// <summary>
        /// The current photographer ViewModel
        /// </summary>
        public IPhotographerViewModel CurrentPhotographer { get; set; }

        /// <summary>
        /// The current picture ViewModel
        /// </summary>
        public IPictureViewModel CurrentPicture { get; set; }

        /// <summary>
        /// ViewModel with a list of all Pictures
        /// </summary>
        public IPictureListViewModel List { get; }

        /// <summary>
        /// Search ViewModel
        /// </summary>
        public ISearchViewModel Search { get; }

        /// <summary>
        /// Command to set photographer to picture
        /// </summary>
        public ICommand SetPhotographer_command
        {
            get
            {
                return _command1 ?? (_command1 = new RelayCommand(() => SetPhotographer(), true));
            }
        }

        private void SetPhotographer()
        {
            _bl.SetPhotographer(((PictureViewModel) CurrentPicture).Picture, ((PhotographerViewModel)CurrentPhotographer).Photographer);
        }
    }
}
