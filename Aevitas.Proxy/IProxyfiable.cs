namespace Aevitas.Proxy
{
    internal interface IProxyfiable<out T>
    {
        T Run(params object[] args);
    }
}
