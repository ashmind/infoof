using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace InfoOf.Tests {
    public class MethodInfoTests {
        [Fact]
        public void Instance_Void_NoArguments() {
            var method = Info.MethodOf<TestClass>(c => c.VoidNoArguments());
            Assert.Same(method, typeof(TestClass).GetMethod("VoidNoArguments"));
        }

        [Fact]
        public void Instance_Void_OneArgument() {
            var method = Info.MethodOf<TestClass>(c => c.VoidOneArgument(null));
            Assert.Same(method, typeof(TestClass).GetMethod("VoidOneArgument"));
        }

        [Fact]
        public void Instance_ReferenceType_NoArguments() {
            var method = Info.MethodOf<TestClass>(c => c.ObjectNoArguments());
            Assert.Same(method, typeof(TestClass).GetMethod("ObjectNoArguments"));
        }

        [Fact]
        public void Instance_ValueType_NoArguments() {
            var method = Info.MethodOf<TestClass>(c => c.Int32NoArguments());
            Assert.Same(method, typeof(TestClass).GetMethod("Int32NoArguments"));
        }

        [Fact]
        public void Instance_Dynamic_NoArguments() {
            var method = Info.MethodOf<TestClass>(c => c.DynamicNoArguments());
            Assert.Same(method, typeof(TestClass).GetMethod("DynamicNoArguments"));
        }

        [Fact]
        public void Static_Void_NoArguments() {
            var method = Info.MethodOf(() => TestClass.StaticVoidNoArguments());
            Assert.Same(method, typeof(TestClass).GetMethod("StaticVoidNoArguments"));
        }

        private class TestClass {
            public void VoidNoArguments() {}
            public void VoidOneArgument(object x) {}
            public object ObjectNoArguments() { return null; }
            public dynamic DynamicNoArguments() { return null; }
            public int Int32NoArguments() { return 0; }

            public static void StaticVoidNoArguments() { }
        }
    }
}
