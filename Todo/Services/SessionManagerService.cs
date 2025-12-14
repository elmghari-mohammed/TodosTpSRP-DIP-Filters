using System.Collections.Generic;
using System.Text.Json;
using Todo.Models;

namespace Todo.Services
{
    public class SessionManagerService: ISessionManagerService
    {
        public void Add(string key,object obj,HttpContext context)
        {
            string chaine = JsonSerializer.Serialize(obj);
            context.Session.SetString(key, chaine);
        }

        public T Get<T>(string key, HttpContext context)
        {
            var json = context.Session.GetString(key);
            if (!string.IsNullOrEmpty(json))
            {
                return JsonSerializer.Deserialize<T>(json);
            }
            return default;
        }
    }
}
