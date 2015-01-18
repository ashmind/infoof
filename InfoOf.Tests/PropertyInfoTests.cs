using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace InfoOf.Tests {
    public class PropertyInfoTests {
        [Fact]
        public void Instance_ReferenceType() {
            var property = Info.PropertyOf<TestClass>(c => c.Object);
            Assert.Same(property, typeof(TestClass).GetProperty("Object"));
        }

        [Fact]
        public void Instance_ValueType() {
            var property = Info.PropertyOf<TestClass>(c => c.Int32);
            Assert.Same(property, typeof(TestClass).GetProperty("Int32"));
        }

        [Fact]
        public void Instance_Dynamic() {
            var property = Info.PropertyOf<TestClass>(c => c.Dynamic);
            Assert.Same(property, typeof(TestClass).GetProperty("Dynamic"));
        }

        [Fact]
        public void Static_ReferenceType() {
            var property = Info.PropertyOf(() => TestClass.StaticObject);
            Assert.Same(property, typeof(TestClass).GetProperty("StaticObject"));
        }

        private class TestClass {
            public object Object { get; set; }
            public int Int32 { get; set; }
            public dynamic Dynamic { get; set; }

            public static object StaticObject { get; set; }
        }
    }
}
