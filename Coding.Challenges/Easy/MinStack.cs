namespace Coding.Challenges.Easy;

/*
 * Difficulty: Easy
 * Problem:
 *  You need to modify the design of the stack data structure such that it supports push() , pop() , top() and getMin() operations in constant time( O(1) ).
 *  Note:
 *      top() gets the top element
 *      getMin() returns the minimum element in the stack
 *      push(elem) pushes an element elem in the stack
 *      pop() removes the top element
 *      It is guaranteed that input is consistent, i.e., only push() will be called if the stack is supposed to be empty
 *      The input provided in this case would be a series of function calls to push() , pop() , top() and getMin()
 */
public class MinStack
{
    private readonly Stack<int> _stack = new();
    private readonly Stack<int> _minStack = new();

    public void Push(int elem)
    {
        _stack.Push(elem);
        if (_minStack.Count == 0 || elem <= _minStack.Peek())
            _minStack.Push(elem);
    }

    public void Pop()
    {
        if (_stack.Count == 0)
            return;

        if (_stack.Peek() == _minStack.Peek())
            _minStack.Pop();
        _stack.Pop();
    }

    public int Top()
    {
        return _stack.Count == 0 ? -1 : _stack.Peek();
    }

    public int GetMin()
    {
        return _minStack.Count == 0 ? -1 : _minStack.Peek();
    }
}