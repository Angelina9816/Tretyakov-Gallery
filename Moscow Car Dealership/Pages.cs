using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moscow_Car_Dealership
{
    class Pages
    {
        private static MainPage main = new MainPage();
        private static Login login = new Login();
        private static Sign_Up sign_up = new Sign_Up();
        private static Dealers dealer = new Dealers();

        public static Login Login
        {
            get
            {
                return login;
            }
        }

        public static MainPage MainPage
        {
            get
            {
                return main;
            }
        }

        public static Sign_Up Sign_Up
        {
            get
            {
                return sign_up;
            }
        }

        public static Dealers Dealers
        {
            get
            {
                return dealer;
            }
        }

    }

 }
    
