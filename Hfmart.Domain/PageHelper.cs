using Hfmart.Domain.Request;
using Hfmart.Domain.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hfmart.Domain
{
   public static class PageHelper
    {
        public static ResponseBase<T> GetPage<T>(IQueryable<T> data, SearchBase pagingCriteria)
        {
            if (data == null)
            {
                return new ResponseBase<T>();
            }
            var rowCount = data.Count();
            var result = new ResponseBase<T>
            {
                Page = pagingCriteria.page,
                PageSize = pagingCriteria.pagesize,
                Total = rowCount
            };
            if (result.PageSize == 0)
            {
                result.PageSize = 20;
            }
            result.PageCount = result.Total / result.PageSize + (result.Total % result.PageSize > 0 ? 1 : 0);
            result.Data = data.Skip((result.Page - 1) * result.PageSize).Take(result.PageSize);
            return result;
        }
        public static string GetEnumDescription(this Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
        }
        public static string GetEnumDescription(this Enum enumValue, string SuccessMs)
        {
            if (enumValue.ToString() == "Success")
            {
                return SuccessMs;
            }
            if (enumValue.ToString() == "Calculated_Success")
            {
                return SuccessMs;
            }
            if (enumValue.ToString() == "Digital_Success")
            {
                return SuccessMs;
            }
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
        }
    }
}
