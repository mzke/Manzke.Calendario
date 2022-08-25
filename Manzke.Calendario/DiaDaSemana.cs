using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manzke.Calendario
{
    public class DiaDaSemana
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

        public DiaDaSemana(int id, string nome, string sigla)
        {
            ID = id;
            Nome = nome;
            Sigla = sigla; 
        }
    }
}
