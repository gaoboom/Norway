using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Norway.DataLibrary
{
    /// <summary>
    /// 数据仓储类
    /// </summary>
    /// <remarks>
    /// Created at 2016.08.10
    /// </remarks>
    /// <typeparam name="T">实体模型</typeparam>
    public class Repository<T> where T :class
    {
        /// <summary>
        /// 数据上下文
        /// </summary>
        public DbContext DbContext { get; set; }

        public Repository()
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbContext">数据上下文</param>
        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
        }


    }
}