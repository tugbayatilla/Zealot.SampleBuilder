using Zealot.Interfaces;

namespace Zealot.Withs;

internal class WithString : IWithString
{
    public string Prefix { get; set; } = string.Empty;
    public string Suffix { get; set; } = string.Empty;
}
