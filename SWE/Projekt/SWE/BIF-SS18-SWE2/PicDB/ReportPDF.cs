using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PicDB
{
    public class ReportPDF
    {
        public ReportPDF(IEnumerable<IPictureViewModel> list)
        {
            List = list;
            TagString = AllTags(List);
        }

        public ReportPDF (IPictureModel picture)
        {
            PictureModel = picture;
            HtmlString = PictureString(PictureModel);
        }

        public string HtmlString { get; set; }
        public string TagString { get; set; }
        public IPictureModel PictureModel { get; set; }
        public IEnumerable<IPictureViewModel> List { get; set; }

        /// <summary>
        /// Method to return picture with its path and all information with a string
        /// </summary>
        /// <param name="picture">current picture model</param>
        /// <returns>html string</returns>
        private string PictureString(IPictureModel picture)
        {
            string tmp;

            tmp = $"<p>Report by (c) PicDB</p>";
            tmp += $"<h1>{picture.FileName}</h1>";

            //missing source image
            tmp += $"<img src='{ImageManager.Instance.FilePath}/{picture.FileName}' alt='{picture.FileName}' Width='auto' Height='auto' style='text-align:center;'>";

            //IPTC information
            tmp += $"<p>ID: {picture.ID}</p>";
            tmp += $"<p>Headline: {picture.IPTC.Headline}</p>";
            tmp += $"<p>ByLine: {picture.IPTC.ByLine}</p>";
            tmp += $"<p>Caption: {picture.IPTC.Caption}</p>";
            tmp += $"<p>CopyrightNotice: {picture.IPTC.CopyrightNotice}</p>";         
            tmp += $"<p>Keywords: {picture.IPTC.Keywords}</p>";

            //EXIF information
            tmp += $"<p>ExposureProgram: {picture.EXIF.ExposureProgram}</p>";
            tmp += $"<p>ExposureTime: {picture.EXIF.ExposureTime}</p>";
            tmp += $"<p>FNumber: {picture.EXIF.FNumber}</p>";
            tmp += $"<p>Flash: {picture.EXIF.Flash}</p>";
            tmp += $"<p>ISOValue: {picture.EXIF.ISOValue}</p>";
            tmp += $"<p>Make: {picture.EXIF.Make}</p>";

            //Camera 
            tmp += $"<p>Cam-ID: {picture.Camera.ID}</p>";
            tmp += $"<p>BoughtOn: {picture.Camera.BoughtOn}</p>";
            tmp += $"<p>Producer: {picture.Camera.Producer}</p>";

            //Photographer information
            
            return tmp;
        }

        /// <summary>
        /// Method to return all tags and their count with a string
        /// </summary>
        /// <param name="list">List with IPictureViewModels</param>
        /// <returns>all tags in a string</returns>
        private string AllTags(IEnumerable<IPictureViewModel> list)
        {
            string allTagsString = "Report all tags (c) PicDB<br><h1>All Tags listed</h1>";
            List<string> keywordList = new List<string>();
            Dictionary<string,int> tagDictionary = new Dictionary<string, int>();
            
            foreach (var item in list)
            {
                keywordList.Add(item.IPTC.Keywords);
            }

            foreach (var item in keywordList)
            {
                if (tagDictionary.Count == 0)
                {
                    tagDictionary.Add(item, 1);
                }
                else if (tagDictionary.ContainsKey(item))
                {
                    tagDictionary[item]++;
                }
                else
                {
                    tagDictionary.Add(item, 1);
                }
            }

            foreach (var item in tagDictionary)
            {              
                allTagsString += $"{item.Key} {item.Value}<br>";
            }

            return allTagsString;
        }

    }
}
