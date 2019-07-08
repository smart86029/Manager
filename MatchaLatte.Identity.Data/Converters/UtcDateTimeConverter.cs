using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MatchaLatte.Identity.Data.Converters
{
    public class UtcDateTimeConverter : ValueConverter<DateTime, DateTime>
    {
        private static Expression<Func<DateTime, DateTime>> convertTo = x => x.ToUniversalTime();
        private static Expression<Func<DateTime, DateTime>> convertFrom = x => DateTime.SpecifyKind(x, DateTimeKind.Utc);

        public UtcDateTimeConverter() : base(convertTo, convertFrom)
        {
        }
    }
}