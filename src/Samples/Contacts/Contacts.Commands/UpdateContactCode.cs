using SharpDomain.Commanding;

namespace Contacts.Commands
{
    public class UpdateContactCode : EntityCreationCommand
    {
        public string Code { get; set; }
    }
}