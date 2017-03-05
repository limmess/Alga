using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Alga.Models
{
    public class IsImageFileValid : ValidationAttribute
    {


        public override bool IsValid(object value)
        {
            var image = value as HttpPostedFileBase;
            var tt = aaa.InputStream;
            return true;
        }



        //public override bool IsValid(object value)
        //{
        //    var aaa = value as HttpPostedFileBase;
        //    return true;
        //}


        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    var asmuo = (Asmuo)validationContext.ObjectInstance;
        //    HttpPostedFileBase asmuoImage = value as HttpPostedFileBase;
        //    if (asmuoImage == null)
        //    {
        //        return new ValidationResult("File is corrupt");
        //    }

        //    if (asmuoImage.ContentLength > 1 * 1024 * 512)
        //    {
        //        return new ValidationResult("File size should less than 500 kb");
        //    }

        //    try
        //    {
        //        using (var img = Image.FromStream(asmuoImage.InputStream))
        //        {
        //            return img.RawFormat.Equals(ImageFormat.Jpeg) == true
        //                ? ValidationResult.Success
        //                : new ValidationResult("File should be JPEG");

        //            //var img = Image.FromStream(file.InputStream);
        //            //var format = img.RawFormat;
        //            //var codec = ImageCodecInfo.GetImageDecoders().First(c => c.FormatID == format.Guid);
        //            //var mimeType = codec.MimeType;
        //            //if (mimeType != "image/jpg")
        //            //    return new ValidationResult("Please upload a valid JPG file");


        //        }
        //    }
        //    catch { }
        //    return new ValidationResult("File should be JPEG format");
        //}
    }
}
