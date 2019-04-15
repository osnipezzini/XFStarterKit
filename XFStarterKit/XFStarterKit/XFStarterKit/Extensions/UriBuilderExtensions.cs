using System;
using System.IO;

namespace XFStarterKit.Core.Extensions
{
    public static class UriBuilderExtensions
    {
        internal static void AppendToPath(this UriBuilder builder, string pathToAdd)
        {
            var completePath = Path.Combine(builder.Path, pathToAdd);
            builder.Path = completePath;
        }
    }
}
