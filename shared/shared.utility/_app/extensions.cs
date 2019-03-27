using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

namespace domain.utility._app {
    public static class Extensions {
        public static IDictionary<Type, DbType> TypeMap = new Dictionary<Type, DbType> {
            //[typeof(System.Collections.IEnumerable)] = DbType.Object,
            [typeof(byte)] = DbType.Byte,
            [typeof(sbyte)] = DbType.SByte,
            [typeof(short)] = DbType.Int16,
            [typeof(ushort)] = DbType.UInt16,
            [typeof(int)] = DbType.Int32,
            [typeof(uint)] = DbType.UInt32,
            [typeof(long)] = DbType.Int64,
            [typeof(ulong)] = DbType.UInt64,
            [typeof(float)] = DbType.Single,
            [typeof(double)] = DbType.Double,
            [typeof(decimal)] = DbType.Decimal,
            [typeof(bool)] = DbType.Boolean,
            [typeof(string)] = DbType.String,
            [typeof(char)] = DbType.StringFixedLength,
            [typeof(Guid)] = DbType.Guid,
            [typeof(DateTime)] = DbType.DateTime,
            [typeof(DateTimeOffset)] = DbType.DateTimeOffset,
            [typeof(byte[])] = DbType.Binary,
            [typeof(byte?)] = DbType.Byte,
            [typeof(sbyte?)] = DbType.SByte,
            [typeof(short?)] = DbType.Int16,
            [typeof(ushort?)] = DbType.UInt16,
            [typeof(int?)] = DbType.Int32,
            [typeof(uint?)] = DbType.UInt32,
            [typeof(long?)] = DbType.Int64,
            [typeof(ulong?)] = DbType.UInt64,
            [typeof(float?)] = DbType.Single,
            [typeof(double?)] = DbType.Double,
            [typeof(decimal?)] = DbType.Decimal,
            [typeof(bool?)] = DbType.Boolean,
            [typeof(char?)] = DbType.StringFixedLength,
            [typeof(Guid?)] = DbType.Guid,
            [typeof(DateTime?)] = DbType.DateTime,
            [typeof(DateTimeOffset?)] = DbType.DateTimeOffset,
            //[typeof(Binary)] = DbType.Binary
        };

        public static string Truncate(this string value, int maxChars = 100) {
            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + "...";
        }

        public static string CharacterNormalizer(this string value) {
            value = value.Trim();
            //value = value.Replace(",", "_");
            //value = value.Replace("'", "_");
            //value = value.Replace("\"", "_");
            //value = value.Replace("'", "''");
            //value = value.Replace(">", "_>");
            //value = value.Replace("<", "<_");
            //value = value.Replace("/*", " ");
            //value = value.Replace("*/", " ");

            value = value.Replace("ي", "ی");
            value = value.Replace("ك", "ک");
            value = value.Replace("ك", "ڪ");

            //Eastern Arabic (٠	 ١	٢	٣	٤	٥	٦	٧	٨	٩)
            value = value.Replace("١", "1");
            value = value.Replace("٢", "2");
            value = value.Replace("٣", "3");
            value = value.Replace("٤", "4");
            value = value.Replace("٥", "5");
            value = value.Replace("٦", "6");
            value = value.Replace("٧", "7");
            value = value.Replace("٨", "8");
            value = value.Replace("٩", "9");
            value = value.Replace("٠", "0");

            //Perso-Arabic variant (۰	۱	۲	۳	۴	۵	۶	۷	۸	۹)
            value = value.Replace("۱", "1");
            value = value.Replace("۲", "2");
            value = value.Replace("۳", "3");
            value = value.Replace("۴", "4");
            value = value.Replace("۵", "5");
            value = value.Replace("۶", "6");
            value = value.Replace("۷", "7");
            value = value.Replace("۸", "8");
            value = value.Replace("۹", "9");
            value = value.Replace("۰", "0");

            return value;
        }

        public static string ToDescriptionString(this Enum val) {
            var attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }

        public static string ToErrorString(this Enum val) {
            var attributes = (ErrorAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(ErrorAttribute), false);
            return attributes.Length > 0 ? attributes[0].Message : string.Empty;
        }

        public static byte ToByte(this Enum val) {
            return Convert.ToByte(val);
        }

        public static IMappingExpression<TSource, TDestination> IgnoreAllVirtual<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression) {
            var desType = typeof(TDestination);
            foreach(var property in desType.GetProperties().Where(p => p.Name.ToLower() != "id" && p.GetGetMethod().IsVirtual)) {
                expression.ForMember(property.Name, opt => opt.Ignore());
            }
            return expression;
        }

        public static IQueryable<T> OrderByField<T>(this IQueryable<T> q, string sortField, bool ascending) {
            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, sortField);
            var exp = Expression.Lambda(prop, param);
            var method = ascending ? "OrderBy" : "OrderByDescending";
            var types = new[] { q.ElementType, exp.Body.Type };
            var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
            return q.Provider.CreateQuery<T>(mce);
        }

        public static long? UnixTimestampFromDateTime(this DateTime? date) {
            if(!date.HasValue)
                return null;
            long unixTimestamp = date.Value.Ticks - new DateTime(1970, 1, 1).Ticks;
            unixTimestamp /= TimeSpan.TicksPerSecond;
            return unixTimestamp;
        }

        public static string PersianFromDateTime(this DateTime GregorianDate) {
            var pc = new PersianCalendar();
            return string.Format("{0}/{1}/{2} {3:00}:{4:00}", pc.GetYear(GregorianDate), pc.GetMonth(GregorianDate), pc.GetDayOfMonth(GregorianDate), pc.GetHour(GregorianDate), pc.GetMinute(GregorianDate));
        }

        public static DateTime? DateTimeFromUnix(this long? unixTime) {
            if(!unixTime.HasValue)
                return null;
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTime.Value).ToLocalTime();
            return dtDateTime;
        }

        public static DateTime DateTimeFromUnixMilisec(this long unixTime) {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(unixTime).ToLocalTime();
            return dtDateTime;
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> list) {
            var dataTable = new DataTable();
            var propertyDescriptorCollection = TypeDescriptor.GetProperties(typeof(T));
            for(int i = 0; i < propertyDescriptorCollection.Count; i++) {
                var propertyDescriptor = propertyDescriptorCollection[i];
                var type = propertyDescriptor.PropertyType;
                if(type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    type = Nullable.GetUnderlyingType(type);
                dataTable.Columns.Add(propertyDescriptor.Name, type);
            }
            object[] values = new object[propertyDescriptorCollection.Count];
            foreach(T item in list) {
                for(int i = 0; i < values.Length; i++) {
                    values[i] = propertyDescriptorCollection[i].GetValue(item);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        public static DbType ToDbType(this Type type) {
            return TypeMap[type];
        }

        public static string SchemaName(this IBaseSchema baseSchema) {
            var name = baseSchema.GetType().Name;
            var attrs = baseSchema.GetType().GetCustomAttributes(true);
            foreach(var attr in attrs) {
                if(attr is Schema schema && !string.IsNullOrWhiteSpace(schema.Name))
                    name = schema.Name;
            }
            return name;
        }
    }
}
