using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileUpload.Web.Models
{
    public class CustomFileUploadValidation:ValidationAttribute
    {
        /// <summary>
        /// 允許的檔案類型, 用;區隔
        /// </summary>
        public string AllowExts { get; set; }

        /// <summary>
        /// 允許的檔案大小
        /// </summary>
        public int MaxKBs { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            HttpPostedFileBase postedFile = (HttpPostedFileBase)value;
            if (postedFile == null) return ValidationResult.Success; //沒有上傳檔案一律不處理, 因為會先由[Required]檢查

            // 檔案大小
            int maxSize = this.MaxKBs * 1024;
            if (postedFile.ContentLength >= maxSize)
            {
                var errorMessage = $"檔案大小不能超過 {MaxKBs} KB";
                return new ValidationResult(errorMessage);
            }

            // 檢查副檔名
            if (!string.IsNullOrWhiteSpace(AllowExts))
            {
                string[] arrExts = AllowExts.Split(';');
                string ext = System.IO.Path.GetExtension(postedFile.FileName);
                bool result = arrExts.Contains(ext, StringComparer.CurrentCultureIgnoreCase);
                if (!result)
                {
                    var errorMessage = $"副檔名必需是 {AllowExts}";
                    return new ValidationResult(errorMessage);
                }
            }

            return ValidationResult.Success;
        }
	}
}