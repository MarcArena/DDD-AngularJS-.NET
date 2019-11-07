using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace devTest.Application.Core.Messaging
{
    public class AutoDisposable
    {
        public void Dispose()
        {
            AutoDispose(this, GetType());
        }

        private static readonly BindingFlags _bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy;

        private static void AutoDispose(object item, Type type)
        {
            if (item != null && type != null && type != typeof(AutoDisposable))
            {
                var members = type
                    .GetMembers(_bindingFlags)
                    .Where(member => member is FieldInfo || member is PropertyInfo);

                foreach (var member in members)
                    if (GetMemberValue(item, member) is IDisposable disposable)
                        try { disposable.Dispose(); } catch (Exception) { }

                AutoDispose(item, type.BaseType);
            }
        }

        private static object GetMemberValue(object item, MemberInfo member)
        {
            if (member is PropertyInfo property)
                return property.GetValue(item);

            if (member is FieldInfo field)
                return field.GetValue(item);

            return null;
        }
    }
}
