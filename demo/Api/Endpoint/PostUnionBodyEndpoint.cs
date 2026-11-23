using Api.Contract;

namespace Api.Endpoint;

public class PostUnionBodyEndpoint
{
    public IValueHttpResult<PostUnionBodyResponse> Handle(PostUnionBodyRequest request)
    {
        return request.Body switch
        {
            Apple apple => TypedResults.Ok(new PostUnionBodyResponse(new PostUnionBodyAppleResponse(request.Identifier, apple))),
            Pear pear => TypedResults.Ok(new PostUnionBodyResponse(new PostUnionBodyPearResponse(request.Identifier, pear)))
        };
    }
}