using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tretyakov_Gallery
{
    class Online
    {
        public static Online GetOnline()
        {
            Online t = null;
            string filename = W.TicketFile;
            if (File.Exists(filename))
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    XmlSerializer xmlser = new XmlSerializer(typeof(Online));
                    t = (Online)xmlser.Deserialize(fs);
                    fs.Close();
                }
            }
            else t = new Online();
            return t;
        }

        public void Save()
        {
            string filename = W.TicketFile;
            if (File.Exists(filename)) File.Delete(filename);
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                XmlSerializer xmlser = new XmlSerializer(typeof(Online));
                xmlser.Serialize(fs, this);
                fs.Close();
            }
        }
        public string Surname { get; set; }
        public string Name { get; set; }        
        public string Email { get; set; }     
    }
}

    

