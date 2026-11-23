namespace Api.Contract;

public record GetUnionPathParameterRequest(Identifier Identifier);
public record GetUnionPathParameterResponse(string Message);