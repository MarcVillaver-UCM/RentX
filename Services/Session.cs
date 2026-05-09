using RentXpress.Models;

namespace RentXpress.Services
{
    public static class Session
    {
        public static User CurrentUser { get; private set; }
        public static bool IsLoggedIn => CurrentUser != null;

        public static void Login(User user) => CurrentUser = user;
        public static void Logout() => CurrentUser = null;
    }
}

