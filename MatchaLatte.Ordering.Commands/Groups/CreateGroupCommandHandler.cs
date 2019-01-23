using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MatchaLatte.Common.Commands;
using MatchaLatte.Common.Exceptions;
using MatchaLatte.Ordering.App.Commands.Groups;
using MatchaLatte.Ordering.App.Queries.Groups;
using MatchaLatte.Ordering.Domain;
using MatchaLatte.Ordering.Domain.Groups;
using MatchaLatte.Ordering.Domain.Stores;

namespace MatchaLatte.Ordering.Commands.Groups
{
    /// <summary>
    /// 新增團命令處理常式。
    /// </summary>
    public class CreateGroupCommandHandler : ICommandHandler<CreateGroupCommand, GroupDetail>
    {
        private readonly IOrderingUnitOfWork unitOfWork;
        private readonly IGroupRepository groupRepository;
        private readonly IStoreRepository storeRepository;

        /// <summary>
        /// 初始化 <see cref="CreateGroupCommandHandler"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="groupRepository">團存放庫。</param>
        /// <param name="storeRepository">店家存放庫。</param>
        public CreateGroupCommandHandler(IOrderingUnitOfWork unitOfWork, IGroupRepository groupRepository, IStoreRepository storeRepository)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
            this.storeRepository = storeRepository ?? throw new ArgumentNullException(nameof(storeRepository));
        }

        /// <summary>
        /// 處理。
        /// </summary>
        /// <param name="command">新增團命令。</param>
        /// <returns>團。</returns>
        public async Task<GroupDetail> HandleAsync(CreateGroupCommand command)
        {
            var store = await storeRepository.GetStoreAsync(command.Store.StoreId);
            if (store == default(Store))
                throw new InvalidException();

            var group = new Group(command.Store.StoreId, command.StartTime, command.EndTime, command.Remark, command.CreatedBy);

            groupRepository.Add(group);
            await unitOfWork.CommitAsync();

            var result = new GroupDetail
            {
                GroupId = group.GroupId,
                StartTime = group.StartTime,
                EndTime = group.EndTime,
                Remark = group.Remark,
                Store = new StoreDetail
                {
                    StoreId = store.StoreId,
                    Name = store.Name
                }
            };

            return result;
        }
    }
}
