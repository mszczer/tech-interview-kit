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
    private readonly List<int> _minArray;
    private readonly List<int> _stack;

    public MinStack()
    {
        _stack = new List<int>();
        _minArray = new List<int>();
    }

    // push(elem) pushes an element elem in the stack
    public void Push(int elem)
    {
        if (_minArray.Count == 0 || elem <= _minArray[^1])
            _minArray.Add(elem);

        _stack.Add(elem);
    }

    // pop() removes the top element
    public void Pop()
    {
        if (_stack.Count > 0)
        {
            if (_stack[^1] == _minArray[^1])
                _minArray.RemoveAt(_minArray.Count - 1);
            _stack.RemoveAt(_stack.Count - 1);
        }
    }

    // top() gets the top element
    public int Top()
    {
        return _stack.Count > 0 ? _stack[^1] : -1;
    }

    // getMin() returns the minimum element in the stack
    public int GetMin()
    {
        return _minArray.Count > 0 ? _minArray[^1] : -1;
    }
}