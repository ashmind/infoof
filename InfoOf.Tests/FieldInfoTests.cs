using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace InfoOf.Tests {
    public class FieldInfoTests {
        [Fact]
        public void Instance_ReferenceType() {
            var field = Info.FieldOf<TestClass>(c => c.Object);
            Assert.Same(field, typeof(TestClass).GetField("Object"));
        }

        [Fact]
        public void Instance_ValueType() {
            var field = Info.FieldOf<TestClass>(c => c.Int32);
            Assert.Same(field, typeof(TestClass).GetField("Int32"));
        }

        [Fact]
        public void Instance_Dynamic() {
            var field = Info.FieldOf<TestClass>(c => c.Dynamic);
            Assert.Same(field, typeof(TestClass).GetField("Dynamic"));
        }

        [Fact]
        public void Static_ReferenceType() {
            var field = Info.FieldOf(() => TestClass.StaticObject);
            Assert.Same(field, typeof(TestClass).GetField("StaticObject"));
        }

        private class TestClass {
            #pragma warning disable 649
            public object Object;

            public int Int32;
            public dynamic Dynamic;

            public static object StaticObject;
            #pragma warning restore 649
        }
    }
}
