using System;
using Transverse._Common.Exceptions;

namespace Transverse._Common.String;

public static class StringExtension
{
    public static string EndsWith_(this string string_, bool mustEndWith, string end)
    {
        var retour = string_;
        var endsWith = string_.EndsWith(end);

        if (!endsWith && mustEndWith)
        {
            retour += end;
        }

        else if (endsWith && !mustEndWith)
        {
            retour = retour.AsSpan(0, retour.Length - end.Length).ToString();
        }

        return (retour);
    }

    public static string StartsWith_(this string string_, bool mustStartWith, string start)
    {
        var retour = string_;
        var startsWith = string_.StartsWith(start);

        if (!startsWith && mustStartWith)
        {
            retour = start + retour;
        }

        else if (startsWith && !mustStartWith)
        {
            retour = retour.AsSpan(start.Length).ToString();
        }

        return (retour);
    }

    public static string Substring_(this string string_, int startIndex, int substringLength)
    {
        string retour = string.Empty;

        if (startIndex < 0)
        {
            throw new InvalidNegativeIndexException(startIndex);
        }

        if (startIndex < string_.Length)
        {
            if (startIndex+substringLength > string_.Length) 
            {
                substringLength = string_.Length - startIndex;
            }
            retour = string_.AsSpan(startIndex, substringLength).ToString();
        }

        return (retour);
    }
    public static string Substring_(this string string_, int startIndex)
    {
        if (startIndex < 0)
        {
            throw new InvalidNegativeIndexException(startIndex);
        }
        var retour = (startIndex >= string_.Length) ? string.Empty : string_.AsSpan(startIndex).ToString();
        return (retour);
    }
}