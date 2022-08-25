using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manzke.Calendario
{
    public class Mes
    {

        public string Nome { get; set; } = String.Empty;
        public string Sigla { get; set; } = String.Empty;
        public string ID { get; set; } = String.Empty;
        public string Valor { get; set; } = String.Empty;

        public Mes(string id, string valor)
        {
            ID = id;
            Valor = valor;
        }

        public Mes(string id, string nome, string sigla)
        {
            ID = id;
            Nome = nome;
            Sigla = sigla;
            Valor = Sigla;
        }
    }
}
