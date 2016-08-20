using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Remoting.Messaging;

namespace Norway.Core
{
    /// <summary>
    /// 数据上下文工厂
    /// </summary>
    public class ContextFactory
    {
        /// <summary>
        /// 获取当前线程的数据上下文
        /// </summary>
        /// <returns>数据上下文</returns>
        public static NorwayContext CurrentContext()
        {
            NorwayContext _nContext = CallContext.GetData("NorwayContext") as NorwayContext;
            if (_nContext == null)
            {
                _nContext = new NorwayContext();
                CallContext.SetData("NorwayContext", _nContext);
            }
            return _nContext;
        }
    }
}