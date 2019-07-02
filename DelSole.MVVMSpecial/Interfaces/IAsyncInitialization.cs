using System.Threading.Tasks;

namespace DelSole.MVVMSpecial.Interfaces
{
    public interface IAsyncInitialization
    {
        Task InitializeAsync();
    }
}