namespace SharpDomain.Models
{
    public class InitContext : SoftwareDefinitionElement
    {
        private readonly SoftwareDefinition _root;

        public SoftwareDefinition Root
        {
            get { return _root; }
        }

        public InitContext(SoftwareDefinition root)
        {
            _root = root;
        }
    }
}