using Nethereum.Web3;
using System.Threading.Tasks;
using SendEncryptedEmail.Models;

namespace SendEncryptedEmail.Libraries
{
    public class BlockchainHelper
    { 
        Web3 web3;

        public BlockchainHelper()
        {
            web3 = new Web3(Constants.EthereumURL);
        }

        /// <summary>
        /// Used by the sender to create the first transaction of the email on Ethereum with the generated Email Id and the recipient's Ethereum public address.
        /// </summary>
        /// <param name="ethContract"></param>
        /// <param name="sender"></param>
        /// <param name="recipientAddress"></param>
        /// <param name="emailId"></param>
        /// <returns></returns>
        protected internal async Task<string> UploadEmailId(EthereumContract ethContract, EthereumUser sender, string recipientAddress, string emailId)
        {
            var contract = web3.Eth.GetContract(ethContract.ContractABI, ethContract.ContractAddress);
            var txCount = await web3.Eth.Transactions.GetTransactionCount.SendRequestAsync(sender.PublicAddress).ConfigureAwait(false);
            var function = contract.GetFunction("uploadEmailId");
            var data = function.GetData(recipientAddress, emailId);
            var encoded = web3.OfflineTransactionSigning.SignTransaction(sender.PrivateKey, ethContract.ContractAddress, 0, txCount.Value, 1000000000000L, 900000, data);

            return await web3.Eth.Transactions.SendRawTransaction.SendRequestAsync(encoded).ConfigureAwait(false); ;
        }

        /// <summary>
        /// Used by the recipient to confirm the email receival. The recipient uses this method to create a transaction on Ethereum with the received email hash and the public encryption key of the public/private generated RSA encryption keypair.
        /// </summary>
        /// <param name="ethContract"></param>
        /// <param name="recipient"></param>
        /// <param name="emailId"></param>
        /// <param name="emailHash"></param>
        /// <param name="encryptionPublicKey"></param>
        /// <returns></returns>
        protected internal async Task<string> ConfirmReceivalAndUploadEmailHash(EthereumContract ethContract, EthereumUser recipient, string emailId, string emailHash, string encryptionPublicKey)
        {
            var contract = web3.Eth.GetContract(ethContract.ContractABI, ethContract.ContractAddress);
            var txCount = await web3.Eth.Transactions.GetTransactionCount.SendRequestAsync(recipient.PublicAddress).ConfigureAwait(false);
            var function = contract.GetFunction("confirmReceivalAndUploadEmailHash");
            var data = function.GetData(emailId, emailHash, encryptionPublicKey);
            var encoded = web3.OfflineTransactionSigning.SignTransaction(recipient.PrivateKey, ethContract.ContractAddress, 0, txCount.Value, 1000000000000L, 900000, data);

            return await web3.Eth.Transactions.SendRawTransaction.SendRequestAsync(encoded).ConfigureAwait(false);
        }

        /// <summary>
        /// Used by the sender to get the email hash provided by the recipient.
        /// </summary>
        /// <param name="ethContract"></param>
        /// <param name="sender"></param>
        /// <param name="emailId"></param>
        /// <returns></returns>
        protected internal async Task<string> GetEmailHashWithTransaction(EthereumContract ethContract, EthereumUser sender, string emailId)
        {
            var contract = web3.Eth.GetContract(ethContract.ContractABI, ethContract.ContractAddress);
            var txCount = await web3.Eth.Transactions.GetTransactionCount.SendRequestAsync(sender.PublicAddress).ConfigureAwait(false);
            var function = contract.GetFunction("getEmailHash");
            var data = function.GetData(emailId);
            var encoded = web3.OfflineTransactionSigning.SignTransaction(sender.PrivateKey, ethContract.ContractAddress, 0, txCount.Value, 1000000000000L, 900000, data);

            return await web3.Eth.Transactions.SendRawTransaction.SendRequestAsync(encoded).ConfigureAwait(false);
        }

        /// <summary>
        /// Used to get email hash for display.
        /// </summary>
        /// <param name="ethContract"></param>
        /// <param name="emailId"></param>
        /// <returns></returns>
        protected internal async Task<string> GetEmailHashWithoutTransaction(EthereumContract ethContract, string emailId)
        {
            var contract = web3.Eth.GetContract(ethContract.ContractABI, ethContract.ContractAddress);
            var function = contract.GetFunction("getEmailHash");
            var result = await function.CallAsync<string>(emailId).ConfigureAwait(false);

            return result;
        }

