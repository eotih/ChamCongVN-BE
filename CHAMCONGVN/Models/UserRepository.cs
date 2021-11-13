using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAMCONGVN.Models
{
    public class UserRepository
    {
        public List<NguoiDung> TestUsers;
        public UserRepository()
        {
            TestUsers = new List<NguoiDung>();
            TestUsers.Add(new NguoiDung() { Username = "Test2", Password = "Pass2" });
            TestUsers.Add(new NguoiDung() { Username = "Test1", Password = "Pass1" });
        }
        public NguoiDung GetUser(string username)
        {
            try
            {
                return TestUsers.First(user => user.Username.Equals(username));
            }
            catch
            {
                return null;
            }
        }
    }
}