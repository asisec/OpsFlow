using OpsFlow.Core.Models;

namespace OpsFlow.Core.Session;

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