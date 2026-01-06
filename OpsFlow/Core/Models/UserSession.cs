namespace OpsFlow.Core.Models;

public static class UserSession
{
    public static User? CurrentUser { get; private set; }

    public static void StartSession(User user)
    {
        CurrentUser = user;
    }

    public static void ClearSession()
    {
        CurrentUser = null;
    }
}