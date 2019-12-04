using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTests.Tests.HelperClasses
{

    // This class help us to define lot of different test samples at the same time
    public class PersonTheoryData<T> : TheoryData<T>
    {
        public PersonTheoryData(IEnumerable<T> data)
        {
            foreach (var item in data)
            {
                Add(item);
            }

        }
    }
}
