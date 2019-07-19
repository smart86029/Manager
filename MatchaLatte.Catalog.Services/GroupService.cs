using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.Catalog.App.Commands.Groups;
using MatchaLatte.Catalog.App.Queries;
using MatchaLatte.Catalog.App.Queries.Groups;
using MatchaLatte.Catalog.App.Services;
using MatchaLatte.Catalog.Domain;
using MatchaLatte.Catalog.Domain.Groups;
using MatchaLatte.Catalog.Domain.Stores;
using MatchaLatte.Common.Exceptions;

namespace MatchaLatte.Catalog.Services
{
    public class GroupService : IGroupService
    {
        private ICatalogUnitOfWork unitOfWork;
        private IGroupRepository groupRepository;
        private IStoreRepository storeRepository;
        private PictureSettings pictureSettings;

        /// <summary>
        /// 初始化 <see cref="GroupService"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="groupRepository">團存放庫。</param>
        /// <param name="storeRepository">店家存放庫。</param>
        /// <param name="pictureSettings">圖片設定。</param>
        public GroupService(ICatalogUnitOfWork unitOfWork, IGroupRepository groupRepository, IStoreRepository storeRepository, PictureSettings pictureSettings)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
            this.storeRepository = storeRepository ?? throw new ArgumentNullException(nameof(storeRepository));
            this.pictureSettings = pictureSettings ?? throw new ArgumentNullException(nameof(pictureSettings));
        }

        /// <summary>
        /// 取得團的集合。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>團的集合。</returns>
        public async Task<PaginationResult<GroupSummary>> GetGroupsAsync(GroupOption option)
        {
            var groups = default(ICollection<Group>);
            var count = 0;

            switch (option.SearchType)
            {
                case GroupSearchType.All:
                    groups = await groupRepository.GetGroupsAsync(option.Offset, option.Limit);
                    count = await groupRepository.GetGroupsCountAsync();
                    break;

                case GroupSearchType.Active:
                    groups = await groupRepository.GetActiveGroupsAsync(option.Offset, option.Limit);
                    count = await groupRepository.GetActiveGroupsCountAsync();
                    break;
            }

            var result = new PaginationResult<GroupSummary>
            {
                Items = groups
                    .Select(x => new GroupSummary
                    {
                        Id = x.Id,
                        StartOn = x.StartOn,
                        EndOn = x.EndOn,
                        CreatedOn = x.CreatedOn,
                        Store = new StoreSummary
                        {
                            Name = x.Store.Name,
                            LogoUri = $"{pictureSettings.BaseUri}{x.StoreId}/logo"
                        }
                    })
                    .ToList(),
                ItemCount = count
            };

            return result;
        }

        /// <summary>
        /// 取得團。
        /// </summary>
        /// <param name="groupId">團 ID。</param>
        /// <returns>團。</returns>
        public async Task<GroupDetail> GetGroupAsync(Guid groupId)
        {
            var group = await groupRepository.GetGroupAsync(groupId);
            var result = new GroupDetail
            {
                Id = group.Id,
                StartOn = group.StartOn,
                EndOn = group.EndOn,
                Remark = group.Remark,
                Store = new StoreDetail
                {
                    Id = group.StoreId,
                    Name = group.Store.Name
                }
            };

            return result;
        }

        /// <summary>
        /// 新增團。
        /// </summary>
        /// <param name="command">新增團命令。</param>
        /// <returns>團。</returns>
        public async Task<GroupDetail> CreateGroupAsync(CreateGroupCommand command)
        {
            var store = await storeRepository.GetStoreAsync(command.Store.id);
            if (store == default(Store))
                throw new InvalidException("商店不存在");

            var group = new Group(command.Store.id, command.StartOn, command.EndOn, command.Remark, command.CreatedBy);

            groupRepository.Add(group);
            await unitOfWork.CommitAsync();

            var result = new GroupDetail
            {
                Id = group.Id,
                StartOn = group.StartOn,
                EndOn = group.EndOn,
                Remark = group.Remark,
                Store = new StoreDetail
                {
                    Id = store.Id,
                    Name = store.Name
                }
            };

            return result;
        }

        /// <summary>
        /// 更新團。
        /// </summary>
        /// <param name="command">更新團命令。</param>
        /// <returns>成功返回 <c>true</c>，否則為 <c>false</c>。</returns>
        public async Task<bool> UpdateGroupAsync(UpdateGroupCommand command)
        {
            var group = await groupRepository.GetGroupAsync(command.id);

            group.UpdateStartOn(command.StartOn);
            group.UpdateEndOn(command.EndOn);
            group.UpdateRemark(command.Remark);
            groupRepository.Update(group);
            await unitOfWork.CommitAsync();

            return true;
        }
    }
}