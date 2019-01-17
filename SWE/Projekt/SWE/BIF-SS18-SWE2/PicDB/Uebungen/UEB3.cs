using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB;
using PicDB.Model;
using PicDB.ViewModel;

namespace Uebungen
{
    public class UEB3 : IUEB3
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

        public IDataAccessLayer GetDataAccessLayer()
        {
            return new DataAccessLayerMock();
        }

        public ISearchViewModel GetSearchViewModel()
        {
            return new SearchViewModel();
        }
    }
}
