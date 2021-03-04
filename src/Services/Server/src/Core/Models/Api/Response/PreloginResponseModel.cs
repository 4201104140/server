using Core.Enums;
using Core.Models.Data;

namespace Core.Models.Api
{
    public class PreloginResponseModel
    {
        public PreloginResponseModel(UserKdfInformation kdfInformation)
        {
            Kdf = kdfInformation.Kdf;
            KdfIterations = kdfInformation.KdfIterations;
        }

        public KdfType Kdf { get; set; }
        public int KdfIterations { get; set; }
    }
}
