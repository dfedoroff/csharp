using ClinicService.Models;
using ClinicService.Models.Requests;
using ClinicService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicService.Controllers
{
    /// <summary>
    /// Контроллер для работы с консультациями.
    /// Предоставляет API для выполнения операций CRUD над консультациями.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationRepository _consultationRepository;

        /// <summary>
        /// Конструктор контроллера консультаций.
        /// </summary>
        /// <param name="consultationRepository">Репозиторий для работы с данными консультаций.</param>
        public ConsultationController(IConsultationRepository consultationRepository)
        {
            _consultationRepository = consultationRepository;
        }

        /// <summary>
        /// Создает новую консультацию в системе.
        /// </summary>
        /// <param name="createRequest">Данные новой консультации.</param>
        /// <returns>Идентификатор созданной консультации.</returns>
        [HttpPost("create")]
        public ActionResult<int> Create([FromBody] CreateConsultationRequest createRequest)
        {
            int res = _consultationRepository.Create(new Consultation
            {
                ClientId = createRequest.ClientId,
                PetId = createRequest.PetId,
                ConsultationDate = createRequest.ConsultationDate,
                Description = createRequest.Description,
            });
            return Ok(res);
        }

        /// <summary>
        /// Обновляет данные существующей консультации.
        /// </summary>
        /// <param name="updateRequest">Обновленные данные консультации.</param>
        /// <returns>Результат выполнения операции.</returns>
        [HttpPut("update")]
        public ActionResult<int> Update([FromBody] UpdateConsultationRequest updateRequest)
        {
            int res = _consultationRepository.Update(new Consultation
            {
                ConsultationId = updateRequest.ConsultationId,
                ClientId = updateRequest.ClientId,
                PetId = updateRequest.PetId,
                ConsultationDate = updateRequest.ConsultationDate,
                Description = updateRequest.Description,
            });
            return Ok(res);
        }

        /// <summary>
        /// Удаляет консультацию по ее идентификатору.
        /// </summary>
        /// <param name="consultationId">Идентификатор консультации.</param>
        /// <returns>Результат выполнения операции.</returns>
        [HttpDelete("delete")]
        public ActionResult<int> Delete(int consultationId)
        {
            int res = _consultationRepository.Delete(consultationId);
            return Ok(res);
        }

        /// <summary>
        /// Получает список всех консультаций.
        /// </summary>
        /// <returns>Список консультаций.</returns>
        [HttpGet("get-all")]
        public ActionResult<List<Consultation>> GetAll()
        {
            return Ok(_consultationRepository.GetAll());
        }

        /// <summary>
        /// Получает консультацию по ее идентификатору.
        /// </summary>
        /// <param name="consultationId">Идентификатор консультации.</param>
        /// <returns>Данные консультации.</returns>
        [HttpGet("get-by-id")]
        public ActionResult<Consultation> GetById(int consultationId)
        {
            return Ok(_consultationRepository.GetById(consultationId));
        }
    }
}
