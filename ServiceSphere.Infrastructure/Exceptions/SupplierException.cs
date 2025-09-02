using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.Infrastructure.Exceptions
{
    public class SupplierException : Exception
    {
        public SupplierException(string message) : base(message) { }
    }

}
