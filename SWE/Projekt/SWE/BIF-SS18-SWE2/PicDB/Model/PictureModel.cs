using BIF.SWE2.Interfaces.Models;

namespace PicDB.Model
{
    class PictureModel : IPictureModel
    {
        public PictureModel() {}
        public PictureModel(string filename)
        {
            FileName = filename;
        }

        /// <summary>
        /// Database primary key
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Filename of the picture, without path.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// IPTC information
        /// </summary>
        public IIPTCModel IPTC { get; set; } = new IPTCModel();

        /// <summary>
        /// EXIF information
        /// </summary>
        public IEXIFModel EXIF { get; set; } = new EXIFModel();

        /// <summary>
        /// The camera (optional)
        /// </summary>
        public ICameraModel Camera { get; set; } = new CameraModel();
    }
}
