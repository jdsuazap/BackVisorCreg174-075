namespace Core.Options
{
    public class CredencialesCorreoOptions
    {
        public int Puerto { get; set; } = 587;
        public string Host { get; set; } = "smtp.office365.com";
        public string From { get; set; } = "no-reply-solicitudes@eep.com.co";
        public string Pass { get; set; } = "po4shAEWbu4Dgt2xpw4W";
        public bool HasAuth { get; set; } = true;
        public bool Ssl { get; set; } = true;
    }
}