using System.Collections.Generic;
using System.Threading.Tasks;
using Manager.Data;
using Manager.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Manager.Service.Tests
{
    /// <summary>
    /// 角色服務測試。
    /// </summary>
    [TestClass]
    public class RoleServiceTests
    {
        [TestMethod]
        public async Task GetRolesAsync_ReturnAllRoles_WithoutRoleId()
        {
            var roles = new List<Role>
            {
                new Role { RoleId = 1, Name = "Administraoter", IsEnabled = true },
                new Role { RoleId = 2, Name = "Member", IsEnabled = true }
            };
            var unitOfWork = new Mock<IUnitOfWork>();
            var roleRepository = new Mock<IRoleRepository>();
            roleRepository.Setup(r => r.ManyAsync(null)).ReturnsAsync(roles);
            var service = new RoleService(unitOfWork.Object, roleRepository.Object);

            var result = await service.GetRolesAsync();
            CollectionAssert.AreEqual(roles, result as List<Role>);
        }

        [TestMethod]
        public async Task GetRoleAsync_ReturnRole_WithExistentRoleId()
        {
            var role = new Role { RoleId = 10, Name = "Test Role", IsEnabled = true };
            var unitOfWork = new Mock<IUnitOfWork>();
            var roleRepository = new Mock<IRoleRepository>();
            roleRepository.Setup(r => r.FindAsync(10)).ReturnsAsync(role);
            var service = new RoleService(unitOfWork.Object, roleRepository.Object);

            var result = await service.GetRoleAsync(10);

            Assert.AreEqual(role, result);
        }

        [TestMethod]
        public async Task GetRoleAsync_ReturnNull_WithNonexistentRoleId()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var roleRepository = new Mock<IRoleRepository>();
            var service = new RoleService(unitOfWork.Object, roleRepository.Object);

            var result = await service.GetRoleAsync(99);

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task CreateAsync_ReturnTrue_WithNewRole()
        {
            var role = new Role { Name = "New Role", IsEnabled = true };
            var unitOfWork = new Mock<IUnitOfWork>();
            var roleRepository = new Mock<IRoleRepository>();
            var service = new RoleService(unitOfWork.Object, roleRepository.Object);

            var result = await service.CreateAsync(role);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task UpdateAsync_ReturnTrue_WithExistentRole()
        {
            var role = new Role { RoleId = 10, Name = "Old Role Name", IsEnabled = true };
            var unitOfWork = new Mock<IUnitOfWork>();
            var roleRepository = new Mock<IRoleRepository>();
            roleRepository.Setup(r => r.FindAsync(10)).ReturnsAsync(role);
            var service = new RoleService(unitOfWork.Object, roleRepository.Object);

            role.Name = "New Role Name";
            var result = await service.UpdateAsync(role, null);

            Assert.IsTrue(result);
        }

        //[TestMethod]
        //public async Task Put_ReturnNoContent_WithDifferentRoleId()
        //{
        //    var role = new Role { RoleId = 10, Name = "New Role", IsEnabled = true };
        //    var unitOfWork = new Mock<IUnitOfWork>();
        //    var roleRepository = new Mock<IRoleRepository>();
        //    var service = new RoleService(unitOfWork.Object, roleRepository.Object);

        //    var actionResult = await controller.Put(11, role);

        //    Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult));
        //}

        [TestMethod]
        public async Task DeleteAsync_ReturnTrue_WithExistentRoleId()
        {
            var role = new Role { RoleId = 10, Name = "Test Role", IsEnabled = true };
            var unitOfWork = new Mock<IUnitOfWork>();
            var roleRepository = new Mock<IRoleRepository>();
            roleRepository.Setup(r => r.FindAsync(10)).ReturnsAsync(role);
            var service = new RoleService(unitOfWork.Object, roleRepository.Object);

            var result = await service.DeleteAsync(10);

            Assert.IsTrue(result);
        }
    }
}