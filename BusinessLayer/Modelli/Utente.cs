using System;

namespace BusinessLayer
{
    public class Utente
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool IsAdmin { get; set; }
        public int Id { get; set; }

        public Utente(string username, string password)
        {
            Username = username;
            Password = password;
            IsAdmin = false;
            IsAuthenticated = false;
        }

        public Utente(string username, string password, bool admin)
        {
            Username = username;
            Password = password;
            IsAdmin = admin;
            IsAuthenticated = false;
        }

        public Utente(string username, string password, bool admin, int id)
        {
            Username = username;
            Password = password;
            IsAdmin = admin;
            IsAuthenticated = false;
            Id = id;
        }
    }
}
