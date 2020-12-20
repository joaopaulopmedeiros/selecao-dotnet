namespace App.Contracts.Services
{
    public interface IEmailService
    {
        string Send(string destination);
    }
}
