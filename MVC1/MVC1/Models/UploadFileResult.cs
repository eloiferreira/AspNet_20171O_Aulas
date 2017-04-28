using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC1.Models
{
    public class UploadFileResult
    {
        [Required]
        public HttpPostedFileBase File { get; set; }
    }
}