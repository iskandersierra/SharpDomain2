using SharpDomain.EventSourcing;

namespace Contacts.Events
{
    public class ContactCreated : EntityCreationEvent
    {
        public string Title { get; set; }
    }
}
