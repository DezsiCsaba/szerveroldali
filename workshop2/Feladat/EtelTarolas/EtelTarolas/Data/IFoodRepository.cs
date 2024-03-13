using EtelTarolas.Models;

namespace EtelTarolas.Data
{
    public interface IFoodRepository
    {
        void Create(Food food);
        IEnumerable<Food> ReadAll();
    }
}
