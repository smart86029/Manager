using System;
using System.Threading.Tasks;
using Manager.App.Commands;
using Manager.App.Commands.System;
using Manager.Domain.Models.System;
using Manager.Domain.Repositories.System;

namespace Manager.Commands.System
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, bool>
    {
        private readonly ISystemUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        public UpdateUserCommandHandler(ISystemUnitOfWork unitOfWork, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
        }

        public async Task<bool> HandleAsync(ICommand command)
        {
            var updateUserCommand = command as UpdateUserCommand ?? throw new NotSupportedException();

            var user = await userRepository.GetUserAsync(updateUserCommand.UserId);
            if (user == default(User))
                return false;

            //var roleIds = query.Roles.Where(x => x.IsChecked).Select(x => x.RoleId);
            //user.UserName = query.UserName;
            //if (!string.IsNullOrWhiteSpace(query.Password))
            //    user.PasswordHash = CryptographyUtility.Hash(query.Password);

            //var specification = new PaginationSpecification<Role> { Criteria = r => roleIds.Contains(r.RoleId) };
            //user.IsEnabled = query.IsEnabled;
            //user.UserRoles = (await roleRepository.ManyAsync(specification)).Select(r => new UserRole { UserId = user.UserId, RoleId = r.RoleId }).ToList();
            user.UpdateUserName(updateUserCommand.UserName);
            userRepository.Update(user);
            await unitOfWork.CommitAsync();

            return true;
        }
    }
}