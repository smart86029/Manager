using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Dapper;
using MatchaLatte.Common.Attributes;
using static Dapper.SqlMapper;

namespace MatchaLatte.Ordering.Queries
{
    public class TypeMap<T> : ITypeMap where T : class
    {
        private readonly IEnumerable<ITypeMap> maps;

        public TypeMap()
        {
            maps = new ITypeMap[]
            {
                new CustomPropertyTypeMap(typeof(T), SelectProperty),
                new DefaultTypeMap(typeof(T))
            };
        }

        public ConstructorInfo FindConstructor(string[] names, Type[] types)
        {
            return maps.Select(m => m.FindConstructor(names, types)).FirstOrDefault(m => m != null);
        }

        public IMemberMap GetConstructorParameter(ConstructorInfo constructor, string columnName)
        {
            return maps.Select(m => m.GetConstructorParameter(constructor, columnName)).FirstOrDefault(m => m != null);
        }

        public IMemberMap GetMember(string columnName)
        {
            return maps.Select(m => m.GetMember(columnName)).FirstOrDefault(m => m != null);
        }

        public ConstructorInfo FindExplicitConstructor()
        {
            return maps.Select(m => m.FindExplicitConstructor()).FirstOrDefault(c => c != null);
        }

        private PropertyInfo SelectProperty(Type type, string columnName)
        {
            var result = type.GetProperties()
                .FirstOrDefault(p => p.GetCustomAttributes(typeof(ColumnAttribute), false)
                .OfType<ColumnAttribute>()
                .Any(a => a.Name.ToLower() == columnName.ToLower()));

            return result;
        }
    }
}