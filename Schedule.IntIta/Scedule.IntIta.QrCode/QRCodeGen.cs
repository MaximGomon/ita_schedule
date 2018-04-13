using System;
using System.Collections.Generic;
using System.Text;
using QRCoder;
using Schedule.IntIta.Domain.Models;
using System.DrawingCore;

namespace Scedule.IntIta.QrCode
{
    public class QRCodeGen
    {
        public Bitmap GenerateQR(string UrLAddressRoomId)
        {
            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(UrLAddressRoomId, QRCodeGenerator.ECCLevel.Q);
            QRCode qRCode = new QRCode(qRCodeData);
            Bitmap bitmap = qRCode.GetGraphic(20);
            return bitmap;
        }
          
     }
}
