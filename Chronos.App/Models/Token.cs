namespace Chronos.App.Models
{
    public sealed class Token
    {
        public string AccessToken { get; set; }

        public string Expiration { get; set; }

        public string Error { get; set; }
    }
}
