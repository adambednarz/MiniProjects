using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTests.SampleData
{
    public interface IEngine
    {
        double OilStatus { get; }

        bool IsOilOk();
    }
}
