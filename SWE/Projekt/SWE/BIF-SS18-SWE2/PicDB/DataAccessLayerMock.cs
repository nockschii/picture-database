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


namespace PicDB
{
    class DataAccessLayerMock : IDataAccessLayer
    {
        private List<PictureModel> _pictureList = new List<PictureModel>()
        {
            new PictureModel()
            {
                ID = 12,
                FileName = "Img1.jpg",
                EXIF = new EXIFModel()
                {
                    Make = "Make1",
                    FNumber = 1,
                    ExposureTime = 2,
                    ISOValue = 3
                },
                IPTC = new IPTCModel()
                {
                    Keywords = "Img1",
                    ByLine = "byImg1",
                    CopyrightNotice = "cpyrnotice",
                    Headline = "1",
                    Caption = "hat"
                }
            },
            new PictureModel()
            {
                ID = 123,
                FileName = "blume",
                EXIF = new EXIFModel()
                {
                    Make = "Nikon",
                    FNumber = 1,
                    ExposureTime = 1,
                    ISOValue = 1
                },
                IPTC = new IPTCModel()
                {
                    Keywords = "blume",
                    ByLine = "byblume",
                    CopyrightNotice = "cpyrnotice",
                    Headline = "1",
                    Caption = "hat"
                }
            },
            new PictureModel()
            {
                ID = 1234,
                FileName = "Img2.jpg",
                EXIF = new EXIFModel()
                {
                    Make = "Make2",
                    FNumber = 1,
                    ExposureTime = 2,
                    ISOValue = 3
                },
                IPTC = new IPTCModel()
                {
                    Keywords = "Img2",
                    ByLine = "byImg2",
                    CopyrightNotice = "cpyrnotice2",
                    Headline = "2",
                    Caption = "hat2"
                }
            },
            new PictureModel()
            {
                ID = 12345,
                FileName = "Img3.jpg",
                EXIF = new EXIFModel()
                {
                    Make = "Make3",
                    FNumber = 1,
                    ExposureTime = 2,
                    ISOValue = 3
                },
                IPTC = new IPTCModel()
                {
                    Keywords = "Img3",
                    ByLine = "byImg3",
                    CopyrightNotice = "cpyrnotice3",
                    Headline = "3",
                    Caption = "hat3"
                }
            },
            new PictureModel()
            {
                ID = 123456,
                FileName = "Img4.jpg",
                EXIF = new EXIFModel()
                {
                    Make = "Make4",
                    FNumber = 1,
                    ExposureTime = 2,
                    ISOValue = 3
                },
                IPTC = new IPTCModel()
                {
                    Keywords = "Img4",
                    ByLine = "byImg4",
                    CopyrightNotice = "cpyrnotice",
                    Headline = "4",
                    Caption = "hat4"
                }
            }
        };

        private List<CameraModel> _cameralist = new List<CameraModel>() { new CameraModel() { ID = 1234 } };

        private List<PhotographerModel> _pglist = new List<PhotographerModel>() { new PhotographerModel() { ID = 1234 } };

        /// <summary>
        /// Deletes a Photographer. A Exception is thrown if a Photographer is still linked to a picture.
        /// </summary>
        /// <param name="ID"></param>
        public void DeletePhotographer(int ID)
        {
            var itemToRemove = _pglist.Single(r => r.ID == ID);
            _pglist.Remove(itemToRemove);
        }

        /// <summary>
        /// Deletes a Picture from the database.
        /// </summary>
        /// <param name="ID"></param>
        public void DeletePicture(int ID)
        {
            var itemToRemove = _pictureList.Single(r => r.ID == ID);
            _pictureList.Remove(itemToRemove);
        }

        /// <summary>
        /// Returns ONE Camera
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ICameraModel GetCamera(int ID)
        {
            return _cameralist.Find(item => item.ID == ID);
        }

        /// <summary>
        /// Returns a list of ALL Cameras.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICameraModel> GetCameras()
        {
            return _cameralist;
        }

        /// <summary>
        /// Returns ONE Photographer
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IPhotographerModel GetPhotographer(int ID)
        {
            return _pglist.Find(item => item.ID == ID);
        }

        /// <summary>
        /// Returns a list of ALL Photographers.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPhotographerModel> GetPhotographers()
        {
            return _pglist;
        }

        /// <summary>
        /// Returns ONE Picture from the database.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public IPictureModel GetPicture(int ID)
        {
            return _pictureList.Find(item => item.ID == ID);
        }

        /// <summary>
        /// Returns a filterd list of Pictures from the directory, based on a database query.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPictureModel> GetPictures(string namePart, IPhotographerModel photographerParts, IIPTCModel iptcParts, IEXIFModel exifParts)
        {
            if (namePart != null)
            {
                return _pictureList.Where(x => x.FileName == namePart);
            }
            return _pictureList;
        }

        /// <summary>
        /// Saves all changes to the database with given picture.
        /// </summary>
        /// <param name="picture">picture</param>
        public void Save(IPictureModel picture)
        {
            picture.ID = 1;
            while (_pictureList.Exists(x => x.ID == picture.ID))
            {
                picture.ID++;
            }
            _pictureList.Add((PictureModel)picture);
        }

        /// <summary>
        /// Saves all changes to the database with given photographer.
        /// </summary>
        /// <param name="picture">photographer</param>
        public void Save(IPhotographerModel photographer)
        {
            _pglist.Add((PhotographerModel)photographer);
        }
    }
}
