using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using OutlookAddIn1.MsgVaultSvc;
using Microsoft.Office.Interop.Outlook;

namespace OutlookAddIn1
{
    public partial class ThisAddIn
    {
        const string PR_ATTACH_DATA_BIN =
                "http://schemas.microsoft.com/mapi/proptag/0x37010102";
        //Outlook.Explorer thisExplorer;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {

            //thisExplorer = Application.ActiveExplorer();
            //thisExplorer.FolderSwitch +=
            //new Microsoft.Office.Interop.Outlook.ExplorerEvents_10_FolderSwitchEventHandler(ThisApplication_SelectionChange);
            //thisExplorer.SelectionChange += 
            //new Microsoft.Office.Interop.Outlook.ExplorerEvents_10_SelectionChangeEventHandler(ThisApplication_SelectionChange);
            
            //TODO: throw error when not connected to exchange server
            //var CurrentUserEmailAddr = this.Application.ActiveExplorer().Session.CurrentUser.AddressEntry.GetExchangeUser().PrimarySmtpAddress;

            var CurrentUserEmailAddr = "george@quantumsys.com.au";

            this.Application.NewMail += new Microsoft.Office.Interop.Outlook.ApplicationEvents_11_NewMailEventHandler(ThisApplication_NewMail);

            string folderName = "QISMsgVault";
            Outlook.MAPIFolder inbox = (Outlook.MAPIFolder)
                this.Application.ActiveExplorer().Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
            // TODO: if folder dones't exist, create it.
            try
            {
                this.Application.ActiveExplorer().CurrentFolder = inbox.Parent.Folders[folderName];
                this.Application.ActiveExplorer().CurrentFolder.WebViewURL = "http://localhost/MsgVaultWeb/Default.htm";
                this.Application.ActiveExplorer().CurrentFolder.WebViewOn = true;
               // this.Application.ActiveExplorer().CurrentFolder.Display();
            }
            catch
            {
                MessageBox.Show("There is no folder named " + folderName +
                    ".", "Find Folder Name");
            }

            //Outlook.MAPIFolder inbox = Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
            Outlook.MailItem moveMail = null;
            Outlook.Items items = (Outlook.Items)inbox.Items;
            
