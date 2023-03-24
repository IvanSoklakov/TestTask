using System.Runtime.Serialization;

namespace TestTaskApi.DAL.Models
{
    class KeyValueItem<T> 
    {
        public T Id { get; set; }
        public string Name { get; set; }
    }
}
