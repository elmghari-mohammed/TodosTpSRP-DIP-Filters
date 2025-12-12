namespace Todo.Services
{
    public interface ISessionManagerService
    {
        public void Add(string key, object obj, HttpContext context);

    }
}
