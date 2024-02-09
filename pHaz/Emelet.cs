using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace pHaz
{
    internal class Emelet
    {
        public string Nev { get; set; }
        public List<int> szektorSzam { get; set; }


        public Emelet(string sorok)
        {
            string[] sor = sorok.Split(";");
            Nev = sor[0];
            szektorSzam = new List<int>();


            for (int i = 1; i < sor.Length; i++)
            {
                szektorSzam.Add(Convert.ToInt32(sor[i]));
            }
        }


        public override string ToString()
        {
            return $"szint neve {Nev}, szektor: {string.Join(" ", szektorSzam)}";
        }
    }
}

