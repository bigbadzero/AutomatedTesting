using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKata.ConsoleApp;

namespace ZombieSurvivorKata.Tests.Mocks
{
    public class MockIUserInput
    {
        public static Mock<IUserInput> GetMockUserInput()
        {
            var mockUserInput = new Mock<IUserInput>();
            mockUserInput.Setup(r => r.GetIntFromUser()).Returns(1);
            mockUserInput.Setup(r => r.GetIntFromUserWithRange(0, 4)).Returns(3);
            return mockUserInput;
        }
    }
}
