using System;

namespace MatchaLatte.Common.Attributes
{
    /// <summary>
    /// 標示對映的欄位名稱。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ColumnAttribute : Attribute
    {
        /// <summary>
        /// 初始化 <see cref="ColumnAttribute"/> 類別的新執行個體。
        /// </summary>
        /// <param name="name">名稱</param>
        public ColumnAttribute(string name) : base()
        {
            Name = name;
        }

        /// <summary>
        /// 取得名稱。
        /// </summary>
        /// <value>名稱。</value>
        public string Name { get; private set; }
    }
}