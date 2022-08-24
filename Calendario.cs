using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manzke.Calendario
{
    public class Calendario
    {
        private DateTime Data { get; set; }
        private List<DiaDaSemana> diasDaSemana;
        private List<Mes> Meses { get;set; }

        public Calendario()
        {
            diasDaSemana = DiasDaSemana();
            Meses = new List<Mes>();
            for (int m = 1; m <= 12; m++)
            {
                DateTime d = new DateTime(2000, m, 1);
                Meses.Add(new Mes(m.ToString(), d.ToString("MMMM"), d.ToString("MMM")));
            }
        }

        public Calendario(DateTime data) : this()
        {
            this.Data = data;
        }

        /// <summary>
        /// Retorna uma frase com o tempo decorrido em minutos, horas ou dias.
        /// </summary>
        /// <returns></returns>
        public string TempoDecorrido()
        {
            return TempoDecorrido(Data, false);
        }

        public static string TempoDecorrido(DateTime data)
        {
            return TempoDecorrido(data, false);
        }
        public static string TempoDecorrido(DateTime data, bool sigla)
        {
            double result = 0;
            var descricao = string.Empty;
            var d = DateTime.Now.Subtract(data);
            result = Math.Truncate(d.TotalDays);
            if (result < 1)
            {
                result = Math.Truncate(d.TotalHours);
                if (result < 1)
                {
                    result = Math.Truncate(d.TotalMinutes);
                    if (result < 1)
                    {
                        descricao = sigla ? "<1m" : "menos de 1 minuto atrás";
                    }
                    else
                    {
                        if (sigla)
                        {
                            descricao = "m";
                        }
                        else
                        {
                            if (result == 1)
                                descricao = " minuto atrás";
                            else
                                descricao = " minutos atrás";
                        }

                    }
                }
                else
                {
                    if (sigla)
                    {
                        descricao = "h";
                    }
                    else
                    {
                        if (result == 1)
                            descricao = " hora atrás";
                        else
                            descricao = " horas atrás";
                    }
                }
            }
            else
            {
                if (sigla)
                {
                    descricao = "d";
                }
                else
                {
                    if (result == 1)
                        descricao = " dia atrás";
                    else
                        descricao = " dias atrás";
                }
            }
            if (result > 0)
                return result.ToString() + descricao;
            else
                return descricao;

        }

        public static List<DiaDaSemana> DiasDaSemana()
        {
            var result = new List<DiaDaSemana>();
            result.Add(new DiaDaSemana(0, "Domingo", "DOM"));
            result.Add(new DiaDaSemana(1, "Segunda-Feira", "SEG"));
            result.Add(new DiaDaSemana(2, "Terça-Feira", "TER"));
            result.Add(new DiaDaSemana(3, "Quarta-Feira", "QUA"));
            result.Add(new DiaDaSemana(4, "Quinta-Feira", "QUI"));
            result.Add(new DiaDaSemana(5, "Sexta-Feira", "SEX"));
            result.Add(new DiaDaSemana(6, "Sábado", "SAB"));
            return result;
        }

        /// <summary>
        /// Retorna um objeto DiaDaSemana para indice. (Domingo = 0).
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DiaDaSemana DiaDaSemana(int id)
        {
            return diasDaSemana.First(D => D.ID == id);
        }

        /// <summary>
        /// Retorna uma lista com os dias do mês.
        /// </summary>
        /// <param name="mes"></param>
        /// <param name="ano"></param>
        /// <returns></returns>
        public List<int> DiasDoMes(int mes, int ano)
        {
            if (ano == 0)
                ano = DateTime.Now.Year;
            List<int> dias = new List<int>();
            for (int dia = 1; dia <= DateTime.DaysInMonth(ano, mes); dia++)
            {
                dias.Add(dia);
            }
            return dias;
        }

        /// <summary>
        /// Retorna a data ajusta para o último dia do mês anterior.
        /// </summary>
        /// <returns></returns>
        public  DateTime MesPassado()
        {
            return MesPassado(Data);
        }
        public static DateTime MesPassado(DateTime data)
        {
            DateTime mesPassado = new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month)).AddMonths(-1);
            return new DateTime(mesPassado.Year, mesPassado.Month, DateTime.DaysInMonth(mesPassado.Year, mesPassado.Month));
        }

        public static DiaDaSemana DiaDaSemana(DateTime data)
        {
            return DiasDaSemana().First(D => D.ID == (int)data.DayOfWeek);
        }

        /// <summary>
        /// Retorna a data para o primeiro dia do mes.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DateTime PrimeiroDia(DateTime? data)
        {
            if (data.HasValue)
                return new DateTime(data.Value.Year, data.Value.Month, 1);
            else
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        /// <summary>
        /// Retorna a data para o ultimo dia do mes.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DateTime UltimoDia(DateTime? data)
        {
            if (data.HasValue)
                return new DateTime(data.Value.Year, data.Value.Month, DateTime.DaysInMonth(data.Value.Year, data.Value.Month));
            else
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
        }

        /// <summary>
        /// Retorna a data para a ultima hora do dia.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DateTime UltimaHora(DateTime? data)
        {
            if (data.HasValue)
                return new DateTime(data.Value.Year, data.Value.Month, data.Value.Day, 23, 59, 59);
            else
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
        }

        /// <summary>
        /// Retorna a data util.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DateTime DiaUtil(DateTime data, bool noMesmoMes)
        {
            if (data.DayOfWeek == DayOfWeek.Saturday)
            {
                var ultimoData = UltimoDia(data);
                if (data.Date == ultimoData.Date && noMesmoMes)
                    data = data.Subtract(new TimeSpan(1, 0, 0, 0));
                else
                    data = data.Add(new TimeSpan(1, 0, 0, 0, 0));
            }

            if (data.DayOfWeek == DayOfWeek.Sunday)
            {
                var ultimoData = UltimoDia(data);
                if (data.Date == ultimoData.Date && noMesmoMes)
                    data = data.Subtract(new TimeSpan(2, 0, 0, 0));
                else
                    data = data.Add(new TimeSpan(1, 0, 0, 0, 0));
            }
            return data;
        }

        /// <summary>
        /// Retorma uma lista de anos de um período.
        /// </summary>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        /// <returns></returns>
        public static List<int> Anos(DateTime dataInicial, DateTime dataFinal)
        {
            var result = new List<int>();
            var anoInicial = dataInicial.Year;
            var anofinal = dataFinal.Year;
            for (int ano = anoInicial; ano <= anofinal; ano++)
            {
                result.Add(ano);
            }
            return result;
        }

        public static int Idade(DateTime DataDeNascimento)
        {
            DateTime now = DateTime.Today; // today is fine, don't need the timestamp from now
            int years = now.Year - DataDeNascimento.Year;
            if (now.Month < DataDeNascimento.Month || (now.Month == DataDeNascimento.Month && now.Day < DataDeNascimento.Day))
                --years;
            return years;
        }

        public string NomeDoMes()
        {
            return NomeDoMes(Data.Month, false);
        }

        public static string NomeDoMes(int mes)
        {
            return NomeDoMes(mes, false);
        }

        public static string NomeDoMes(int mes, bool abreviado)
        {
            if (mes < 1 || mes > 12)
                throw new ArgumentOutOfRangeException("mes");
            DateTime date = new DateTime(1, mes, 1);
            if (abreviado)
                return date.ToString("MMM");
            else
                return date.ToString("MMMM");
        }

        public static bool IsDate(object data)
        {
            try
            {
                if (data != null)
                {
                    DateTime temp = Convert.ToDateTime(data);
                    return true; 
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static DateTime PrimeiraDataDoAno(int ano)
        {
            return new DateTime(ano, 1, 1, 0, 0, 0);
        }

        public static DateTime UltimaDataDoAno(int ano)
        {
            return new DateTime(ano, 12, 31, 23, 59, 59);
        }


    }
}
