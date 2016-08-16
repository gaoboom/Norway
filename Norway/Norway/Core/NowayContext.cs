using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Norway.Core.Users;

namespace Norway.Core
{
    public class NowayContext:DbContext
    {
        /// <summary>
        /// 管理员集合
        /// </summary>
        public DbSet<Administrator> Administrators { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<User> Users { get; set; }

        #region 栏目

        /// <summary>
        /// 栏目
        /// </summary>
        public DbSet<Category.Category> Categories { get; set; }

        /// <summary>
        /// 常规栏目
        /// </summary>
        public DbSet<CategoryGeneral> CategoryGeneral { get; set; }

        /// <summary>
        /// 单页栏目
        /// </summary>
        public DbSet<CategoryPage> CategoryPages { get; set; }

        /// <summary>
        /// 链接栏目
        /// </summary>
        public DbSet<CategoryLink> CategoryLinks { get; set; }

        #endregion

        #region 内容
        /// <summary>
        /// 内容类型
        /// </summary>
        public DbSet<ContentType> ContentTypes { get; set; }

        #endregion

        public NowayContext():base("DefaultConnection")
        {
            Database.SetInitializer<NowayContext>(new CreateDatabaseIfNotExists<NowayContext>());
        }
    }
}