            MsgVaultSvc.MsgVaultServiceClient client = new MsgVaultSvc.MsgVaultServiceClient();
            VaultUser currentUser = client.GetUserByEmail(CurrentUserEmailAddr);
            if (currentUser != null)
            {
                //MessageBox.Show("User exist!");
                if (!currentUser.initialized) //not initialized, import all emails
                {
                    int i = 0;
                    foreach (Object eMail in items)
                    {
                        //export email to temp folder
                        // i++;
                        //MessageBox.Show("processing no. " + i.ToString());                    
                        if (eMail is Outlook.MailItem)
                        {
                            i++;
                            List<string> atts = new List<string>();
                            try
                            {
                                moveMail = eMail as Outlook.MailItem;
                                foreach (Attachment attachment in moveMail.Attachments)
                                {
                                    string retrive_type = attachment.FileName.ToString();
                                    // if (System.IO.Path.GetExtension(attachment.FileName) == ".txt")
                                    //var attachmentData = attachment.PropertyAccessor.GetProperty(PR_ATTACH_DATA_BIN);
                                    atts.Add(retrive_type);
                                }
                                MongoMail msg = new MongoMail()
                                {
                                    Subject = moveMail.Subject,
                                    Categories = moveMail.Categories,
                                    CreationTime = moveMail.CreationTime,
                                    ReceivedTime = moveMail.ReceivedTime,
                                    CC = moveMail.CC,
                                    SenderEmailAddress = moveMail.SenderName,//moveMail.SenderEmailAddress,
                                    Body = moveMail.Body,
                                    To = moveMail.To,
                                    EntryID = moveMail.EntryID,
                                    Attachments = atts.ToArray()

                                };

                                client.UploadEmail(msg); //TODO: need to consider InsertBatch in MongoDB for better performance

                                //if (GetUserProperty((Outlook.MailItem)eMail) == null)
                                //{
                                //    SetUserProperty((Outlook.MailItem)eMail, "3001440");
                                //    ((Outlook.MailItem)eMail).Save();
                                //}

                                //this line cause out of memory issue
                                // moveMail.SaveAs("C:\\temp\\" + moveMail.Subject + ".msg", Outlook.OlSaveAsType.olMSG); //cause out of memory error
                            }
                            catch (System.Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        //if (i > 200)
                        //{
                        //    //MessageBox.Show("Imported !");
                        //    break;
                        //}
                    }
                    currentUser.initialized = true;
                    client.UpdateUser(currentUser);
                }
            }
            else
            {
                //please create the user first
                //MessageBox.Show("User doesn't exist!");
                VaultUser usr = new VaultUser()
                {
                    emailAddress = CurrentUserEmailAddr,
                    initialized = false,
                    CreationTime = DateTime.Now,
                    LastUpdated = DateTime.Now
                };
                client.CreateUser(usr);
            }

        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        private void ThisApplication_NewMail()
        {
            Outlook.MAPIFolder inBox = this.Application.ActiveExplorer()
                .Session.GetDefaultFolder(Outlook
                .OlDefaultFolders.olFolderInbox);
            Outlook.Items inBoxItems = inBox.Items;
            Outlook.MailItem newEmail = null;
            inBoxItems = inBoxItems.Restrict("[Unread] = true");
            try
            {
                foreach (object collectionItem in inBoxItems)
                {
                    newEmail = collectionItem as Outlook.MailItem;
                    Outlook.PropertyAccessor objPA = null;
                    byte[] varX; //Dynamic
                    if (newEmail != null)
                    {
                        if (newEmail.Attachments.Count > 0)
                        {
                            for (int i = 1; i <= newEmail.Attachments.Count; i++)
                            {
                                newEmail.Attachments[i].SaveAsFile(@"C:\TestFileSave\" + newEmail.Attachments[i].FileName);
                                objPA = newEmail.Attachments[i].PropertyAccessor;
                                varX = objPA.GetProperty("http://schemas.microsoft.com/mapi/proptag/0x37010102");
                                //newEmail.Attachments.Add(
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                string errorInfo = (string)ex.Message
                    .Substring(0, 11);
                if (errorInfo == "Cannot save")
                {
                    MessageBox.Show(@"Create Folder C:\TestFileSave");
                }
            }
        }
        //void ThisApplication_SelectionChange()
        //{
        //    string folderName = thisExplorer.CurrentFolder.Name;
        //    MessageBox.Show("Current Folder: " + folderName);
        //}

        private void SetUserProperty(Outlook.MailItem mail, string value)
        {
            mail.UserProperties.Add("ProjectCode", Outlook.OlUserPropertyType.olText,
                true, Outlook.OlFormatText.olFormatTextText);
            mail.UserProperties["ProjectCode"].Value = value;
        }
        private string GetUserProperty(Outlook.MailItem mail)
        {
            if (mail.UserProperties["ProjectCode"] == null)
                return null;
            return (string)mail.UserProperties["ProjectCode"].Value;
        }
        /*
    Dim strMessageClass As String
    Dim oAppointItem As Outlook.AppointmentItem
    Dim oContactItem As Outlook.ContactItem
    Dim oMailItem As Outlook.MailItem
    Dim oJournalItem As Outlook.JournalItem
    Dim oNoteItem As Outlook.NoteItem
    Dim oTaskItem As Outlook.TaskItem
    
    ' You need the message class to determine the type.
    strMessageClass = oItem.MessageClass
    
    If (strMessageClass = "IPM.Appointment") Then       ' Calendar Entry.
        Set oAppointItem = oItem
        MsgBox oAppointItem.Subject
        MsgBox oAppointItem.Start
    ElseIf (strMessageClass = "IPM.Contact") Then       ' Contact Entry.
        Set oContactItem = oItem
        MsgBox oContactItem.FullName
        MsgBox oContactItem.Email1Address
    ElseIf (strMessageClass = "IPM.Note") Then          ' Mail Entry.
        Set oMailItem = oItem
        MsgBox oMailItem.Subject
        MsgBox oMailItem.Body
    ElseIf (strMessageClass = "IPM.Activity") Then      ' Journal Entry.
        Set oJournalItem = oItem
        MsgBox oJournalItem.Subject
        MsgBox oJournalItem.Actions
    ElseIf (strMessageClass = "IPM.StickyNote") Then    ' Notes Entry.
        Set oNoteItem = oItem
        MsgBox oNoteItem.Subject
        MsgBox oNoteItem.Body
    ElseIf (strMessageClass = "IPM.Task") Then          ' Tasks Entry.
        Set oTaskItem = oItem
        MsgBox oTaskItem.DueDate
        MsgBox oTaskItem.PercentComplete
    End If        
         */
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
