using SharpDomain.EventSourcing;

namespace Contacts.Events
{
    public class ContactTitleUpdated : EntityEvent
    {
        public string Title { get; set; }
    }
}