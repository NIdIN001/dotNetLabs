using dotNetLab2.lab2.ru.nsu.brideApplication.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dotNetLab2Test;

[TestClass]
public class FriendTest
{
    [TestMethod]
    public void AddFriendTest_addOneToList_expectSuccess()
    {
        var friend = new Friend();
        var wasWatched = friend.GetTotalWatchedCount();

        friend.AddWatched(new Contender("", "", 100));

        var result = friend.GetTotalWatchedCount();
        Assert.AreEqual(result, wasWatched + 1);
    }

    [TestMethod]
    public void GetCountTest_expectSuccess()
    {
        var friend = new Friend();
        friend.AddWatched(new Contender("", "", 100));
        friend.AddWatched(new Contender("", "", 100));
        friend.AddWatched(new Contender("", "", 100));

        var result = friend.GetTotalWatchedCount();

        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void ClearTest_clearWatchedList_expectSuccess()
    {
        var friend = new Friend();
        friend.AddWatched(new Contender("", "", 100));
        friend.AddWatched(new Contender("", "", 100));
        friend.AddWatched(new Contender("", "", 100));

        var result = friend.GetTotalWatchedCount();

        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void CompareTest_compareDifferent_expectMore()
    {
        var friend = new Friend();
        var moreAttractivenessContender = new Contender("", "", 100);
        var lessAttractivenessContender = new Contender("", "", 50);

        var result = friend.Compare(moreAttractivenessContender, lessAttractivenessContender);

        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void CompareTest_compareDifferent_expectLess()
    {
        var friend = new Friend();
        var moreAttractivenessContender = new Contender("", "", 100);
        var lessAttractivenessContender = new Contender("", "", 50);

        var result = friend.Compare(lessAttractivenessContender, moreAttractivenessContender);

        Assert.AreEqual(-1, result);
    }

    [TestMethod]
    public void CompareTest_compareEqual_expectEqual()
    {
        var friend = new Friend();
        var moreAttractivenessContender = new Contender("", "", 100);

        var result = friend.Compare(moreAttractivenessContender, moreAttractivenessContender);

        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void CompareTest_compareWithNull_expectedException()
    {
        var friend = new Friend();
        var moreAttractivenessContender = new Contender("", "", 100);

        Assert.ThrowsException<Exception>(() => friend.Compare(null, moreAttractivenessContender));
    }

    [TestMethod]
    public void CompareTest_compareNull_expectedException()
    {
        var friend = new Friend();
        var moreAttractivenessContender = new Contender("", "", 100);

        Assert.ThrowsException<Exception>(() => friend.Compare(moreAttractivenessContender, null));
    }

    [TestMethod]
    public void IsBetterThenAllViewed_assertTrueTest()
    {
        var friend = new Friend();
        var contender1 = new Contender("", "", 1);
        var contender2 = new Contender("", "", 2);
        var contender3 = new Contender("", "", 50);
        var contender4 = new Contender("", "", 77);

        friend.AddWatched(contender1);
        friend.AddWatched(contender2);
        friend.AddWatched(contender3);

        var result = friend.IsBetterThenAllViewed(contender4);
        Assert.IsTrue(result);
    }
    
    [TestMethod]
    public void IsBetterThenAllViewed_assertFalseTest()
    {
        var friend = new Friend();
        var contender1 = new Contender("", "", 1);
        var contender2 = new Contender("", "", 2);
        var contender3 = new Contender("", "", 50);
        var contender4 = new Contender("", "", 43);

        friend.AddWatched(contender1);
        friend.AddWatched(contender2);
        friend.AddWatched(contender3);

        var result = friend.IsBetterThenAllViewed(contender4);
        Assert.IsFalse(result);
    }
}