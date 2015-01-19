// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.IO;
using Microsoft.Framework.FunctionalTestUtils;

namespace Microsoft.Framework.PackageManager
{
    public class KpmTestEnvironment : IDisposable
    {
        private readonly string _projectName;
        private readonly string _outputDirName;
        private readonly string _dotnetPath;

        public KpmTestEnvironment(string dotnetPath, string projectName = null, string outputDirName = null)
        {
            _projectName = projectName ?? "ProjectName";
            _outputDirName = outputDirName ?? "OutputDirName";
            _dotnetPath = dotnetPath;
            RootDir = TestUtils.CreateTempDir();
        }

        public string RootDir { get; private set; }

        public string ProjectName
        {
            get
            {
                return _projectName;
            }
        }

        public string ProjectPath
        {
            get
            {
                return Path.Combine(RootDir, ProjectName);
            }
        }

        public string PackOutputDirName
        {
            get
            {
                return _outputDirName;
            }
        }

        public string PackOutputDirPath
        {
            get
            {
                return Path.Combine(RootDir, PackOutputDirName);
            }
        }

        public void Dispose()
        {
            TestUtils.DeleteFolder(RootDir);

            if (!string.IsNullOrEmpty(_dotnetPath))
            {
                TestUtils.DeleteFolder(_dotnetPath);
            }
        }
    }
}
