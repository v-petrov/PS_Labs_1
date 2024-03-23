using System.Text;
using System.Security.Cryptography;
using Welcome.Others;
using System.Runtime.CompilerServices;

namespace Welcome.Model
{
    public class User
    {
        public string? Names { get; set; }
        private string? _password;
        public string Password
        {
            get { return _password; }
            set { _password = HashPassword(value); }
        }
        public int FacultyNumber { get; set; }
        public string? Email { get; set; }
        public UserRolesEnum Role { get; set; }
        public virtual int Id { get; set; }
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
