using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace HelenaGerber_Promo.Utils
{
    // Класс сейчас не используется, но он нужен для загрузки картинок по определённому маршруту
    public class ImageRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new ImageHandler(requestContext);
        }
    }

    public class ImageHandler : IHttpHandler
    {
        public ImageHandler(RequestContext context)
        {
            ProcessRequest(context);
        }

        private static void ProcessRequest(RequestContext requestContext)
        {
            var response = requestContext.HttpContext.Response;
            var request = requestContext.HttpContext.Request;
            var validRequestFile = requestContext.RouteData.Values["filename"].ToString();
            const string invalidRequestFile = "emptyFile.gif";

            string path = ImageUtils.ImagesPath;
            response.Clear();
            response.ContentType = GetContentType(request.Url.ToString());

            if (request.ServerVariables["HTTP_REFERER"] != null &&
                (request.ServerVariables["HTTP_REFERER"].Contains("helenagerber.ru") || request.ServerVariables["HTTP_REFERER"].Contains("localhost:61091"))) {
                response.TransmitFile(path + validRequestFile);
            } else {
                response.TransmitFile(path + invalidRequestFile);
            }
            response.End();
        }

        private static string GetContentType(string url)
        {
            switch (Path.GetExtension(url)) {
                case ".gif":
                    return "Image/gif";
                case ".jpg":
                    return "Image/jpeg";
                case ".jpeg":
                    return "Image/jpeg";
                case ".png":
                    return "Image/png";
                default:
                    break;
            }
            return null;
        }

        public void ProcessRequest(HttpContext context)
        {
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}