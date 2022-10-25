using Microsoft.Data.SqlClient;
using System;

namespace Wheelish.Utils
{
    public class DbUtils
    {
        public static string GetNullableString(SqlDataReader reader, string column)
        {
            var ordinal = reader.GetOrdinal(column);
            if (reader.IsDBNull(ordinal))
            {
                return null;
            }
            return reader.GetString(ordinal);
        }

        public static DateTime? GetNullableDateTime(SqlDataReader reader, string column)
        {
            var ordinal = reader.GetOrdinal(column);
            if (reader.IsDBNull(ordinal))
            {
                return null;
            }
            return reader.GetDateTime(ordinal);
        }

        public static object ValueOrDBNull(object value)
        {
            return value ?? DBNull.Value;
        }
    }
}
