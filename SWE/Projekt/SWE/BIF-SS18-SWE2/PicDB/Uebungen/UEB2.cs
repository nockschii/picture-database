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
    public class UEB2 : IUEB2
    {
        public void HelloWorld()
        {
        }

        public IBusinessLayer GetBusinessLayer()
        {
            return new BusinessLayer(new DataAccessLayerMock());
        }

        public BIF.SWE2.Interfaces.ViewModels.IMainWindowViewModel GetMainWindowViewModel()
        {
            return new MainWindowViewModel();
        }

        public BIF.SWE2.Interfaces.Models.IPictureModel GetPictureModel(string filename)
        {
            return new PictureModel(filename);
        }

        public BIF.SWE2.Interfaces.ViewModels.IPictureViewModel GetPictureViewModel(BIF.SWE2.Interfaces.Models.IPictureModel mdl)
        {
            return new PictureViewModel((PictureModel) mdl);
        }

        public void TestSetup(string picturePath)
        {
            ImageManager.Instance.FilePath = picturePath;
        }

        public ICameraModel GetCameraModel(string producer, string make)
        {
            return new CameraModel(producer, make);
        }

        public ICameraViewModel GetCameraViewModel(ICameraModel mdl)
        {
            return new CameraViewModel((CameraModel)mdl);
        }
    }
}
