using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MisBase;
using MisBase.Users;
using MickUserFrameWork.Models;
using MickUserFrameWork;

namespace MickUserFrameWork.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            List<MisBase.Users.Roles> list = null ;

            UserDbContext uc = new UserDbContext("ConnStr1");

            list = uc.GetRoles(string.Empty, true);

            if (list == null) list = new List<Roles>();

            return View(list);
        }


        /// <summary>
        /// 增删减一个角色
        /// </summary>
        /// <param name="updateType">更新类型，1-新增，2-修改，3-删除</param>
        /// <param name="id">角色的ID</param>
        /// <returns></returns>
        public ActionResult UpdateRole(string updateType,string id)
        {
            Roles data = new Roles();

            if (string.IsNullOrEmpty(updateType))
            {
                updateType = "1";
            }

            switch (updateType)
            {
                case "1":
                    break;
                case "2":
                    UserDbContext uc1 = new UserDbContext("ConnStr1");
                    data = uc1.GetRoleByID(id);
                    break;
                case "3": 
                    UserDbContext uc2 = new UserDbContext("ConnStr1");
                    data = uc2.GetRoleByID(id);
                    break;
                default:
                    throw new Exception("更新类型出错。");
            }

            if (data == null) data = new Roles();

            return View(data);
        }

        /// <summary>
        /// 增加一个角色，Post方法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="updateType">更新类型，1-新增，2-修改，3-删除</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateRole(Roles data,string updateType)
        {
            if (string.IsNullOrEmpty(updateType))
            {
                updateType = "1";
            }

            UserDbContext uc = new UserDbContext("ConnStr1");

            try
            {
                switch (updateType)
                {
                    case "1":
                        if (data != null)
                        {
                            data = uc.AddRole(data);                   
                            uc.SaveChanges();
                        }
                        else
                        {
                            data = new Roles();
                        }
                        break;
                    case "2":
                        if (data == null) throw new Exception("数据为空，无法更新。");
                        uc.ModifyRole(data);
                        uc.SaveChanges();
                        break;
                    case "3":
                        if (data == null) throw new Exception("数据为空，无法删除。");
                        uc.DeleteRole(data);
                        uc.SaveChanges();
                        break;
                    default:
                        throw new Exception("更新类型出错。");
                }

                //return View(data);
                //var script = String.Format("<script>alert('更新成功!');location.href='{0}';</script>", Url.Action("UpdateRole"));
                string script = MvcUT.ShowAlertAndHref(this, "更新成功", "UpdateRole", new { updateType=2,id=data.RoleID });
                return Content(script,"text/html");

            }
            catch (Exception ex)
            {
                if (ex.Message != null) { }

                this.ViewBag.ErrMsg = MisBase.BaseUT.GetRootException(ex).Message;

                return View(data);
            }
        }

        /// <summary>
        /// 获取现有的角色列表
        /// </summary>
        /// <returns></returns>
        public ActionResult RoleList()
        {
            List<MisBase.Users.Roles> list = null;

            UserDbContext uc = new UserDbContext("ConnStr1");

            list = uc.GetRoles(string.Empty, true);

            if (list == null) list = new List<Roles>();

            return View(list);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="updateType">更新类型，1-新增，2-修改，3-删除</param>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public ActionResult UpdateUser(string updateType, string id)
        {
            UserRegister data = new UserRegister();

            if (string.IsNullOrEmpty(updateType))
            {
                updateType = "1";
            }

            switch (updateType)
            {
                case "1":
                    break;
                case "2":
                    UserDbContext uc1 = new UserDbContext("ConnStr1");
                    data = (UserRegister)uc1.GetUsersByID(id);
                    break;
                case "3":
                    UserDbContext uc2 = new UserDbContext("ConnStr1");
                    data = (UserRegister)uc2.GetUsersByID(id);
                    break;
                default:
                    throw new Exception("更新类型出错。");
            }

            if (data == null) data = new UserRegister();

            return View(data);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="data">用户信息</param>
        /// <param name="updateType">更新类型，1-新增，2-修改，3-删除</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateUser(UserRegister data, string updateType)
        {
            if (string.IsNullOrEmpty(updateType))
            {
                updateType = "1";
            }

            UserDbContext uc = new UserDbContext("ConnStr1");
            Users data2 = null;

            try
            {
                switch (updateType)
                {
                    case "1":
                        if (data != null)
                        {
                            data2 = (Users)data;
                            data = (UserRegister)uc.AddUser(data2);                   
                            uc.SaveChanges();
                        }
                        else
                        {
                            data = new UserRegister();
                        }
                        break;
                    case "2":
                        if (data == null) throw new Exception("数据为空，无法更新。");
                        uc.ModifyUser(data);
                        uc.SaveChanges();
                        break;
                    case "3":
                        if (data == null) throw new Exception("数据为空，无法删除。");
                        uc.DeleteUser(data);
                        uc.SaveChanges();
                        break;
                    default:
                        throw new Exception("更新类型出错。");
                }

                string script = MvcUT.ShowAlertAndHref(this, "更新成功", "UpdateUser");
                return Content(script);
            }
            catch (Exception ex)
            {
                if (ex.Message != null) { }

                this.ViewBag.ErrMsg = MisBase.BaseUT.GetRootException(ex).Message;

                return View(data);
            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 用户登录，post
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(Users data)
        {
            try
            {
                UserDbContext uc = new UserDbContext("ConnStr1");

                Users user = uc.Login(data.UserAccount, data.UserPwd, Enum_LoginMethod.UserAccount);

                string tickStr = string.Empty;
                if (user != null)
                {
                    tickStr = "登录成功。";
                    SessionManager.User = user;
                    SessionManager.UserName = user.UserName;
                    SessionManager.UserID = user.UserID;

                    string script = MvcUT.Href(this, "Index", null);
                    return Content(script);
                }
                else
                {
                    SessionManager.User = null;
                    SessionManager.UserName = string.Empty;
                    SessionManager.UserID = string.Empty;
                    tickStr = "登录失败，请检查账户与密码是否有误？";

                    string script = MvcUT.ShowAlertAndHref(this, tickStr,"Login",null);
                    return Content(script);
                }

                

            }
            catch (Exception ex)
            {
                if (ex.Message != null) { }

                this.ViewBag.ErrMsg = MisBase.BaseUT.GetRootException(ex).Message;

                return View(data);
            }            
        }

        /// <summary>
        /// 更新用户所属角色
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateUserRole()
        {
            try
            {
                if (Session["User"] == null) throw new Exception("你还未登录，请重新登录。");
                //if (string.IsNullOrEmpty(userID)) throw new Exception("用户ID不能为空。");
                UserDbContext uc = new UserDbContext("ConnStr1");

                List<Roles> datas = uc.GetRoles(string.Empty, true);

                if (datas != null)
                {
                    return View(datas);
                }
                else
                {
                    return View(new List<Roles>());
                }
            }
            catch (Exception ex)
            {
                if (ex.Message != null) { }

                this.ViewBag.ErrMsg = MisBase.BaseUT.GetRootException(ex).Message;

                string script = MvcUT.ShowAlertAndHref(this, ex.Message, "Index");
                return Content(script);
            }
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUser()
        {
            //List<SelectListItem> list = new List<SelectListItem>()
            //{
            //    new SelectListItem() {Text="A11",Value="001"},
            //    new SelectListItem() {Text="A12",Value="002"},
            //    new SelectListItem() {Text="A13",Value="003"}
            //};

            List<string> list = new List<string>();

            Users selectUser = new Users();

            string str = this.HttpContext.Request.Url.ToString();

            try
            {
                UserDbContext uc = new UserDbContext("ConnStr1");

                List<Users> uList = uc.GetUsersByName(string.Empty, true);

                List<SelectListItem> userList = new List<SelectListItem>();

                for(int i=0;i<uList.Count;i++)
                {
                    SelectListItem item = new SelectListItem();
                    item.Text = uList[i].UserName;
                    item.Value = uList[i].UserID;

                    userList.Add(item);
                }

                this.ViewData["USERLIST"] = userList;

            }
            catch (Exception ex)
            {
                if (ex.Message != null) { }

                this.ViewBag.ErrMsg = MisBase.BaseUT.GetRootException(ex).Message;

            }

            return View(selectUser);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="selectUser">所选择的用户</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetUser(Users selectUser)
        {
            if (selectUser != null)
            {
                Session["SelectUserID"] = selectUser.UserID;
                Session["SelectUserName"] = selectUser.UserName;
            }
                
            string script = MvcUT.Href(this, "UpdateUserRole");
            return Content(script);
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetRoles(string page, string rows)
        {
            try
            {
                UserDbContext udb = new UserDbContext("ConnStr1");

                List<Roles> list = udb.GetRoles(string.Empty, true);

                var list2 = from r in list
                            select new
                            {
                                r.RoleDesc,
                                r.RoleID,
                                r.RoleLevel,
                                r.RoleName,
                                RoleID2=r.RoleID
                            };

                int pagesizeI = int.Parse(rows);//Request["rows"]
                int pagenumI = int.Parse(page);//Request["page"]

                var json = new
                {
                    total = list2.ToList().Count,
                    rows = list2.ToList().Skip((pagenumI - 1) * pagesizeI).Take(pagesizeI).ToArray()
                };

                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                if (ex.Message != null) { string str = MisBase.BaseUT.GetRootException(ex).Message; }

                return new JsonResult();
            }
            
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetRolesComboBox()
        {
            UserDbContext udb = new UserDbContext("ConnStr1");

            List<Roles> list = udb.GetRoles(string.Empty, true);
            var list2 = from r in list
                        select new
                        {
                            RoleID = r.RoleID,
                            RoleName = r.RoleName
                        };

            JsonResult jr = Json(list2.ToList(), JsonRequestBehavior.AllowGet);

            return jr;
        }

        /// <summary>
        /// 根据RoleID获取角色权限列表
        /// </summary>
        /// <param name="roleID">roleID</param>
        /// <returns></returns>
        public JsonResult GetRightsByRoleID(string roleID)
        {
            UserDbContext udb = new UserDbContext("ConnStr1");
            List<Rights> list = udb.GetRightsByRoleID(roleID);

            var list2 = from r in list
                        select new
                        {
                            RightName=r.RightName
                        };

            JsonResult jr = Json(list2.ToList(), JsonRequestBehavior.AllowGet);

            return jr;
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public ActionResult SetRoleRight()
        {
            MickUserFrameWork.Models.RoleRightList rrl = new Models.RoleRightList();
            rrl.RoleID = "001";
            rrl.RightIDList.Add("right001");
            rrl.RightIDList.Add("right002");

            string str = Newtonsoft.Json.JsonConvert.SerializeObject(rrl);

            return View(rrl);
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SetRoleRight(RoleRightList data)
        {
            //string str = this.Request.Form["data"];

            //if (data == null) data = new Models.RoleRightList();
            //rrl.RoleID = str;

            return View(data);
        }

        /// <summary>
        /// 选择角色
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectRole()
        {
            string str = string.Empty;

            try
            {
                string userID = SessionManager.UserID;
                string rightUrl = this.Request.RawUrl;//"/User/AddRight";
                UserDbContext uc = new UserDbContext("ConnStr1");
                bool flag = uc.IsUserHasRight(userID, rightUrl);

                if (flag)
                {
                    //str = "用户" + userID + "具有" + rightUrl + "权限";
                    return View();
                }
                else
                {
                    str = "用户" + SessionManager.UserName + "不具有" + rightUrl + "权限";

                    string resStr = MisBase.MvcUT.ShowAlertAndHref(this, str, "Login");
                    return Content(resStr);
                }
            }
            catch (Exception ex)
            {
                str = MisBase.BaseUT.GetRootException(ex).Message;
                string resStr = MisBase.MvcUT.ShowAlertAndHref(this, str, "Login");
                return Content(resStr);
            }
        }

        /// <summary>
        /// 增加一个权限，get
        /// </summary>
        /// <returns></returns>
        public ActionResult AddRight()
        {
            Rights data = new Rights();
            string str=string.Empty;

            try
            {
                string userID = SessionManager.UserID;
                string rightUrl = this.Request.RawUrl;//"/User/AddRight";
                UserDbContext uc = new UserDbContext("ConnStr1");
                bool flag = uc.IsUserHasRight(userID, rightUrl);

                if (flag)
                {
                    //str = "用户" + userID + "具有" + rightUrl + "权限";
                    return View(data);
                }                    
                else
                {
                    str = "用户" + SessionManager.UserName + "不具有" + rightUrl + "权限";

                    string resStr = MisBase.MvcUT.ShowAlertAndHref(this, str, "Login");
                    return Content(resStr);
                }
            }
            catch (Exception ex)
            {
                str = MisBase.BaseUT.GetRootException(ex).Message;
                string resStr = MisBase.MvcUT.ShowAlertAndHref(this, str, "Login");
                return Content(resStr);
            }             
        }

        /// <summary>
        /// 增加一个权限，post
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string AddRight2(Rights data)
        {
            try
            {
                UserDbContext uc = new UserDbContext("ConnStr1");

                uc.AddRight(data);
                uc.SaveChanges();

                //string script = MvcUT.ShowAlertAndHref(this, "增加成功", "AddRight");
                return "ok;增加成功";
            }
            catch (Exception ex)
            {
                //提示错误信息
                string str = MisBase.BaseUT.GetRootException(ex).Message;

                return "false;" + str;
            }
            
        }

        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetRights()
        {
            UserDbContext udb = new UserDbContext("ConnStr1");

            List<Rights> list = udb.GetRights();
            var list2 = from r in list
                        select new
                        {
                            RightName = r.RightName,
                            RightID = r.RightID
                        };

            JsonResult jr = Json(list2.ToList(), JsonRequestBehavior.AllowGet);

            return jr;
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetRoles2()
        {
            UserDbContext udb = new UserDbContext("ConnStr1");

            List<Roles> list = udb.GetRoles(string.Empty,true);
            var list2 = from r in list
                        select new
                        {
                            RoleName = r.RoleName,
                            RoleID = r.RoleID,
                            RoleDesc = r.RoleDesc,
                            RoleLevel = r.RoleLevel
                        };

            JsonResult jr = Json(list2.ToList(), JsonRequestBehavior.AllowGet);

            return jr;
        }

        /// <summary>
        /// 更新角色的相关权限
        /// </summary>
        /// <returns></returns>
        public JsonResult SetRoleRight2(RoleRightList data)
        {
            try
            {
                if (data == null) throw new Exception("提供的更新列表不存在。");

                UserDbContext udb = new UserDbContext("ConnStr1");

                List<RoleRight> list = udb.GetRoleRights(data.RoleID);

                //如果旧的在新的不存在，则删除
                foreach (RoleRight rr in list)
                {
                    bool flag = false;
                    int i = 0;
                    for (i = 0; i < data.RightIDList.Count; i++)
                    {
                        if (rr.RightID == data.RightIDList[i])
                        {
                            flag = true;
                            break;
                        }
                    }
                    //如果不存在，则删除
                    if (flag == false) udb.DeleteRoleRight(rr);
                }
                //保存数据库变更
                udb.SaveChanges();

                //如果新的在旧的不存在，则新增
                foreach (string str in data.RightIDList)
                {
                    bool flag = false;
                    int i = 0;
                    for (i = 0; i < list.Count; i++)
                    {
                        if (str == list[i].RightID)
                        {
                            flag = true;
                            break;
                        }
                    }
                    //如果不存在，则新增
                    if (flag == false)
                    {
                        RoleRight rr = new RoleRight();
                        rr.RoleID = data.RoleID;
                        rr.RightID = str;
                        udb.AddRoleRight(rr);
                    }
                }
                //保存数据库变更
                udb.SaveChanges();

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (ex.Message != null) { }

                throw;
            }            
        }

        /// <summary>
        /// 进行用户与角色关联
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public JsonResult UpdateUserRoles2(UserRoleList data)
        {
            try
            {
                if (data == null) throw new Exception("提供的更新列表不存在。");
                UserDbContext udb = new UserDbContext("ConnStr1");
                List<UserRole> list = udb.GetUserRolesByUserID(data.UserID);

                //先删除
                foreach (UserRole d in list)
                {
                    udb.DeleteUserRole(d);
                }

                //再增加
                foreach (string str in data.RoleIDList)
                {
                    UserRole ur = new UserRole();
                    ur.UserID = data.UserID;
                    ur.RoleID = str;

                    udb.AddUserRole(ur);
                }

                udb.SaveChanges();
                //udb.DeleteUserRole()

                return Json(data);
            }
            catch (Exception ex)
            {
                if (ex.Message != null) { }

                Exception ex1 = MisBase.BaseUT.GetRootException(ex);

                throw;
            }

            
        }

        /// <summary>
        /// 生成一个随机验证码图片
        /// </summary>
        /// <returns></returns>
        public ActionResult ValidateCode()
        {
            MisBase.ValidateCode vc = new MisBase.ValidateCode();
            string code = vc.CreateValidateCode(4);
            Session["ValidateCode"] = code;
            byte[] buffer = vc.CreateValidateGraphic(code);

            return File(buffer, "image/jpeg");
        }

        /// <summary>
        /// 另一种首页样式
        /// </summary>
        /// <returns></returns>
        public ActionResult Index2()
        {
            return View();
        }

        /// <summary>
        /// 显示用户列表
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectUser()
        {
            return View();
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetUserDataGrid()
        {
            UserDbContext udb = new UserDbContext("ConnStr1");
            List<Users> list = udb.GetUsersByName(string.Empty, true);

            var list2 = from r in list
                        select new
                        {
                            UserAccount = r.UserAccount,
                            UserCertNo = r.UserCertNo,
                            UserCertType=r.UserCertType,
                            UserID=r.UserID,
                            UserID2=r.UserID,
                            UserName=r.UserName,
                            UserPhone=r.UserPhone,
                            UserUnit=r.UserUnit
                        };

            return Json(list2.ToList(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 显示权限列表
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectRight()
        {
            return View();
        }

        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetRightDataGrid()
        {
            UserDbContext udb = new UserDbContext("ConnStr1");
            List<Rights> list = udb.GetRights();

            var list2 = from r in list
                        select new
                        {
                            r.RightDesc,
                            r.RightID,
                            r.RightName,
                            r.RightUrl,
                            RightID2 = r.RightID
                        };


            return Json(list2.ToList(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据用户ID删除一个用户
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public string DeleteUser(string userID)
        {
            if (string.IsNullOrEmpty(userID)) return "false;UserID为空。";

            UserDbContext udb = new UserDbContext("ConnStr1");
            Users data = new Users();
            data.UserID = userID;
            udb.DeleteUser(data);
            udb.SaveChanges();

            return "ok;删除成功。";
        }

        /// <summary>
        /// 根据角色ID删除一个角色
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public string DeleteRole(string roleID)
        {
            string resStr = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(roleID)) throw new Exception( "false;UserID为空。");
                UserDbContext udb = new UserDbContext("ConnStr1");
                Roles data = new Roles();
                data.RoleID = roleID;

                udb.DeleteRole(data);
                udb.SaveChanges();

                return "ok;删除成功。";
            }
            catch (Exception ex)
            {
                resStr = MisBase.BaseUT.GetRootException(ex).Message;
            }

            return resStr;
        }

        /// <summary>
        /// 权限更新页面
        /// </summary>
        /// <param name="rightID"></param>
        /// <returns></returns>
        public ActionResult UpdateRight(string rightID)
        {
            Rights data = new Rights();
            string resStr = string.Empty;

            try
            {
                UserDbContext udb = new UserDbContext("ConnStr1");
                data = udb.GetRights(rightID);
            }
            catch(Exception ex)
            {
                resStr = MisBase.BaseUT.GetRootException(ex).Message;
            }

            return View(data);
        }

        /// <summary>
        /// 更新一个权限
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string UpdateRight2(Rights data)
        {
            try
            {
                UserDbContext uc = new UserDbContext("ConnStr1");

                uc.ModifyRight(data);
                uc.SaveChanges();

                //string script = MvcUT.ShowAlertAndHref(this, "增加成功", "AddRight");
                return "ok;更新成功";
            }
            catch (Exception ex)
            {
                //提示错误信息
                string str = MisBase.BaseUT.GetRootException(ex).Message;

                return "false;" + str;
            }
        }

        /// <summary>
        /// 删除一个权限
        /// </summary>
        /// <param name="rightID"></param>
        /// <returns></returns>
        public string DeleteRight(string rightID)
        {
            try
            {
                UserDbContext uc = new UserDbContext("ConnStr1");

                Rights data = new Rights();
                data.RightID = rightID;

                uc.DeleteRight(data);
                uc.SaveChanges();

                //string script = MvcUT.ShowAlertAndHref(this, "增加成功", "AddRight");
                return "ok;删除成功";
            }
            catch (Exception ex)
            {
                //提示错误信息
                string str = MisBase.BaseUT.GetRootException(ex).Message;

                return "false;" + str;
            }
        }

        /// <summary>
        /// 判断用户是否有相关权限
        /// </summary>
        /// <returns></returns>
        public ActionResult UserHasRight()
        {
            string str = string.Empty;
            try
            {
                string userID = SessionManager.UserID;
                string rightUrl = this.Request.RawUrl;//"/User/AddRight";
                UserDbContext uc = new UserDbContext("ConnStr1");
                bool flag = uc.IsUserHasRight(userID, rightUrl);

                if (flag)
                    str = "用户"+userID+"具有"+rightUrl+"权限";
                else str = "用户" + userID + "不具有" + rightUrl + "权限";
            }
            catch (Exception ex)
            {
                str = MisBase.BaseUT.GetRootException(ex).Message;
            }
            return Content(str);
        }
    }
}