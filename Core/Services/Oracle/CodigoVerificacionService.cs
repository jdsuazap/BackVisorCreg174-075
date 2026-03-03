namespace Core.Services.Oracle
{
    using Core.Exceptions;
    using Core.Extensions;
    using Core.Interfaces;
    using Core.Interfaces.Oracle;
    using Core.Options;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Options;
    using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;

    public class CodigoVerificacionService : ICodigoVerificacionService
    {
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;
        private readonly CodigoVerificacionOptions _codigoVerificacionOptions;

        public CodigoVerificacionService(
            IMemoryCache cache,
             IOptions<CodigoVerificacionOptions> codigoVerificacionOptions,
             IUnitOfWork unitOfWork,
             IEmailService emailService)
        { 
            _cache = cache;
            _unitOfWork = unitOfWork;
            _emailService = emailService;
            _codigoVerificacionOptions = codigoVerificacionOptions.Value;
        }

        public async Task<string> GenerarCodigoVerificacion(string Contacto, string titulo, string mensaje)
        {
            //var parametros = await _parametrosGlobalesService.GetAll();
            Contacto = Contacto.RemoveSpace();

            var random = new Random();
            var codigo = new string(Enumerable.Repeat(_codigoVerificacionOptions.Chars, _codigoVerificacionOptions.NumberAmount)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            _cache.Set(Contacto, codigo, TimeSpan.FromMinutes(_codigoVerificacionOptions.Time));

            //var plantilla = parametros
            //    .Where(p => p.Id == (int)EnumParametrosGlobales.PLANTILLA_CODIGO_VERIFICACION)
            //    .Select(p => p.Cuerpo)
            //    .FirstOrDefault() ?? 
            
            var plantilla = $"El Codigo de verificacion es: {codigo}";

            plantilla = plantilla.Replace("##CODIGO##", codigo.ToString());
            plantilla = plantilla.Replace("##MINUTOS##", _codigoVerificacionOptions.Time.ToString());
            plantilla = plantilla.Replace("##MENSAJE##", mensaje);
            plantilla = plantilla.Replace("##FECHA_VENCIMIENTO##", DateTime.Now.AddMinutes(5).ToString());


            _emailService.EnviaMail(Contacto, plantilla, titulo);           
            return codigo;
        }

        public bool ValidarCodigoVerificacion(string email, string codigoIngresado)
        {
            if (_cache.TryGetValue(email, out string codigoGuardado))
            {
                return codigoGuardado.Equals(codigoIngresado, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }
    }
}
