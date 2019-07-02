using System.Threading.Tasks;

namespace DelSole.MVVMSpecial.Interfaces
{
    public interface IRefreshable
    {
        Task Refresh(object[] constructorParams);
    }
}