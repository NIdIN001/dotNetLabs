using dotNetLab2.lab2.ru.nsu.brideApplication.configuration;
using dotNetLab2.lab2.ru.nsu.brideApplication.service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dotNetLab2Test;

[TestClass]
public class ContenderGeneratorServiceTest
{
    [TestMethod]
    public void GenerateContenderTest()
    {
        var config = new ContenderConfiguration();
        config.ContendersCount = 100;
        config.Firstname = "/Users/stanislavutockin/Documents/reports/firstname";
        config.Lastname = "/Users/stanislavutockin/Documents/reports/lastname";
        var contenderGeneratorService = new ContenderGeneratorService(new ContenderConfiguration());
        contenderGeneratorService.FillPossibleAttractiveness();

        var result = contenderGeneratorService.GenerateContender();

        Assert.IsNotNull(result);
    }
}