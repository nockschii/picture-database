using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB;
using PicDB.Model;
using PicDB.Properties;
using PicDB.ViewModel;

namespace PicDB
{
    class DataAccessLayer : IDataAccessLayer
    {
        //private readonly string _connectionstring = $"Server={Settings.Default["Servername"]}; Database={Settings.Default["Database"]}; User Id={Settings.Default["UserID"]}; Password={Settings.Default["ServerPW"]};"
        private readonly string _connectionstring = $"Server={Settings.Default.Servername}; Database=PicDB; Integrated Security=True;";
        public SqlConnection Connection => new SqlConnection(_connectionstring);

        /// <summary>
        /// Deletes a Photographer. A Exception is thrown if a Photographer is still linked to a picture.
        /// </summary>
        /// <param name="ID">PhotographerID</param>
        public void DeletePhotographer(int ID)
        {
            try
            {
                SqlConnection connection = Connection;
                connection.Open();

                string sqlstring = "DELETE FROM Photographer WHERE PhotographerID = @Id";
                SqlCommand command = new SqlCommand(sqlstring, connection);

                command.Parameters.Add(new SqlParameter("@Id", $"{ID}"));
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }   
        }

        /// <summary>
        /// Deletes a Picture from the database.
        /// </summary>
        /// <param name="ID">PictureID</param>
        public void DeletePicture(int ID)
        {
            try
            {
                SqlConnection connection = Connection;
                connection.Open();

                string sqlstring = "DELETE FROM Picture WHERE PictureID = @Id";
                SqlCommand command = new SqlCommand(sqlstring, connection);

                command.Parameters.Add(new SqlParameter("@Id", $"{ID}"));
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Returns ONE Camera
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ICameraModel GetCamera(int ID)
        {
            try
            {
                SqlConnection connection = Connection;
                connection.Open();

                string sqlstring = "SELECT * FROM Camera WHERE CameraID = @Id";
                SqlCommand command = new SqlCommand(sqlstring, connection);

                command.Parameters.Add(new SqlParameter("@Id", $"{ID}"));
                command.ExecuteNonQuery();

                CameraModel result = new CameraModel();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    result.ID = reader.GetInt32(0);
                    result.Producer = reader.GetString(1);
                    result.Make = reader.GetString(2);
                    result.BoughtOn = reader.GetDateTime(3);
                    result.Notes = reader.GetString(4);
                    result.ISOLimitGood = reader.GetInt32(5);
                    result.ISOLimitAcceptable = reader.GetInt32(6);
                }
                connection.Close();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Returns a list of ALL Cameras.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICameraModel> GetCameras()
        {
            try
            {
                SqlConnection connection = Connection;
                connection.Open();

                SqlCommand command = new SqlCommand("SelectAllCameras", connection) { CommandType = CommandType.StoredProcedure };
                command.ExecuteNonQuery();

                List<CameraModel> ResultList = new List<CameraModel>();
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    CameraModel result = new CameraModel();

                    result.ID = reader.GetInt32(0);
                    result.Producer = reader.GetString(1);
                    result.Make = reader.GetString(2);
                    result.BoughtOn = reader.GetDateTime(3);
                    result.Notes = reader.GetString(4);
                    result.ISOLimitGood = reader.GetInt32(5);
                    result.ISOLimitAcceptable = reader.GetInt32(6);

                    ResultList.Add(result);
                }
                connection.Close();
                return ResultList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Returns ONE Photographer
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IPhotographerModel GetPhotographer(int ID)
        {
            try
            {
                SqlConnection connection = Connection;
                connection.Open();

                string sqlstring = "SELECT * FROM Photographer WHERE PhotographerID = @Id";
                SqlCommand command = new SqlCommand(sqlstring, connection);

                command.Parameters.Add(new SqlParameter("@Id", $"{ID}"));
                command.ExecuteNonQuery();

                PhotographerModel result = new PhotographerModel();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    result.ID = reader.GetInt32(0);
                    result.FirstName = reader.GetString(1);
                    result.LastName = reader.GetString(2);
                    result.BirthDay = reader.GetDateTime(3);
                    result.Notes = reader.GetString(4);
                }
                connection.Close();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Returns a list of ALL Photographers.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPhotographerModel> GetPhotographers()
        {
            try
            {
                SqlConnection connection = Connection;
                connection.Open();

                SqlCommand command = new SqlCommand("SelectAllPhotographers", connection) { CommandType = CommandType.StoredProcedure };
                command.ExecuteNonQuery();

                List<PhotographerModel> ResultList = new List<PhotographerModel>();           
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    PhotographerModel result = new PhotographerModel();

                    result.ID = reader.GetInt32(0);
                    result.FirstName = reader.GetString(1);
                    result.LastName = reader.GetString(2);
                    result.BirthDay = reader.GetDateTime(3);
                    result.Notes = reader.GetString(4);

                    ResultList.Add(result);
                }
                connection.Close();
                return ResultList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Returns ONE Picture from the database.
        /// </summary>
        /// <param name="ID">PictureID</param>
        /// <returns>Picture with PictureID</returns>
        public IPictureModel GetPicture(int ID)
        {
            try
            {
                SqlConnection connection = Connection;
                connection.Open();

                string sqlstring = "SELECT * FROM Photographer WHERE PhotographerID = @Id";
                SqlCommand command = new SqlCommand(sqlstring, connection);

                command.Parameters.Add(new SqlParameter("@Id", $"{ID}"));
                command.ExecuteNonQuery();

                PictureModel result = new PictureModel();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    result.ID = reader.GetInt32(0);
                    result.FileName = reader.GetString(1);
                    result.EXIF.Make = reader.GetString(2);
                    result.EXIF.FNumber = reader.GetInt32(3);
                    result.EXIF.ExposureTime = reader.GetInt32(4);
                    result.EXIF.ISOValue = reader.GetInt32(5);
                    result.EXIF.Flash = reader.GetBoolean(6);
                    result.IPTC.Keywords = reader.GetString(7);
                    result.IPTC.ByLine = reader.GetString(8);
                    result.IPTC.CopyrightNotice = reader.GetString(9);
                    result.IPTC.Headline = reader.GetString(10);
                    result.IPTC.Caption = reader.GetString(11);
                    result.Camera = GetCamera(ID);
                }
                connection.Close();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Returns a filterd list of Pictures from the directory, based on a database query.
        /// </summary>
        /// <returns>Pictures with given parameters</returns>
        public IEnumerable<IPictureModel> GetPictures(string namePart, IPhotographerModel photographerParts, IIPTCModel iptcParts, IEXIFModel exifParts)
        {
            try
            {
                SqlConnection connection = Connection;
                connection.Open();

                List<PictureModel> ResultList = new List<PictureModel>();
                SqlDataReader reader;

                if (namePart == null)
                {
                    SqlCommand command = new SqlCommand("SelectAllPictures", connection) { CommandType = CommandType.StoredProcedure };
                    reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        PictureModel result = new PictureModel();
                        result.ID = reader.GetInt32(0);
                        result.FileName = reader.GetString(1);
                        result.EXIF.Make = reader.GetString(2);
                        result.EXIF.FNumber = reader.GetInt32(3);
                        result.EXIF.ExposureTime = reader.GetInt32(4);
                        result.EXIF.ISOValue = reader.GetInt32(5);
                        result.EXIF.Flash = reader.GetBoolean(6);
                        result.IPTC.Keywords = reader.GetString(7);
                        result.IPTC.ByLine = reader.GetString(8);
                        result.IPTC.CopyrightNotice = reader.GetString(9);
                        result.IPTC.Headline = reader.GetString(10);
                        result.IPTC.Caption = reader.GetString(11);
                        result.Camera = GetCamera(result.ID);
                        ResultList.Add(result);
                    }
                }
                else
                {
                    string sqlstring = "SELECT * FROM Picture WHERE FileName LIKE @namePart";
                    SqlCommand command = new SqlCommand(sqlstring, connection);

                    command.Parameters.AddWithValue("@namePart", "%" + namePart + "%");
                    command.ExecuteNonQuery();

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        PictureModel result = new PictureModel();
                        result.ID = reader.GetInt32(0);
                        result.FileName = reader.GetString(1);
                        result.EXIF.Make = reader.GetString(2);
                        result.EXIF.FNumber = reader.GetInt32(3);
                        result.EXIF.ExposureTime = reader.GetInt32(4);
                        result.EXIF.ISOValue = reader.GetInt32(5);
                        result.EXIF.Flash = reader.GetBoolean(6);
                        result.IPTC.Keywords = reader.GetString(7);
                        result.IPTC.ByLine = reader.GetString(8);
                        result.IPTC.CopyrightNotice = reader.GetString(9);
                        result.IPTC.Headline = reader.GetString(10);
                        result.IPTC.Caption = reader.GetString(11);
                        result.Camera = GetCamera(result.ID);
                        ResultList.Add(result);
                    }
                }
                connection.Close();
                return ResultList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Edits IPTC information with given picture
        /// </summary>
        /// <param name="picture">Picturemodel</param>
        public void EditIPTC(IPictureModel picture)
        {
            try
            {
                SqlConnection connection = Connection;
                connection.Open();
                SqlCommand command = new SqlCommand("EditIPTC", connection) { CommandType = CommandType.StoredProcedure };

                command.Parameters.Add(new SqlParameter("@Keywords", $"{picture.IPTC.Keywords}"));
                command.Parameters.Add(new SqlParameter("@ByLine", $"{picture.IPTC.ByLine}"));
                command.Parameters.Add(new SqlParameter("@CopyrightNotice", $"{picture.IPTC.CopyrightNotice}"));
                command.Parameters.Add(new SqlParameter("@Headline", $"{picture.IPTC.Headline}"));
                command.Parameters.Add(new SqlParameter("@Caption", $"{picture.IPTC.Caption}"));
                command.Parameters.Add(new SqlParameter("@FileName", $"{picture.FileName}"));

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Sets the photographer of a picture
        /// </summary>
        /// <param name="picture">picture</param>
        public void SetPhotographer(IPictureModel picture, IPhotographerModel photographer)
        {
            try
            {
                SqlConnection connection = Connection;
                connection.Open();
                SqlCommand command = new SqlCommand("SetPhotographer", connection) { CommandType = CommandType.StoredProcedure };

                command.Parameters.Add(new SqlParameter("@ID", $"{picture.ID}"));
                command.Parameters.Add(new SqlParameter("@FK_Photographer_PictureID", $"{photographer.ID}"));

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IPhotographerModel SelectSetPhotographer(IPictureModel picture)
        {
            try
            {
                SqlConnection connection = Connection;
                connection.Open();
                SqlCommand command = new SqlCommand("SelectSetPhotographer", connection) { CommandType = CommandType.StoredProcedure };

                command.Parameters.Add(new SqlParameter("@FileName", $"{picture.FileName}"));

                command.ExecuteNonQuery();
                PhotographerModel result = new PhotographerModel();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    result.ID = reader.GetInt32(0);
                    result.FirstName = reader.GetString(1);
                    result.LastName = reader.GetString(2);
                    result.BirthDay = reader.GetDateTime(3);
                    result.Notes = reader.GetString(4);
                }
                connection.Close();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Saves all changes to the database.
        /// </summary>
        /// <param name="picture">picture</param>
        public void Save(IPictureModel picture)
        {
            try
            {
                SqlConnection connection = Connection;
                connection.Open();
                SqlCommand command = new SqlCommand("SavePicture", connection) { CommandType = CommandType.StoredProcedure };

                command.Parameters.Add(new SqlParameter("@FileName", $"{picture.FileName}"));
                command.Parameters.Add(new SqlParameter("@Make", $"{picture.EXIF.Make}"));
                command.Parameters.Add(new SqlParameter("@FNumber", $"{picture.EXIF.FNumber}"));
                command.Parameters.Add(new SqlParameter("@ExposureTime", $"{picture.EXIF.ExposureTime}"));
                command.Parameters.Add(new SqlParameter("@ISOValue", $"{picture.EXIF.ISOValue}"));
                command.Parameters.Add(new SqlParameter("@Flash", $"{picture.EXIF.Flash}"));
                command.Parameters.Add(new SqlParameter("@Keywords", $"{picture.IPTC.Keywords}"));
                command.Parameters.Add(new SqlParameter("@ByLine", $"{picture.IPTC.ByLine}"));
                command.Parameters.Add(new SqlParameter("@CopyrightNotice", $"{picture.IPTC.CopyrightNotice}"));
                command.Parameters.Add(new SqlParameter("@Headline", $"{picture.IPTC.Headline}"));
                command.Parameters.Add(new SqlParameter("@Caption", $"{picture.IPTC.Caption}"));

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Saves all changes.
        /// </summary>
        /// <param name="photographer"></param>
        public void Save(IPhotographerModel photographer)
        {
            try
            {
                SqlConnection connection = Connection;
                connection.Open();
                SqlCommand command = new SqlCommand("SavePhotographer", connection) { CommandType = CommandType.StoredProcedure };

                command.Parameters.Add(new SqlParameter("@ID", $"{photographer.ID}"));
                command.Parameters.Add(new SqlParameter("@FirstName", $"{photographer.FirstName}"));
                command.Parameters.Add(new SqlParameter("@LastName", $"{photographer.LastName}"));
                command.Parameters.Add(new SqlParameter("@Birthday", $"{photographer.BirthDay}"));
                command.Parameters.Add(new SqlParameter("@Notes", $"{photographer.Notes}"));

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Edits data of a photographer
        /// </summary>
        /// <param name="photographer">photographer</param>
        public void EditPhotographer(IPhotographerModel photographer)
        {
            try
            {
                SqlConnection connection = Connection;
                connection.Open();
                SqlCommand command = new SqlCommand("EditPhotographer", connection) { CommandType = CommandType.StoredProcedure };

                command.Parameters.Add(new SqlParameter("@FirstName", $"{photographer.FirstName}"));
                command.Parameters.Add(new SqlParameter("@LastName", $"{photographer.LastName}"));
                command.Parameters.Add(new SqlParameter("@BirthDay", photographer.BirthDay));
                command.Parameters.Add(new SqlParameter("@Notes", $"{photographer.Notes}"));
                command.Parameters.Add(new SqlParameter("@ID", $"{photographer.ID}"));

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
