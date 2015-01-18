using Contacts.Commands;
using Contacts.Events;
using SharpDomain.Commanding;
using SharpDomain.EventSourcing;
using SharpDomain.IoC;

namespace Contacts.CommandProcessing
{
    public class UpdateContactCodeProcessor :
        CommandToEventProcessor<UpdateContactCode>,
        IRequire<UpdateContactCodeProcessor.ContactWithCode>
    {
        public override void Process(UpdateContactCode command)
        {
            if (Contact.Code != command.Code)
                Emit<ContactCodeUpdated>(e => { e.Code = command.Code; });
        }

        public ContactWithCode Contact { get; set; }

        public class ContactWithCode : EventSourced
        {
            public string Code { get; private set; }

            private void Apply(ContactCodeUpdated e)
            {
                Code = e.Code;
            }
        }
    }
}