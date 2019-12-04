using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTests.SampleData
{
    public class Engine : IEngine
    {
        public double OilStatus { get; private set; }
        public bool IsOilOk()
        {
            throw new NotImplementedException();
        }
    }
}
