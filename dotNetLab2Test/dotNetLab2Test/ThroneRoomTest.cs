using dotNetLab2.lab2.ru.nsu.brideApplication.model;
using dotNetLab2.lab2.ru.nsu.brideApplication.service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace dotNetLab2Test;

[TestClass]
public class ThroneRoomTest
{
    [TestMethod]
    public void ChooseHusband_husbandNotFound_AssertNull()
    {
        var mockHall = new Mock<Hall>();
        var mockPrincess = new Mock<Princess>();
        var contender = new Contender("", "", 50);

        mockHall.Setup(s => s.GetContendersCount()).Returns(1);
        mockHall.Setup(s => s.GetByIndex(0)).Returns(contender);
        mockPrincess.Setup(s => s.MakeDecision(contender)).Returns(false);

        var throneRoom = new ThroneRoom(mockPrincess.Object, mockHall.Object);

        var result = throneRoom.ChooseHusband();
        Assert.IsNull(result);
    }
    
    [TestMethod]
    public void ChooseHusband_husbandFound_AssertNotNull()
    {
        var mockHall = new Mock<Hall>();
        var mockPrincess = new Mock<Princess>();
        var contender = new Contender("", "", 50);

        mockHall.Setup(s => s.GetContendersCount()).Returns(1);
        mockHall.Setup(s => s.GetByIndex(0)).Returns(contender);
        mockPrincess.Setup(s => s.MakeDecision(contender)).Returns(true);

        var throneRoom = new ThroneRoom(mockPrincess.Object, mockHall.Object);

        var result = throneRoom.ChooseHusband();
        Assert.AreEqual(result, contender);
    }
}