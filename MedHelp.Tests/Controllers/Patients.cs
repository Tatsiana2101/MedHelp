namespace MedHelp.Tests.Controllers
{
    public class Patients
    {
        private Mock<IPatientService> _mockPatientService;
        private Mock<ITokenService> _mockTokenService;
        private Mock<IConfiguration> _mockConfiguration;
        private HttpContext _fakeContext;

        [SetUp]
        public void Setup()
        {
            _mockPatientService = new Mock<IPatientService>();
            _mockPatientService.Setup(patientService => patientService.GetPatients())
                               .Returns(Task.FromResult(It.IsAny<List<Patient>>()));
            _mockPatientService.Setup(patientService => patientService.GetPatient(It.IsAny<int>()))
                               .Returns(Task.FromResult(It.IsAny<Patient>()));
            _mockPatientService.Setup(patientService => patientService.GetTolones(It.IsAny<int>()))
                               .Returns(Task.FromResult(It.IsAny<List<Tolon>>()));
            _mockPatientService.Setup(patientService => patientService.GetReception(It.IsAny<int>()))
                               .Returns(Task.FromResult(It.IsAny<List<Reception>>()));
            _mockPatientService.Setup(patientService => patientService.DeletePatient(It.IsAny<int>()))
                               .Returns(Task.FromResult(It.IsAny<int>()));
            _mockPatientService.Setup(patientService => patientService.AddPatient(It.IsAny<Patient>()))
                               .Returns(Task.FromResult(It.IsAny<int>()));
            _mockPatientService.Setup(patientService => patientService.UpdatePatient(It.IsAny<Patient>()))
                               .Returns(Task.FromResult(It.IsAny<int>()));
            _mockPatientService.Setup(patientService => patientService.Search(It.IsAny<string>()))
                               .Returns(Task.FromResult(It.IsAny<List<Patient>>()));

            _mockTokenService = new Mock<ITokenService>();
            _mockTokenService.Setup(tokenService => tokenService.CheckAccessKey(It.IsAny<string>()))
                             .Returns(Task.FromResult(true));

            var mockIConfigurationSection = new Mock<IConfigurationSection>();
            mockIConfigurationSection.Setup(x => x.Path)
                                     .Returns("RootLevelValue:SecondLevel");
            mockIConfigurationSection.Setup(x => x.Key)
                                     .Returns("ThirdLevel");
            mockIConfigurationSection.Setup(x => x.Value)
                                     .Returns(It.IsAny<string>());

            _mockConfiguration = new Mock<IConfiguration>();
            _mockConfiguration.Setup(config => config.GetSection(It.IsAny<string>()))
                              .Returns(mockIConfigurationSection.Object);

            _fakeContext = new DefaultHttpContext();
            _fakeContext.Request.Headers["name"] = It.IsAny<string>();
        }

        [Test]
        public async Task GetPatients_Patients()
        {
            var controller = new PatientController(_mockPatientService.Object, _mockTokenService.Object, _mockConfiguration.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = _fakeContext
            };

            var result = await controller.GetPatients();

            Assert.That(result, Is.InstanceOf(typeof(ActionResult<List<Patient>>)));
        }

        [Test]
        public async Task GetPatient_Id_Patient()
        {
            var controller = new PatientController(_mockPatientService.Object, _mockTokenService.Object, _mockConfiguration.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = _fakeContext
            };

            var result = await controller.GetPatient(It.IsAny<int>());

            Assert.That(result, Is.InstanceOf(typeof(ActionResult<Patient>)));
        }

        [Test]
        public async Task GetTolones_Id_Tolones()
        {
            var controller = new PatientController(_mockPatientService.Object, _mockTokenService.Object, _mockConfiguration.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = _fakeContext
            };

            var result = await controller.GetTolones(It.IsAny<int>());

            Assert.That(result, Is.InstanceOf(typeof(ActionResult<List<Tolon>>)));
        }

        [Test]
        public async Task GetReceptions_Id_Tolones()
        {
            var controller = new PatientController(_mockPatientService.Object, _mockTokenService.Object, _mockConfiguration.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = _fakeContext
            };

            var result = await controller.GetReceptions(It.IsAny<int>());

            Assert.That(result, Is.InstanceOf(typeof(ActionResult<List<Reception>>)));
        }

        [Test]
        public async Task DeletePatient_Id_Id()
        {
            var controller = new PatientController(_mockPatientService.Object, _mockTokenService.Object, _mockConfiguration.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = _fakeContext
            };

            var result = await controller.DeletePatient(It.IsAny<int>());

            Assert.That(result, Is.InstanceOf(typeof(ActionResult<int>)));
        }

        [Test]
        public async Task AddPatient_Patient_Id()
        {
            var controller = new PatientController(_mockPatientService.Object, _mockTokenService.Object, _mockConfiguration.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = _fakeContext
            };

            var result = await controller.AddPatient(It.IsAny<Patient>());

            Assert.That(result, Is.InstanceOf(typeof(ActionResult<int>)));
        }

        [Test]
        public async Task UpdatePatient_Patient_Id()
        {
            var controller = new PatientController(_mockPatientService.Object, _mockTokenService.Object, _mockConfiguration.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = _fakeContext
            };

            var result = await controller.UpdatePatient(It.IsAny<Patient>());

            Assert.That(result, Is.InstanceOf(typeof(ActionResult<int>)));
        }

        [Test]
        public async Task Search_Text_Patients()
        {
            var controller = new PatientController(_mockPatientService.Object, _mockTokenService.Object, _mockConfiguration.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = _fakeContext
            };

            var result = await controller.Search(It.IsAny<string>());

            Assert.That(result, Is.InstanceOf(typeof(ActionResult<List<Patient>>)));
        }
    }
}
