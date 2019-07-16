using System;
using System.Threading.Tasks;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Ordering.Domain.Buyers
{
    public interface IBuyerRepository : IRepository<Buyer>
    {
        /// <summary>
        /// 取得買家。
        /// </summary>
        /// <param name="buyerId">買家 ID。</param>
        /// <returns>買家。</returns>
        Task<Buyer> GetBuyerAsync(Guid buyerId);

        /// <summary>
        /// 加入買家。
        /// </summary>
        /// <param name="buyer">買家。</param>
        void Add(Buyer buyer);

        /// <summary>
        /// 更新買家。
        /// </summary>
        /// <param name="buyer">買家。</param>
        void Update(Buyer buyer);
    }
}