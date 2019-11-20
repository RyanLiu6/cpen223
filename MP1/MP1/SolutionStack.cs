// MP1: HTML Validator
// Implementation of a simple stack for HtmlTags.

// You should implement this class.
// You should add comments and improve the documentation.

using System;
using System.Collections.Generic;

namespace HtmlValidator
{
    public class MyStack
    {
        // A List to hold HtmlTag objects.
        // Use this to implement a stack.
        private List<HtmlTag> stack_internal;

        /// <summary>
        /// Create an empty stack.
        /// </summary>
        public MyStack()
        {
            this.stack_internal = new List<HtmlTag>();
        }

        /// <summary>
        /// Push a tag onto the top of the stack.
        /// </summary>
        public void Push(HtmlTag tag)
        {
            this.stack_internal.Add(tag);
        }

        /// <summary>
        /// Removes the tag at the top of the stack.
        /// Should throw an exception if the stack is empty.
        /// </summary>
        public HtmlTag Pop()
        {
            HtmlTag ret_val = this.Peek();

            int index = this.stack_internal.Count - 1;

            this.stack_internal.RemoveAt(index);

            return ret_val;
        }


        /// <summary>
        /// Looks at the HtmlTag at the top of the stack but does
        /// not actually remove the tag from the stack.
        /// Should throw an exception if the stack is empty.
        /// Returns the HtmlTag at the top of the stack.
        /// </summary>
        public HtmlTag Peek()
        {
            if (this.IsEmpty())
            {
                throw new ArgumentException("Stack is empty");
            }

            return this.stack_internal[this.stack_internal.Count - 1];
        }

        /// <summary>
        /// Tests if the stack is empty.
        /// Returns true if the stack is empty; false otherwise.
        /// </summary>
        public bool IsEmpty()
        {
            return this.stack_internal.Count == 0;
        }
    }
}
