<b>Why it's needed</b><br/>
Email encryption alone is no longer enough, the ability to track email flow as transactions is becoming a necessity now, especially in cases where business is conducted and real-time validation of email flow is required.  Think billing, invoicing, and contract exchange.  We also need a stronger authentication mechanism for user identities. Securing email accounts as we do in cryptocurrency wallets for critical transactions is a necessity today.

In practice, email encryption today is implemented on the email provider level in most cases, GMAIL to YAHOO, etc.  This approach provides in transit security for emails only; it does not take into account many other exposure levels that centralization brings to the table. Additionally, tracking and investigating email transactions is also a complex task today, often requiring access to many internal email platforms and reviewing large amounts of logs for traces of email exchange evidence.  Utilizing email as a tamper proof platform legal exchange medium is held back by this limitation. 

EXPIT research addresses these challenges of with a simple modification to how existing emails can work when we augment SMTP with Blockchain as an additional security layer. EXPIT’s Registered Email solution gives the needed option to the user to send an email through the secured or a regular channel. 

<b>How it works </b><br/>
We developed two distinct components to augment email security </br>
1- An outlook plugin that connects to a Blockchain (in this case the Ethereum Ropsten Testnet) </br>
2- A smart contract on Ethereum </br>

<b>Outlook plugin</b><br/>

The Outlook plugin is responsible for handling all activities taking place between the Blockchain and the email client including sending/receiving mechanisms. We chose Outlook due to its popularity and ability to be enhanced via simple plug-ins.
We built the plugin using .NET(C#), Ethereum supports this approach via Nethereum, a.NET integration library for Ethereum, this approach also allowed us to interact with Ethereum clients like geth, eth or parity using RPC.

While designing the plug-in we took into consideration not to alter any behavior Outlook users are used to while sending or receiving emails. So, the main entry points for our plugin are embedded within the new-email and read-email screens. </br>
The plugin is designed to ensure the below features:</br>
&nbsp;&nbsp;&nbsp;<b>•	Security:</b></br>
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;o	“Rijndael Symmetric Encryption Algorithm” is used as our email content encryption algorithm.</br>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;o	“RSA Asymmetric Encryption Algorithm” is used to encrypt the shared key. This allows us to protect the shared key during transit via the Blockchain.</br>
&nbsp;&nbsp;&nbsp;<b>•	Integrity:</b></br>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;o	After the original email with its attachments (if any) are encrypted. We then use the “SHA256 Algorithm” to hash the encrypted email.</br>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;o	Hashing acts as an insurance policy for both the sender and recipient to detect any alteration attempts while emails are in   transit </br>
&nbsp;&nbsp;&nbsp;<b>•	Trackability:</b></br>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;o	All validations, key exchanges, and audit trails take place via the BlockChain, creating a proof of transaction per email.</br>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;o	The current email status is updated by referencing the BlockChain contract on each side of the transaction (sender/recipient).</br>



