using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCD.Model
{
    [Table("tblFile")]
    public class File
    {

        [Key]
        [Column("FileID")]
        public int FileId { get; set; }

        [Required()]
        public string Path { get; set; }

        [Required()]
        public string Name { get; set; }

        [ForeignKey("User")]
        [Column("UserID")]
        [Required()]
        public int UserId { get; set; }

        public User User { get; set; }

        [ForeignKey("FileType")]
        [Column("FileTypeID")]
        [Required()]
        public int FileTypeId { get; set; }

        public FileType FileType { get; set; }

    }
}
