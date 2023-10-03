using ClinicService.Models;

namespace ClinicService.Services
{
    /// <summary>
    /// Интерфейс репозитория клиентов.
    /// Определяет контракты для работы с данными о клиентах.
    /// </summary>
    public interface IClientRepository : IRepository<Client, int>
    {
    }
}
