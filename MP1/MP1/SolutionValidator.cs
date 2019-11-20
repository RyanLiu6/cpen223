// MP1: HTML Validator
// Implementation of the HtmlValidator class.

// You should implement this class.
// You should add comments and improve the documentation.

using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlValidator
{
    public class HtmlValidator
    {
        Queue<HtmlTag> queue;
        readonly string space = "   ";

        public HtmlValidator()
        {
            this.queue = new Queue<HtmlTag>();
        }

        public HtmlValidator(Queue<HtmlTag> tags)
        {
            if (tags == null)
            {
                throw new ArgumentException("Input tags are null");
            }

            this.queue = new Queue<HtmlTag>(tags);
        }

        public void AddTag(HtmlTag tag)
        {
            if (tag == null)
            {
                throw new ArgumentException("Input tag is null");
            }

            this.queue.Enqueue(tag);
        }

        public string GetTags()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("front [ ");
            foreach(HtmlTag x in this.queue)
            {
                sb.Append(x.ToString());
                sb.Append(", ");
            }

            if (this.queue.Count != 0)
            {
                sb.Remove(sb.Length - 2, 2);
            }

            sb.Append(" ] back");

            return sb.ToString();
        }

        public void Remove(string element)
        {
            if (element == null)
            {
                throw new ArgumentException("Input tag is null");
            }

            for (int i = 0; i < this.queue.Count; i++)
            {
                HtmlTag current = this.queue.Peek();

                if (!current.GetElement().Equals(element))
                {
                    this.queue.Enqueue(current);
                }
                else
                {
                    i--;
                }

                this.queue.Dequeue();
            }
        }

        public void Validate()
        {
            MyStack stack = new MyStack();
            int white_space = 0;

            foreach (HtmlTag x in this.queue)
            {
                if (x.GetIsOpenTag())
                {
                    if (x.IsSelfClosing())
                    {
                        for (int i = 0; i < white_space; i++)
                        {
                            Console.Write(this.space);
                        }

                        Console.WriteLine(x);
                    }
                    else
                    {                   
                        for (int i = 0; i < white_space; i++)
                        {
                            Console.Write(this.space);
                        }
                        white_space++;

                        Console.WriteLine(x);
                        stack.Push(x);
                    }
                }
                else
                {
                    if (stack.IsEmpty())
                    {
                        Console.WriteLine("ERROR unexpected tag: " + x);
                    }
                    else
                    {
                        if (x.Matches(stack.Peek()))
                        {
                            white_space--;
                            for (int i = 0; i < white_space; i++)
                            {
                                Console.Write(this.space);
                            }

                            Console.WriteLine(x);
                            stack.Pop();
                        }
                        else
                        {
                            Console.WriteLine("ERROR unexpected tag: " + x);
                        }
                    }
                }
            }

            while (!stack.IsEmpty())
            {
                Console.WriteLine("ERROR unclosed tag: " + stack.Peek());
                stack.Pop();
            }
        }
    }
}
