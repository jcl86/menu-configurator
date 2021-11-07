namespace MenuConfigurator.Domain
{
    public interface IUser
    {
        string Id { get; }
        string UserName { get; }
        bool EmailConfirmed { get; }
    }

}
