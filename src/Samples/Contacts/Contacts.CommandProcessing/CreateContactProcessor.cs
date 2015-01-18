using Contacts.Commands;
using Contacts.Events;
using SharpDomain.Commanding;

namespace Contacts.CommandProcessing
{
    public class CreateContactProcessor : 
        CommandToEventProcessor<CreateContact>
    {
        public override void Process(CreateContact command)
        {
            Emit<ContactCreated>(e => { e.Title = command.Title; });
        }
    }
}
