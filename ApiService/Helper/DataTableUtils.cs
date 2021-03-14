using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace ApiService.Helper
{
    static class DataTableUtils
    {
        /// <summary>
        /// Convert data row into given T type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();
            foreach (var property in properties)
            {
                if (row.Table.Columns.Contains(property.Name))
                {
                    object value = row[property.Name];
                    if (value == DBNull.Value)
                        value = null;

                    try
                    {
                        property.SetValue(item, value, null);
                    }
                    catch
                    {
                        property.SetValue(item, Convert.ChangeType(value, property.PropertyType));
                    }
                }
            }
            return item;
        }

        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            List<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<T> rowList = new List<T>();

            foreach (DataRow row in table.Rows)
            {
                var item = CreateItemFromRow<T>(row, properties);
                rowList.Add(item);
            }
            return rowList;
        }

    }
}
