#region namespaces
using System.Net;
#endregion

namespace CoreComponents.ExceptionHandler
{
    public class InternalServerException : CustomException
    {
        public InternalServerException(string message, List<string>? errors = default)
            : base(message, errors, HttpStatusCode.InternalServerError) { }
    }


}
