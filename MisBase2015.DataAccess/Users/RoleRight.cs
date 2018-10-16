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
    /// 角色对页面的访问权限类
    /// </summary>
    [Table("RoleRight")]
    public class RoleRight
    {
        /// <summary>
        /// 角色对页面访问权限ID
        /// </summary>
        [Key, Column(Order = 1)]
        [StringLength(36)]
        public string RightID
        {
            set;
            get;
        }

        /// <summary>
        /// 角色ID
        /// </summary>
        [Key, Column(Order = 2)]
        [StringLength(36)]
        public string RoleID
        {
            set;
            get;
        }

        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(500)]
        public string RoleRightDesc
        {
            set;
            get;
        }

        /// <summary>
        /// 构造
        /// </summary>
        public RoleRight()
        {
        }

        /// <summary>
        /// 设置数据
        /// </summary>
        /// <param name="rightID"></param>
        /// <param name="roleID"></param>
        /// <param name="roleRightDesc"></param>
        public void SetData(string rightID, string roleID, string roleRightDesc)
        {
            this.RoleRightDesc = roleRightDesc;
            this.RoleID = roleID;
            this.RightID = rightID;
        }
    }
}
