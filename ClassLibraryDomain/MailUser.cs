using System;

namespace ClassLibraryDomain
{
    public class MailUser
    {

        public int Id    { get;set; }
        public String Name { get; set; }

        public String forName { get; set; }

        public String RankNbr { get; set; }

        public String Address { get; set; }

        public String Unit { get; set; }

        public Classification Classification { get; set; }
        
    }
}