using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IFoodsRepository: IRepositoryBase<Foods>
    {
        Task<IEnumerable<Foods>> GetAllFoods();
        Task<Foods> GetFoodById(int foodId);
        void CreateFood(Foods food);
        void UpdateFood(Foods food);
        void DeleteFood(Foods food);
    }
}
