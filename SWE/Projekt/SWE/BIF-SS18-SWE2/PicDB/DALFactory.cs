using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using PicDB.Properties;

namespace PicDB
{
    public static class DALFactory
    {
        /// <summary>
        /// DataAccesLayer Factory to determine if MockDAL or DAL is needed
        /// </summary>
        /// <returns>MockDAL or DAL</returns>
        public static IDataAccessLayer CreateDAL()
        {
            IDataAccessLayer DAL = null;

            if (Settings.Default.DALType == 1)
            {
                DAL = new DataAccessLayer();
                return DAL;
            }
            else if(Settings.Default.DALType == 2)
            {
                DAL = new DataAccessLayerMock();
                return DAL;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

    }
}
