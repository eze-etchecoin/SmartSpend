namespace SmartSpend.Domain.Core.Entities
{
    public abstract class BaseEntity : ICreatedOn
    {
        public Guid Id { get; set; }

        public DateTimeOffset CreatedOn { get; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTimeOffset.Now;
        }

        public static bool operator == (BaseEntity obj1, BaseEntity obj2)
        {
            if (obj1?.Id == obj2?.Id)
                return true;

            return false;
        }

        public static bool operator !=(BaseEntity obj1, BaseEntity obj2)
        {
            if (obj1?.Id != obj2?.Id)
                return true;

            return false;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
