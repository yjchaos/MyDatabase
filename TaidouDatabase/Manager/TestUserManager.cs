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
                    transaction.Commit();
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
                    transaction.Commit();
                    return userlist.List();
                }
            }
        }

        public void SaveUser(TestUser user)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(user);
                    transaction.Commit();
                }
            }
        }

        public void DeleteById(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    TestUser tu = new TestUser();
                    tu.Id = id;
                    session.Delete(tu);
                    transaction.Commit();
                }
            }  
        }

        public void UpdateUser(TestUser tu)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(tu);
                    transaction.Commit();
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

            Console.WriteLine("-----------save");
            TestUser tu2 = new TestUser();
            tu2.Username = "taikr";
            tu2.Password = "111111";
            tu2.Age = 16;
//            testUserManager.SaveUser(tu2);

            Console.WriteLine("-----------delete");
            //            testUserManager.DeleteById(3);

            Console.WriteLine("-----------update");
            TestUser tu3 = testuserList[0];
            tu3.Age = 44;
            testUserManager.UpdateUser(tu3);
            Console.ReadKey();
        }
    }
}
