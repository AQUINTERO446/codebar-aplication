using System.Threading.Tasks;
using MyPassMobile.Interfaces;
using ZXing.Mobile;
using Xamarin.Forms;

[assembly: Dependency(typeof(MyPassMobile.iOS.QrCodeScanningService))]

namespace MyPassMobile.iOS
{
    public class QrCodeScanningService : IQrCodeScanningService
    {
        public async Task<string> ScanAsync()
        {
            var scanner = new MobileBarcodeScanner();
            var scanResults = await scanner.Scan();
            return scanResults.Text;
        }
    }
}
