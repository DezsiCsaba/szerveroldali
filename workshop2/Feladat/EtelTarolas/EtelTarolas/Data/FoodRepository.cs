using EtelTarolas.Models;

namespace EtelTarolas.Data
{
    public class FoodRepository: IFoodRepository
    {
        FoodDbContext context;

        public FoodRepository(FoodDbContext context)
        {
            this.context = context;
        }

        public void Create(Food food)
        {
            context.Foods.Add(food);
            context.SaveChanges();
        }

        public IEnumerable<Food> ReadAll()
        {
            System.Threading.Thread.Sleep(1000);
            return context.Foods;
        }
    }
}
