﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace HelenaGerber_Promo.Utils
{
    public static class ImageUtils
    {
        private static readonly string ImagesPath = HttpContext.Current.Server.MapPath("~/Bin/App_Data/Files/ProductImages");

        public static string GenerateTempFileName(string contentType)
        {
            // Удаляем "image/"
            contentType = contentType.Remove(0, 6);
            string filename = Path.GetTempFileName();
            filename = Path.GetFileNameWithoutExtension(filename);
            filename = Path.Combine(ImagesPath, filename);
            filename = string.Format("{0}.{1}", filename, contentType);
            return filename;
        }


        public static string GetDataImagePath()
        {
            return ImagesPath;
        }
    }
}