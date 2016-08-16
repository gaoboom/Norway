using Norway.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norway.Core.Category
{
    /// <summary>
    /// 链接栏目管理
    /// </summary>
    public class CategoryLinkManager : BaseManager<CategoryLink>
    {
        /// <summary>
        /// 删除链接栏目-根据栏目ID
        /// </summary>
        /// <param name="categoryID">栏目ID</param>
        /// <returns></returns>
        public Response DeleteByCategoryID(int categoryID)
        {
            return base.Delete(cl => cl.CategoryID == categoryID);
        }
    }
}