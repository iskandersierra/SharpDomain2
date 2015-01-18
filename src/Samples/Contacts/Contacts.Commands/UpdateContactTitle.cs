using SharpDomain.Commanding;

namespace Contacts.Commands
{
    public class UpdateContactTitle : EntityCommand
    {
        public string Title { get; set; }
    }
}
