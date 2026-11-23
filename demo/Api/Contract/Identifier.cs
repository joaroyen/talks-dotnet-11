using System.Diagnostics.CodeAnalysis;

namespace Api.Contract;

public union Identifier(int, string, Guid) : IParsable<Identifier>
{
    public override string? ToString() => Value.ToString();
    public static Identifier Parse(string s, IFormatProvider? provider)
    {
        if (int.TryParse(s, provider, out var intIdentifier))
        {
            return new Identifier(intIdentifier);
        }
        
        if (Guid.TryParse(s, provider, out var guidIdentifier))
        {
            return new Identifier(guidIdentifier);
        }

        return s;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out Identifier result)
    {
        if (s == null)
        {
            result = default;
            return false;
        }
        
        try
        {
            result = Parse(s, provider);
            return true;
        }
        catch (Exception)
        {
            result = default;
            return false;
        }
    }
}