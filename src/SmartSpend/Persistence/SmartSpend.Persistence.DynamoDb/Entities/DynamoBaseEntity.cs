using Amazon.DynamoDBv2.DataModel;

namespace SmartSpend.Persistence.DynamoDb.Entities
{
    [DynamoDBTable("SmartSpend_Data")]
    public abstract class DynamoBaseEntity
    {
        private string _globalIdentifier;
        private string _id;

        public DynamoBaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTimeOffset.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz");
        }

        [DynamoDBHashKey]
        protected abstract string EntityName { get; set; }

        public string GlobalIdentifier 
        { 
            get => _globalIdentifier ?? $"{EntityName}#{Id}";
            internal set => _globalIdentifier = value;
        }

        [DynamoDBRangeKey]
        public string CreatedOn { get; internal set; }

        public Guid Id 
        { 
            get => Guid.Parse(_id); 
            set => _id = value.ToString(); 
        }
        
    }
}