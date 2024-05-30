using FinalProject.Dal;
public interface ICategoryManger
{
    List<CategoryReadDTO> GetAll();

    int Add(CategoryAddDTO category);

    bool Remove(int id);

    bool Update(CategoryUpdateDTO category);
}
