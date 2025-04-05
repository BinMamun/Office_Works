namespace SchoolManagement.Domain.Entities
{
    public interface IEntity<TKey> where TKey : IComparable
    {
        TKey Id { get; set; }
    }
}
