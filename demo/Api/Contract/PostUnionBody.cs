namespace Api.Contract;

public enum AppleCultivar { GrannySmith, PinkLady, Løeple };
public enum PearCultivar { IberianPear, EuropeanPear, PlymouthPear };

public record Apple(string AppleDescription, AppleCultivar Cultivar);
public record Pear(string PearDescription, PearCultivar Cultivar);

//[JsonUnion(TypeClassifier = typeof(JsonUnionTypeStructuralClassifier))]
//[JsonUnion(TypeClassifier = typeof(FruitClassifierFactory))]
public union PostUnionBody(Apple, Pear);

public record PostUnionBodyRequest(Identifier Identifier, PostUnionBody Body);

public record PostUnionBodyAppleResponse(Identifier Identifier, Apple Apple);
public record PostUnionBodyPearResponse(Identifier Identifier, Pear Pear);
public union PostUnionBodyResponse(PostUnionBodyAppleResponse, PostUnionBodyPearResponse);


