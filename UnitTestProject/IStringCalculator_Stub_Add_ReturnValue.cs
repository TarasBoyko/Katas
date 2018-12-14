using Kata1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    // A stub class for "IStringCalculator".
    // "Add" method of the class returns defined in the ctor call value.
    class IStringCalculator_Stub_Add_ReturnValue : IStringCalculator
    {
        // Initialize "StringCalculator_Stub" object.
        // @Add_return specified assing value for field "m_Add_return".
        public IStringCalculator_Stub_Add_ReturnValue(int Add_return)
        {
            m_Add_return = Add_return;
        }

        // Always returns field "m_Add_return"
        // @inputString specifies fake parameter of the method.
        public int Add(string inputString)
        {
            return m_Add_return;
        }

        protected readonly int m_Add_return; // a value, that "Add" always returns
    }
}
