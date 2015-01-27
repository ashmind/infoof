using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using JetBrains.Annotations;

namespace InfoOf {
    public static class Info {
        [NotNull]
        public static PropertyInfo PropertyOf([NotNull] Expression<Func<object>> reference) {
            return NonCallMember<PropertyInfo>(reference, "property");
        }

        [NotNull]
        public static PropertyInfo PropertyOf<TResult>([NotNull] Expression<Func<TResult>> reference) {
            return NonCallMember<PropertyInfo>(reference, "property");
        }

        [NotNull]
        public static PropertyInfo PropertyOf<T>([NotNull] Expression<Func<T, object>> reference) {
            return NonCallMember<PropertyInfo>(reference, "property");
        }

        [NotNull]
        public static PropertyInfo PropertyOf<T, TResult>([NotNull] Expression<Func<T, TResult>> reference) {
            return NonCallMember<PropertyInfo>(reference, "property");
        }

        [NotNull]
        public static FieldInfo FieldOf([NotNull] Expression<Func<object>> reference) {
            return NonCallMember<FieldInfo>(reference, "field");
        }
        
        [NotNull]
        public static FieldInfo FieldOf<TResult>([NotNull] Expression<Func<TResult>> reference) {
            return NonCallMember<FieldInfo>(reference, "field");
        }

        [NotNull]
        public static FieldInfo FieldOf<T>([NotNull] Expression<Func<T, object>> reference) {
            return NonCallMember<FieldInfo>(reference, "field");
        }
        
        [NotNull]
        public static FieldInfo FieldOf<T, TResult>([NotNull] Expression<Func<T, TResult>> reference) {
            return NonCallMember<FieldInfo>(reference, "field");
        }

        [NotNull]
        public static MethodInfo MethodOf([NotNull] Expression<Action> reference) {
            return Method(reference);
        }

        [NotNull]
        public static MethodInfo MethodOf<T>([NotNull] Expression<Action<T>> reference) {
            return Method(reference);
        }

        private static TMemberInfo NonCallMember<TMemberInfo>(LambdaExpression reference, string what)
            where TMemberInfo : MemberInfo {
            var inner = ValidateAndUnwrap(reference);
            var member = inner as MemberExpression;
            if (member == null)
                throw NewExpressionException(inner, "cannot be converted to a " + what);

            var result = member.Member as TMemberInfo;
            if (result == null)
                throw NewExpressionException(inner, "is a " + member.Member.GetType().Name + " and cannot be converted to a " + what);

            return result;
        }

        private static MethodInfo Method(LambdaExpression reference) {
            var inner = ValidateAndUnwrap(reference);
            var call = inner as MethodCallExpression;
            if (call == null)
                throw NewExpressionException(inner, "cannot be converted to a method call.");

            return call.Method;
        }
    
        private static Expression ValidateAndUnwrap(LambdaExpression reference) {
            if (reference == null)
                throw new ArgumentNullException("reference");

            var inner = reference.Body;
            var unary = inner as UnaryExpression;
            if (unary != null && unary.NodeType == ExpressionType.Convert && unary.Type == typeof(object))
                inner = unary.Operand;
            return inner;
        }

        private static ArgumentException NewExpressionException(Expression expression, string message) {
            return new ArgumentException(expression.GetType().Name + " '" + expression + "' " + message);
        }
    }
}