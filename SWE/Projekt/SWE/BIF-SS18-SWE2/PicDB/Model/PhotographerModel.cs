using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.Models;

namespace PicDB.Model
{
    class PhotographerModel : IPhotographerModel
    {
        /// <summary>
        /// Database primary key
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Firstname, including middle name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Lastname
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Birthday
        /// </summary>
        public DateTime? BirthDay { get; set; }

        /// <summary>
        /// Notes
        /// </summary>
        public string Notes { get; set; }
    }
}
