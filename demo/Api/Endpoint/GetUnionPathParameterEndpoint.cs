using Api.Contract;

namespace Api.Endpoint;

public class GetUnionPathParameterEndpoint
{
    public IValueHttpResult<GetUnionPathParameterResponse> Handle(GetUnionPathParameterRequest request)
    {
        var message = request.Identifier switch
        {
            int => $"Integer identifier: {request.Identifier}",
            string => $"String identifier: {request.Identifier}",
            Guid => $"Guid identifier: {request.Identifier}"
        };
    
        return TypedResults.Ok(new GetUnionPathParameterResponse(message));
    }
}