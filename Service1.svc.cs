using System;           // URI class
using System.Net;       // WebClient class
using System.Xml.Linq;  // XElement class

namespace WcfService1{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1{

        public string Hello(){
            return "Hello World";
        }

        public double PiValue() {
            double pi = System.Math.PI;
            return (pi);
        }

        public int absValue(int x) {
            if (x >= 0) return (x);
            else return (-x);
        }

        public string getRandom(int len) {
            string baseURL = "http://venus.sod.asu.edu/WSRepository/Services/RandomString/Service.svc/GetRandomString/";
            string fullURL = baseURL + Convert.ToSingle(len);

            Uri ServivrUri = new Uri(fullURL);  // convert string to Uri type
            WebClient proxy = new WebClient();  // proxy
            byte[] abc = proxy.DownloadData(ServivrUri);    // byte[] type
            string str = System.Text.UTF8Encoding.UTF8.GetString(abc);  // to a string

            XElement xmlroot = XElement.Parse(str);
            string txtContent = ((XElement)(xmlroot)).Value;
            return txtContent;
        }
    }
}
