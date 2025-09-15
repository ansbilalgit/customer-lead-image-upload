namespace CompanyPlanner.Infrastructure.Entitities.Interfaces
{
    public interface IProfile<TImage>
    {
        int Id { get; set; }
        ICollection<TImage> Images { get; set; }
    }
}
