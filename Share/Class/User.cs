using Share.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Share.Class
{
    public class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        private string password { get; set; }
        public string Password
        {
            get
            {
                string uniqueId = "";
                using (MD5 md5 = MD5.Create())
                {
                    byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(Email));
                    uniqueId = PassWordSecurity.NameUUIDFromBytes(hash);
                }
                return uniqueId + PassWordSecurity.Hash(password);
            }
            set { password = value; }
        }
        private string UniqueID {
            get
            {
                string uniqueId = "";
                using (MD5 md5 = MD5.Create())
                {
                    byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(Email));
                    uniqueId = PassWordSecurity.NameUUIDFromBytes(hash);
                }
                return uniqueId;


            }
        }
        public string AlreadyHashedPassword { get; set; }
    }
}
