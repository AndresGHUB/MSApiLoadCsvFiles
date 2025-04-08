namespace MSApiLoadCsvFiles.Utils
{
    public class Constants
    {
        #region Response
        /// <summary
        /// Error Code
        /// </sumary>
        public const string ERR_CODE = "0001";

        /// <summary
        /// Error Message
        /// </sumary>
        public const string ERR_MSG = "An error ocurred while uploadig a file";

        /// <summary
        /// Error Description
        /// </sumary>
        public const string ERR_DESC = "One or more files haven't been uploaded";


        /// <summary
        /// Successfull Code
        /// </sumary>
        public const string OK_CODE = "0000";

        /// <summary
        /// Successfull Message
        /// </sumary>
        public const string OK_MSG = "Files uploaded successfully";

        /// <summary
        /// Successfull Description
        /// </sumary>
        public const string OK_DESC = "Files uploaded successfully";

        /// <summary
        /// General path for all csv files
        /// </sumary>
        public const string PATH = @"D:\\Personal\\Csv";

        /// <summary
        /// File name for Departments
        /// </sumary>
        public const string FN_DEPARTMENTS = "departments.csv";

        /// <summary
        /// File name for Jobs
        /// </sumary>
        public const string FN_JOBS = "jobs.csv";

        /// <summary
        /// File name for Employees
        /// </sumary>
        public const string FN_EMPLOYEES = "hired_employees.csv";

        /// <summary
        /// CSV file type
        /// </sumary>
        public const string FT_CSV = "csv";

        /// <summary
        /// Error file Code
        /// </sumary>
        public const string ERR_CODE_FILE = "0002";

        /// <summary
        /// Error file Message
        /// </sumary>
        public const string ERR_MSG_FILE = "An error ocurred while uploadig a file";

        /// <summary
        /// Error file Description
        /// </sumary>
        public const string ERR_DESC_FILE = "An error ocurred while uploadig a file";

        /// <summary
        /// Successfull file Code
        /// </sumary>
        public const string OK_CODE_FILE = "0000";

        /// <summary
        /// Successfull file Message
        /// </sumary>
        public const string OK_MSG_FILE = "File uploaded successfully";

        /// <summary
        /// Successfull file Description
        /// </sumary>
        public const string OK_DESC_FILE = "File uploaded successfully";

        /// <summary
        /// File structure (folder) where the file will be storage
        /// </sumary>
        public const string FOLDER_STORAGE = "uploads/";

        /// <summary
        /// Error Code
        /// </sumary>
        public const string ERR_CODE_PL = "0001";

        /// <summary
        /// Error Message
        /// </sumary>
        public const string ERR_MSG_PL = "An error ocurred while triggering the pipeline";

        /// <summary
        /// Success Code
        /// </sumary>
        public const string OK_CODE_PL = "0000";

        /// <summary
        /// Success Message
        /// </sumary>
        public const string OK_MSG_PL = "The pipeline have been trigered successfuly";

        #endregion
    }
}
