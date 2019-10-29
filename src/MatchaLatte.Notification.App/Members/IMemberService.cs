using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatchaLatte.Notification.App.Members
{
    /// <summary>
    /// 成員服務。
    /// </summary>
    public interface IMemberService
    {
        /// <summary>
        /// 取得成員的集合。
        /// </summary>
        /// <returns>成員的集合。</returns>
        Task<ICollection<MemberDetail>> GetMembersAsync();

        /// <summary>
        /// 建立成員。
        /// </summary>
        /// <param name="command">建立成員命令。</param>
        Task CreateMemberAsync(CreateMemberCommand command);
    }
}