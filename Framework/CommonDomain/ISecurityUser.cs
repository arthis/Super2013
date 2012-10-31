namespace CommonDomain
{
    public interface ISecurityUser
    {
        IAction CreateAction(IActionFactory factory, ICommand cmd);
    }
}