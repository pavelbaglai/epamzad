using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace quizApp.BLL.Infrastructure
{
    public class ValidationException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }
        public string Property { get; private set; }
        public ValidationException(string message, HttpStatusCode statusCode, string property) : base(message)
        {
            StatusCode = statusCode;
            Property = property;
        }
    }
}
