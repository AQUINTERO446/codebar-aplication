using System.Threading.Tasks;
using MyPassMobile.Interfaces;
using ZXing.Mobile;
using Xamarin.Forms;

[assembly: Dependency(typeof(MyPassMobile.Droid.QrCodeScanningService))]

namespace MyPassMobile.Droid
{
    
    public class QrCodeScanningService : IQrCodeScanningService
    {
        public async Task<string> ScanAsync()
        {
            var options = new MobileBarcodeScanningOptions();
            var scanner = new MobileBarcodeScanner();
            var scanResults = await scanner.Scan(options);
            return scanResults.Text;
        }
    }
}
