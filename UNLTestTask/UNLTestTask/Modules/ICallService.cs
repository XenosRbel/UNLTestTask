using System.Threading.Tasks;

namespace UNLTestTask.Modules
{
    public interface ICallService
    {
        Task CallNumber(string phoneNumber);
    }
}
