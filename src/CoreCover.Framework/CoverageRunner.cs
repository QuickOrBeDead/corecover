// MIT License
// Copyright (c) 2017 Paulo Gomes (https://pjbgf.mit-license.org/)

using System;
using CoreCover.Framework.Abstractions;
using CoreCover.Framework.Model;
using File = OpenCover.Framework.Model.File;

namespace CoreCover.Framework
{
    public class CoverageRunner : ICoverageRunner
    {
        private readonly ITestsRunner _testRunner;
        private readonly IAssemblyIterator _instrumentator;
        private readonly ICoverageReport _coverageReport;

        public CoverageRunner(IAssemblyIterator instrumentator, ITestsRunner testRunner, ICoverageReport coverageReport)
        {
            _instrumentator = instrumentator;
            _testRunner = testRunner;
            _coverageReport = coverageReport;
        }

        public void Run(string testProjectOutputPath, string reportPath)
        {
            if (String.IsNullOrEmpty(reportPath))
                reportPath = "coverage.xml";

            var coverageContext = new CoverageContext();
            _instrumentator.ProcessAssembliesInFolder(coverageContext, testProjectOutputPath);
            _testRunner.Run(coverageContext, testProjectOutputPath);
            _coverageReport.Export(coverageContext, reportPath);
        }
    }
}