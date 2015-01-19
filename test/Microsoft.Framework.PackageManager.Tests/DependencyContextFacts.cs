using System;
using Microsoft.Framework.PackageManager.Packing;
using Xunit;

namespace Microsoft.Framework.PackageManager.Packing.Tests
{
    public class DependencyContextFacts
    {
        [Theory]
        [InlineData("dotnet-clr-x86.1.0.0", "Asp.Net")]
        [InlineData("dotnet-clr-amd64.1.0.0", "Asp.Net")]
        [InlineData("dotnet-coreclr-x86.1.0.0", "Asp.NetCore")]
        [InlineData("dotnet-coreclr-amd64.1.0.0", "Asp.NetCore")]
        [InlineData("dotnet-mono.1.0.0", "Asp.Net")]  // Absence of architecture component is allowed for mono runtime
        [InlineData("dotnet-mono-x86.1.0.0", "Asp.Net")]
        [InlineData("dotnet-clr.1.0.0", null)]
        [InlineData("dotnet-coreclr-x86", null)]
        [InlineData("dotnet-mono", null)]
        [InlineData("dotnet", null)]
        public void GetCorrectFrameworkNameForRuntimes(string runtimeName, string frameworkIdentifier)
        {
            var frameworkName = DependencyContext.GetFrameworkNameForRuntime(runtimeName);

            Assert.Equal(frameworkIdentifier, frameworkName?.Identifier);
        }
    }
}