namespace DocumentManagment.Domains.Primitives;

public abstract class Entity
{
    public Guid Identity { get; protected set; }
}
