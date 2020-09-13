namespace JwtAuthExample.Core.Models
{
    public class AppSettings
    {
        public string Key { get; set; }
     
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int LifeTimeSec { get; set; }
    }
}
