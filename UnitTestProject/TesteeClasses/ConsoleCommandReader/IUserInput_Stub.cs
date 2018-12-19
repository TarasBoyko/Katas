using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata1
{
    class IUserInput_Stub : IUserInput
    {
        public IUserInput_Stub(List<string> ReadLineReturns)
        {
            m_ReadLineReturns = ReadLineReturns;
            m_numberOfDoneUsersInputs = 0;
        }
        public string ReadLine()
        {
            Debug.Assert(m_numberOfDoneUsersInputs < m_ReadLineReturns.Count);
            return m_ReadLineReturns[m_numberOfDoneUsersInputs++];
        }

        protected List<string> m_ReadLineReturns;
        protected int m_numberOfDoneUsersInputs;
    }
}
