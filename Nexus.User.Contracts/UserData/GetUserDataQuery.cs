using Nexus.Shared.Cqrs.Interfaces;

namespace Nexus.User.Contracts.UserData;

public class GetUserDataQuery: IQuery<GetUserDataQueryResult>
{
}

public class GetUserDataQueryResult: IQueryResult
{
}