using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tretyakov_Gallery
{
    class Pictures
    {
        
        private string author;
        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int year;
        public int Year
        {
            get { return year ; }
            set { year = value; }
        }

        public Pictures(string _author, string _name, int _year)
        {         
            author = _author;
            name = _name;
            year = _year;
        }

        public string Show()
        {
            return string.Format("Автор: {0}" + " " + "Название: {1}" + " " + "Год написания: {2}", author,name, year);
        }
    }
}
  
    

