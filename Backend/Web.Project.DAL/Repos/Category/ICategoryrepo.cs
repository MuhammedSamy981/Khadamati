using FinalProject.Dal;
public interface ICategoryrepo
{
    List<Category> GetAll();

    Category? GetbyID(int id);   

    void Add(Category category);

    void Remove(Category category);

    int SaveChanges();

    void Update(Category category);

}
