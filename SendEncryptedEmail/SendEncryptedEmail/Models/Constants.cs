﻿using System;

namespace SendEncryptedEmail.Models
{
    public static class Constants
    {
        public const string ContractAddress = "0x102805F387322190Ff589c950264Bf7C39BAEd71";
        public const string ContractABI = @"[{""constant"":true,""inputs"":[{""name"":""recipientAddress"",""type"":""address""}],""name"":""isEmptyAddress"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":false,""stateMutability"":""pure"",""type"":""function""},{""constant"":false,""inputs"":[],""name"":""kill"",""outputs"":[],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""recipientAddress"",""type"":""address""},{""name"":""eId"",""type"":""string""},{""name"":""ekey"",""type"":""string""}],""name"":""confirmEmailHash"",""outputs"":[{""name"":"""",""type"":""string""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""recipientAddress"",""type"":""address""},{""name"":""eId"",""type"":""string""}],""name"":""uploadEmailId"",""outputs"":[{""name"":"""",""type"":""string""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""eId"",""type"":""string""}],""name"":""getEmailKey"",""outputs"":[{""name"":"""",""type"":""string""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":true,""inputs"":[{""name"":""key"",""type"":""string""}],""name"":""isEmptyString"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":false,""stateMutability"":""pure"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""eId"",""type"":""string""},{""name"":""eHash"",""type"":""string""},{""name"":""ePublicKey"",""type"":""string""}],""name"":""confirmReceivalAndUploadEmailHash"",""outputs"":[{""name"":"""",""type"":""string""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":true,""inputs"":[{""name"":""eId"",""type"":""string""}],""name"":""updateEmailStatus"",""outputs"":[{""name"":"""",""type"":""int256""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""eId"",""type"":""string""}],""name"":""getEmailHash"",""outputs"":[{""name"":"""",""type"":""string""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""eId"",""type"":""string""}],""name"":""getEmailEncryptionPublicKey"",""outputs"":[{""name"":"""",""type"":""string""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[],""payable"":false,""stateMutability"":""nonpayable"",""type"":""constructor""}]";
        public const string SenderFile = "SenderExpit.dt";
        public const string RecipientFile = "RecipientExpit.dt";
        public const string EtherScanURL = "https://ropsten.etherscan.io/address/0x102805f387322190ff589c950264bf7c39baed71";
        public const string EthereumURL = "https://ropsten.infura.io";
        public const string EncryptedFileExtension = ".expit";
    }
}