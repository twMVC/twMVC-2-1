using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetMvc.StartFromScratch.Models
{
    [MetadataType(typeof(BlogCommentMetadata))]
    public partial class BlogComment
    {
        public class BlogCommentMetadata
        {
            [Required, StringLength(50)]
            public string PostName { get; set; }

            [Required, StringLength(500)]
            public string Comment { get; set; }
        }
    }
}