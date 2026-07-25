namespace Clinical.Common.Domain;

public abstract class Entity<TId>
{
    public TId Id { get; protected set; }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && EqualityComparer<TId>.Default.Equals(Id, entity.Id);
    }
    
    public override int GetHashCode()
    {
        return EqualityComparer<TId>.Default.GetHashCode(Id);
    }
}