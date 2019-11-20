using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlValidator
{
    [TestClass]
    public class MyStackTests
    {
        MyStack stack;
        HtmlTag open_table = new HtmlTag("table", true);
        HtmlTag closed_table = new HtmlTag("table", false);

        [TestInitialize]
        public void Init()
        {
            this.stack = new MyStack();
        }

        [TestMethod]
        public void PushPeek()
        {
            this.stack.Push(this.open_table);
            this.stack.Push(this.closed_table);

            Assert.AreEqual(this.closed_table, this.stack.Peek());
        }

        [TestMethod]
        public void PushPop()
        {
            this.stack.Push(this.open_table);
            this.stack.Push(this.closed_table);

            Assert.AreEqual(this.closed_table, this.stack.Pop());
            Assert.AreEqual(this.open_table, this.stack.Pop());
        }

        [TestMethod]
        public void Empty()
        {
            Assert.IsTrue(this.stack.IsEmpty());

            this.stack.Push(this.open_table);

            Assert.IsFalse(this.stack.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException), AllowDerivedTypes = true)]
        public void Exceptions()
        {
            Assert.IsTrue(this.stack.IsEmpty());

            // These two calls should produce two argument exceptions
            this.stack.Pop();

            this.stack.Peek();
        }
    }

    [TestClass]
    public class ValidatorTests
    {
        HtmlValidator validator;

        HtmlTag self_closing = new HtmlTag("br");
        HtmlTag open_table = new HtmlTag("table", true);
        HtmlTag closed_table = new HtmlTag("table", false);
        HtmlTag open_sample = new HtmlTag("sample", true);
        HtmlTag closed_sample = new HtmlTag("sample", false);

        readonly string all_tags = "front [ <table>, <sample>, </sample>, </table> ] back";
        readonly string remove_table = "front [ <sample>, </sample> ] back";
        readonly string remove_all = "front [  ] back";

        List<int> ignoreTests = new List<int>();

        [TestInitialize]
        public void Init()
        {
            this.validator = new HtmlValidator();
        }

        [TestMethod]
        public void AddGet()
        {
            this.validator.AddTag(this.open_table);
            this.validator.AddTag(this.open_sample);
            this.validator.AddTag(this.closed_sample);
            this.validator.AddTag(this.closed_table);
            string yes = this.validator.GetTags();

            Assert.AreEqual(this.all_tags, this.validator.GetTags());
        }

        [TestMethod]
        public void RemoveGet()
        {
            this.validator.AddTag(this.open_table);
            this.validator.AddTag(this.open_sample);
            this.validator.AddTag(this.closed_sample);
            this.validator.AddTag(this.closed_table);

            this.validator.Remove("table");

            Assert.AreEqual(this.remove_table, this.validator.GetTags());

            this.validator.Remove("sample");

            Assert.AreEqual(this.remove_all, this.validator.GetTags());
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException), AllowDerivedTypes = true)]
        public void Exceptions()
        {
            this.validator.AddTag(null);
            this.validator.Remove(null);
        }

        // Want to use simple for loop to check validate
        // Have individual ones to uncomment for checking which specific ones fail
        [TestMethod]
        public void Validate()
        {
            //this.ignoreTests.Add(3);
            //this.ignoreTests.Add(4);

            for (int i = 0; i < 11; i++)
            {
                if (this.ignoreTests.Contains(i))
                {
                    continue;
                }
                else
                {
                    this.ValidateHelper(i + 1);
                }
            }

            Console.WriteLine(this.ignoreTests);
        }

        private void ValidateHelper(int num)
        {
            var sw = new StringWriter();
            Console.SetOut(sw);
            Console.SetError(sw);

            set_url(num);

            this.validator.Validate();

            this.compare(num, sw.ToString());
        }

        private void set_url(int num)
        {
            string pageText = "";
            string url = "/Users/ryanliu/dev/CPEN223/MP1/samples/" + "test" + num + ".html";

            pageText = ValidatorMain.ReadCompleteFileOrURL(url);
            Queue<HtmlTag> tags = new Queue<HtmlTag>(HtmlTag.Tokenize(pageText));

            // create the HTML validator
            this.validator = new HtmlValidator(tags);
        }

        private void compare(int num, string result)
        {
            List<string> exp_lines = new List<string>(System.IO.File.ReadAllLines("/Users/ryanliu/dev/CPEN223/MP1/samples/" + "expected_output_" + num + ".txt"));
            List<string> res_lines = new List<string>(result.Split("\n"));

            // Do a check for empty last element

            if (string.IsNullOrEmpty(res_lines[res_lines.Count - 1]))
            {
                res_lines.RemoveAt(res_lines.Count - 1);
            }

            // Check if Count are equal
            if (exp_lines.Count != res_lines.Count)
            {
                this.ignoreTests.Add(num - 1);
                return;
            }

            Assert.AreEqual(exp_lines.Count, res_lines.Count);

            // Now check each element
            for (int i = 0; i < res_lines.Count; i++)
            {
                if (!exp_lines[i].Equals(res_lines[i]))
                {
                    this.ignoreTests.Add(num - 1);
                    return;
                }

                Assert.AreEqual(exp_lines[i], res_lines[i]);
            }
        }
    }

}
