namespace Core.Services
{
    using System.Net.Mail;
    using System.Net;
    using Core.Options;
    using Microsoft.Extensions.Options;
    using Core.Interfaces;

    public class EmailService: IEmailService
    {
        private readonly CredencialesCorreoOptions _options;
        MailMessage Email;
        public string error = "";

        public EmailService(IOptions<CredencialesCorreoOptions> options)
        { 
            _options = options.Value;
        }

        public bool EnviaMail(string receptor, string mensaje, string asunto, string? alias = null, List<string>? ListadoAdjuntos_URL = null)
        {

            if (string.IsNullOrWhiteSpace(receptor) || string.IsNullOrWhiteSpace(mensaje) || string.IsNullOrWhiteSpace(asunto))
            {
                error = "El mail, el asunto y el mensaje son obligatorios";
                return false;
            }

            //aqui comenzamos el proceso
            //comienza-------------------------------------------------------------------------
            try
            {
                //creamos un objeto tipo MailMessage
                //este objeto recibe el sujeto o persona que envia el mail,
                //la direccion de procedencia, el asunto y el mensaje
                Email = new MailMessage(_options.From, receptor, asunto, mensaje);

                //si viene archivo a adjuntar
                //realizamos un recorrido por todos los adjuntos enviados en la lista
                //la lista se llena con direcciones fisicas, por ejemplo: c:/pato.txt
                if (ListadoAdjuntos_URL != null && ListadoAdjuntos_URL.Any())
                {
                    //agregado de archivo
                    foreach (string archivo in ListadoAdjuntos_URL)
                    {
                        //comprobamos si existe el archivo y lo agregamos a los adjuntos
                        if (File.Exists(@archivo))
                            Email.Attachments.Add(new Attachment(@archivo));
                    }
                }

                Email.IsBodyHtml = true; //definimos si el contenido sera html
                Email.From = new MailAddress(_options.From); //definimos la direccion de procedencia

                //aqui creamos un objeto tipo SmtpClient el cual recibe el servidor que utilizaremos como smtp
                //en este caso me colgare de gmail
                using (var smtpMail = new SmtpClient(_options.Host, _options.Puerto))
                {
                    smtpMail.EnableSsl = _options.Ssl;
                    smtpMail.UseDefaultCredentials = false;
                    smtpMail.Credentials = new NetworkCredential(_options.From, _options.Pass);

                    //enviamos el mail
                    smtpMail.Send(Email);

                    //eliminamos el objeto
                    smtpMail.Dispose();
                }
                //regresamos true
                return true;
            }
            catch (Exception ex)
            {
                //si ocurre un error regresamos false y el error
                error = "Ocurrio un error: " + ex.Message;
                return false;
            }
        }
    }
}
