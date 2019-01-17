using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Model;

namespace PicDB.ViewModel
{
    class PhotographerListViewModel : ViewModel, IPhotographerListViewModel
    {
        private BusinessLayer _bl;

        public PhotographerListViewModel()
        {
            _bl = new BusinessLayer(DALFactory.CreateDAL());
            List<PhotographerModel> PMList = (List<PhotographerModel>)_bl.GetPhotographers();
            List<IPhotographerViewModel> PVMList = new List<IPhotographerViewModel>();

            foreach (var item in PMList)
            {
                PVMList.Add(new PhotographerViewModel(item));
            }
            List = PVMList;
            CurrentPhotographer = List.First();
        }
        /// <summary>
        /// List of all PhotographerViewModel
        /// </summary>
        public IEnumerable<IPhotographerViewModel> List { get; set; }

        /// <summary>
        /// The currently selected PhotographerViewModel
        /// </summary>
        public IPhotographerViewModel CurrentPhotographer
        {
            get => photographer;
            set
            {
                if (photographer != value)
                {
                    photographer = value;
                    //MessageBox.Show("new List");
                    OnPropertyChanged("CurrentPhotographer");
                }
            }
        }

        private IPhotographerViewModel photographer;
    }
}
