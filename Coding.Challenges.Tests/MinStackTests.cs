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
        Assert.That(minStack.Top(), Is.EqualTo(3));
    }

    [Test]
    public void Push_SingleElement_ReturnsMinElement()
    {
        var minStack = new MinStack();
        minStack.Push(3);
        Assert.That(minStack.GetMin(), Is.EqualTo(3));
    }

    [Test]
    public void Pop_AfterPushingSingleElement_ReturnsNegativeOneForTop()
    {
        var minStack = new MinStack();
        minStack.Push(3);
        minStack.Pop();
        Assert.That(minStack.Top(), Is.EqualTo(-1));
    }

    [Test]
        public void Pop_AfterPushingSingleElement_ReturnsNegativeOneForMin()
    {
        var minStack = new MinStack();
        minStack.Push(3);
        minStack.Pop();
        Assert.That(minStack.GetMin(), Is.EqualTo(-1));
    }

    [Test]
    public void PushMultiple_TopIsCorrect()
    {
        var minStack = new MinStack();
        minStack.Push(3);
        minStack.Push(5);
        minStack.Push(2);
        Assert.That(minStack.Top(), Is.EqualTo(2));
    }

    [Test]
    public void PushMultiple_MinIsCorrect()
    {
        var minStack = new MinStack();
        minStack.Push(3);
        minStack.Push(5);
        minStack.Push(2);
        Assert.That(minStack.GetMin(), Is.EqualTo(2));
    }

    [Test]
    public void Pop_OnEmptyStack_DoesNotThrow()
    {
        var minStack = new MinStack();
        Assert.DoesNotThrow(() => minStack.Pop());
    }

    [Test]
    public void Top_OnEmptyStack_AfterPop_ReturnsNegativeOne()
    {
        var minStack = new MinStack();
        minStack.Pop();
        Assert.That(minStack.Top(), Is.EqualTo(-1));
    }

    [Test]
    public void GetMin_OnEmptyStack_AfterPop_ReturnsNegativeOne()
    {
        var minStack = new MinStack();
        minStack.Pop();
        Assert.That(minStack.GetMin(), Is.EqualTo(-1));
    }

    [Test]
    public void Push_DuplicateMinimums_PopOne_MinRemains()
    {
        var minStack = new MinStack();
        minStack.Push(2);
        minStack.Push(2);
        minStack.Pop();
        Assert.That(minStack.GetMin(), Is.EqualTo(2));
    }

    [Test]
    public void Push_DecreasingSequence_MinIsCorrectAfterPush3()
    {
        var minStack = new MinStack();
        minStack.Push(5);
        minStack.Push(4);
        minStack.Push(3);
        Assert.That(minStack.GetMin(), Is.EqualTo(3));
    }

    [Test]
    public void Push_DecreasingSequence_MinIsCorrectAfterPop3()
    {
        var minStack = new MinStack();
        minStack.Push(5);
        minStack.Push(4);
        minStack.Push(3);
        minStack.Pop();
        Assert.That(minStack.GetMin(), Is.EqualTo(4));
    }

    [Test]
    public void Push_DecreasingSequence_MinIsCorrectAfterPop4()
    {
        var minStack = new MinStack();
        minStack.Push(5);
        minStack.Push(4);
        minStack.Push(3);
        minStack.Pop();
        minStack.Pop();
        Assert.That(minStack.GetMin(), Is.EqualTo(5));
    }

    [Test]
    public void Push_IncreasingSequence_MinIsCorrectAfterPush3()
    {
        var minStack = new MinStack();
        minStack.Push(1);
        minStack.Push(2);
        minStack.Push(3);
        Assert.That(minStack.GetMin(), Is.EqualTo(1));
    }

    [Test]
    public void Push_IncreasingSequence_MinIsCorrectAfterPop3()
    {
        var minStack = new MinStack();
        minStack.Push(1);
        minStack.Push(2);
        minStack.Push(3);
        minStack.Pop();
        Assert.That(minStack.GetMin(), Is.EqualTo(1));
    }

    [Test]
    public void Push_IncreasingSequence_MinIsCorrectAfterPop2()
    {
        var minStack = new MinStack();
        minStack.Push(1);
        minStack.Push(2);
        minStack.Push(3);
        minStack.Pop();
        minStack.Pop();
        Assert.That(minStack.GetMin(), Is.EqualTo(1));
    }
}