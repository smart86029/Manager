using System.Collections.Generic;
using System.Threading.Tasks;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Notification.Domain.Members
{
    /// <summary>
    /// 成員存放庫。
    /// </summary>
    public interface IMemberRepository : IRepository<Member>
    {
        /// <summary>
        /// 取得成員的集合。
        /// </summary>
        /// <returns>成員的集合。</returns>
        Task<ICollection<Member>> GetMembersAsync();

        /// <summary>
        /// 加入成員。
        /// </summary>
        /// <param name="member">成員。</param>
        Task AddAsync(Member member);
    }
}