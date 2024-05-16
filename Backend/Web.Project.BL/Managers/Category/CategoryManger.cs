using FinalProject.Dal;
public class CategoryManger : ICategoryManger
{
    private readonly ICategoryrepo _repo;

    public CategoryManger(ICategoryrepo repo)
    {
        _repo = repo;
    }
    public int Add(CategoryAddDTO CategoryFromRueqest)
    {
        Category category = new Category()
        {
            Name = CategoryFromRueqest.Name
            
        };
        _repo.Add(category);
        _repo.SaveChanges();
        return category.Id;
    }

    public List<CategoryReadDTO> GetAll()
    {
        List<Category> categories = _repo.GetAll();
        return categories.Select(d => new CategoryReadDTO
        {
            Id = d.Id,
            Name = d.Name

        }).ToList();
    }

    public bool Remove(int id)
    {
        Category? category = _repo.GetbyID(id);
        if (category == null) return false;
        
        _repo.Remove(category);
        _repo.SaveChanges();
        return true;
    }

   

    public bool Update(CategoryUpdateDTO CategoryRequested)
    {
        Category? category = _repo.GetbyID(CategoryRequested.Id);
        if (category == null) return false;
        category.Name = CategoryRequested.Name;
        category.Id = CategoryRequested.Id;
        _repo.Update(category);
        _repo.SaveChanges();
        return true;
    }
}
