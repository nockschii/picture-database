using BIF.SWE2.Interfaces;
using PicDB.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
using BIF.SWE2.Interfaces.Models;
using System.Data.SqlClient;
using PicDB.Properties;
//using MetadataExtractor; 

namespace PicDB
{
    public class ImageManager
    {
        private static readonly Lazy<ImageManager> _instance = new Lazy<ImageManager>(() => new ImageManager());
        public static ImageManager Instance = _instance.Value;
        
        //$"C:/Users/Alfred/Desktop/SWE_Projekt/SWE/BIF-SS18-SWE2/deploy/Pictures"
        /// <summary>
        /// Path to picture folder
        /// </summary>
        public string FilePath { get; set; } = Settings.Default.FilePath;

        /// <summary>
        /// All imgages in folder saved in a list
        /// </summary>
        public List<IPictureModel> ImageList { get; set; } = new List<IPictureModel>();

        /// <summary>
        /// Inserts all pictures from folder in to database and creates default values for each picture
        /// </summary>
        public void CreateDefaultPictureModels()
        {
            string[] imgFiles = Directory.GetFiles($"{FilePath}", "*.jpg").Select(Path.GetFileName).ToArray();
            DataAccessLayer DAL = new DataAccessLayer();
            int count_dal = DAL.GetPictures(null, null, null, null).Count();
            int count_folder = imgFiles.Count();

            if (count_dal != 0 && count_dal != count_folder)
            {
                foreach (var item in imgFiles)
                {
                    PictureModel Default = new PictureModel();
                    IEnumerable<IPictureModel> CheckList = DAL.GetPictures(item, null, null, null);

                    if (CheckList.Count() == 0)
                    {
                        Default.FileName = item;
                        Default.EXIF.Make = "Default Make";
                        Default.EXIF.FNumber = 0;
                        Default.EXIF.ExposureTime = 0;
                        Default.EXIF.ISOValue = 0;
                        Default.EXIF.Flash = false;
                        Default.IPTC.Keywords = "Default Keyword";
                        Default.IPTC.ByLine = "Default ByLine";
                        Default.IPTC.CopyrightNotice = "Independent Photographer - ©2018 Ralph Quidet, all rights reserved";
                        Default.IPTC.Headline = "Default Headline";
                        Default.IPTC.Caption = "Default Caption";

                        DAL.Save(Default);
                        ImageList.Add(Default);
                        CheckList = null;
                    }
                    else
                    {
                        CheckList = null;
                        continue;
                    }
                }
            }
            else
            {
                try
                {
                    foreach (var item in imgFiles)
                    {
                        PictureModel Default = new PictureModel();

                        Default.FileName = item;
                        Default.EXIF.Make = "Default Make";
                        Default.EXIF.FNumber = 0;
                        Default.EXIF.ExposureTime = 0;
                        Default.EXIF.ISOValue = 0;
                        Default.EXIF.Flash = false;
                        Default.IPTC.Keywords = "Default Keyword";
                        Default.IPTC.ByLine = "Default ByLine";
                        Default.IPTC.CopyrightNotice = "Independent Photographer - ©2018 Ralph Quidet, all rights reserved";
                        Default.IPTC.Headline = "Default Headline";
                        Default.IPTC.Caption = "Default Caption";

                        DAL.Save(Default);
                        ImageList.Add(Default);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}

#region unused code
//PictureModel (ID - Filename - IPTC - EXIF - Camera) 
//EXIF (Make - FNumber - ExposureTime - ISOValue - Flash - ExposureProgram) 
//IPTC (Keywords - ByLine - CopyrightNotice - Headline - Caption)
//Camera (ID - Producer - Make - BoughtOn - Notes - ISOLimitGood - ISOLimitAcceptable)

//private void CreateDefaultPicModels()
//{
//    string[] imgFiles = Directory.GetFiles($"{FilePath}", "*.jpg").Select(Path.GetFileName).ToArray();
//    //List<Directory> directories = ImageMetadataReader.ReadMetadata(filepath).ToList();

//    //PictureModel (ID - Filename - IPTC - EXIF - Camera) 
//    //EXIF (Make - FNumber - ExposureTime - ISOValue - Flash - ExposureProgram) 
//    //IPTC (Keywords - ByLine - CopyrightNotice - Headline - Caption)
//    //Camera (ID - Producer - Make - BoughtOn - Notes - ISOLimitGood - ISOLimitAcceptable)
//    foreach (var item in imgFiles)
//    {
//        PictureModel p = new PictureModel();
//        Random rand = new Random();
//        p.FileName = item;
//        p.ID = Counter;
//        Counter++;

//        if (rand.Next(0, 2) == 0)
//        {
//            p.EXIF.Make = "Canon";
//        }
//        p.EXIF.Make = "Nikon";

//        p.EXIF.FNumber = rand.Next(1, 10);
//        p.EXIF.ExposureTime = rand.Next(1, 10);

//        int exifrand = rand.Next(0, 4);
//        switch (exifrand)
//        {
//            case 0:
//                p.EXIF.ISOValue = 200;
//                break;
//            case 1:
//                p.EXIF.ISOValue = 400;
//                break;
//            case 2:
//                p.EXIF.ISOValue = 800;
//                break;
//            case 3:
//                p.EXIF.ISOValue = 1600;
//                break;
//            default:
//                p.EXIF.ISOValue = 800;
//                break;
//        }

//        if (rand.Next(0, 2) == 0)
//        {
//            p.EXIF.Flash = true;
//        }
//        else
//        {
//            p.EXIF.Flash = false;
//        }

//        int eprand = rand.Next(0, 8);
//        //if (rand.Next(0, 9) == 0) p.EXIF.ExposureProgram = ExposurePrograms.NotDefined;
//        switch (eprand)
//        {
//            case 0:
//                p.EXIF.ExposureProgram = ExposurePrograms.Manual;
//                break;
//            case 1:
//                p.EXIF.ExposureProgram = ExposurePrograms.Normal;
//                break;
//            case 2:
//                p.EXIF.ExposureProgram = ExposurePrograms.AperturePriority;
//                break;
//            case 3:
//                p.EXIF.ExposureProgram = ExposurePrograms.ShutterPriority;
//                break;
//            case 4:
//                p.EXIF.ExposureProgram = ExposurePrograms.CreativeProgram;
//                break;
//            case 5:
//                p.EXIF.ExposureProgram = ExposurePrograms.ActionProgram;
//                break;
//            case 6:
//                p.EXIF.ExposureProgram = ExposurePrograms.PortraitMode;
//                break;
//            case 7:
//                p.EXIF.ExposureProgram = ExposurePrograms.LandscapeMode;
//                break;
//            default:
//                p.EXIF.ExposureProgram = ExposurePrograms.Normal;
//                break;
//        }

//        p.IPTC.Keywords = "Default";

//        int bylinerand = rand.Next(0, 3);
//        switch (bylinerand)
//        {
//            case 0:
//                p.IPTC.ByLine = "Ralph";
//                break;
//            case 1:
//                p.IPTC.ByLine = "Eduard";
//                break;
//            case 2:
//                p.IPTC.ByLine = "Mustermann";
//                break;
//            default:
//                p.IPTC.ByLine = "Mustermann";
//                break;
//        }

//        p.IPTC.CopyrightNotice = "Independent Photographer - ©2018 Ralph Quidet, all rights reserved";
//        p.IPTC.Headline = "Default Headline";
//        p.IPTC.Caption = "Default Description";

//        p.Camera.BoughtOn = DateTime.Today;
//        p.Camera.ISOLimitAcceptable = 1;
//        p.Camera.ISOLimitGood = 1;
//        p.Camera.Make = "CameraMakeT";
//        p.Camera.Notes = "CameraNotesT";
//        p.Camera.Producer = "CameraProdT";

//        if (rand.Next(0, 2) == 0)
//        {
//            p.Camera.ID = 1;
//        }
//        else
//        {
//            p.Camera.ID = 2;
//        }

//        _imageList.Add(p);

/****************************************************/
/****************************************************/
/****************************************************/
/****************************************************/
/****************************************************/
/**********      SOME THINGS I TESTED ***************/
/****************************************************/
/****************************************************/
/****************************************************/
/****************************************************/


//FileName - File - File Name

/* EXIF (Make - FNumber - ExposureTime - ISOValue) */
////Make - Exif IFD0 - Make
//foreach (var info in directories)
//{
//    foreach (var attribute in info.Tags)
//    {
//        if ($"{info.Tags}" == "Exif IFD0")
//        {
//            if ($"{attribute.Name}" == "Make")
//            {
//                p.EXIF.Make = $"{attribute.Description}";
//            }
//        }
//    }
//}

////FNumber - Exif SubIFD - F-Number
//foreach (var info in directories)
//{
//    foreach (var attribute in info.Tags)
//    {
//        if ($"{info.Tags}" == "Exif SubIFD")
//        {
//            if ($"{attribute.Name}" == "F-Number")
//            {
//                p.EXIF.FNumber = Int32.Parse($"{attribute.Description}");
//            }
//        }
//    }
//}

////ExposureTime - Exif SubIFD - Exposure Time
//foreach (var info in directories)
//{
//    foreach (var attribute in info.Tags)
//    {
//        if ($"{info.Tags}" == "Exif SubIFD")
//        {
//            if ($"{attribute.Name}" == "Exposure Time")
//            {
//                p.EXIF.ExposureTime = Int32.Parse($"{attribute.Description}");
//            }
//        }
//    }
//}

////ISOValue - Exif SubIFD - ISO Speed Ratings
//foreach (var info in directories)
//{
//    foreach (var attribute in info.Tags)
//    {
//        if ($"{info.Tags}" == "Exif SubIFD")
//        {
//            if ($"{attribute.Name}" == "ISO Speed Ratings")
//            {
//                p.EXIF.ISOValue = Int32.Parse($"{attribute.Description}");
//            }
//        }
//    }
//}

////Flash - Exif SubIFD - Flash (Flash / No Flash)
//foreach (var info in directories)
//{
//    foreach (var attribute in info.Tags)
//    {
//        if ($"{info.Tags}" == "Exif SubIFD")
//        {
//            if ($"{attribute.Name}" == "Flash")
//            {
//                if ($"{attribute.Description}".Contains("No") || $"{attribute.Description}".Contains("Kein"))
//                {
//                    p.EXIF.Flash = false;
//                }
//                p.EXIF.Flash = true;
//            }
//        }
//    }
//}
////ExposureProgram - Exif SubIFD - Exposure Program
//foreach (var info in directories)
//{
//    foreach (var attribute in info.Tags)
//    {
//        if ($"{info.Tags}" == "Exif SubIFD")
//        {
//            if ($"{attribute.Name}" == "Flash")
//            {
//                if ($"{attribute.Description}".IndexOf("manual", StringComparison.OrdinalIgnoreCase) >= 0)
//                {
//                    p.EXIF.ExposureProgram = ExposurePrograms.Manual;
//                }

//                if ($"{attribute.Description}".IndexOf("normal", StringComparison.OrdinalIgnoreCase) >= 0)
//                {
//                    p.EXIF.ExposureProgram = ExposurePrograms.Normal;
//                }

//                if ($"{attribute.Description}".IndexOf("aperture", StringComparison.OrdinalIgnoreCase) >= 0)
//                {
//                    p.EXIF.ExposureProgram = ExposurePrograms.AperturePriority;
//                }

//                if ($"{attribute.Description}".IndexOf("shutter", StringComparison.OrdinalIgnoreCase) >= 0)
//                {
//                    p.EXIF.ExposureProgram = ExposurePrograms.ShutterPriority;
//                }

//                if ($"{attribute.Description}".IndexOf("creative", StringComparison.OrdinalIgnoreCase) >= 0)
//                {
//                    p.EXIF.ExposureProgram = ExposurePrograms.CreativeProgram;
//                }

//                if ($"{attribute.Description}".IndexOf("action", StringComparison.OrdinalIgnoreCase) >= 0)
//                {
//                    p.EXIF.ExposureProgram = ExposurePrograms.ActionProgram;
//                }

//                if ($"{attribute.Description}".IndexOf("portrait", StringComparison.OrdinalIgnoreCase) >= 0)
//                {
//                    p.EXIF.ExposureProgram = ExposurePrograms.PortraitMode;
//                }

//                if ($"{attribute.Description}".IndexOf("landscape", StringComparison.OrdinalIgnoreCase) >= 0)
//                {
//                    p.EXIF.ExposureProgram = ExposurePrograms.LandscapeMode;
//                }

//                p.EXIF.ExposureProgram = ExposurePrograms.NotDefined;

//            }
//        }
//    }
//}

//-IPTC
//Keywords ByLine Copyrightnotices Headline Caption
//-Camera
#endregion