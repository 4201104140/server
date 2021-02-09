using System;

namespace Core.Models.Table
{
    public interface ITableObject<T> where T : IEquatable<T>
    {
        T Id { get; set; }
        void SetNewId();
    }
}