        /// <summary>
        /// Used by the sender to get the public encryption key provided by the recipient that will be used to encrypt the shared key.
        /// </summary>
        /// <param name="ethContract"></param>
        /// <param name="sender"></param>
        /// <param name="emailId"></param>
        /// <returns></returns>
        protected internal async Task<string> GetEmailEncryptionPublicKeyWithTransaction(EthereumContract ethContract, EthereumUser sender, string emailId)
        {
            var contract = web3.Eth.GetContract(ethContract.ContractABI, ethContract.ContractAddress);
            var txCount = await web3.Eth.Transactions.GetTransactionCount.SendRequestAsync(sender.PublicAddress).ConfigureAwait(false);
            var function = contract.GetFunction("getEmailEncryptionPublicKey");
            var data = function.GetData(emailId);
            var encoded = web3.OfflineTransactionSigning.SignTransaction(sender.PrivateKey, ethContract.ContractAddress, 0, txCount.Value + 1, 1000000000000L, 900000, data);

            return await web3.Eth.Transactions.SendRawTransaction.SendRequestAsync(encoded).ConfigureAwait(false);
        }

        /// <summary>
        /// Used to get the public encryption key that will be used to encrypt the shared key for display.
        /// </summary>
        /// <param name="ethContract"></param>
        /// <param name="emailId"></param>
        /// <returns></returns>
        protected internal async Task<string> GetEmailEncryptionPublicKeyWithoutTransaction(EthereumContract ethContract, string emailId)
        {
            var contract = web3.Eth.GetContract(ethContract.ContractABI, ethContract.ContractAddress);
            var function = contract.GetFunction("getEmailEncryptionPublicKey");
            var result = await function.CallAsync<string>(emailId).ConfigureAwait(false);

            return result;
        }

        /// <summary>
        /// Used by the sender to confirm the email hash provided by the recipient.
        /// </summary>
        /// <param name="ethContract"></param>
        /// <param name="sender"></param>
        /// <param name="recipientAddress"></param>
        /// <param name="emailId"></param>
        /// <param name="encryptionKey"></param>
        /// <returns></returns>
        protected internal async Task<string> ConfirmEmailHash(EthereumContract ethContract, EthereumUser sender, string recipientAddress, string emailId, string encryptionKey)
        {
            var contract = web3.Eth.GetContract(ethContract.ContractABI, ethContract.ContractAddress);
            var txCount = await web3.Eth.Transactions.GetTransactionCount.SendRequestAsync(sender.PublicAddress).ConfigureAwait(false);
            var function = contract.GetFunction("confirmEmailHash");
            var data = function.GetData(recipientAddress, emailId, encryptionKey);
            var encoded = web3.OfflineTransactionSigning.SignTransaction(sender.PrivateKey, ethContract.ContractAddress, 0, txCount.Value, 1000000000000L, 900000, data);

            return await web3.Eth.Transactions.SendRawTransaction.SendRequestAsync(encoded).ConfigureAwait(false);
        }

        /// <summary>
        /// Used by the recpient to get the shared key to decrypt the email with.
        /// </summary>
        /// <param name="ethContract"></param>
        /// <param name="recipient"></param>
        /// <param name="emailId"></param>
        /// <returns></returns>
        protected internal async Task<string> GetEmailKeyWithTransaction(EthereumContract ethContract, EthereumUser recipient, string emailId)
        {
            var contract = web3.Eth.GetContract(ethContract.ContractABI, ethContract.ContractAddress);
            var txCount = await web3.Eth.Transactions.GetTransactionCount.SendRequestAsync(recipient.PublicAddress).ConfigureAwait(false);
            var function = contract.GetFunction("getEmailKey");
            var data = function.GetData(emailId);
            var encoded = web3.OfflineTransactionSigning.SignTransaction(recipient.PrivateKey, ethContract.ContractAddress, 0, txCount.Value, 1000000000000L, 900000, data);

            return await web3.Eth.Transactions.SendRawTransaction.SendRequestAsync(encoded).ConfigureAwait(false);
        }

        /// <summary>
        /// Used to get the encrypted shared key that will be used to decrypt the email for display.
        /// </summary>
        /// <param name="ethContract"></param>
        /// <param name="emailId"></param>
        /// <returns></returns>
        protected internal async Task<string> GetEmailKeyWithoutTransaction(EthereumContract ethContract, string emailId)
        {
            var contract = web3.Eth.GetContract(ethContract.ContractABI, ethContract.ContractAddress);
            var function = contract.GetFunction("getEmailKey");
            var result = await function.CallAsync<string>(emailId).ConfigureAwait(false);

            return result;
        }

        /// <summary>
        /// Used to get the email status and current step being executed.
        /// </summary>
        /// <param name="ethContract"></param>
        /// <param name="emailId"></param>
        /// <returns></returns>
        protected internal async Task<int> UpdateEmailStatus(EthereumContract ethContract, string emailId)
        {
            var contract = web3.Eth.GetContract(ethContract.ContractABI, ethContract.ContractAddress);
            var function = contract.GetFunction("updateEmailStatus");
            var result = await function.CallAsync<int>(emailId).ConfigureAwait(false);

            return result;
        }
    }
}
