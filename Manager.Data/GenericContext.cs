using Manager.Data.Configurations.Generic;
using Microsoft.EntityFrameworkCore;

namespace Manager.Data
{
    /// <summary>
    /// 通用內容。
    /// </summary>
    public class GenericContext : DbContext
    {
        /// <summary>
        /// 結構描述。
        /// </summary>
        public const string Schema = "Generic";

        /// <summary>
        /// 初始化 <see cref="GenericContext"/> 類別的新執行個體。
        /// </summary>
        public GenericContext(DbContextOptions<GenericContext> options) : base(options)
        {
        }

        /// <summary>
        /// 此方法的呼叫時機是在初始化衍生內容的模型時，但在鎖定此模型及使用此模型初始化內容之前。
        /// </summary>
        /// <param name="modelBuilder">針對建立的內容定義模型的產生器。</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BusinessEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
        }
    }
}