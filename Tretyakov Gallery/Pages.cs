using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tretyakov_Gallery
{
    class Pages
    {
        private static StartPage startPage = new StartPage();
        private static LoginPage loginPage = new LoginPage();
        private static SignUp signUp = new SignUp();
        private static Portrait portrait = new Portrait();       
        private static View view = new View();
        private static Ticket ticket = new Ticket();

        public static LoginPage LoginPage
        {
            get
            {
                return loginPage;
            }
        }

        public static StartPage StartPage
        {
            get
            {
                return startPage;
            }
        }

        public static SignUp SignUp
        {
            get
            {
                return signUp;
            }
        }

        public static Portrait Portrait
        {
            get
            {
                return portrait;
            }
        }
    
        public static View View
        {
            get
            {
                return view;
            }
        }

        public static Ticket Ticket
        {
            get
            {
                return ticket;
            }
        }
    }
}
