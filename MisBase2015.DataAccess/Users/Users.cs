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
    /// 用户信息
    /// </summary>
    public class Users
    {
        /// <summary>
        /// 用户唯一ID
        /// </summary>
        [Key]
        [StringLength(36)]
        public string UserID
        {
            set;
            get;
        }

        /// <summary>
        /// 用户名称
        /// </summary>
        [Required(ErrorMessage="用户名称为必输项")]
        [StringLength(100)]
        public string UserName
        {
            set;
            get;
        }

        /// <summary>
        /// 用户账号
        /// </summary>
        [Required(ErrorMessage="用户账号为必输项")]
        [StringLength(50)]
        public string UserAccount
        {
            set;
            get;
        }

        /// <summary>
        /// 用户证件号码
        /// </summary>
        [StringLength(36)]
        public string UserCertNo
        {
            set;
            get;
        }

        /// <summary>
        /// 用户证件类型
        /// </summary>
        [StringLength(2)]
        public string UserCertType
        {
            set;
            get;
        }

        /// <summary>
        /// 用户联系电话 
        /// </summary>
        [StringLength(36)]
        public string UserPhone
        {
            set;
            get;
        }

        /// <summary>
        /// 用户密码
        /// </summary>
        [Required(ErrorMessage="用户密码为必输项")]
        [StringLength(50)]
        public string UserPwd
        {
            set;
            get;
        }

        /// <summary>
        /// 用户所属网点
        /// </summary>
        [StringLength(100)]
        public string UserUnit
        {
            set;
            get;
        }

        /// <summary>
        /// 构造
        /// </summary>
        public Users()
        {
        }

        /// <summary>
        /// 设置数据
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="userName"></param>
        /// <param name="userAccount"></param>
        /// <param name="userCertNo"></param>
        /// <param name="userCertType"></param>
        /// <param name="userPhone"></param>
        /// <param name="userPwd"></param>
        /// <param name="userUnit"></param>
        public void SetData(string userID, string userName, string userAccount, string userCertNo, string userCertType, string userPhone,
            string userPwd, string userUnit)
        {
            this.UserAccount = userAccount;
            this.UserCertNo = userCertNo;
            this.UserCertType = userCertType;
            this.UserID = userID;
            this.UserName = userName;
            this.UserPhone = userPhone;
            this.UserPwd = userPwd;
            this.UserUnit = userUnit;
        }

    }

    /// <summary>
    /// 注册用户
    /// </summary>
    public class UserRegister : Users
    {
        /// <summary>
        /// 确认密码
        /// </summary>
        [Required]
        [StringLength(50)]
        [Compare("UserPwd",ErrorMessage="密码不一致")]
        public string UserPwdConfirm
        {
            get;
            set;
        }

        /// <summary>
        /// 验证码
        /// </summary>
        public string ValidateCode
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 用户登录方式
    /// </summary>
    public enum Enum_LoginMethod
    {
        /// <summary>
        /// 用户账号方式
        /// </summary>
        UserAccount=1,
        /// <summary>
        /// 用户名称方式
        /// </summary>
        UserName=2,
        /// <summary>
        /// 用户ID方式
        /// </summary>
        UserID=3
    }
}
