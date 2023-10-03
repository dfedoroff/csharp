using ClinicService.Models;
using ClinicService.Models.Requests;
using ClinicService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicService.Controllers
{
    /// <summary>
    /// Контроллер для работы с животными (питомцами) клиентов клиники.
    /// Предоставляет API для выполнения операций CRUD над питомцами.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _petRepository;

        /// <summary>
        /// Конструктор контроллера питомцев.
        /// </summary>
        /// <param name="petRepository">Репозиторий для работы с данными питомцев.</param>
        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        /// <summary>
        /// Создает нового питомца в системе.
        /// </summary>
        /// <param name="createRequest">Данные нового питомца.</param>
        /// <returns>Идентификатор созданного питомца.</returns>
        [HttpPost("create")]
        public ActionResult<int> Create([FromBody] CreatePetRequest createRequest)
        {
            int res = _petRepository.Create(new Pet
            {
                ClientId = createRequest.ClientId,
                Name = createRequest.Name,
                Birthday = createRequest.Birthday,
            });
            return Ok(res);
        }

        /// <summary>
        /// Обновляет данные существующего питомца.
        /// </summary>
        /// <param name="updateRequest">Обновленные данные питомца.</param>
        /// <returns>Результат выполнения операции.</returns>
        [HttpPut("update")]
        public ActionResult<int> Update([FromBody] UpdatePetRequest updateRequest)
        {
            int res = _petRepository.Update(new Pet
            {
                PetId = updateRequest.PetId,
                ClientId = updateRequest.ClientId,
                Name = updateRequest.Name,
                Birthday = updateRequest.Birthday,
            });
            return Ok(res);
        }

        /// <summary>
        /// Удаляет питомца по его идентификатору.
        /// </summary>
        /// <param name="petId">Идентификатор питомца.</param>
        /// <returns>Результат выполнения операции.</returns>
        [HttpDelete("delete")]
        public ActionResult<int> Delete(int petId)
        {
            int res = _petRepository.Delete(petId);
            return Ok(res);
        }

        /// <summary>
        /// Получает список всех питомцев.
        /// </summary>
        /// <returns>Список питомцев.</returns>
        [HttpGet("get-all")]
        public ActionResult<List<Pet>> GetAll()
        {
            return Ok(_petRepository.GetAll());
        }

        /// <summary>
        /// Получает питомца по его идентификатору.
        /// </summary>
        /// <param name="petId">Идентификатор питомца.</param>
        /// <returns>Данные питомца.</returns>
        [HttpGet("get-by-id")]
        public ActionResult<Pet> GetById(int petId)
        {
            return Ok(_petRepository.GetById(petId));
        }
    }
}
