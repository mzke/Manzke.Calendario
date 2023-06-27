using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manzke.Calendario
{
    public class Periodo
    {
        public DateTime? Inicio { get; set; } = DateTime.MinValue;
        public DateTime? Fim { get; set; } = DateTime.MaxValue;
        public bool HasValue { get; set; }

        public Periodo(DateTime? inicio, DateTime? fim)
        {
            Inicio = inicio;
            Fim = fim;
            HasValue = inicio.HasValue | fim.HasValue;
        }

        public string Format()
        {
            if (Inicio.HasValue && Fim.HasValue)
            {
                if (Inicio.Value.Day == 1 && Inicio.Value.Month == 1 && Fim.Value.Day == 31 && Fim.Value.Month == 12)
                    return FormatAnos();
                if (Inicio.Value.Day == 1 && Fim == Calendario.UltimoDia(Fim))
                    return FormatMeses();
            }
            var result = string.Empty;
            if (Inicio.HasValue)
                result = Inicio.Value.ToShortDateString();
            if (Inicio.HasValue && Fim.HasValue)
                result += " até ";
            if (Fim.HasValue)
                result += Fim.Value.ToShortDateString();
            return result;
        }

        private string FormatMeses()
        {
            if (Inicio.Value.Month == Fim.Value.Month && Inicio.Value.Year == Fim.Value.Year)
                return $"{Inicio.Value.Month.ToString("D2")}/{Inicio.Value.Year}";
            else
                return $"{Inicio.Value.Month.ToString("D2")}/{Inicio.Value.Year} até {Fim.Value.Month}/{Fim.Value.Year}";
        }

        private string FormatAnos()
        {
            string result = string.Empty;

            if (Inicio.HasValue)
            {
                result += Inicio.Value.Year;
            }

            if (Fim.HasValue)
            {
                if (Inicio.HasValue)
                {
                    if (Fim.Value.Year > Inicio.Value.Year)
                    {
                        result += " até " + Fim.Value.Year;
                    }
                }
                else
                {
                    result += Fim.Value.Year;
                }
            }
            return result;
        }

        public enum Formato
        {
            Anos,
            Meses
        }
    }
}
