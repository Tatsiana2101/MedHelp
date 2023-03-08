namespace MedHelp.Tests.Controllers
{
    public class Doctors
    {
        private Mock<IDoctorService> _mockDoctorService;
        private Mock<ITokenService> _mockTokenService;
        private Mock<IConfiguration> _mockConfiguration;
        private HttpContext _fakeContext;

        [SetUp]
        public void Setup()
        {
            _mockDoctorService = new Mock<IDoctorService>();
            _mockDoctorService.Setup(doctorService => doctorService.GetDoctors())
                              .Returns(Task.FromResult(It.IsAny<List<Doctor>>()));
            _mockDoctorService.Setup(doctorService => doctorService.AddDoctor(It.IsAny<Doctor>()))
                              .Returns(Task.FromResult(It.IsAny<int>()));
            _mockDoctorService.Setup(doctorService => doctorService.DeleteDoctor(It.IsAny<int>()))
                              .Returns(Task.FromResult(It.IsAny<int>()));
            _mockDoctorService.Setup(doctorService => doctorService.UpdateDoctor(It.IsAny<Doctor>()))
                              .Returns(Task.FromResult(It.IsAny<int>()));
            _mockDoctorService.Setup(doctorService => doctorService.GetTolones(It.IsAny<int>()))
                              .Returns(Task.FromResult(It.IsAny<List<Tolon>>()));
            _mockDoctorService.Setup(doctorService => doctorService.AddTolon(It.IsAny<Tolon>()))
                              .Returns(Task.FromResult(It.IsAny<int>()));
            _mockDoctorService.Setup(doctorService => doctorService.DeleteTolon(It.IsAny<int>()))
                              .Returns(Task.FromResult(It.IsAny<int>()));
            _mockDoctorService.Setup(doctorService => doctorService.GetTolon(It.IsAny<int>()))
                              .Returns(Task.FromResult(It.IsAny<Tolon>()));
            _mockDoctorService.Setup(doctorService => doctorService.AddReception(It.IsAny<Reception>()))
                              .Returns(Task.FromResult(It.IsAny<int>()));
            _mockDoctorService.Setup(doctorService => doctorService.GetReception(It.IsAny<int>()))
                              .Returns(Task.FromResult(It.IsAny<List<Reception>>()));

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
        public async Task GetDoctors_Doctors()
        {
            var controller = new DoctorController(_mockDoctorService.Object, _mockTokenService.Object, _mockConfiguration.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = _fakeContext
            };

            var result = await controller.GetDoctors();

            Assert.That(result, Is.InstanceOf(typeof(ActionResult<List<Doctor>>)));
        }

        [Test]
        public async Task AddDoctor_Doctor_Id()
        {
            var controller = new DoctorController(_mockDoctorService.Object, _mockTokenService.Object, _mockConfiguration.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = _fakeContext
            };

            var result = await controller.AddDoctor(It.IsAny<Doctor>());

            Assert.That(result, Is.InstanceOf(typeof(ActionResult<int>)));
        }

        [Test]
        public async Task DeleteDoctor_Id_Id()
        {
            var controller = new DoctorController(_mockDoctorService.Object, _mockTokenService.Object, _mockConfiguration.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = _fakeContext
            };

            var result = await controller.DeleteDoctor(It.IsAny<int>());

            Assert.That(result, Is.InstanceOf(typeof(ActionResult<int>)));
        }

        [Test]
        public async Task UpdateDoctor_Doctor_Id()
        {
            var controller = new DoctorController(_mockDoctorService.Object, _mockTokenService.Object, _mockConfiguration.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = _fakeContext
            };

            var result = await controller.UpdateDoctor(It.IsAny<Doctor>());

            Assert.That(result, Is.InstanceOf(typeof(ActionResult<int>)));
        }

        [Test]
        public async Task GetTolones_Tolones()
        {
            var controller = new DoctorController(_mockDoctorService.Object, _mockTokenService.Object, _mockConfiguration.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = _fakeContext
            };

            var result = await controller.GetTolones(It.IsAny<int>());

            Assert.That(result, Is.InstanceOf(typeof(ActionResult<List<Tolon>>)));
        }

        [Test]
        public async Task AddTolon_Tolon_Id()
        {
            var controller = new DoctorController(_mockDoctorService.Object, _mockTokenService.Object, _mockConfiguration.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = _fakeContext
            };

            var result = await controller.AddTolon(It.IsAny<Tolon>());

            Assert.That(result, Is.InstanceOf(typeof(ActionResult<int>)));
        }

        [Test]
        public async Task DeleteTolon_Id_Id()
        {
            var controller = new DoctorController(_mockDoctorService.Object, _mockTokenService.Object, _mockConfiguration.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = _fakeContext
            };

            var result = await controller.DeleteTolon(It.IsAny<int>());

            Assert.That(result, Is.InstanceOf(typeof(ActionResult<int>)));
        }

        [Test]
        public async Task GetTolon_Id_Tolon()
        {
            var controller = new DoctorController(_mockDoctorService.Object, _mockTokenService.Object, _mockConfiguration.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = _fakeContext
            };

            var result = await controller.GetTolon(It.IsAny<int>());

            Assert.That(result, Is.InstanceOf(typeof(ActionResult<Tolon>)));
        }

        [Test]
        public async Task AddReception_Reception_Id()
        {
            var controller = new DoctorController(_mockDoctorService.Object, _mockTokenService.Object, _mockConfiguration.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = _fakeContext
            };

            var result = await controller.AddReception(It.IsAny<Reception>());

            Assert.That(result, Is.InstanceOf(typeof(ActionResult<int>)));
        }

        [Test]
        public async Task GetReceptions_Id_Reception()
        {
            var controller = new DoctorController(_mockDoctorService.Object, _mockTokenService.Object, _mockConfiguration.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = _fakeContext
            };

            var result = await controller.GetReceptions(It.IsAny<int>());

            Assert.That(result, Is.InstanceOf(typeof(ActionResult<List<Reception>>)));
        }
    }
}
