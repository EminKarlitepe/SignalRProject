using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace SignalRWebUI.Controllers
{
    public class QRCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string value)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (QRCodeGenerator createQRCode = new QRCodeGenerator())
                {
                    QRCodeData qrCodeData = createQRCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
                    using (BitmapByteQRCode squareCode = new BitmapByteQRCode(qrCodeData))
                    {
                        byte[] qrCodeAsBitmapBytes = squareCode.GetGraphic(10);

                        ViewBag.QrCodeImage = "data:image/png;base64," + Convert.ToBase64String(qrCodeAsBitmapBytes);
                    }
                }
            }
            return View();
        }
    }
}