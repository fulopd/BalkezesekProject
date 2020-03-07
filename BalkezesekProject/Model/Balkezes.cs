using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkezesekProject.Model
{
    class Balkezes
    {
        public string nev { get; set; }
        public DateTime elso { get; set; }
        public DateTime utolso { get; set; }
        public int suly { get; set; }
        public int magassag { get; set; }

        public Balkezes(string nev, DateTime elso, DateTime utolso, int suly, int magassag)
        {
            this.nev = nev;
            this.elso = elso;
            this.utolso = utolso;
            this.suly = suly;
            this.magassag = magassag;
        }

    }
}
