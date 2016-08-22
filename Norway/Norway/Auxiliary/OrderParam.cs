namespace Norway.Auxiliary
{
    /// <summary>
    /// 排序参数
    /// <remarks>
    /// 2016.08.22检查优化
    /// </remarks>
    /// </summary>
    public class OrderParam
    {
        /// <summary>
        /// 属性名
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// 排序方式
        /// </summary>
        public OrderMethod Method { get; set; }
    }

    /// <summary>
    /// 排序方式
    /// </summary>
    public enum OrderMethod
    {
        /// <summary>
        /// 正序
        /// </summary>
        ASC,
        /// <summary>
        /// 倒序
        /// </summary>
        DESC
    }
}