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
    /// 用户与角色关联类，多对多
    /// </summary>
    [Table("UserRole")]
    public class UserRole
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Key,Column(Order=1)]
        [StringLength(36)]
        public string UserID
        {
            set;
            get;
        }

        /// <summary>
        /// 角色ID
        /// </summary>
        [Key,Column(Order=2)]
        [StringLength(36)]
        public string RoleID
        {
            set;
            get;
        }

        /// <summary>
        /// 构造
        /// </summary>
        public UserRole()
        {
        }
    }
}
