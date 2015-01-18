namespace SharpDomain.Utils
{
    /// <summary>
    /// User the type of instance and parameter to cache a method invocation like:
    /// instance.Apply(parameter)
    /// </summary>
    public interface IAutoInvoker
    {
        object Invoke(object instance, object parameter);
    }
}