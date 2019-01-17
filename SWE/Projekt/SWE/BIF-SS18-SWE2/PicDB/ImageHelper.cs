using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicDB
{
    public class ImageHelper
    {
        private static readonly Lazy<ImageHelper> _instance = new Lazy<ImageHelper>(() => new ImageHelper());
        public static ImageHelper Instance => _instance.Value;

        private ImageHelper()
        {
            
        }
    }
}
