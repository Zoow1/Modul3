using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul4
{
    internal class program
    {
        public enum datakota
        {
            Batununggal,
            Kujangsari,
            Mengger,
            Wates,
            Cijaura,
            Jatisari,
            Margasari,
            Sekejati,
            Kebonwaru,
            Maleer,
            Samoja
        };
        public class getkodepos
        {
            //public static int[] kodepos = { 40266, 40287, 40267, 40256, 40287, 40286, 40286, 40286, 40272, 4027, 40273 };
            public static int getkode(datakota kota)
            {
                int[] kodepos = { 40266, 40287, 40267, 40256, 40287, 40286, 40286, 40286, 40272, 4027, 40273 };
                return kodepos[(int)kota];
            }
        }
        public static void Main(string[] args)
        {
            //getkodepos KODEPOS = new getkodepos();
            datakota kota = datakota.Batununggal;
            int kode = getkodepos.getkode(kota);
            Console.WriteLine("kelurahan : " + kota + "\nkodepos : " + kode);
        }
    }
}
