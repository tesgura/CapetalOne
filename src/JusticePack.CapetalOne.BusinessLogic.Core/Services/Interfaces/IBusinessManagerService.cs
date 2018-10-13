using System.Threading.Tasks;

namespace JusticePack.CapetalOne.BusinessLogic.Core.Services.Interfaces
{
    public interface IBusinessManagerService
    {
        Task AddConflict(string message);
        Task AddNotFound(string message);
        Task AddResult(string key, object value);
        string GetConflicts();
        string GetNotFounds();
        Task<T> GetResult<T>(string key);
        bool HasConflicts();
        bool HasNotFounds();
    }
}
