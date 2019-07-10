using System;
using System.Threading.Tasks;
using MatchaLatte.Ordering.Domain.Buyers;
using Microsoft.EntityFrameworkCore;

namespace MatchaLatte.Ordering.Data.Repositories
{
    public class BuyerRepository : IBuyerRepository
    {
        private readonly OrderingContext context;

        /// <summary>
        /// 初始化 <see cref="BuyerRepository"/> 類別的新執行個體。
        /// </summary>
        /// <param name="context">訂購內容。</param>
        public BuyerRepository(OrderingContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 取得買家。
        /// </summary>
        /// <param name="buyerId">買家 ID。</param>
        /// <returns>買家。</returns>
        public async Task<Buyer> GetBuyerAsync(Guid buyerId)
        {
            return await context.Set<Buyer>().SingleOrDefaultAsync(b => b.Id == buyerId);
        }

        /// <summary>
        /// 加入買家。
        /// </summary>
        /// <param name="buyer">買家。</param>
        public void Add(Buyer buyer)
        {
            context.Set<Buyer>().Add(buyer);
        }

        /// <summary>
        /// 更新買家。
        /// </summary>
        /// <param name="buyer">買家。</param>
        public void Update(Buyer buyer)
        {
            context.Entry(buyer).State = EntityState.Modified;
        }
    }
}