namespace TemplateMvvmLight.Models
{
    /// <summary>
    /// Model utilizzato per memorizzare l'utente autenticato all' interno dell' app
    /// </summary>
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}

