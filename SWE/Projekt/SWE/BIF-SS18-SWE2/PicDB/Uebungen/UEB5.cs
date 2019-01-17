using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB;
using PicDB.Model;
using PicDB.ViewModel;

namespace Uebungen
{
    public class UEB5 : IUEB5
    {
        public void HelloWorld()
        {
        }

        public IBusinessLayer GetBusinessLayer()
        {
            return new BusinessLayer(new DataAccessLayerMock());
        }

        public void TestSetup(string picturePath)
        {
            ImageManager.Instance.FilePath = picturePath;
        }

        public IPhotographerModel GetEmptyPhotographerModel()
        {
            return new PhotographerModel();
        }

        public IPhotographerViewModel GetPhotographerViewModel(IPhotographerModel mdl)
        {
            return new PhotographerViewModel((PhotographerModel)mdl);
        }

        public ICameraModel GetEmptyCameraModel()
        {
            return new CameraModel();
        }

        public ICameraViewModel GetCameraViewModel(ICameraModel mdl)
        {
            return new CameraViewModel((CameraModel)mdl);
        }
    }
}
