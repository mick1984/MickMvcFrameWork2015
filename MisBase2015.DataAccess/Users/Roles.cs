using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MisBase.Users
{
    /// <summary>
    /// 管理角色的类
    /// </summary>
    public class Roles
    {
        /// <summary>
        /// 角色的唯一键
        /// </summary>     
        [Key]
        [StringLength(36)]
        public string RoleID
        {
            set;
            get;
        }

        /// <summary>
        /// 角色的名称
        /// </summary>      
        [Unique]
        [Required]
        [StringLength(100)]
        public string RoleName
        {
            set;
            get;
        }

        /// <summary>
        /// 角色的等级
        /// </summary>
        public int RoleLevel
        {
            set;
            get;
        }

        /// <summary>
        /// 角色描述
        /// </summary>
        [StringLength(500)]
        public string RoleDesc
        {
            set;
            get;
        }

        /// <summary>
        /// 构造
        /// </summary>
        public Roles()
        {
        }

        /// <summary>
        /// 设置数据
        /// </summary>
        /// <param name="roleID"></param>
        /// <param name="roleName"></param>
        /// <param name="roleLevel"></param>
        /// <param name="roleDesc"></param>
        public void SetData(string roleID, string roleName, int roleLevel, string roleDesc)
        {
            this.RoleID = roleID;
            this.RoleDesc = roleDesc;
            this.RoleLevel = roleLevel;
            this.RoleName = roleName;
        }
    }
}

