using SharpDomain.EventSourcing;

namespace Contacts.Events
{
    public class ContactCodeUpdated : EntityEvent
    {
        public string Code { get; set; }
    }
}