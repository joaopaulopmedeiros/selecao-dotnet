using System.Collections.Generic;
using App.Models;
using App.Helpers;

namespace App.Repositories
{
    //Temp dumb repository
    public static class UserRepository
    {
        public static User Get(string email, string password)
        {
            var users = new List<User>();

            users.Add(new User { Id = 1, FirstName = "João", LastName = "Medeiros", Password = Hash.Make("12345678"), Cpf = "111.111.111-11", Email = "joao@email.com" });
            return users[0];
        }

    }
}