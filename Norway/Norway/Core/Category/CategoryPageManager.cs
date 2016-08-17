using Norway.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norway.Core.Category
{
    /// <summary>
    /// 单页栏目管理
    /// </summary>
    public class CategoryPageManager : BaseManager<CategoryPage>
    {
        /// <summary>
        /// 删除单页栏目-根据栏目ID
        /// </summary>
        /// <param name="categoryID">栏目ID</param>
        /// <returns></returns>
        public Response DeleteByCategoryID(int categoryID)
        {
            return base.Delete(cp => cp.CategoryID == categoryID);
        }
    }
}