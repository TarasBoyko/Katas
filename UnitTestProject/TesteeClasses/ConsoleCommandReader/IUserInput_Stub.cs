using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata1
{
    // A stub class for "IUserInput".
    class IUserInput_Stub : IUserInput
    {
        // Initializes "IUserInput_Stub" object.
        // @ReadLine_Returns assigns value for field "m_ReadLine_Returns".
        public IUserInput_Stub(List<string> ReadLine_Returns)
        {
            m_ReadLine_Returns = ReadLine_Returns;
            m_numberOfDoneUsersInputs = 0;
        }

        // Returns next element of field "m_Add_return"
        public string ReadLine()
        {
            Debug.Assert(m_numberOfDoneUsersInputs < m_ReadLine_Returns.Count);
            return m_ReadLine_Returns[m_numberOfDoneUsersInputs++];
        }

        protected List<string> m_ReadLine_Returns; // contains elements for concrete call of "ReadLine" method of this class
        protected int m_numberOfDoneUsersInputs;
    }
}
