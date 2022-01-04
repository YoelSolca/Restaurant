using Contracts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public class FoodsRepository : RepositoryBase<Foods>, IFoodsRepository
    {
        public FoodsRepository(Context context): base(context)
        {

        }
        public async Task<IEnumerable<Foods>> GetAllFoods()
        {
            return await FindAll()
                .ToListAsync();
        }

        public async Task<Foods> GetFoodById(int foodId)
        {
            return await FinByCondition(id => id.ID.Equals(foodId))
                .FirstOrDefaultAsync();
        }

        public void UpdateFood(Foods food)
        {
            throw new System.NotImplementedException();
        }

        public void CreateFood(Foods food)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteFood(Foods food)
        {
            Delete(food);
        }

   
    }
}
