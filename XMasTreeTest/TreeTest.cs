using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XMasTree;

namespace XMasTreeTest
{
    [TestClass]
    public class TreeTest
    {
        Tree<int> tree;
        List<int> values=new List<int>();

        Random random = new Random();

        [TestInitialize]
        public void TestInit()
        {
            values.Clear();

            while (values.Count<int.MaxValue/2)
            {
                int value = random.Next();

                if (!values.Contains(value))
                {
                    values.Add(value);
                }
            }

            tree = new Tree<int>(values);
        }

        [TestMethod]
        public void ValueMatchTest()
        {
            for (int i = 0; i<int.MaxValue; i++)
            {
                if (values.Contains(i))
                {
                    Assert.IsTrue(tree.Search(i), $"Value {i} was expected in tree.");
                }
                else
                {
                    Assert.IsFalse(tree.Search(i), $"Value {i} was not expected in tree.");
                }
            }
        }

        [TestMethod]
        public void InsertTest()
        {
            for (int i = 0; i < int.MaxValue / 2; i++)
            {
                int value = random.Next();
                values.Add(value);

                tree.Insert(value);
                Assert.IsTrue(tree.Search(value),$"Value {i} was not added into tree.");
            }

            ValueMatchTest();
        }

        [TestMethod]
        public void DeleteTest()
        {
            for (int i = 0; i < int.MaxValue / 2; i++)
            {
                int value = random.Next();
                values.Remove(value);

                tree.Delete(value);
                Assert.IsFalse(tree.Search(value), $"Value {i} was not removed from tree.");
            }

            ValueMatchTest();
        }

        [TestMethod]
        public void MinMaxTest()
        {
            values.Sort();

            for (int i = 0; i < int.MaxValue / 8; i++)
            {
                Assert.AreEqual(tree.GetMinimum(), values[0], $"Reported minimum was {tree.GetMinimum()}, {values[0]} expected.");
                tree.Delete(tree.GetMinimum());
                values.Remove(values[0]);
            }

            for (int i = 0; i < int.MaxValue / 8; i++)
            {
                Assert.AreEqual(tree.GetMaximum(), values[values.Count-1], $"Reported maximum was {tree.GetMaximum()}, {values[values.Count - 1]} expected.");
                tree.Delete(tree.GetMaximum());
                values.Remove(values[values.Count - 1]);
            }
        }
    }
}
