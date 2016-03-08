using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaidouDatabase.Model;

namespace TaidouDatabase.Manager
{
    class TestUserManager
    {
        public IList<TestUser> GetAllUser()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var userlist = session.QueryOver<TestUser>();
                    return userlist.List();
                }
            }
        }

        public IList<TestUser> GetUserByUserName(string username)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var userlist = session.QueryOver<TestUser>().Where( user => user.Username == username);
                    return userlist.List();
                }
            }
        }
        static void Main(string[] args)
        {
            TestUserManager testUserManager = new TestUserManager();
            IList<TestUser> testuserList = testUserManager.GetAllUser();
            foreach (var testUser in testuserList)
            {
                Console.WriteLine("username = " + testUser.Username);
            }
            Console.WriteLine("-----------------------------------------");
            IList<TestUser> testuserList2 = testUserManager.GetUserByUserName("yaojun");
            foreach (var testUser in testuserList2)
            {
                Console.WriteLine("username = " + testUser.Username);
            }
            Console.ReadKey();
        }
    }
}
