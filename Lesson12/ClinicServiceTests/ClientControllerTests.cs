using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicService.Controllers;
using ClinicService.Models;
using ClinicService.Models.Requests;
using ClinicService.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ClinicServiceTests
{
    public class ClientControllerTests
    {
        private ClientController _clientController;
        private Mock<IClientRepository> _mocClientRepository;

        public ClientControllerTests()
        {
            _mocClientRepository = new Mock<IClientRepository>();
            _clientController = new ClientController(_mocClientRepository.Object);
        }

        [Fact]
        public void GetAllClientsTests()
        {
            List<Client> list = new List<Client>();
            list.Add(new Client());
            list.Add(new Client());
            list.Add(new Client());


            _mocClientRepository.Setup(repository => repository.GetAll()).Returns(list);

            var operationResult = _clientController.GetAll();

            Assert.IsType<OkObjectResult>(operationResult.Result);
            Assert.IsAssignableFrom<List<Client>>(((OkObjectResult)operationResult.Result).Value);

            _mocClientRepository.Verify(repository => repository.GetAll(), Times.AtLeastOnce());
        }

        public static readonly object[][] CorrectCreateClientData =
        {
            new object[] { new DateTime(1985, 5, 20), "123 1234", "Иванов", "Андрей", "Сергеевич" },
            new object[] { new DateTime(1987, 2, 18), "123 2222", "Иванов", "Андрей", "Сергеевич" },
            new object[] { new DateTime(1979, 1, 22), "123 4321", "Иванов", "Андрей", "Сергеевич" },
        };

        [Theory]
        [MemberData(nameof(CorrectCreateClientData))]
        public void CreateClientTest(DateTime birthday, string document, string surName, string firstName, string patronymic)
        {
            _mocClientRepository.Setup(repository => repository.Create(It.IsNotNull<Client>())).Returns(1).Verifiable();

            var operationResult = _clientController.Create(new CreateClientRequest
            {
                Birthday = birthday,
                Document = document,
                SurName = surName,
                FirstName = firstName,
                Patronymic = patronymic
            });

            Assert.IsType<OkObjectResult>(operationResult.Result);
            Assert.IsAssignableFrom<int>(((OkObjectResult)operationResult.Result).Value);

            _mocClientRepository.Verify(repository => repository.Create(It.IsNotNull<Client>()), Times.AtLeastOnce());
        }

        [Fact]
        public void DeleteClientTest()
        {
            int clientId = 2;
            _mocClientRepository.Setup(repository => repository.Delete(It.IsAny<int>())).Returns(1).Verifiable();
            var operationResult = _clientController.Delete(clientId);

            Assert.IsType<OkObjectResult>(operationResult.Result);
            Assert.IsAssignableFrom<int>(((OkObjectResult)operationResult.Result).Value);

            _mocClientRepository.Verify(repository => repository.Delete(It.IsAny<int>()), Times.AtLeastOnce());
        }

        public static readonly object[][] CorrectUpdateClientData =
        {
            new object[] { 1, new DateTime(1985, 5, 20), "123 1234", "Иванов", "Андрей", "Сергеевич" },
            new object[] { 2, new DateTime(1987, 2, 18), "123 2222", "Иванов", "Андрей", "Сергеевич" },
            new object[] { 3, new DateTime(1979, 1, 22), "123 4321", "Иванов", "Андрей", "Сергеевич" },
        };

        [Theory]
        [MemberData(nameof(CorrectUpdateClientData))]
        public void UpdateClientTest(int clientId, DateTime birthday, string document, string surName, string firstName, string patronymic)
        {
            _mocClientRepository.Setup(repository => repository.Update(It.IsNotNull<Client>())).Returns(1).Verifiable();

            var operationResult = _clientController.Update(new UpdateClientRequest
            {
                ClientId = clientId,
                Birthday = birthday,
                Document = document,
                SurName = surName,
                FirstName = firstName,
                Patronymic = patronymic
            });

            Assert.IsType<OkObjectResult>(operationResult.Result);
            Assert.IsAssignableFrom<int>(((OkObjectResult)operationResult.Result).Value);

            _mocClientRepository.Verify(repository => repository.Update(It.IsNotNull<Client>()), Times.AtLeastOnce());
        }

        [Fact]
        public void GerByIdClient()
        {
            Client client = new Client();
            int clientId = 2;

            _mocClientRepository.Setup(repository => repository.GetById(It.IsAny<int>())).Returns(client).Verifiable();

            var operationResult = _clientController.GetById(clientId);

            Assert.IsType<OkObjectResult>(operationResult.Result);
            Assert.IsAssignableFrom<Client>(((OkObjectResult)operationResult.Result).Value);

            _mocClientRepository.Verify(repository => repository.GetById(It.IsAny<int>()), Times.AtLeastOnce());
        }
    }
}
