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
        /// <param name="startOn">開始時間。</param>
        /// <param name="endOn">結束時間。</param>
        /// <param name="remark">備註。</param>
        /// <param name="createdBy">建立者 ID。</param>
        public Group(Guid storeId, DateTime startOn, DateTime endOn, string remark, Guid createdBy)
        {
            StoreId = storeId;
            StartOn = startOn;
            EndOn = endOn;
            Remark = remark;
            CreatedBy = createdBy;
            CreatedOn = DateTime.UtcNow;
        }

        /// <summary>
        /// 取得店家 ID。
        /// </summary>
        public Guid StoreId { get; private set; }

        /// <summary>
        /// 取得開始時間。
        /// </summary>
        public DateTime StartOn { get; private set; }

        /// <summary>
        /// 取得結束時間。
        /// </summary>
        public DateTime EndOn { get; private set; }

        /// <summary>
        /// 取得備註。
        /// </summary>
        public string Remark { get; private set; }

        /// <summary>
        /// 取得建立者 ID。
        /// </summary>
        public Guid CreatedBy { get; private set; }

        /// <summary>
        /// 取得建立時間。
        /// </summary>
        public DateTime CreatedOn { get; private set; }

        /// <summary>
        /// 取得是否進行中。
        /// </summary>
        public bool IsActive => StartOn <= DateTime.UtcNow && EndOn > DateTime.UtcNow;

        /// <summary>
        /// 取得店家。
        /// </summary>
        public Store Store { get; private set; }

        /// <summary>
        /// 更新開始時間。
        /// </summary>
        public void UpdateStartOn(DateTime startOn)
        {
            StartOn = startOn;
        }

        /// <summary>
        /// 更新結束時間。
        /// </summary>
        /// <param name="endOn">結束時間。</param>
        public void UpdateEndOn(DateTime endOn)
        {
            EndOn = endOn;
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