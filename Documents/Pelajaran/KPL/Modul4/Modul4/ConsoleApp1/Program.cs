using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Modul4.program.doormachine;

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
        public enum pintu
        {
            terkunci,
            terbuka
        }
        public enum Trigger
        {
            pintu_buka,
            pintu_kunci
        }
        

        public class doormachine
        {
            public pintu currentstate = pintu.terkunci;
            public class Transisi
            {
                public pintu stateawal;
                public pintu stateakhir;
                public Trigger trigger;
                public Transisi(pintu stateawal, pintu stateakhir, Trigger trigger)
                {
                    this.stateawal = stateawal;
                    this.stateakhir = stateakhir;
                    this.trigger = trigger;
                }
            }

            Transisi[] transisii =
            {
                new Transisi(pintu.terkunci, pintu.terbuka, Trigger.pintu_buka),
                new Transisi(pintu.terbuka, pintu.terkunci, Trigger.pintu_kunci),
                new Transisi(pintu.terbuka, pintu.terbuka, Trigger.pintu_buka),
                new Transisi(pintu.terkunci, pintu.terkunci, Trigger.pintu_kunci)
            };

            private pintu getstateberikutnya(pintu stateawal, Trigger trigger)
            {
                pintu stateakhir = stateawal;
                for(int i = 0; i < transisii.Length; i++)
                {
                    Transisi perubahan = transisii[i];
                    if(stateawal == perubahan.stateawal && trigger == perubahan.trigger)
                    {
                        stateakhir = perubahan.stateakhir;
                    }
                }
                return stateakhir;
                 
            }
            public void trigeraktif(Trigger trigger)
            {
                currentstate = getstateberikutnya(currentstate, trigger);
                Console.WriteLine("State sekarang adalah " + currentstate);
                if(currentstate == pintu.terkunci)
                {
                    Console.WriteLine("pintu sedang terkunci");
                }else if(currentstate == pintu.terbuka)
                {
                    Console.WriteLine("pintu sedang terbuka");
                }
            }
        }

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
            doormachine Pintu = new doormachine();
            Pintu.trigeraktif(Trigger.pintu_kunci);
            Pintu.trigeraktif(Trigger.pintu_buka);
            Pintu.trigeraktif(Trigger.pintu_kunci);
            Pintu.trigeraktif(Trigger.pintu_kunci);
            Pintu.trigeraktif(Trigger.pintu_buka);
            Pintu.trigeraktif(Trigger.pintu_buka);

            Console.WriteLine("----------------------------");

            datakota kota = datakota.Batununggal;
            int kode = getkodepos.getkode(kota);
            Console.WriteLine("kelurahan : " + kota + "\nkodepos : " + kode);
        }
    }
}
