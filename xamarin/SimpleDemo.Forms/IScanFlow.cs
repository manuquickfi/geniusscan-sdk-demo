using System.Threading.Tasks;
namespace SimpleDemo.Forms
{
    public interface IScanFlow
    {
        Task<string> StartScanning();

        //Task<string> StartScanning(string jsonConfiguration);
    }
}
