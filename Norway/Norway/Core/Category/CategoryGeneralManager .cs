using Norway.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norway.Core.Category
{
    /// <summary>
    /// 常规栏目管理
    /// </summary>
    public class CategoryGeneralManager : BaseManager<CategoryGeneral>
    {
        /// <summary>
        /// 删除常规栏目-根据栏目ID
        /// </summary>
        /// <param name="categoryID">栏目ID</param>
        /// <returns></returns>
        public Response DeleteByCategoryID(int categoryID)
        {
            return base.Delete(cg => cg.CategoryID == categoryID);
        }
    }
}