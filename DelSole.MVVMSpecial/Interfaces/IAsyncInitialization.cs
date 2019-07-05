using System.Threading.Tasks;

namespace DelSole.MVVMSpecial.Interfaces
{
    /// <summary>
    /// A contract for classes that need async initialization when instantiated
    /// </summary>
    public interface IAsyncInitialization
    {
        /// <summary>
        /// Run asynchronous code when an object is initialized
        /// </summary>
        /// <returns></returns>
        Task InitializeAsync();
    }
}