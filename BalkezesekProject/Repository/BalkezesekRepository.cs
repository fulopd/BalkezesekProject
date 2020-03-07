using BalkezesekProject.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkezesekProject.Repository
{
    class BalkezesekRepository
    {
        List<Balkezes> balkezesekLista = new List<Balkezes>();
        int bekertSzam;

        public BalkezesekRepository()
        {
            getAllBalkezes();
        }

        private void getAllBalkezes()
        {
            using (StreamReader sr = new StreamReader("balkezesek.csv", Encoding.UTF8))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(';');
                    balkezesekLista.Add(new Balkezes(
                        line[0],
                        Convert.ToDateTime(line[1]),
                        Convert.ToDateTime(line[2]),
                        Convert.ToInt32(line[3]),
                        Convert.ToInt32(line[4]))
                        );
                }
            }
        }

        public int count()
        {
            return balkezesekLista.Count();
        }

        public void oktoberbenLeptekPalyara()
        {
            var oktobe = balkezesekLista.Where(x => x.utolso.Year == 1999 && x.utolso.Month == 10);

            foreach (var item in oktobe)
            {
                Console.WriteLine("\t"+item.nev + ", {0:N1}",(double)item.magassag * 2.54);
            }
        }

        public void beker() 
        {
            Console.WriteLine("Adj meg egy évet 1990 és 1999 között!");
            string be = Console.ReadLine();            
            
            if (!int.TryParse(be, out bekertSzam))
            {
                Console.WriteLine("Nem számot adtál meg!");
                beker();
            }

            if (!(bekertSzam >= 1990 && bekertSzam <= 1999))
            {
                Console.WriteLine("Nem 1990 - 1999 közötti évet adtál meg!");
                beker();
            }

            Console.WriteLine("A megadott évszám: " + bekertSzam);
            
        }

        public void atlagSulyBekertEvbenPalyaraLeptek()         
        {
            var bekertevbenLista = balkezesekLista.Where(x => x.elso.Year >= bekertSzam && x.utolso.Year <= bekertSzam);
            Console.WriteLine("Átlag súly {0} -ben pályára léptek: {1:N2}",bekertSzam, bekertevbenLista.Average(x => x.suly)); 
        }

        public void atlagSulyBekertEvbenPalyaraLeptek(int bee)
        {
            double sum =0;
            var bekertevbenLista = balkezesekLista.Where(x => x.elso.Year >= bee && x.utolso.Year <= bee);
            Console.WriteLine("\n\nÁtlag súly {0} -ben pályára léptek: {1:N2}", bee, bekertevbenLista.Average(x => x.suly));
            Console.WriteLine("Elemek száma: "+bekertevbenLista.Count());
            foreach (var item in bekertevbenLista)
            {
                sum += item.suly;
            }
            Console.WriteLine("Átlag máshogy: " + sum / bekertevbenLista.Count());
        }
    }
}
