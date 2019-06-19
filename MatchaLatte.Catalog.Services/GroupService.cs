using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MatchaLatte.Catalog.App.Commands.Groups;
using MatchaLatte.Catalog.App.Queries;
using MatchaLatte.Catalog.App.Queries.Groups;
using MatchaLatte.Catalog.App.Services;
using MatchaLatte.Catalog.Domain;
using MatchaLatte.Catalog.Domain.Groups;

namespace MatchaLatte.Catalog.Services
{
    public class GroupService : IGroupService
    {
        private ICatalogUnitOfWork unitOfWork;
        private IGroupRepository groupRepository;
        private PictureSettings pictureSettings;

        /// <summary>
        /// 初始化 <see cref="GroupService"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="groupRepository">團存放庫。</param>
        /// <param name="pictureSettings">圖片設定。</param>
        public GroupService(ICatalogUnitOfWork unitOfWork, IGroupRepository groupRepository, PictureSettings pictureSettings)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
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
                        GroupId = x.GroupId,
                        StartTime = x.StartTime,
                        EndTime = x.EndTime,
                        CreatedOn = x.CreatedOn
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
        public Task<GroupDetail> GetGroupAsync(Guid groupId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 取得新團。
        /// </summary>
        /// <param name="storeId">店家 ID。</param>
        /// <returns>新團。</returns>
        public Task<GroupDetail> GetNewGroupAsync(Guid storeId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新增團。
        /// </summary>
        /// <param name="command">新增團命令。</param>
        /// <returns>團。</returns>
        public Task<GroupDetail> CreateGroupAsync(CreateGroupCommand command)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 更新團。
        /// </summary>
        /// <param name="command">更新團命令。</param>
        /// <returns>成功返回 <c>true</c>，否則為 <c>false</c>。</returns>
        public Task<bool> UpdateGroupAsync(UpdateGroupCommand command)
        {
            throw new NotImplementedException();
        }
    }
}