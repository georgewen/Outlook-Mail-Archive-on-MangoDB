using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MsgVaultWeb
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMsgVaultService" in both code and config file together.
    [ServiceContract]
    public interface IMsgVaultService
    {
        [OperationContract]
        List<MongoMail> GetAllEmails();

        [OperationContract]
        List<MongoMail> GetEmailsPage(int pageIndex,int pageSize);

        [OperationContract]
        void UploadEmail(MongoMail msg);

        [OperationContract]
        void CreateUser(VaultUser user);

        [OperationContract]
        VaultUser GetUserByEmail(string emailaddr);

        [OperationContract]
        void UpdateUser(VaultUser user);

    }
}
