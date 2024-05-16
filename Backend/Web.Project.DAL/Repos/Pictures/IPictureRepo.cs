using FinalProject.Dal;

    public interface IPictureRepo
    {
        void Add(Picture picture);
        void Update(Picture picture);
        Picture? GetById(int id);
                void Delete(Picture pic);

        int SaveDbChange();
    }
