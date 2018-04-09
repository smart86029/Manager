﻿using System.Data.Entity;
using Manager.Models.GroupBuying;

namespace Manager.Data.EntityFramework
{
    /// <summary>
    /// 店家倉儲。
    /// </summary>
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        /// <summary>
        /// 初始化 <see cref="StoreRepository"/> 類別的新執行個體。
        /// </summary>
        /// <param name="db">內容執行個體。</param>
        public StoreRepository(DbContext db) : base(db)
        {
        }
    }
}