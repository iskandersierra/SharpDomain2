using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDomain.EventSourcing;

namespace Contacts.Events
{
    public class ContactCreated : EntityCreationEvent
    {
        public string Title { get; set; }
    }

    public class ContactUpdated : EntityEvent
    {
        public string Title { get; set; }
    }
}
