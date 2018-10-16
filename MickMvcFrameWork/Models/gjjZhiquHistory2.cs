using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using MickUserFrameWork;

namespace MickUserFrameWork.Models
{
    public class ZhiquHisContext : DbContext
    {
        public ZhiquHisContext() :
            base("ConnStr1")
        {
        }

        //public DbSet<gjjZhiquHistory> ZhiquHistSet
        //{
        //    get;
        //    set;
        //}

        public DbSet<MisBase.Users.Roles> RoleList
        {
            get;
            set;
        }

        public DbSet<gjjZhiquHistory> ZqHisList
        {
            get;
            set;
        }


        /// <summary>
        /// 获取支取流水
        /// </summary>
        /// <returns></returns>
        public List<MisBase.Users.Roles> GetZhiquHis()
        {
            //var list = from r in this.Set<gjjZhiquHistory>().AsNoTracking() 
            //           select r;

            var list = from r in this.Set<MisBase.Users.Roles>().AsNoTracking()
                       select r;

            return list.Take(100).ToList();
        }

        /// <summary>
        /// 获取支取流水
        /// </summary>
        /// <param name="name">姓名，模糊查询</param>
        /// <returns></returns>
        public List<gjjZhiquHistory> GetZhiquHis2(string name)
        {
            var list = from r in this.Set<gjjZhiquHistory>().AsNoTracking()
                       where r.hisName.Contains(name)
                       select r;

            return list.Take(100).ToList();
        }
    }

    [Table("gjjZhiquHistory")]
    public  class gjjZhiquHistory
    {
        [Key]
        public long hisNum { get; set; }
        public string hisName { get; set; }
        public string hisID { get; set; }
        public Nullable<System.DateTime> hisDate { get; set; }
        public Nullable<decimal> hisMoney { get; set; }
        public string hisType { get; set; }
        public string hisOperator { get; set; }
        public Nullable<int> hisCount { get; set; }
        public string hisDaNum { get; set; }
        public string hisRemark { get; set; }
        public string hisNetwork { get; set; }
        public string hisRemark2 { get; set; }
        public string hisNumStr { get; set; }
        public string hisTypeSub { get; set; }
        public string hisgjjID { get; set; }
        public Nullable<System.DateTime> hisImportDate { get; set; }
        public Nullable<long> hiswtspNum { get; set; }
        public string hisWork { get; set; }
        public string hiszrAccount { get; set; }
        public string hiszrAccName { get; set; }
        public string hisStateFlag { get; set; }
    }

    public class GuideBar
    {
        /// <summary>
        /// 页数
        /// </summary>
        public int PageCount
        {
            set;
            get;
        }

        /// <summary>
        /// 当前页序号
        /// </summary>
        public int CurrPageIndex
        {
            get;
            set;
        }

        /// <summary>
        /// 每页显示数量
        /// </summary>
        public int PageSize
        {
            get;
            set;
        }

        public GuideBar()
        {
            this.PageCount = this.PageSize = this.CurrPageIndex = 0;
        }
    }

    public class ZhiquHistory_Web
    {
        public List<gjjZhiquHistory> HisList
        {
            get;
            set;
        }

        public GuideBar GuildBarInst
        {
            get;
            set;
        }

        public ZhiquHistory_Web()
        {
            this.HisList = new List<gjjZhiquHistory>();
            this.GuildBarInst = new GuideBar();
        }
    }
}