using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectSharing.DAL.Entities
{
    public class File
    {
        [Key]
        public int FileID { get; set; }
        public string FileName { get; set; }
        public int PageID { get; set; }
        public string FileVersion { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public string FileSize { get; set; }

        [ForeignKey("PageID")]
        public Page Page { get; set; }
    }
}
