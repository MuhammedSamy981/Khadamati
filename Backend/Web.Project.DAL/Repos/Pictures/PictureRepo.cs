
using FinalProject.Dal;
using WebApplications4.DAL;

public class PictureRepo :IPictureRepo
{
    private readonly KhadamatiContext _context;

    public PictureRepo(KhadamatiContext context)
    {
      _context=context;
    }

    public Picture? GetById(int id)
    {
        return _context.Set<Picture>().Find(id);
    }

    public void Add(Picture picture)
    {
        _context.Set<Picture>().Add(picture);
    }
    public void Update(Picture picture)
    {
         _context.Set<Picture>().Update(picture);
    }
        public void Delete(Picture pic)
        {
                _context.Set<Picture>().Remove(pic);
           
        }
    public int SaveDbChange()
    {
       return _context.SaveChanges();
    }

    }

