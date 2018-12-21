using Kata1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.TesteeClasses.ConsoleCommandReader
{
    // A mock class for "IOutputStringCalculator".

    class IOutputStringCalculator_Mock : IOutputStringCalculator
    {
        // Initializes "IOutputStringCalculator_Stub" object.
        // @Add_return specified assing value for field "m_Add_returns".
        public IOutputStringCalculator_Mock(int Add_return) : this(new List<int> { Add_return })
        {
            ;   
        }

        // Initializes "IOutputStringCalculator_Stub" object.
        // @Add_returns specified assing value for field "m_Add_returns".
        public IOutputStringCalculator_Mock(List<int> Add_returns)
        {
            m_Add_returns = Add_returns;
            m_numberOfAddCalls = 0;
        }

        // Does mock actions and returns next element of field "m_Add_return"
        // @inputString specifies fake parameter of the method.
        public int Add(string inputString)
        {
            Debug.Assert(m_numberOfAddCalls < m_Add_returns.Count);
            Console.WriteLine("The result is " + m_Add_returns[m_numberOfAddCalls]);
            new CalculationResultLogger_Mock_NormalWrite("OutputStringCalculator_logs.txt").Write(m_Add_returns[m_numberOfAddCalls].ToString());
            return m_Add_returns[m_numberOfAddCalls++];
        }

        protected int m_numberOfAddCalls; // number of done calls of "Add" method of this class
        protected List<int> m_Add_returns; // contains elements for concrete call of "Add" method of this class
    }
}
