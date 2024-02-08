namespace Coding.Challenges.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class MinStackTests
{
    [Test]
    public void Push_SingleElement_ReturnsTopElement()
    {
        var minStack = new MinStack();
        minStack.Push(3);
        Assert.AreEqual(3, minStack.Top());
    }

    [Test]
    public void Push_SingleElement_ReturnsMinElement()
    {
        var minStack = new MinStack();
        minStack.Push(3);
        Assert.AreEqual(3, minStack.GetMin());
    }

    [Test]
    public void Pop_AfterPushingSingleElement_ReturnsNegativeOneForTop()
    {
        var minStack = new MinStack();
        minStack.Push(3);
        minStack.Pop();
        Assert.AreEqual(-1, minStack.Top());
    }

    [Test]
    public void Pop_AfterPushingSingleElement_ReturnsNegativeOneForMin()
    {
        var minStack = new MinStack();
        minStack.Push(3);
        minStack.Pop();
        Assert.AreEqual(-1, minStack.GetMin());
    }

    [Test]
    public void PushMultiple_ReturnsTopAndMinCorrectly()
    {
        var minStack = new MinStack();
        minStack.Push(3);
        minStack.Push(5);
        minStack.Push(2);

        Assert.Multiple(() =>
        {
            Assert.AreEqual(2, minStack.Top());
            Assert.AreEqual(2, minStack.GetMin());
        });
    }
}