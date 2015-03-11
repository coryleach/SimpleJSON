﻿using NUnit.Framework;

namespace SimpleJSON.Test
{
    [TestFixture]
    public class ArrayTest
    {
        [Test]
        public void Array_Add_Null()
        {
            // arrange
            var node = new JSONClass();

            // act
            node["value"].Add(new JSONData(null));

            // assert
            Assert.IsTrue(node["value"][0].IsNull);
        }

        [Test]
        public void Array_Add_String()
        {
            // arrange
            var node = new JSONClass();

            // act
            node["value"].Add(new JSONData("string"));

            // assert
            Assert.AreEqual("string", node["value"][0].Value);
        }

        [Test]
        public void Array_Add_Int()
        {
            // arrange
            var node = new JSONClass();

            // act
            node["value"].Add(new JSONData(1));

            // assert
            Assert.AreEqual(1, node["value"][0].AsInt);
        }

        [Test]
        public void Array_Add_Long()
        {
            // arrange
            var node = new JSONClass();
            const long expected = 12345678900000;

            // act
            node["value"].Add(new JSONData(expected));

            // assert
            Assert.AreEqual(expected, node["value"][0].AsLong);
        }

        [Test]
        public void Array_Add_Bool()
        {
            // arrange
            var node = new JSONClass();
            const bool expected = true;

            // act
            node["value"].Add(new JSONData(expected));

            // assert
            Assert.AreEqual(expected, node["value"][0].AsBool);
        }

        [Test]
        public void Array_Add_Double()
        {
            // arrange
            var node = new JSONClass();
            const double expected = 1.5;

            // act
            node["value"].Add(new JSONData(expected));

            // assert
            Assert.AreEqual(expected, node["value"][0].AsDouble);
        }

        [Test]
        public void Array_Add_Float()
        {
            // arrange
            var node = new JSONClass();
            const float expected = 1.5f;

            // act
            node["value"].Add(new JSONData(expected));

            // assert
            Assert.AreEqual(expected, node["value"][0].AsFloat);
        }

        [Test]
        public void Array_Remove_WithOneItemAtIndex()
        {
            // arrange
            var node = new JSONClass();
            const float value = 1.5f;
            node["value"].Add(new JSONData(value));

            // act
            node["value"].Remove(0);

            // assert
            Assert.AreEqual(0, node["value"].Count);
        }

        [Test]
        public void Array_Remove_WithOneItemByObject()
        {
            // arrange
            var node = new JSONClass();
            JSONNode value = new JSONData(1.5);
            node["value"].Add(value);

            // act
            node["value"].Remove(value);

            // assert
            Assert.AreEqual(0, node["value"].Count);
        }

        [Test]
        public void Array_Remove_WithTwoItemsAtIndex()
        {
            // arrange
            var node = new JSONClass();
            const float value = 1.5f;
            node["value"].Add(new JSONData(value));
            node["value"].Add(new JSONData(value));

            // act
            node["value"].Remove(0);

            // assert
            Assert.AreEqual(1, node["value"].Count);
        }

        [Test]
        public void Array_Remove_WithTwoItemsByObject()
        {
            // arrange
            var node = new JSONClass();
            JSONNode value = new JSONData(1.5);
            node["value"].Add(value);
            node["value"].Add(new JSONData(2.0));

            // act
            node["value"].Remove(value);

            // assert
            Assert.AreEqual(1, node["value"].Count);
        }

        [Test]
        public void Array_Remove_NegativeIndex()
        {
            // arrange
            var node = new JSONClass();
            JSONNode value = new JSONData(1.5);
            node["value"].Add(value);

            // act
            var removed = node["value"].Remove(-1);

            // assert
            Assert.IsNull(removed);
        }

        [Test]
        public void Array_Remove_IndexTooHigh()
        {
            // arrange
            var node = new JSONClass();
            JSONNode value = new JSONData(1.5);
            node["value"].Add(value);

            // act
            var removed = node["value"].Remove(2);

            // assert
            Assert.IsNull(removed);
        }
    }
}
