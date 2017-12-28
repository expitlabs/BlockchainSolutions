
*pragma solidity ^0.4.0;

contract KeysExchange {
    address contractOwner;

    mapping(string => address) emailsIds;
    mapping(string => address) emailsSendersList;
    mapping(string => string) emailsHashes;
    mapping(string => string) emailsKeys;
    mapping(string => string) emailsEncryptionPublicKeys;
    mapping(string => int) emailsStatus;


        function KeysExchange() public{
        contractOwner = msg.sender;
    }

    function uploadEmailId(address recipientAddress, string eId) public returns(string){
        if(isEmptyString(eId) == false){
                emailsIds[eId] = recipientAddress ;
                emailsSendersList[eId] = msg.sender;
                emailsStatus[eId] = 0;
                return "Email Id was added successfully!"; 
        }
        else 
            return "Please enter a valid Email ID.";
    }

    function confirmReceivalAndUploadEmailHash(string eId, string eHash, string ePublicKey) public returns(string) {
        if(isEmptyString(eId) == false){
                if(emailsIds[eId] == msg.sender) {
                emailsHashes[eId] = eHash;
                emailsEncryptionPublicKeys[eId] = ePublicKey;
                emailsStatus[eId] = 1;
                return "Email hash and encryption key were added successfully!"; 
                }
        }
        else 
            return "Please enter a valid Email Id.";
    }

    function getEmailHash(string eId) public returns(string){
        if(isEmptyString(eId) == false){
            if(isEmptyString(emailsHashes[eId]) == false){
                    emailsStatus[eId] = 2;
                return emailsHashes[eId];
            }
        } 
        return "No email hash found.";
    }

    function getEmailEncryptionPublicKey(string eId) public returns(string){
        if(isEmptyString(eId) == false){
            if(isEmptyString(emailsEncryptionPublicKeys[eId]) == false){
                    emailsStatus[eId] = 2;
                return emailsEncryptionPublicKeys[eId];
            }
        } 
        return "No encryption public key found.";
    }

    function confirmEmailHash(address recipientAddress, string eId, string ekey) public returns(string){
        if(isEmptyString(eId) == false){
                if(emailsIds[eId] == recipientAddress){
                emailsKeys[eId] = ekey;
                    emailsStatus[eId] = 3;
                return "Email encryption key was added successfully!"; 
                }
        }
        else 
            return "No email found. Enter a valid email Id.";
    }

    function getEmailKey(string eId) public returns(string){
        if(isEmptyString(eId) == false){
            emailsStatus[eId] = 4;
            return emailsKeys[eId]; 
        }
        else 
            return "Enter a valid email Id.";
    }

    function updateEmailStatus(string eId) view public returns(int){
        return  emailsStatus[eId];
    }

    function isEmptyString(string key) pure public returns(bool){
        bytes memory tempKey = bytes(key);
        if(tempKey.length == 0)
            return true;
        else
            return false;
    }

    function isEmptyAddress(address recipientAddress) pure public returns(bool){
        if(recipientAddress == address(0))
            return true;
        else
            return false;
    }

        function kill() public{ 
        if (msg.sender == contractOwner){
            selfdestruct(contractOwner);  // kills this contract and sends remaining funds back to creator
        }
        }
}
