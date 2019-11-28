using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAttributes.Attributes
{
    [AttributeUsage(AttributeTargets.Class | 
                    AttributeTargets.Method |
                    AttributeTargets.Constructor|
                    AttributeTargets.Property, 
                    AllowMultiple = true, 
                    Inherited = false)]
    public class DebugInfo : Attribute
    {
        public int CodeNumber { get; private set; }
        public string DeveloperName { get; private  set; }
        public string LastReviewData { get; private set; }
        public string Message { get; set; }

        public DebugInfo(int code, string developerName, string lastReviewData)
        {
            CodeNumber = code;
            DeveloperName = developerName;
            LastReviewData = lastReviewData;
        }
    }
}
