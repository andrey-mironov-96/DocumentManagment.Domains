using DocumentManagment.Domains.Primitives;

namespace DocumentManagment.Domains.ValueObjects;

public sealed class CreateAt : ValueObject
{
    private CreateAt()
    {
        Value = DateTime.UtcNow;
    }

    public DateTime Value { get; }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<CreateAt> Create()
    {
        return new CreateAt();
    }
}
