using System.Globalization;

namespace WebApi_Net6_PostgreSQL.Helpers {
    public class AppException : Exception {
        public AppException() : base() { }
        public AppException(string message) : base(message) { }
        public AppException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args)) { }
    }
}
