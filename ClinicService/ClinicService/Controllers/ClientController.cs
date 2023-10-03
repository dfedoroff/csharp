using ClinicService.Models;
using ClinicService.Models.Requests;
using ClinicService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicService.Controllers
{
    /// <summary>
    /// Контроллер для работы с клиентами клиники.
    /// Предоставляет API для выполнения операций CRUD над клиентами.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        /// <summary>
        /// Конструктор контроллера клиентов.
        /// </summary>
        /// <param name="clientRepository">Репозиторий для работы с данными клиентов.</param>
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        /// <summary>
        /// Создает нового клиента в системе.
        /// </summary>
        /// <param name="createRequest">Данные нового клиента.</param>
        /// <returns>Идентификатор созданного клиента.</returns>
        [HttpPost("create")]
        public ActionResult<int> Create([FromBody] CreateClientRequest createRequest)
        {
            int res = _clientRepository.Create(new Client
            {
                Document = createRequest.Document,
                SurName = createRequest.SurName,
                FirstName = createRequest.FirstName,
                Patronymic = createRequest.Patronymic,
                Birthday = createRequest.Birthday,
            });
            return Ok(res);
        }

        /// <summary>
        /// Обновляет данные существующего клиента.
        /// </summary>
        /// <param name="updateRequest">Обновленные данные клиента.</param>
        /// <returns>Результат выполнения операции.</returns>
        [HttpPut("update")]
        public ActionResult<int> Update([FromBody] UpdateClientRequest updateRequest)
        {
            int res = _clientRepository.Update(new Client
            {
                ClientId = updateRequest.ClientId,
                Document = updateRequest.Document,
                SurName = updateRequest.SurName,
                FirstName = updateRequest.FirstName,
                Patronymic = updateRequest.Patronymic,
                Birthday = updateRequest.Birthday,
            });
            return Ok(res);
        }

        /// <summary>
        /// Удаляет клиента по его идентификатору.
        /// </summary>
        /// <param name="clientId">Идентификатор клиента.</param>
        /// <returns>Результат выполнения операции.</returns>
        [HttpDelete("delete")]
        public ActionResult<int> Delete(int clientId)
        {
            int res = _clientRepository.Delete(clientId);
            return Ok(res);
        }

        /// <summary>
        /// Получает список всех клиентов.
        /// </summary>
        /// <returns>Список клиентов.</returns>
        [HttpGet("get-all")]
        public ActionResult<List<Client>> GetAll()
        {
            return Ok(_clientRepository.GetAll());
        }

        /// <summary>
        /// Получает клиента по его идентификатору.
        /// </summary>
        /// <param name="clientId">Идентификатор клиента.</param>
        /// <returns>Данные клиента.</returns>
        [HttpGet("get-by-id")]
        public ActionResult<Client> GetById(int clientId)
        {
            return Ok(_clientRepository.GetById(clientId));
        }
    }
}
