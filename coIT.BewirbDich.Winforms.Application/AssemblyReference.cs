using System.Reflection;

namespace coIT.BewirbDich.Application;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}