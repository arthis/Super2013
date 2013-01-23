namespace CommonDomain
{
    public interface ISecurityUser
    {
        IAction CreateAction<T>(IActionHandler handler, T cmd) where T:ICommand;
    }
}