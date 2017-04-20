﻿using OpenCover.Framework.Model;

namespace CoreCover.Framework
{
    public interface ICoverageReport
    {
        void Export(CoverageSession coverageSession, string reportPath);
    }
}