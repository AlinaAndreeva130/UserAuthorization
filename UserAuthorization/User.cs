namespace UserAuthorization
{
    public class User
    {
        public string Login { get; }
        public string Password { get; }

        public User(string login, string password)
        {
            this.Login = login;
            this.Password = CriptoHelper.HashPassword(password);
        }
    }
}
