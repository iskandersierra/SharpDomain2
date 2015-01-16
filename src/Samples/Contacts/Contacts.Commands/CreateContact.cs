using SharpDomain.Commanding;

namespace Contacts.Commands
{
    public class CreateContact : EntityCreationCommand
    {
        public string Title { get; set; }
    }
}