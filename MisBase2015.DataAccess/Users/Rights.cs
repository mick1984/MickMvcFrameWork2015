using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MisBase.Users
{
    /// <summary>
    /// 具体权限描述
    /// </summary>
    public class Rights
    {
        /// <summary>
        /// 权限ID
        /// </summary>
        [Key]
        [StringLength(36)]
        public string RightID
        {
            get;set;
        }

        /// <summary>
        /// 权限描述
        /// </summary>
        [Required]
        [StringLength(500)]
        public string RightDesc
        {
            get;set;

        }

        /// <summary>
        /// 权限URL
        /// </summary>
        [Required]
        [StringLength(300)]
        public string RightUrl
        {
            get;set;
        }

        /// <summary>
        /// 权限名称
        /// </summary>
        [Required]
        [StringLength(100)]
        public string RightName
        {
            get;set;
        }

    }
}
