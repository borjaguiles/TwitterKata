namespace TwitterKata
{
    public interface IUserContainer
    {
        User GetUser(string name);
        User AddNewUser(string name);
    }
}