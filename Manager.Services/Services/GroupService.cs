using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager.Data;
using Manager.Models.GroupBuying;

namespace Manager.Services
{
    /// <summary>
    /// 團服務。
    /// </summary>
    public class GroupService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGroupRepository groupRepository;

        /// <summary>
        /// 初始化 <see cref="GroupService"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="groupRepository">團存放庫。</param>
        public GroupService(IUnitOfWork unitOfWork, IGroupRepository groupRepository)
        {
            this.unitOfWork = unitOfWork;
            this.groupRepository = groupRepository;
        }

        /// <summary>
        /// 取得所有團。
        /// </summary>
        /// <returns>所有團。</returns>
        public async Task<ICollection<Group>> GetGroupsAsync()
        {
            var groups = await groupRepository.ManyAsync(null);

            return groups.ToList();
        }
    }
}
