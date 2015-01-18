using SharpDomain.Commanding;

namespace Contacts.Commands
{
    public class UpdateContactCode : EntityCommand
    {
        public string Code { get; set; }
    }
}