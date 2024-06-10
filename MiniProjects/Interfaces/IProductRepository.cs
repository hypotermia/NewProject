using System.Threading.Tasks;
using MiniProjects.Models;

namespace MiniProjects.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetTasksAsync(); // Change the return type
        Task<Product> GetTaskByIdAsync(Guid uId);
        Task AddTaskAsync(Product products);
        Task UpdateTaskAsync(Guid uId, Product products);
        Task DeleteTaskAsync(Guid uId);
    }
}
