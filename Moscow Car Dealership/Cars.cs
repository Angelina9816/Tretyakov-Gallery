using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moscow_Car_Dealership
{
    class Cars
    {
        private string mark;

        public string Mark
        {
            get { return mark; }
            set { mark = value; }
        }
        private string diler;

        public string Diler
        {
            get { return diler; }
            set { diler = value; }
        }
        private string street;

        public string Street
        {
            get { return street; }
            set { street = value; }
        }
        private int house;

        public int House
        {
            get { return house; }
            set { house = value; }
        }

        public Cars(string _mark, string _diler, string _street, int _house)
        {
            mark = _mark;
            diler = _diler;
            street = _street;
            house = _house;
        }
        public string Show()
        {
            return string.Format("{0}" + ";" + " " + "Дилер: {1}" + ";" + " " + "Улица: {2}" + ";" + " " + "Дом № {3}", mark, diler, street, house);
        }
    }
}
