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

    [Test]
    public void Pop_OnEmptyStack_DoesNotThrow()
    {
        var minStack = new MinStack();
        Assert.DoesNotThrow(() => minStack.Pop());
        Assert.AreEqual(-1, minStack.Top());
        Assert.AreEqual(-1, minStack.GetMin());
    }

    [Test]
    public void Top_OnEmptyStack_ReturnsNegativeOne()
    {
        var minStack = new MinStack();
        Assert.AreEqual(-1, minStack.Top());
    }

    [Test]
    public void GetMin_OnEmptyStack_ReturnsNegativeOne()
    {
        var minStack = new MinStack();
        Assert.AreEqual(-1, minStack.GetMin());
    }

    [Test]
    public void Push_DuplicateMinimums_PopOne_MinRemains()
    {
        var minStack = new MinStack();
        minStack.Push(2);
        minStack.Push(2);
        minStack.Pop();
        Assert.AreEqual(2, minStack.GetMin());
    }

    [Test]
    public void Push_DecreasingSequence_MinUpdatesCorrectly()
    {
        var minStack = new MinStack();
        minStack.Push(5);
        minStack.Push(4);
        minStack.Push(3);
        Assert.AreEqual(3, minStack.GetMin());
        minStack.Pop();
        Assert.AreEqual(4, minStack.GetMin());
        minStack.Pop();
        Assert.AreEqual(5, minStack.GetMin());
    }

    [Test]
    public void Push_IncreasingSequence_MinRemainsFirst()
    {
        var minStack = new MinStack();
        minStack.Push(1);
        minStack.Push(2);
        minStack.Push(3);
        Assert.AreEqual(1, minStack.GetMin());
        minStack.Pop();
        Assert.AreEqual(1, minStack.GetMin());
        minStack.Pop();
        Assert.AreEqual(1, minStack.GetMin());
    }
}