using Norway.Auxiliary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbContext">数据上下文</param>
        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        //查找实体
        #region Find
        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="ID">实体主键值</param>
        /// <returns></returns>
        public T Find(int ID)
        {
            return DbContext.Set<T>().Find(ID);
        }

        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="where">查询Lambda表达式</param>
        /// <returns></returns>
        public T Find(Expression<Func<T, bool>> where)
        {
            return DbContext.Set<T>().SingleOrDefault(where);
        }
        #endregion

        //查找实体列表
        #region FindList
        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> FindList()
        {
            return DbContext.Set<T>();
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="where">查询Lambda表达式</param>
        /// <returns></returns>
        public IQueryable<T> FindList(Expression<Func<T, bool>> where)
        {
            return DbContext.Set<T>().Where(where);
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="where">查询Lambda表达式</param>
        /// <param name="number">获取的记录数量</param>
        /// <returns></returns>
        public IQueryable<T> FindList(Expression<Func<T, bool>> where, int number)
        {
            return DbContext.Set<T>().Where(where).Take(number);
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="where">查询Lambda表达式</param>
        /// <param name="orderParam">排序参数</param>
        /// <returns></returns>
        public IQueryable<T> FindList(Expression<Func<T, bool>> where, OrderParam orderParam)
        {
            return FindList(where, orderParam, 0);
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="where">查询Lambda表达式</param>
        /// <param name="orderParam">排序参数</param>
        /// <param name="number">获取的记录数量【0-不启用】</param>
        public IQueryable<T> FindList(Expression<Func<T, bool>> where, OrderParam orderParam, int number)
        {
            OrderParam[] _orderParams = null;
            if (orderParam != null) _orderParams = new OrderParam[] { orderParam };
            return FindList(where, _orderParams, number);
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="where">查询Lambda表达式</param>
        /// <param name="orderParams">排序参数</param>
        /// <param name="number">获取的记录数量【0-不启用】</param>
        /// <returns></returns>
        public IQueryable<T> FindList(Expression<Func<T, bool>> where, OrderParam[] orderParams, int number)
        {
            var _list = DbContext.Set<T>().Where(where);
            var _orderParames = Expression.Parameter(typeof(T), "o");
            if (orderParams != null && orderParams.Length > 0)
            {
                bool _isFirstParam = true;
                for (int i = 0; i < orderParams.Length; i++)
                {
                    //根据属性名获取属性
                    var _property = typeof(T).GetProperty(orderParams[i].PropertyName);
                    //创建一个访问属性的表达式
                    var _propertyAccess = Expression.MakeMemberAccess(_orderParames, _property);
                    var _orderByExp = Expression.Lambda(_propertyAccess, _orderParames);
                    string _orderName;
                    if (_isFirstParam)
                    {
                        _orderName = orderParams[i].Method == OrderMethod.ASC ? "OrderBy" : "OrderByDescending";
                        _isFirstParam = false;
                    }
                    else _orderName = orderParams[i].Method == OrderMethod.ASC ? "ThenBy" : "ThenByDescending";
                    MethodCallExpression resultExp = Expression.Call(typeof(Queryable), _orderName, new Type[] { typeof(T), _property.PropertyType }, _list.Expression, Expression.Quote(_orderByExp));
                    _list = _list.Provider.CreateQuery<T>(resultExp);
                }
            }
            if (number > 0) _list = _list.Take(number);
            return _list;
        }
        #endregion

        //查找实体分页列表
        #region FindPageList

        /// <summary>
        /// 查找分页列表
        /// </summary>
        /// <param name="pageSize">每页记录数。必须大于1</param>
        /// <param name="pageIndex">页码。首页从1开始，页码必须大于1</param>
        /// <param name="totalNumber">总记录数</param>
        /// <returns></returns>
        public IQueryable<T> FindPageList(int pageSize, int pageIndex, out int totalNumber)
        {
            OrderParam _orderParam = null;
            return FindPageList(pageSize, pageIndex, out totalNumber, _orderParam);
        }

        /// <summary>
        /// 查找分页列表
        /// </summary>
        /// <param name="pageSize">每页记录数。必须大于1</param>
        /// <param name="pageIndex">页码。首页从1开始，页码必须大于1</param>
        /// <param name="totalNumber">总记录数</param>
        /// <param name="order">排序键</param>
        /// <param name="asc">是否正序</param>
        /// <returns></returns>
        public IQueryable<T> FindPageList(int pageSize, int pageIndex, out int totalNumber, OrderParam orderParam)
        {
            return FindPageList(pageSize, pageIndex, out totalNumber, (T) => true, orderParam);
        }

        /// <summary>
        /// 查找分页列表
        /// </summary>
        /// <param name="pageSize">每页记录数。必须大于1</param>
        /// <param name="pageIndex">页码。首页从1开始，页码必须大于1</param>
        /// <param name="totalNumber">总记录数</param>
        /// <param name="where">查询表达式</param>
        public IQueryable<T> FindPageList(int pageSize, int pageIndex, out int totalNumber, Expression<Func<T, bool>> where)
        {
            OrderParam _param = null;
            return FindPageList(pageSize, pageIndex, out totalNumber, where, _param);
        }

        /// <summary>
        /// 查找分页列表
        /// </summary>
        /// <param name="pageSize">每页记录数。</param>
        /// <param name="pageIndex">页码。首页从1开始</param>
        /// <param name="totalNumber">总记录数</param>
        /// <param name="where">查询表达式</param>
        /// <param name="orderParam">排序【null-不设置】</param>
        /// <returns></returns>
        public IQueryable<T> FindPageList(int pageSize, int pageIndex, out int totalNumber, Expression<Func<T, bool>> where, OrderParam orderParam)
        {
            OrderParam[] _orderParams = null;
            if (orderParam != null) _orderParams = new OrderParam[] { orderParam };
            return FindPageList(pageSize, pageIndex, out totalNumber, where, _orderParams);
        }

        /// <summary>
        /// 查找分页列表
        /// </summary>
        /// <param name="pageSize">每页记录数。</param>
        /// <param name="pageIndex">页码。首页从1开始</param>
        /// <param name="totalNumber">总记录数</param>
        /// <param name="where">查询表达式</param>
        /// <param name="orderParams">排序【null-不设置】</param>
        public IQueryable<T> FindPageList(int pageSize, int pageIndex, out int totalNumber, Expression<Func<T, bool>> where, OrderParam[] orderParams)
        {
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1) pageSize = 10;
            IQueryable<T> _list = DbContext.Set<T>().Where(where);
            var _orderParames = Expression.Parameter(typeof(T), "o");
            if (orderParams != null && orderParams.Length > 0)
            {
                for (int i = 0; i < orderParams.Length; i++)
                {
                    //根据属性名获取属性
                    var _property = typeof(T).GetProperty(orderParams[i].PropertyName);
                    //创建一个访问属性的表达式
                    var _propertyAccess = Expression.MakeMemberAccess(_orderParames, _property);
                    var _orderByExp = Expression.Lambda(_propertyAccess, _orderParames);
                    string _orderName = orderParams[i].Method == OrderMethod.ASC ? "OrderBy" : "OrderByDescending";
                    MethodCallExpression resultExp = Expression.Call(typeof(Queryable), _orderName, new Type[] { typeof(T), _property.PropertyType }, _list.Expression, Expression.Quote(_orderByExp));
                    _list = _list.Provider.CreateQuery<T>(resultExp);
                }
            }
            totalNumber = _list.Count();
            return _list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        #endregion
    }
}