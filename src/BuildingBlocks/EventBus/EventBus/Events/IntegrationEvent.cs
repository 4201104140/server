using System;
using System.Text.Json.Serialization;

namespace BuildingBlocks.EventBus.Events
{
    public record IntegrationEvent
    {
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        [JsonConstructor]
        public IntegrationEvent(Guid id, DateTime createDate)
        {
            Id = id;
            CreationDate = createDate;
        }

        [JsonPropertyName("Id")]
        public Guid Id { get; private init; }

        [JsonPropertyName("CreationDate")]
        public DateTime CreationDate { get; private init; }
    }
}
