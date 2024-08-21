namespace API.AppMetaData;

public static class Router
{
    #region Const Params
    public const string root = "Api";
    public const string version = "v1";
    public const string Rule = root + "/" + version + "/";
    public const string SignleRoute = "{id}";
    #endregion

    #region Ticket
    public static class Ticket
    {
        public const string Prefix = Rule + "Ticket/";

        public const string Search = Prefix + "Search";
        public const string GetById = Prefix + "GetByID" + "/" + SignleRoute;
        public const string Create = Prefix + "Create";
        public const string HandleTicket = Prefix + "HandleTicket";

    }

    #endregion
}
