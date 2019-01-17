using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Model;

namespace PicDB.ViewModel
{
    class CameraListViewModel : ICameraListViewModel
    {
        /// <summary>
        /// List of all CameraListViewModel
        /// </summary>
        public IEnumerable<ICameraViewModel> List => throw new NotImplementedException();

        /// <summary>
        /// The currently selected CameraListViewModel
        /// </summary>
        public ICameraViewModel CurrentCamera => new CameraViewModel();
    }
}
