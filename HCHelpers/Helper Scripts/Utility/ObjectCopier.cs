using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Ali.Helper
{
    public static class ObjectCopier
    {
        public static T Clone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", nameof(source));
            }

            if (ReferenceEquals(source, null))
            {
                return default;
            }
            return SerializationManager.DeserializeObject<T>(SerializationManager.SerializeObject(source));
        }
    }
}