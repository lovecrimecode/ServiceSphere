using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.Infrastructure.Exceptions
{
    public class OrganizerException : Exception
    {
        public OrganizerException(string message) : base(message) { }
    }

}
