namespace Core.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime GetInitialDateWithBusinessDays(this DateTime fechaInicial, DateTime fechaFinal)
        {
            int diasNoHabiles = CalcularDiasNoHabiles(fechaInicial, fechaFinal);
            DateTime nuevaFechaInicial = fechaInicial.AddDays(-diasNoHabiles);

            // Ajustar la nueva fecha inicial para que caiga en lunes si es sábado o domingo
            if (nuevaFechaInicial.DayOfWeek == DayOfWeek.Saturday)
            {
                nuevaFechaInicial = nuevaFechaInicial.AddDays(2);
            }
            else if (nuevaFechaInicial.DayOfWeek == DayOfWeek.Sunday)
            {
                nuevaFechaInicial = nuevaFechaInicial.AddDays(1);
            }

            return nuevaFechaInicial;
        }

        static int CalcularDiasNoHabiles(DateTime fechaInicial, DateTime fechaFinal)
        {
            int diasNoHabiles = 0;

            // Calcular días no hábiles (sábado y domingo)
            for (DateTime fecha = fechaInicial; fecha <= fechaFinal; fecha = fecha.AddDays(1))
            {
                if (fecha.DayOfWeek == DayOfWeek.Saturday || fecha.DayOfWeek == DayOfWeek.Sunday)
                {
                    diasNoHabiles++;
                }
            }

            return diasNoHabiles;
        }
    }
}
