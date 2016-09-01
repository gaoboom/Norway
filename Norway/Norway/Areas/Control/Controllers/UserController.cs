using LinqKit;
using Norway.Auxiliary;
using Norway.Core.Types;
using Norway.Core.Users;
using Norway.DataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Norway.Areas.Control.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    [AdminAuthorize]
    public class UserController : Controller
    {
        private UserManager userManager = new UserManager();

        /// <summary>
        /// 默认页
        /// </summary>
        /// <returns></returns>
        // GET: Control/User
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="pagingUser">分页数据</param>
        /// <param name="roleID">角色ID</param>
        /// <param name="username">用户名</param>
        /// <param name="name">名称</param>
        /// <param name="sex">性别</param>
        /// <param name="email">Email</param>
        /// <param name="order">排序【null（默认）-ID降序，0-ID升序，1-ID降序，2-注册时间降序，3-注册时间升序，4-最后登录时间升序，5-最后登录时间降序】</param>
        /// <returns></returns>
        public Paging<User> FindPageList(Paging<User> pagingUser, int? roleID, string username, string name, int? sex, string email, int? order)
        {
            //查询表达式
            var _where = PredicateBuilder.New<User>();
            if (roleID != null && roleID > 0) _where = _where.And(u => u.RoleID == roleID);
            if (!string.IsNullOrEmpty(username)) _where = _where.And(u => u.Username.Contains(username));
            if (!string.IsNullOrEmpty(name)) _where = _where.And(u => u.Name.Contains(name));
            if (sex != null && sex >= 0 && sex <= 2) _where = _where.And(u => u.Sex == sex);
            if (!string.IsNullOrEmpty(email)) _where = _where.And(u => u.Email.Contains(email));
            //排序
            OrderParam _orderParam;
            switch (order)
            {
                case 0://ID升序
                    _orderParam = new OrderParam() { PropertyName = "UserID", Method = OrderMethod.ASC };
                    break;
                case 1://ID降序
                    _orderParam = new OrderParam() { PropertyName = "UserID", Method = OrderMethod.DESC };
                    break;
                case 2://注册时间降序
                    _orderParam = new OrderParam() { PropertyName = "RegTime", Method = OrderMethod.ASC };
                    break;
                case 3://注册时间升序
                    _orderParam = new OrderParam() { PropertyName = "RegTime", Method = OrderMethod.DESC };
                    break;
                case 4://最后登录时间升序
                    _orderParam = new OrderParam() { PropertyName = "LastLoginTime", Method = OrderMethod.ASC };
                    break;
                case 5://最后登录时间降序
                    _orderParam = new OrderParam() { PropertyName = "LastLoginTime", Method = OrderMethod.DESC };
                    break;
                default://ID降序
                    _orderParam = new OrderParam() { PropertyName = "UserID", Method = OrderMethod.DESC };
                    break;
            }
            pagingUser.Items = Repository.FindPageList(pagingUser.PageSize, pagingUser.PageIndex, out pagingUser.TotalNumber, _where.Expand(), _orderParam).ToList();
            return pagingUser;
        }

    }
}