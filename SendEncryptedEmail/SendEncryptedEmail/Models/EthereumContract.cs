using System;

namespace SendEncryptedEmail.Models
{
    public class EthereumContract
    {
        public string ContractAddress { get; set; }
        public string ContractABI { get; set; }
        public string EtherScanURL { get; set; }
    }
}
