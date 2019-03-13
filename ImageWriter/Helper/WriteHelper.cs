using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Net.Mime;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ImageFlipAPI.ImageWriter.Helper
{
    public class WriteHelper
    {
        // Identify acceptable image formats
        public enum ImageFormat
        {
            bmp,
            gif,
            jpeg,
            jpg,
            tiff,
            png,
            unknown
        }
        
/*        public sealed class DataImage
        {
            private static readonly Regex DataUriPattern = new Regex(
                @"^data\:(?<type>image\/(png|tiff|jpg|gif));base64,(?<data>[A-Z0-9\+\/\=]+)$",
                RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);

            private DataImage(string mimeType, byte[] rawData)
            {
                MimeType = mimeType;
                RawData = rawData;
            }
            
            public string MimeType { get; }
            public byte[] RawData { get; }
            
            public Image Image => Image.FromStream(string dataUri)
            {
                if (string.IsNullOrWhiteSpace(dataUri)) return null;
        
                Match match = DataUriPattern.Match(dataUri);
                if (!match.Success) return null;
        
                string mimeType = match.Groups["type"].Value;
                string base64Data = match.Groups["data"].Value;
        
                try
                {
                    byte[] rawData = Convert.FromBase64String(base64Data);
                    return rawData.Length == 0 ? null : new DataImage(mimeType, rawData);
                }
                catch (FormatException)
                {
                    return null;
                }
            }
        }

        public bool LoadImage([FromBody] string base64image)
        {
            DataImage image = DataImage.TryParse(base64image);
            if (image == null)
            {
                return false;
            }
            else
            {
                return true;                
            }
        }*/

        public static string GetMimeType(string fileName)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if(!provider.TryGetContentType(fileName, out contentType))
            {
                contentType = "application/octet-stream";
            }
            Console.Write(fileName);
            return contentType;
        }

//        public static ImageFormat ValidateImageFormat(string base64String)
//        {
//            
//        }

        public static ImageFormat GetImageFormat(byte[] bytes)
        {
            
            // Convert byte[] to Base64 String
            string base64String = Convert.ToBase64String(bytes);
            Console.Write(base64String + "1");
            // Convert byte[] to Base64 String
            string contentType = GetMimeType(base64String);
            Console.Write(contentType + "2");

            if (contentType == "png")
            {
                return ImageFormat.png;
            }

            if (contentType == "bmp")
            {
                return ImageFormat.bmp;
            }
            
            if (contentType == "gif")
            {
                return ImageFormat.gif;
            }
            
            if (contentType == "tiff")
            {
                return ImageFormat.tiff;
            }
            
            if (contentType == "tiff2")
            {
                return ImageFormat.tiff;
            }
            
            if (contentType == "jpeg")
            {
                return ImageFormat.jpeg;
            }
            
            if (contentType == "jpeg2")
            {
                return ImageFormat.jpeg;
            }
            
            if (contentType == "jpg")
            {
                return ImageFormat.jpg;
            }
            
/*            var bmp = Encoding.ASCII.GetBytes("BM"); 
            var gif = Encoding.ASCII.GetBytes("GIF"); 
            var png = new byte[] { 137, 80, 78, 71 }; 
            var tiff = new byte[] { 73, 73, 42 }; 
            var tiff2 = new byte[] { 77, 77, 42 }; 
            var jpeg = new byte[] { 255, 216, 255, 224 }; 
            var jpeg2 = new byte[] { 255, 216, 255, 225 };
            Console.Write("gif");

            if (bmp.SequenceEqual(bytes.Take(bmp.Length)))
            {
                return ImageFormat.bmp;
            }

            if (gif.SequenceEqual(bytes.Take(gif.Length)))
            {
                return ImageFormat.gif;
            }

            if (png.SequenceEqual(bytes.Take(png.Length)))
            {
                Console.Write("png");
                return ImageFormat.png;
            }

            if (tiff.SequenceEqual(bytes.Take(tiff.Length)))
            {
                return ImageFormat.tiff;
            }

            if (tiff2.SequenceEqual(bytes.Take(tiff2.Length)))
            {
                return ImageFormat.tiff;
            }

            if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
            {
                return ImageFormat.jpeg;
            }

            if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
            {
                return ImageFormat.jpeg;
            }*/

            return ImageFormat.unknown;
        }
    }
}
