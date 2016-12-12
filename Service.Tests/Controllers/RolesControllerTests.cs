using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Manager.Common;
using Manager.Data;
using Manager.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Manager.Service.Controllers.Tests
{
    /// <summary>
    /// 角色控制器測試。
    /// </summary>
    [TestClass]
    public class RolesControllerTests
    {
        [TestMethod]
        public async Task Get_ReturnAllRoles_WithoutRoleId()
        {
            var roles = new List<Role>
            {
                new Role { RoleId = 1, Name = "Administraoter", IsActivated = true },
                new Role { RoleId = 2, Name = "Member", IsActivated = true }
            };
            var unitOfWork = new Mock<IUnitOfWork>();
            var roleRepository = new Mock<IRoleRepository>();
            roleRepository.Setup(r => r.ManyAsync(null))
                .ReturnsAsync(roles);
            var controller = new RolesController(unitOfWork.Object, roleRepository.Object);

            var actionResult = await controller.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<Role>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(roles, (List<Role>)contentResult.Content);
        }

        [TestMethod]
        public async Task Get_ReturnRole_WithExistentRoleId()
        {
            var role = new Role { RoleId = 10, Name = "Test Role", IsActivated = true };
            var unitOfWork = new Mock<IUnitOfWork>();
            var roleRepository = new Mock<IRoleRepository>();
            roleRepository.Setup(r => r.FindAsync(10))
                .ReturnsAsync(role);
            var conroller = new RolesController(unitOfWork.Object, roleRepository.Object);

            var actionResult = await conroller.Get(10);
            var contentResult = actionResult as OkNegotiatedContentResult<Role>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(role, contentResult.Content);
        }

        [TestMethod]
        public async Task Get_ReturnNotFound_WithNonexistentRoleId()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var roleRepository = new Mock<IRoleRepository>();
            var controller = new RolesController(unitOfWork.Object, roleRepository.Object);

            var actionResult = await controller.Get(99);

            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task Post_ReturnCreated_WithNewRole()
        {
            var role = new Role { Name = "New Role", IsActivated = true };
            var unitOfWork = new Mock<IUnitOfWork>();
            var roleRepository = new Mock<IRoleRepository>();
            var controller = new RolesController(unitOfWork.Object, roleRepository.Object);

            var actionResult = await controller.Post(role);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Role>;

            Assert.IsNotNull(createdResult);
            Assert.AreEqual(Constant.RouteName, createdResult.RouteName);
            Assert.AreEqual(createdResult.Content.RoleId, createdResult.RouteValues["id"]);
        }

        [TestMethod]
        public async Task Put_ReturnNoContent_WithSameRoleId()
        {
            var role = new Role { RoleId = 10, Name = "New Role", IsActivated = true };
            var unitOfWork = new Mock<IUnitOfWork>();
            var roleRepository = new Mock<IRoleRepository>();
            var controller = new RolesController(unitOfWork.Object, roleRepository.Object);

            var actionResult = await controller.Put(role.RoleId, role);
            var statusCodeResult = actionResult as StatusCodeResult;

            Assert.IsNotNull(statusCodeResult);
            Assert.AreEqual(HttpStatusCode.NoContent, statusCodeResult.StatusCode);
        }

        [TestMethod]
        public async Task Put_ReturnNoContent_WithDifferentRoleId()
        {
            var role = new Role { RoleId = 10, Name = "New Role", IsActivated = true };
            var unitOfWork = new Mock<IUnitOfWork>();
            var roleRepository = new Mock<IRoleRepository>();
            var controller = new RolesController(unitOfWork.Object, roleRepository.Object);

            var actionResult = await controller.Put(11, role);

            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task Delete_ReturnNoContent_WithRoleId()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var roleRepository = new Mock<IRoleRepository>();
            var controller = new RolesController(unitOfWork.Object, roleRepository.Object);

            var actionResult = await controller.Delete(10);
            var statusCodeResult = actionResult as StatusCodeResult;

            Assert.IsNotNull(statusCodeResult);
            Assert.AreEqual(HttpStatusCode.NoContent, statusCodeResult.StatusCode);
        }
    }
}