using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MisBase.Users;

namespace MickUserFrameWork
{
    /// <summary>
    /// 管理Session的类
    /// </summary>
    public class SessionManager
    {
        #region 属性
        /// <summary>
        /// 登录用户的名称
        /// </summary>
        public static string UserName
        {
            get
            {
                return (string)System.Web.HttpContext.Current.Session["UserName"];
            }
            set
            {
                System.Web.HttpContext.Current.Session["UserName"] = value;
            }
        }

        /// <summary>
        /// 登录用户的ID 
        /// </summary>
        public static string UserID
        {
            set
            {
                System.Web.HttpContext.Current.Session["UserID"] = value;
            }
            get
            {
                return (string)System.Web.HttpContext.Current.Session["UserID"];
            }
        }

        /// <summary>
        /// 登录的用户信息
        /// </summary>
        public static Users User
        {
            set
            {
                System.Web.HttpContext.Current.Session["User"] = value;
            }
            get
            {
                object o = System.Web.HttpContext.Current.Session["User"];
                if (o != null) return (Users)o;
                else return null;
            }
        }

        #endregion

        public SessionManager()
        {
        }        
    }
}