using Amazon.DynamoDBv2.DataModel;

namespace SmartSpend.Persistence.DynamoDb.Entities
{
    public abstract class DynamoBaseEntity
    {
        private string _globalIdentifier;
        private string _id;

        //private string _createdOn;

        public DynamoBaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTimeOffset.Now;
        }

        protected abstract string EntityName { get; }

        [DynamoDBHashKey]
        public string GlobalIdentifier 
        { 
            get => _globalIdentifier;
            set => _globalIdentifier = $"{EntityName}#{Id}";
        }

        [DynamoDBRangeKey]
        public DateTimeOffset CreatedOn { get; set; }

        public Guid Id 
        { 
            get => Guid.Parse(_id); 
            set => _id = value.ToString(); 
        }
        
    }
}