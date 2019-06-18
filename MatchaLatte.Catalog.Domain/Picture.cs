using System;
using System.Collections.Generic;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Catalog.Domain
{
    public class Picture : ValueObject
    {
        /// <summary>
        /// 初始化 <see cref="Picture"/> 類別的新執行個體。
        /// </summary>
        private Picture()
        {
        }

        /// <summary>
        /// 初始化 <see cref="Picture"/> 類別的新執行個體。
        /// </summary>
        /// <param name="name">檔案名稱。</param>
        public Picture(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// 取得檔案名稱。
        /// </summary>
        /// <value>檔案名稱。</value>
        public string FileName { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FileName;
        }
    }
}