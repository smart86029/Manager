using System;
using MatchaLatte.Common.Domain;
using MatchaLatte.Common.Utilities;

namespace MatchaLatte.Ordering.Domain.Groups
{
    /// <summary>
    /// 團。
    /// </summary>
    public class Group : Entity, IAggregateRoot
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
        public Group(Guid storeId, DateTime startTime, DateTime endTime, string remark, Guid createdBy) :
            this(GuidUtility.NewGuid(), storeId, startTime, endTime, remark, createdBy)
        {
        }

        /// <summary>
        /// 初始化 <see cref="Group"/> 類別的新執行個體。
        /// </summary>
        /// <param name="groupId">團 ID。</param>
        /// <param name="storeId">店家 ID。</param>
        /// <param name="startTime">開始時間。</param>
        /// <param name="endTime">結束時間。</param>
        /// <param name="remark">備註。</param>
        /// <param name="createdBy">新增者 ID。</param>
        public Group(Guid groupId, Guid storeId, DateTime startTime, DateTime endTime, string remark, Guid createdBy)
        {
            GroupId = groupId;
            StoreId = storeId;
            StartTime = startTime;
            EndTime = endTime;
            Remark = remark;
            CreatedBy = createdBy;
            CreatedOn = DateTime.Now;
        }

        /// <summary>
        /// 取得主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public Guid GroupId { get; private set; }

        /// <summary>
        /// 取得店家 ID。
        /// </summary>
        /// <value>店家 ID。</value>
        public Guid StoreId { get; private set; }

        /// <summary>
        /// 取得開始時間。
        /// </summary>
        /// <value>開始時間。</value>
        public DateTime StartTime { get; private set; }

        /// <summary>
        /// 取得結束時間。
        /// </summary>
        /// <value>結束時間。</value>
        public DateTime EndTime { get; private set; }

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
    }
}