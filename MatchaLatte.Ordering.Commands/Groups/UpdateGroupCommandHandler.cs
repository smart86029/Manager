using System;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.Common.Commands;

using MatchaLatte.Ordering.Domain;
using MatchaLatte.Ordering.Domain.Products;
using MatchaLatte.Ordering.Domain.Groups;

namespace MatchaLatte.Ordering.Commands.Groups
{
    ///// <summary>
    ///// 修改團命令處理常式。
    ///// </summary>
    //public class UpdateGroupCommandHandler : ICommandHandler<UpdateGroupCommand, bool>
    //{
    //    private readonly IOrderingUnitOfWork unitOfWork;
    //    private readonly IGroupRepository groupRepository;

    //    /// <summary>
    //    /// 初始化 <see cref="CreateGroupCommandHandler"/> 類別的新執行個體。
    //    /// </summary>
    //    /// <param name="unitOfWork">工作單元。</param>
    //    /// <param name="groupRepository">團存放庫。</param>
    //    public UpdateGroupCommandHandler(IOrderingUnitOfWork unitOfWork, IGroupRepository groupRepository)
    //    {
    //        this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    //        this.groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
    //    }

    //    /// <summary>
    //    /// 處理。
    //    /// </summary>
    //    /// <param name="command">修改團命令。</param>
    //    /// <returns>成功返回為 <c>true</c>，否則為 <c>false</c>。</returns>
    //    public async Task<bool> HandleAsync(UpdateGroupCommand command)
    //    {
    //        var group = await groupRepository.GetGroupAsync(command.GroupId);

    //        group.UpdateEndTime(command.EndTime);
    //        groupRepository.Update(group);
    //        await unitOfWork.CommitAsync();

    //        return true;
    //    }
    //}
}