using System;
using MatchaLatte.Catalog.Domain.Stores;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Catalog.Domain.Groups
{
    /// <summary>
    /// 團。
    /// </summary>
    public class Group : AggregateRoot
    {
        /// <summary>
        /// 初始化 <see cref="Group"/> 類別的新執行個體。
        /// </summary>
        private Group()
        {
        }

        /// <summary>
        /// 初始化 <see cref="Group"/> 類別的新執行個體。
        /// </summary>
        /// <param name="storeId">店家 ID。</param>
        /// <param name="startTime">開始時間。</param>
        /// <param name="endTime">結束時間。</param>
        /// <param name="remark">備註。</param>
        /// <param name="createdBy">新增者 ID。</param>
        public Group(Guid storeId, DateTime startTime, DateTime endTime, string remark, Guid createdBy)
        {
            StoreId = storeId;
            StartOn = startTime;
            EndOn = endTime;
            Remark = remark;
            CreatedBy = createdBy;
            CreatedOn = DateTime.UtcNow;
        }

        /// <summary>
        /// 取得店家 ID。
        /// </summary>
        /// <value>店家 ID。</value>
        public Guid StoreId { get; private set; }

        /// <summary>
        /// 取得開始時間。
        /// </summary>
        /// <value>開始時間。</value>
        public DateTime StartOn { get; private set; }

        /// <summary>
        /// 取得結束時間。
        /// </summary>
        /// <value>結束時間。</value>
        public DateTime EndOn { get; private set; }

        /// <summary>
        /// 取得備註。
        /// </summary>
        /// <value>備註。</value>
        public string Remark { get; private set; }

        /// <summary>
        /// 取得新增者 ID。
        /// </summary>
        /// <value>新增者 ID。</value>
        public Guid CreatedBy { get; private set; }

        /// <summary>
        /// 取得新增時間。
        /// </summary>
        /// <value>新增時間。</value>
        public DateTime CreatedOn { get; private set; }

        /// <summary>
        /// 取得是否進行中。
        /// </summary>
        /// <value>是否進行中。</value>
        public bool IsActive => StartOn <= DateTime.UtcNow && EndOn > DateTime.UtcNow;

        /// <summary>
        /// 取得店家。
        /// </summary>
        /// <value>店家。</value>
        public Store Store { get; private set; }

        /// <summary>
        /// 更新開始時間。
        /// </summary>
        /// <param name="startTime">開始時間。</param>
        public void UpdateStartTime(DateTime startTime)
        {
            StartOn = startTime;
        }

        /// <summary>
        /// 更新結束時間。
        /// </summary>
        /// <param name="endTime">結束時間。</param>
        public void UpdateEndTime(DateTime endTime)
        {
            EndOn = endTime;
        }

        /// <summary>
        /// 更新備註。
        /// </summary>
        /// <param name="remark">備註。</param>
        public void UpdateRemark(string remark)
        {
            Remark = remark;
        }
    }
}