using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementProject.Entities.Contracts
{
    public class Result
    {
        public String? Message { get; set; }
        public bool Status { get; set; }

    }

    public class Result<T>
    {
        public String? Message { get; set; }
        public bool Status { get; set; }
        public T? Data { get; set; }
    }
}
