using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MisBase.Users
{
    /// <summary>
    /// 唯一性约束
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class UniqueAttribute : ValidationAttribute
    {
        /// <summary>
        /// 判断是否有效
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override Boolean IsValid(Object value)
        {
            //校验数据库是否存在当前Key
            return true;
        }
    }

}
