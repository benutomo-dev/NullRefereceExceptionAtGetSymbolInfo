namespace NullRefereceExceptionAtGetSymbolInfo;

public class Class2
{
    void Method()
    {
        var x = Enumerable.Empty<int>().MySelect(v => v);
    }
}

file static class ImmutableArrayExtensionsClass2
{
    internal static IEnumerable<U> MySelect<T, U>(this IEnumerable<T> @this, Func<T, U> selector)
    {
        return Enumerable.Empty<U>();
    }
}
