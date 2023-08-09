namespace NullRefereceExceptionAtGetSymbolInfo;

public class Class1
{
    void Method()
    {
        var x = Enumerable.Empty<int>().MySelect((v, i) => i);
    }
}

file static class ImmutableArrayExtensionsClass1
{
    internal static IEnumerable<U> MySelect<T, U>(this IEnumerable<T> @this, Func<T, int, U> selector)
    {
        return Enumerable.Empty<U>();
    }
}
