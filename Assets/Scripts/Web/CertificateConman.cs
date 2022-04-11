using UnityEngine.Networking;

namespace Assets.Scripts.Web {
    public class CertificateConman : CertificateHandler
    {
        protected override bool ValidateCertificate(byte[] certificateData)
        {
            return true;
        }
    }
}