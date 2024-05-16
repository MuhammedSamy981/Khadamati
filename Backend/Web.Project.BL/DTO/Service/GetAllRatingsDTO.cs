
namespace FinalProject.Dal;
public class GetAllRatingsDTO
{
    public int Id { get; set; }
    public string UserId { get; set; }=string.Empty;
    public string UserName { get; set; }=string.Empty;
    public string Comment { get; set; }=string.Empty;
    public float rating { get; set; }
    public DateTime date { get; set; }
}