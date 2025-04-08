using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSApiLoadCsvFiles.Models
{
    [Table("PARAM_FILES_UPLOAD")]
    public class ParamFilesUpload
    {
        [Required]
        [Key]
        [Column("ID_FILE")]
        public int IdFile {  get; set; }

        [Required]
        [Column("FILE_NAME")]
        public string FileName { get; set; } = string.Empty;

        [Required]
        [Column("FILE_GROUP")]
        public string FileGroup { get; set; } = string.Empty;

        [Required]
        [Column("FILE_PATH")]
        public string FilePath { get; set; } = string.Empty;

        [Required]
        [Column("FILE_TYPE")]
        public string FileType { get; set; } = string.Empty;

        [Required]
        [Column("FILE_STATUS")]
        public int FileStatus { get; set; }
    }
}
