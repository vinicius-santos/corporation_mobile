using System;
using System.Collections.Generic;
using System.Text;

namespace CorporationMobile.Helpers
{
    class Annotations
    {
        [AttributeUsage(AttributeTargets.Method)]
        public sealed class NotifyPropertyChangedInvocatorAttribute : Attribute
        {
            public NotifyPropertyChangedInvocatorAttribute() { }
            public NotifyPropertyChangedInvocatorAttribute(string parameterName)
            {
                ParameterName = parameterName;
            }
            public string ParameterName { get; private set; }
        }
    }
}
