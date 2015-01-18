using Contacts.Commands;
using Contacts.Events;
using SharpDomain.Commanding;
using SharpDomain.EventSourcing;
using SharpDomain.IoC;

namespace Contacts.CommandProcessing
{
    public class UpdateContactTitleProcessor :
        CommandToEventProcessor<UpdateContactTitle>,
        IRequire<UpdateContactTitleProcessor.ContactWithTitle>
    {
        public override void Process(UpdateContactTitle command)
        {
            if (Contact.Title != command.Title)
                Emit<ContactTitleUpdated>(e => { e.Title = command.Title; });
        }

        public ContactWithTitle Contact { get; set; }

        public class ContactWithTitle : EventSourced
        {
            public string Title { get; private set; }

            private void Apply(ContactCreated e)
            {
                Title = e.Title;
            }

            private void Apply(ContactTitleUpdated e)
            {
                Title = e.Title;
            }
        }

    }
}