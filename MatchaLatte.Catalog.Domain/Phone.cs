using System.Collections.Generic;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Catalog.Domain
{
    /// <summary>
    /// 電話。
    /// </summary>
    public class Phone : ValueObject
    {
        /// <summary>
        /// 初始化 <see cref="Phone"/> 類別的新執行個體。
        /// </summary>
        private Phone()
        {
        }

        /// <summary>
        /// 初始化 <see cref="Phone"/> 類別的新執行個體。
        /// </summary>
        /// <param name="phoneNumber">電話。</param>
        public Phone(string phoneNumber) : this(PhoneType.Landline, "886", phoneNumber)
        {
        }

        /// <summary>
        /// 初始化 <see cref="Phone"/> 類別的新執行個體。
        /// </summary>
        /// <param name="phoneType">電話類型。</param>
        /// <param name="countryCode">國碼。</param>
        /// <param name="phoneNumber">電話號碼。</param>
        public Phone(PhoneType phoneType, string countryCode, string phoneNumber)
        {
            PhoneType = phoneType;
            CountryCode = countryCode;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// 取得電話類型。
        /// </summary>
        /// <value>電話類型。</value>
        public PhoneType PhoneType { get; private set; }

        /// <summary>
        /// 取得國碼。
        /// </summary>
        public string CountryCode { get; private set; }

        /// <summary>
        /// 取得電話號碼。
        /// </summary>
        /// <value>電話號碼。</value>
        public string PhoneNumber { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return PhoneType;
            yield return CountryCode;
            yield return PhoneNumber;
        }
    }
}