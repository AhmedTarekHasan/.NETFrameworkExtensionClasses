using System.Collections.Generic;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace DevelopmentSimplyPut.ExtensionMethods.SqlDataReaderEM
{
    public static class SqlDataReaderExtensionMethods
    {
        /// <summary>
        /// Gets a list of dictionaries from a SqlDataReader contents
        /// </summary>
        /// <param name="reader">SqlDataReader</param>
        /// <returns></returns>
        public static Collection<Dictionary<string, object>> ext_ToDictionaries1(this SqlDataReader reader)
        {
            Collection<Dictionary<string, object>> result = null;
            if (reader != null && !reader.IsClosed && reader.HasRows)
            {
                result = new Collection<Dictionary<string, object>>();
                while (reader.Read())
                {
                    Dictionary<string, object> item = new Dictionary<string, object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        item.Add(reader.GetName(i), reader[i]);
                    }
                    result.Add(item);
                }
                return result;
            }

            return null;
        }
        /// <summary>
        /// Gets an IEnumerable of dictionaries from a SqlDataReader contents
        /// </summary>
        /// <param name="reader">SqlDataReader</param>
        /// <returns></returns>
        public static IEnumerable<Dictionary<string, object>> ext_ToDictionaries2(this SqlDataReader reader)
        {
            if (reader == null || reader.IsClosed || !reader.HasRows)
            {
                yield break;
            }

            while (reader.Read())
            {
                Dictionary<string, object> item = new Dictionary<string, object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    item.Add(reader.GetName(i), reader[i]);
                }
                yield return item;
            }
        }
    }
}
