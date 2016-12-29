using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain
{
  public sealed  class UserService
  {
      private static UserService _userService=new UserService();

        

      public MailUser GetUser(String serialNbr)
      {
            return Repository<MailUser>.GetInstance().GetUser(serialNbr);
      }


        public IList<MailUser> Users()
        {
            return Repository<MailUser>.GetInstance().All();
        }


      public MailUser AddUser(MailUser mailUser)
      {
          return Repository<MailUser>.GetInstance().Add(mailUser);
      }


        public void UpdateUser(MailUser mailUser)
        {
            Repository<MailUser>.GetInstance().Update(mailUser);
        }



        public void RemoveUser(MailUser user)
        {
            Repository<MailUser>.GetInstance().Delete(user);
        }

        public void DeleteAll()
        {
             Repository<MailUser>.GetInstance().DeleteAll();
        }

        public static UserService GetInstance()
      {
          return _userService;
      }


    }
}
