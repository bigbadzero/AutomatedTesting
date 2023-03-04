using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.UI;

namespace ZombieZurvivorKatana.Tests.Mocks
{
    public class IUserInputMock
    {
        public static Mock<IUserInput> GetBaseMockUserInput()
        {
            var mockUserInput = new Mock<IUserInput>();
            mockUserInput.Setup(r => r.GetIntFromUser()).Returns(1).Verifiable();
            mockUserInput.Setup(r => r.GetIntFromUserWithRange(0, 4)).Returns(3).Verifiable();
            mockUserInput.Setup(r => r.GetIntFromUserWithRange(0, 1)).Returns(1).Verifiable();
            mockUserInput.Setup(r => r.Proceed()).Returns(true).Verifiable();    
            return mockUserInput;
        }

        public static Mock<IUserInput> GetGameMockUserInput()
        {

            var mockUserInput = new Mock<IUserInput>();
            mockUserInput.Setup(r => r.GetIntFromUser()).Returns(1);
            mockUserInput.Setup(r => r.GetNameFromUser()).Returns("Adam");
            return mockUserInput;
        }
    }
}
