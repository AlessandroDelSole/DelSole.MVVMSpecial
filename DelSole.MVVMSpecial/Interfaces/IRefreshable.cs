using System.Threading.Tasks;

namespace DelSole.MVVMSpecial.Interfaces
{
    /// <summary>
    /// A contract for pages which want to implement content refresh
    /// </summary>
    public interface IRefreshable
    {
        /// <summary>
        /// Refresh content in a page
        /// </summary>
        /// <param name="constructorParams"></param>
        /// <returns><seealso cref="Task"/></returns>
        Task Refresh(object[] constructorParams);
    }
}