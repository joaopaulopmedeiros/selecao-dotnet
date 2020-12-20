using System;
using App.Contracts.Services;

namespace App.Services
{
    public class EmailService : IEmailService
    {
        public string Send (string destination)
        {
            return String.Format("Seja Bem-vindo - {0}.", destination);
        }
    }
}
