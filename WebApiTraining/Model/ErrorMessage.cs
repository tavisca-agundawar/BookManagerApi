using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTraining.Model
{
    public class ErrorMessage
    {
        public const string InvalidId = "Error! Invalid Id!";

        public const string BookNotFound = "Error! Book not found!";

        public const string Unknown = "Unknown error occurred!";

        public const string AuthorNameViolation = "Author name cannot contain numbers!";

        public const string InvalidPrice = "Error! Price must be a non zero positive number!";

        public const string MissingTitle = "Error! Book must have a title!";

        public const string CategoryNameViolation = "Error! Category name cannot contain numbers!";
    }
}
