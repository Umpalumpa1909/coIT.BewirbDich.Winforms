using System.Reflection;

namespace coIT.BewirbDich.Winforms.Infrastructure;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}