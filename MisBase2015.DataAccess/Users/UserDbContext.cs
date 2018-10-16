using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace MisBase.Users
{
    /// <summary>
    /// 数据库访问类
    /// </summary>
    public class UserDbContext : DbContext
    {
        /// <summary>
        /// 角色List
        /// </summary>
        public DbSet<Roles> RoleList
        {
            set;
            get;
        }

        /// <summary>
        /// 角色与权限关联列表
        /// </summary>
        public DbSet<RoleRight> RoleRightList
        {
            set;
            get;
        }

        /// <summary>
        /// 用户List
        /// </summary>
        public DbSet<Users> UserList
        {
            set;
            get;
        }

        /// <summary>
        /// 用户角色关联List
        /// </summary>
        public DbSet<UserRole> UserRoleList
        {
            set;
            get;
        }

        /// <summary>
        /// 权限列表
        /// </summary>
        public DbSet<Rights> RightList
        {
            set;get;
        }

        /// <summary>
        /// 构造
        /// </summary>
        public UserDbContext(string connstr) :
            base(connstr)
        {
        }

        /// <summary>
        /// 构造2
        /// </summary>
        public UserDbContext()
        {
        }

        #region 角色相关
        /// <summary>
        /// 增加一个角色，自动生成ID，最后需要调用SaveChanges更新数据库
        /// </summary>
        /// <param name="data"></param>
        /// <returns>返回生成的Role</returns>
        public Roles AddRole(Roles data)
        {
            if (data == null) throw new Exception("角色信息不能为空");
            data.RoleID = System.Guid.NewGuid().ToString();

            this.Set<Roles>().Add(data);
            //this.SaveChanges();            

            return data;
        }

        /// <summary>
        /// 删除一个角色
        /// </summary>
        /// <param name="data">对应的角色</param>
        public void DeleteRole(Roles data)
        {
            this.Entry<Roles>(data).State = System.Data.EntityState.Deleted;
            //this.RoleList.Remove(data);
        }

        /// <summary>
        /// 修改一个角色
        /// </summary>
        /// <param name="data">对应的修改后的角色</param>
        public void ModifyRole(Roles data)
        {
            this.Entry<Roles>(data).State = System.Data.EntityState.Modified;
        }

        /// <summary>
        /// 根据角色名称获取角色列表
        /// </summary>
        /// <param name="isLike">是否模糊查询</param>
        /// <param name="roleName">角色名称</param>
        /// <returns></returns>
        public List<Roles> GetRoles(string roleName,bool isLike)
        {
            if (roleName == null) roleName = string.Empty;

            List<Roles> list = new List<Roles>();
            if (isLike)
            {
                var data = from r in this.RoleList.AsNoTracking()
                           where r.RoleName.Contains(roleName)
                           orderby r.RoleName
                           select r;

                list = data.ToList();
                
            }
            else
            {
                
                var data = from r in this.RoleList.AsNoTracking()
                           where r.RoleName==roleName
                           orderby r.RoleName
                           select r;

                //foreach (Role r in data)
                //{
                //    list.Add(r);
                //}

                list = data.ToList();
            }

            return list;
        }

        /// <summary>
        /// 根据角色ID获取角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Roles GetRoleByID(string id)
        {
            if (id == null) id = string.Empty;

            var data = from r in RoleList.AsNoTracking()
                       where r.RoleID == id
                       select r;

            if (data.Count() > 0) return data.First();
            else return null;
        }

        /// <summary>
        /// 根据用户ID获取用户拥有的角色列表
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public List<Roles> GetRolesByUserID(string userID)
        {
            if (userID == null) userID = string.Empty;

            List<Roles> list = new List<Roles>();

            var data = from r in this.Set<UserRole>().AsNoTracking()
                       join t in this.Set<Roles>().AsNoTracking() on r.RoleID equals t.RoleID
                       select t;

            foreach (Roles c in data)
            {
                list.Add(c);
            }

            return list;
        }
        #endregion

        #region 角色权限关联相关
        /// <summary>
        /// 给角色增加一个权限，重新生成唯一标识
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public RoleRight AddRoleRight(RoleRight data)
        {
            if (data == null) throw new Exception("角色权限信息不能为空。");

            //data.RoleID = System.Guid.NewGuid().ToString();

            this.Set<RoleRight>().Add(data);

            return data;
        }

        /// <summary>
        /// 根据角色ID获取角色拥有的权限列表
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <returns></returns>
        public List<RoleRight> GetRoleRights(string roleID)
        {
            if (roleID == null) roleID = string.Empty;
            List<RoleRight> list = new List<RoleRight>();

            var data = from r in this.Set<RoleRight>().AsNoTracking()
                       where r.RoleID == roleID
                       select r;

            foreach (RoleRight rr in data)
            {
                list.Add(rr);
            }

            return list;
        }

        /// <summary>
        /// 修改某一项角色权限
        /// </summary>
        /// <param name="data"></param>
        public void ModifyRoleRight(RoleRight data)
        {
            if (data == null) throw new Exception("角色权限不能为空。");

            this.Entry<RoleRight>(data).State = System.Data.EntityState.Modified;
        }

        /// <summary>
        /// 删除一个角色权限 
        /// </summary>
        /// <param name="data"></param>
        public void DeleteRoleRight(RoleRight data)
        {
            if (data == null) throw new Exception("角色权限不能为空。");

            //this.Set<RoleRight>().Remove(data);
            this.Entry<RoleRight>(data).State = System.Data.EntityState.Deleted;
        }
        #endregion

        #region 权限相关
         
        /// <summary>
        /// 增加一个权限
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Rights AddRight(Rights data)
        {
            if (data == null) throw new Exception("权限信息不能为空。");

            data.RightID = System.Guid.NewGuid().ToString();

            this.Set<Rights>().Add(data);

            return data;
        }

        /// <summary>
        /// 修改指定的权限
        /// </summary>
        /// <param name="data"></param>
        public void ModifyRight(Rights data)
        {
            if (data == null) throw new Exception("权限不能为空。");

            this.Entry<Rights>(data).State = System.Data.EntityState.Modified;
        }

        /// <summary>
        /// 删除指定的权限
        /// </summary>
        /// <param name="data"></param>
        public void DeleteRight(Rights data)
        {
            if (data == null) throw new Exception("权限不能为空。");

            this.Entry<Rights>(data).State = System.Data.EntityState.Deleted;
        }

        /// <summary>
        /// 根据权限ID获取一个权限信息
        /// </summary>
        /// <param name="rightID"></param>
        /// <returns></returns>
        public Rights GetRights(string rightID)
        {
            if (rightID == null) rightID = string.Empty;

            var data = from r in this.Set<Rights>().AsNoTracking()
                       where r.RightID == rightID
                       select r;

            return data.Single();
        }

        /// <summary>
        /// 根据角色ID获取其拥有的权限列表
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public List<Rights> GetRightsByRoleID(string roleID)
        {
            if (roleID == null) roleID = string.Empty;

            var data = from r in this.Set<Rights>().AsNoTracking()
                       join r2 in this.Set<RoleRight>().AsNoTracking() on r.RightID equals r2.RightID
                       where r2.RoleID == roleID
                       select r;

            return data.ToList();
        }

        /// <summary>
        /// 获取系统已有的所有权限
        /// </summary>
        /// <returns></returns>
        public List<Rights> GetRights()
        {
            var data = from r in this.Set<Rights>().AsNoTracking()
                       select r;

            return data.ToList() ;
        }
        #endregion

        #region 用户相关
        /// <summary>
        /// 增加一个用户，重新生成唯一标识
        /// </summary>
        /// <param name="data">用户信息</param>
        /// <returns></returns>
        public Users AddUser(Users data)
        {
            if (data == null) throw new Exception("用户信息不能为空");

            data.UserID = System.Guid.NewGuid().ToString();

            this.Set<Users>().Add(data);

            return data;
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="data"></param>
        public void ModifyUser(Users data)
        {
            this.Entry<Users>(data).State = System.Data.EntityState.Modified;
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="data"></param>
        public void DeleteUser(Users data)
        {
            //this.Set<User>().Remove(data);
            this.Entry<Users>(data).State = System.Data.EntityState.Deleted;
        }

        /// <summary>
        /// 根据用户名称获取用户信息
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="isLike">是否模糊</param>
        /// <returns></returns>
        public List<Users> GetUsersByName(string userName,bool isLike)
        {
            if (userName == null) userName = string.Empty;

            List<Users> list = new List<Users>();

            if (isLike)
            {
                var data = from r in this.Set<Users>().AsNoTracking()
                           where r.UserName.Contains(userName)
                           select r;

                foreach (Users u in data)
                {
                    list.Add(u);
                }
            }
            else
            {
                var data = from r in this.Set<Users>().AsNoTracking()
                           where r.UserName==userName
                           select r;

                foreach (Users u in data)
                {
                    list.Add(u);
                }
            }

            return list;
        }

        /// <summary>
        /// 根据用户账号获取用户信息
        /// </summary>
        /// <param name="userAccount">用户账号</param>
        /// <returns></returns>
        public List<Users> GetUsersByAccount(string userAccount)
        {
            if (userAccount == null) userAccount = string.Empty;

            List<Users> list = new List<Users>();

            var data = from r in this.Set<Users>().AsNoTracking()
                       where r.UserName == userAccount
                       select r;

            foreach (Users u in data)
            {
                list.Add(u);
            }

            return list;
        }

        /// <summary>
        /// 根据用户ID获取用户信息
        /// </summary>
        /// <param name="userID">户账号</param>
        /// <returns></returns>
        public Users GetUsersByID(string userID)
        {
            if (userID == null) userID = string.Empty;

            List<Users> list = new List<Users>();

            var data = from r in this.Set<Users>().AsNoTracking()
                       where r.UserID == userID
                       select r;

            if(data.Count()>0) return data.Single();
            else return null;

        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name">登录名称</param>
        /// <param name="pwd">密码</param>
        /// <param name="method">登录方式</param>
        /// <returns>成功返回登录用户的信息，失败返回null</returns>
        public Users Login(string name,string pwd,Enum_LoginMethod method)
        {
            Users user = null;

            switch (method)
            {
                case Enum_LoginMethod.UserAccount:
                     var data = from r in this.Set<Users>().AsNoTracking()
                               where r.UserAccount == name && r.UserPwd == pwd
                               select r;

                     if (data.Count() > 0) user = data.Single();
                     else user = null;

                    break;
                case Enum_LoginMethod.UserID:
                    var data2 = from r in this.Set<Users>().AsNoTracking()
                               where r.UserID == name && r.UserPwd == pwd
                               select r;

                    if (data2.Count() > 0) user = data2.Single();
                    else user = null;

                    break;
                case Enum_LoginMethod.UserName:

                     var data3 = from r in this.Set<Users>().AsNoTracking()
                               where r.UserName == name && r.UserPwd == pwd
                               select r;

                     if (data3.Count() > 0) user = data3.Single();
                     else user = null;

                    break;
            }

            return user;
        }

        /// <summary>
        /// 判断用户是否具有指定的权限，权限树
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="rightUrl">权限URL</param>
        /// <returns>返回是否有权限</returns>
        public bool IsUserHasRight(string userID, string rightUrl)
        {
            bool flag = false;

            if (userID == null) userID = string.Empty;
            if (rightUrl == null) rightUrl = string.Empty;

            var data = from u in this.Set<Users>().AsNoTracking()
                       join ur in this.Set<UserRole>().AsNoTracking() on u.UserID equals ur.UserID
                       join rr in this.Set<RoleRight>().AsNoTracking() on ur.RoleID equals rr.RoleID
                       join r in this.Set<Rights>().AsNoTracking() on rr.RightID equals r.RightID
                       where u.UserID == userID && r.RightUrl == rightUrl
                       select new
                       {
                           uID=u.UserID,
                           uName=u.UserName,
                           rID = rr.RoleID,
                           rUrl=r.RightUrl
                       };

            if (data.ToList().Count > 0) flag = true;

            return flag;
        }
        #endregion

        #region 用户角色相关
        /// <summary>
        /// 增加一个用户角色关联
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public UserRole AddUserRole(UserRole data)
        {
            if (data == null) throw new Exception("用户角色关联信息不能为空。");

            this.Set<UserRole>().Add(data);

            return data;
        }

        /// <summary>
        /// 根据用户ID获取用户角色记录列表
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public List<UserRole> GetUserRolesByUserID(string userID)
        {
            if (userID == null) userID = string.Empty;

            List<UserRole> list = new List<UserRole>();

            var data = from r in this.Set<UserRole>().AsNoTracking()
                       join t in this.Set<Roles>().AsNoTracking() on r.RoleID equals t.RoleID
                       select r;

            foreach (UserRole c in data)
            {
                list.Add(c);
            }

            return list;
        }

        /// <summary>
        /// 删除一个用户角色关联
        /// </summary>
        /// <param name="data"></param>
        public void DeleteUserRole(UserRole data)
        {
            if (data == null) throw new Exception("用户角色关联信息不能为空。");

            //this.Set<UserRole>().Remove(data);
            this.Entry<UserRole>(data).State = System.Data.EntityState.Deleted;
        }
        #endregion

    }
}
