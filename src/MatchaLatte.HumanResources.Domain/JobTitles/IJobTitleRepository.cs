using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.HumanResources.Domain.JobTitles
{
    /// <summary>
    /// 職稱存放庫。
    /// </summary>
    public interface IJobTitleRepository : IRepository<JobTitle>
    {
        /// <summary>
        /// 取得職稱的集合。
        /// </summary>
        /// <returns>職稱的集合。</returns>
        Task<ICollection<JobTitle>> GetJobTitletsAsync();

        /// <summary>
        /// 取得職稱。
        /// </summary>
        /// <returns>職稱。</returns>
        Task<JobTitle> GetJobTitleAsync(Guid jobTitleId);

        /// <summary>
        /// 加入職稱。
        /// </summary>
        /// <param name="jobTitle">職稱。</param>
        void Add(JobTitle jobTitle);

        /// <summary>
        /// 更新職稱。
        /// </summary>
        /// <param name="jobTitle">職稱。</param>
        void Update(JobTitle jobTitle);
    }
}