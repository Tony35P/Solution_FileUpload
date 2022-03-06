using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileUpload.Web.Models
{
    public class ProductVM
    {
        [Required(ErrorMessage ="{0} 必填")]
        [Display(Name ="品名")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "{0} 必填")]
        [Display(Name = "照片")]
        [CustomFileUploadValidation(AllowExts =".jpg;.jpeg;.png" , MaxKBs =200)]
        public HttpPostedFileBase ProductImage { get; set; }
    }
}