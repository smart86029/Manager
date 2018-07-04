namespace Manager.Domain.Models.Generic
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
        /// <param name="phone">電話。</param>
        public Phone(string phone)
        {
            PhoneType = PhoneType.Landline;
            CountryCode = "886";
            AreaCode = "02";
            BaseNumber = phone;
            Extension = string.Empty;
        }

        /// <summary>
        /// 初始化 <see cref="Phone"/> 類別的新執行個體。
        /// </summary>
        /// <param name="phoneType">電話類型。</param>
        /// <param name="countryCode">國碼。</param>
        /// <param name="areaCode">區碼。</param>
        /// <param name="baseNumber">電話號碼。</param>
        /// <param name="extension">分機。</param>
        public Phone(PhoneType phoneType, string countryCode, string areaCode, string baseNumber, string extension)
        {
            PhoneType = phoneType;
            CountryCode = countryCode;
            AreaCode = areaCode;
            BaseNumber = baseNumber;
            Extension = extension ?? string.Empty;
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
        /// 取得區碼。
        /// </summary>
        /// <value>區碼。</value>
        public string AreaCode { get; private set; }

        /// <summary>
        /// 取得電話號碼。
        /// </summary>
        /// <value>電話號碼。</value>
        public string BaseNumber { get; private set; }

        /// <summary>
        /// 取得分機。
        /// </summary>
        /// <value>分機。</value>
        public string Extension { get; private set; }

        public override string ToString()
        {
            return AreaCode + BaseNumber;
        }
    }
}