using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Api.Contract;

public class FruitClassifierFactory : JsonTypeClassifierFactory
{
    public override bool CanClassify(JsonTypeClassifierContext context)
    {
        return context.UnionCases.Any(t => t.CaseType == typeof(Apple) || t.CaseType == typeof(Pear));
    }

    public override JsonTypeClassifier CreateJsonClassifier(JsonTypeClassifierContext context, JsonSerializerOptions options)
    {
        return FruitClassifier;
    }

    private Type? FruitClassifier(ref Utf8JsonReader reader)
    {
        var jsonNode = JsonNode.Parse(ref reader);
        if (jsonNode is not JsonObject jsonObject) throw new InvalidOperationException("reader is not a json object");
        
        var cultivarString = jsonObject["cultivar"]?.GetValue<string>();
        if (Enum.GetNames<AppleCultivar>().Any(c => c == cultivarString))
        {
            return typeof(Apple);
        }

        if (Enum.GetNames<PearCultivar>().Any(c => c == cultivarString))
        {
            return typeof(Pear);
        }
        
        throw new InvalidOperationException($"Cultivar {cultivarString} is not a valid apple nor pear cultivar");
    }
}
