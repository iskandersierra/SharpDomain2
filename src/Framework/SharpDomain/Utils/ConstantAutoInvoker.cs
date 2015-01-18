namespace SharpDomain.Utils
{
    public class ConstantAutoInvoker : IAutoInvoker
    {
        public ConstantAutoInvoker()
        {
        }

        public ConstantAutoInvoker(object constant)
        {
            Constant = constant;
        }

        public object Invoke(object instance, object parameter)
        {
            return Constant;
        }

        public object Constant { get; set; }
    }
}