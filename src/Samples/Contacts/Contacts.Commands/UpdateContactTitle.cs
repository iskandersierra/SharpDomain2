using SharpDomain.Commanding;

namespace Contacts.Commands
{
    public class UpdateContactTitle : EntityCreationCommand
    {
        public string Title { get; set; }
    }
}
