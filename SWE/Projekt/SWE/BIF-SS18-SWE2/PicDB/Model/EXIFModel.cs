using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;

namespace PicDB.Model
{
    class EXIFModel : IEXIFModel
    {
        /// <summary>
        /// Name of camera
        /// </summary>
        public string Make { get; set; }

        /// <summary>
        /// Aperture number
        /// </summary>
        public decimal FNumber { get; set; }

        /// <summary>
        /// Exposure time
        /// </summary>
        public decimal ExposureTime { get; set; }

        /// <summary>
        /// ISO value
        /// </summary>
        public decimal ISOValue { get; set; }

        /// <summary>
        /// Flash yes/no
        /// </summary>
        public bool Flash { get; set; }

        /// <summary>
        /// The exposure program
        /// </summary>
        public ExposurePrograms ExposureProgram { get; set; } = new ExposurePrograms();
        
    }
}
