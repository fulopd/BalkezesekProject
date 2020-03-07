using BalkezesekProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkezesekProject
{
    class Program
    {
        static void Main(string[] args)
        {
            BalkezesekRepository br = new BalkezesekRepository();
            Console.WriteLine("3. Feladat: " + br.count());
            Console.WriteLine("4. Feladat: ");
            br.oktoberbenLeptekPalyara();
            Console.WriteLine("5. Feladat:");
            br.beker();
            Console.WriteLine("6. Feladat:");
            br.atlagSulyBekertEvbenPalyaraLeptek();

            for (int i = 1990; i <= 1999; i++)
            {
                br.atlagSulyBekertEvbenPalyaraLeptek(i);
            }

            Console.ReadKey();
        }
    }
}
