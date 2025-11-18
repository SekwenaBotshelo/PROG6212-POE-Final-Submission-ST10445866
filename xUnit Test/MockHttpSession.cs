using System.Text;
using Microsoft.AspNetCore.Http;

namespace PROG6212_POE.Tests
{
    public class MockHttpSession : ISession
    {
        private readonly Dictionary<string, byte[]> _storage = new Dictionary<string, byte[]>();

        public string Id => Guid.NewGuid().ToString();
        public bool IsAvailable => true;
        public IEnumerable<string> Keys => _storage.Keys;

        public void Clear() => _storage.Clear();

        public Task CommitAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;

        public Task LoadAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;

        public void Remove(string key) => _storage.Remove(key);

        public void Set(string key, byte[] value) => _storage[key] = value;

        public bool TryGetValue(string key, out byte[] value) => _storage.TryGetValue(key, out value);

        // Helper methods for string values
        public void SetString(string key, string value)
        {
            _storage[key] = Encoding.UTF8.GetBytes(value);
        }

        public string GetString(string key)
        {
            return TryGetValue(key, out byte[] value) ? Encoding.UTF8.GetString(value) : null;
        }
    }
}