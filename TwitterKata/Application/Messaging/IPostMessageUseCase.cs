namespace TwitterKata
{
    public interface IPostMessageUseCase
    {
        void PostMessage(string message, string user);
    }
}