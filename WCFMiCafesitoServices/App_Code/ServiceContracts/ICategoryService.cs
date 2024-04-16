using System.Collections.Generic;
using System.ServiceModel;

namespace MiCafesito
{
    [ServiceContract]
    public interface ICategoryService
    {
        [OperationContract]
        List<Category> GetAllCategories();

        [OperationContract]
        Category GetCategoryById(int id);

        [OperationContract]
        void UpdateCategory(Category category);

        [OperationContract]
        void DeleteCategory(int id);

        [OperationContract]
        void AddCategory(Category category);
    }
}