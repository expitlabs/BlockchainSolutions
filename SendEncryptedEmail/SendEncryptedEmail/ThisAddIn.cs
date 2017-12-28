using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using Nethereum.Web3;

namespace SendEncryptedEmail
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //var web3 = new Nethereum.Web3.Web3("https://ropsten.infura.io");
            //var address = "0x22160c2eb00035ded6420d3966ec2ef7e0c0681b";
            //string abi = @"[{""constant"":false,""inputs"":[{""name"":""recipientAddress"",""type"":""address""}],""name"":""isEmptyAddress"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":false,""type"":""function""},{""constant"":false,""inputs"":[{""name"":""key"",""type"":""string""}],""name"":""isEmptyKey"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":false,""type"":""function""},{""constant"":false,""inputs"":[{""name"":""isReceived"",""type"":""bool""}],""name"":""receivalConfirmation"",""outputs"":[{""name"":"""",""type"":""string""}],""payable"":false,""type"":""function""},{""constant"":false,""inputs"":[{""name"":""recipientAddress"",""type"":""address""},{""name"":""key"",""type"":""string""}],""name"":""uploadKey"",""outputs"":[{""name"":"""",""type"":""string""}],""payable"":false,""type"":""function""},{""inputs"":[],""payable"":false,""type"":""constructor""}]";
            //var contract = web3.Eth.GetContract(abi, address).Client;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see http://go.microsoft.com/fwlink/?LinkId=506785
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
