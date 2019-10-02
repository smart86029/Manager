using System.Collections.Generic;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Catalog.Domain
{
    /// <summary>
    /// 地址。
    /// </summary>
    public class Address : ValueObject
    {
        /// <summary>
        /// 初始化 <see cref="Address"/> 類別的新執行個體。
        /// </summary>
        private Address()
        {
        }

        /// <summary>
        /// 初始化 <see cref="Address"/> 類別的新執行個體。
        /// </summary>
        /// <param name="country">國家。</param>
        /// <param name="city">城市。</param>
        /// <param name="district">行政區。</param>
        /// <param name="street">路名。</param>
        public Address(string city, string district, string street)
        {
            PostalCode = string.Empty;
            Country = "臺灣";
            City = city;
            District = district;
            Street = street;
        }

        /// <summary>
        /// 取得郵遞區號。
        /// </summary>
        /// <value>郵遞區號。</value>
        public string PostalCode { get; private set; }

        /// <summary>
        /// 取得國家。
        /// </summary>
        /// <value>國家。</value>
        public string Country { get; private set; }

        /// <summary>
        /// 取得城市。
        /// </summary>
        /// <value>城市。</value>
        public string City { get; private set; }

        /// <summary>
        /// 取得行政區。
        /// </summary>
        /// <value>行政區。</value>
        public string District { get; private set; }

        /// <summary>
        /// 取得路名。
        /// </summary>
        /// <value>路名。</value>
        public string Street { get; private set; }

        public override string ToString()
        {
            return City + District + Street;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return PostalCode;
            yield return Country;
            yield return City;
            yield return District;
            yield return Street;
        }
    }
}