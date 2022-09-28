using dotNetLab2.lab2.ru.nsu.brideApplication.util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dotNetLab2Test;

[TestClass]
public class ContenderNameProviderTest
{
    [TestMethod]
    public void GetEqualName()
    {
        var provider = new ContenderNameProvider(
            "/Users/stanislavutockin/Documents/reports/firstname",
            "/Users/stanislavutockin/Documents/reports/lastname");

        var names = new HashSet<string>();
        for (int i = 0; i < 50; i++)
        {
            names.Add(provider.GetName() + " " + provider.GetSurname());
        }

        Assert.AreEqual(50, names.Count);
    }
}