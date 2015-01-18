using System;
using Microsoft.Framework.PackageManager.Packing;
using Xunit;

namespace Microsoft.Framework.PackageManager.Packing.Tests
{
    public class DependencyContextFacts
    {
        [Theory]
        [InlineData("DOTNET-CLR-x86.1.0.0", "Asp.Net")]
        [InlineData("DOTNET-CLR-amd64.1.0.0", "Asp.Net")]
        [InlineData("DOTNET-CoreCLR-x86.1.0.0", "Asp.NetCore")]
        [InlineData("DOTNET-CoreCLR-amd64.1.0.0", "Asp.NetCore")]
        [InlineData("DOTNET-Mono.1.0.0", "Asp.Net")]  // Absence of architecture component is allowed for Mono KRE
        [InlineData("DOTNET-Mono-x86.1.0.0", "Asp.Net")]
        [InlineData("DOTNET-CLR.1.0.0", null)]
        [InlineData("DOTNET-CoreCLR-x86", null)]
        [InlineData("DOTNET-Mono", null)]
        [InlineData("DOTNET", null)]
        public void GetCorrectFrameworkNameForKREs(string runtimeName, string frameworkIdentifier)
        {
            var frameworkName = DependencyContext.GetFrameworkNameForRuntime(runtimeName);

            Assert.Equal(frameworkIdentifier, frameworkName?.Identifier);
        }
    }
}