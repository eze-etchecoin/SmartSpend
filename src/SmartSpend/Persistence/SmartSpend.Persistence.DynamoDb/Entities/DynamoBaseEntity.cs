using Amazon.DynamoDBv2.DataModel;

namespace SmartSpend.Persistence.DynamoDb.Entities
{
    [DynamoDBTable("SmartSpend_Data")]
    public abstract class DynamoBaseEntity
    {
        private string _parentEntityKey;

        public DynamoBaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            CreatedOn = DateTimeOffset.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz");
        }

        [DynamoDBHashKey]
        protected abstract string EntityName { get; set; }

        protected abstract string ParentEntityName { get; set; }

        public string ParentEntityKey
        { 
            get => _parentEntityKey ?? $"{ParentEntityName}#{Id}";
            internal set => _parentEntityKey = value;
        }

        [DynamoDBRangeKey]
        public string CreatedOn { get; internal set; }

        public string Id { get; set; }
        
    }
}