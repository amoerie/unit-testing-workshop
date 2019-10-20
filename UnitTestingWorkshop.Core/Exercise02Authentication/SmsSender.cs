namespace UnitTestingWorkshop.Core.Exercise02Authentication
{
    public interface ISmsSender
    {
        void Send(string phoneNumer, string message);
    }

}
