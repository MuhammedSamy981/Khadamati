using FinalProject.Dal;

public class PictureManager : IPictureManager
{
    private readonly IPictureRepo _pictureRepo;

    public PictureManager(IPictureRepo pictureRepo)
    {
        _pictureRepo=pictureRepo;
    }

    public void Add(AddPictureDTO pictureDTO)
    {
        var picture= new Picture
        {
            Url=pictureDTO.Url,
            ServiceId=pictureDTO.ServiceId
        };
        _pictureRepo.Add(picture);
        _pictureRepo.SaveDbChange();
    }

    public void Update(UpdatePictureDTO pictureDTO)
    {
      var picture=_pictureRepo.GetById(pictureDTO.Id);
       picture.Url=pictureDTO.Url;
       picture.ServiceId=pictureDTO.ServiceId;

       _pictureRepo.Update(picture);
        _pictureRepo.SaveDbChange();
    }

}