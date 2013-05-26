using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AspNetMvc.StartFromScratch.Models
{
    [MetadataType(typeof(BlogMetadata))]
    public partial class Blog
    {
        public class BlogMetadata
        {
            [Required, StringLength(50)]
            public string Title { get; set; }

            [Required, StringLength(500)]
            public string Description { get; set; }

            [Required]
            public string Content { get; set; }
        }
    }
}