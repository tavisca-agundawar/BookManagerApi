using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTraining.Model
{
    public class ErrorModel
    {
        public int Status { get; private set; }
        public string Message { get; private set; }

        public ErrorModel(int status,string message)
        {
            this.Status = status;
            this.Message = message;
        }
    }
}
