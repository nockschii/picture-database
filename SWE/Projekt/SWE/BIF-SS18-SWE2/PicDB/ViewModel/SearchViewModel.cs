using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Model;

namespace PicDB.ViewModel
{
    class SearchViewModel : ISearchViewModel
    {
        private BusinessLayer _bl = new BusinessLayer(DALFactory.CreateDAL());
        private PictureListViewModel _pListViewModel;
        private ICommand _command;

        public SearchViewModel() {}

        public SearchViewModel(IPictureListViewModel plvm)
        {
            _pListViewModel = (PictureListViewModel) plvm;
        }

        /// <summary>
        /// The search text
        /// </summary>
        public string SearchText { get; set; }

        /// <summary>
        /// True, if a search is active
        /// </summary>
        public bool IsActive => !String.IsNullOrEmpty(SearchText);

        /// <summary>
        /// Number of photos found.
        /// </summary>
        public int ResultCount => _pListViewModel.Count;

        /// <summary>
        /// Command to search a picture
        /// </summary>
        public ICommand Search_command
        {
            get
            {
                return _command ?? (_command = new RelayCommand(() => Search(), true));
            }
        }

        private void Search()
        {
            List<IPictureModel> tmp_pm = new List<IPictureModel>();
            List<IPictureViewModel> tmp_pvm = new List<IPictureViewModel>();

            tmp_pm = _bl.GetPictures(SearchText, null, null, null).ToList();

            foreach (var item in tmp_pm)
            {
                PictureViewModel pvm = new PictureViewModel((PictureModel)item);
                tmp_pvm.Add(pvm);
            }

            _pListViewModel.List = tmp_pvm;
        }
    }
}
