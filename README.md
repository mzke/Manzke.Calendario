![Nuget](https://img.shields.io/nuget/v/Manzke.Calendario?style=for-the-badge)

```
Install-Package Manzke.Calendario
```

Exemplos:

```cs
Calendario.TempoDecorrido(DateTime.Now);
// menos de n minutos atrás

Calendario.MesPassado(new DateTime(2022, 1, 5));
// 31/12/2021

Calendario.DiaDaSemana(new DateTime(2022, 1, 5)).Nome;
// Quarta-Feira

Calendario.PrimeiroDia(new DateTime(2022, 11, 19));
// 01/11/2022

Calendario.UltimoDia(new DateTime(2022, 02, 19));
// 28/02/2022

Calendario.DiaUtil(new DateTime(2022, 08, 27), true)
// 29/08/2022

Calendario.NomeDoMes(8, true);
// ago
```

