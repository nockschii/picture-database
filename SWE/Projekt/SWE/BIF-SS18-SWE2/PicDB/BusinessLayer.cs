using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PicDB
{
    class BusinessLayer : IBusinessLayer
    {
        IDataAccessLayer _dal;

        public BusinessLayer(IDataAccessLayer datal)
        {
            _dal = datal;
        }

        /// <summary>
        /// Deletes a Photographer. A Exception is thrown if a Photographer is still linked to a picture.
        /// </summary>
        /// <param name="ID"></param>
        public void DeletePhotographer(int ID)
        { 
            _dal.DeletePhotographer(ID);
        }

        /// <summary>
        /// Deletes a Picture from the database AND from the file system.
        /// </summary>
        /// <param name="ID"></param>
        public void DeletePicture(int ID)
        {
            _dal.DeletePicture(ID);
        }

        /// <summary>
        /// Extracts EXIF information from a picture. NOTE: You may simulate the action.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public IEXIFModel ExtractEXIF(string filename)
        {
            var tmplist = _dal.GetPictures(filename, null, null, null).Where(x => x.FileName == filename).ToList();

            if (tmplist.First().FileName == filename)
            {
                return tmplist.First().EXIF;
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Extracts IPTC information from a picture. NOTE: You may simulate the action.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public IIPTCModel ExtractIPTC(string filename)
        {
            var tmplist = _dal.GetPictures(filename,null,null,null).Where(x => x.FileName == filename).ToList();

            if (tmplist.First().FileName == filename)
            {
                return tmplist.First().IPTC;
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Returns ONE Camera
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ICameraModel GetCamera(int ID)
        {
            return _dal.GetCamera(ID);
        }

        /// <summary>
        /// Returns a list of ALL Cameras.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICameraModel> GetCameras()
        {
            return _dal.GetCameras();
        }

        /// <summary>
        /// Returns ONE Photographer
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IPhotographerModel GetPhotographer(int ID)
        {
            return _dal.GetPhotographer(ID);
        }

        /// <summary>
        /// Returns a list of ALL Photographers.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPhotographerModel> GetPhotographers()
        {
            return _dal.GetPhotographers();
        }

        /// <summary>
        /// Returns ONE Picture from the database.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public IPictureModel GetPicture(int ID)
        {
            return _dal.GetPicture(ID);
        }

        /// <summary>
        /// Returns a list of ALL Pictures from the directory, based on a database query.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPictureModel> GetPictures()
        {
            return _dal.GetPictures(null,null,null,null);
        }

        /// <summary>
        /// Returns a filterd list of Pictures from the directory, based on a database query.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPictureModel> GetPictures(string namePart, IPhotographerModel photographerParts, IIPTCModel iptcParts, IEXIFModel exifParts)
        {
            return _dal.GetPictures(namePart, photographerParts, iptcParts, exifParts);
        }

        /// <summary>
        /// Saves all changes to the database.
        /// </summary>
        /// <param name="picture"></param>
        public void Save(IPictureModel picture)
        {
            _dal.Save(picture);
        }

        /// <summary>
        /// Saves all changes.
        /// </summary>
        /// <param name="photographer"></param>
        public void Save(IPhotographerModel photographer)
        {
            int id = photographer.ID++;
            _dal.Save(photographer);
        }

        /// <summary>
        /// Syncs the picture folder with the database.
        /// </summary>
        public void Sync()
        {
            ImageManager.Instance.CreateDefaultPictureModels();
        }

        /// <summary>
        /// Writes IPTC information back to a picture. NOTE: You may simulate the action.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="iptc"></param>
        public void WriteIPTC(string filename, IIPTCModel iptc)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Edits IPTC data from picture
        /// </summary>
        /// <param name="picture">picture</param>
        public void EditIPTC(IPictureModel picture)
        {
            //(_dal as DataAccessLayer).EditIPTC(picture);
            ((DataAccessLayer)_dal).EditIPTC(picture);
        }

        /// <summary>
        /// Edits photographer information
        /// </summary>
        /// <param name="photographer"></param>
        public void EditPhotographer(IPhotographerModel photographer)
        {
            ((DataAccessLayer)_dal).EditPhotographer(photographer);
        }

        /// <summary>
        /// Sets the photographer to picture
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="photographer"></param>
        public void SetPhotographer(IPictureModel picture, IPhotographerModel photographer)
        {
            //(_dal as DataAccessLayer).SetPhotographer(picture, photographer);
            ((DataAccessLayer)_dal).SetPhotographer(picture, photographer);
        }

        /// <summary>
        /// Selects set photographer from picture
        /// </summary>
        /// <param name="picture"></param>
        /// <returns>PhotographerModel</returns>
        public IPhotographerModel SelectSetPhotographer(IPictureModel picture)
        {
            //(_dal as DataAccessLayer).SelectSetPhotographer(picture);
            return ((DataAccessLayer)_dal).SelectSetPhotographer(picture);
        }

        /// <summary>
        /// Saves ReportPDF from picture and opens .pdf
        /// </summary>
        /// <param name="picture"></param>
        public void NewReport(IPictureModel picture)
        {
            var renderer = new IronPdf.HtmlToPdf();
            ReportPDF report = new ReportPDF(picture);
            var pdf = renderer.RenderHtmlAsPdf(report.HtmlString);
            var outputPath = $"Report_{picture.ID}.pdf";
            pdf.SaveAs(outputPath);
            // This neat trick opens our PDF file so we can see the result in our default PDF viewer
            System.Diagnostics.Process.Start(outputPath);
        }

        /// <summary>
        /// Saves all tags to a .pdf-File and opens it
        /// </summary>
        /// <param name="list"></param>
        public void AllTagsReport(IEnumerable<IPictureViewModel> list)
        {
            var renderer = new IronPdf.HtmlToPdf();
            var tmpList = list;
            ReportPDF report = new ReportPDF(tmpList);
            var pdf = renderer.RenderHtmlAsPdf(report.TagString);
            var outputPath = $"Report_Tags.pdf";
            pdf.SaveAs(outputPath);
            // This neat trick opens our PDF file so we can see the result in our default PDF viewer
            System.Diagnostics.Process.Start(outputPath);
        }
    }
}
