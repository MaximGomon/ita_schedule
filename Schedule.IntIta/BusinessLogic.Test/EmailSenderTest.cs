using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schedule.Intita.EmailNotification;
using System.IO;
using System.Collections.Generic;
using System.Net.Mail;

namespace BusinessLogic.Test
{
    [TestClass]
    public class EmailSenderTest
    {
        [TestMethod]
        public void EmailTestFrom()
        {

            ISmtpBehaviour smtpBehaviour =  A.Fake<ISmtpBehaviour>();
             A.CallTo(() => smtpBehaviour.GetClient())
                .Returns(new SmtpClient());
            MailMessageAttachment mailMessageAttachment = new MailMessageAttachment()
            {
                FileName = "SomeFile.txt",
                Base64String = @"SGV5LHlvdSwgbW90aGVyZnVja2VyISE="
            };
            MailMessageAttachment mailMessageAttachment1 = new MailMessageAttachment()
            {
                FileName = "email.txt",
                Base64String = @"Q3JlYXRlIGVtYWlsIG5vdGlmaWNhdGlvbiBhYm91dCBuZXcgb3IgY2hhbmdlZCBldmVu
                                 dC4NCkNyZWF0ZSBuZXcgcHJvamVjdCBmb3IgY29tcG9zaW5nIGFuZCBzZW5kaW5nIGVt
                                 YWlsIG1lc3NhZ2VzLiANCk5leHQgcGFyYW1ldGVycyBuZWVkcyB0byBiZSBzdG9yZWQg
                                 aW4gY29uZmlnIGZpbGU6DQotIHNtdHAgYWRkcmVzcw0KLSBzbXRwIGxvZ2luDQotIHNt
                                 dHAgcGFzc3dvcmQ = "

            };

            var d = Directory.GetCurrentDirectory();
            MailMessageAttachment mailMessageAttachment2 = new MailMessageAttachment()
            {
                FileName = "imagetext.txt",
                Base64String = File.ReadAllText("..\\..\\..\\TestImage\\imagetext.txt") 
            };
            List<MailMessageAttachment> attachments = new List<MailMessageAttachment>() { mailMessageAttachment, mailMessageAttachment1, mailMessageAttachment2 };
            EmailMessage msg = new EmailMessage();
            MailMessage createdMessage =  msg.CreateEmail(null, "tanyablin@gmail.com", "Test", "This is test e-mail for first test", null, null, attachments);

            ////Mock invocation of method GetAll
            //// Test 1 where From is Null
            A.CallTo(() => smtpBehaviour.SendMail(A<MailMessage>.Ignored, A<SmtpClient>.Ignored)).Invokes(x =>
            {
                var message = (MailMessage)x.Arguments[0];
                //asserts
                Assert.IsNull(createdMessage.From);
                Assert.AreEqual(createdMessage.To, message.To);
                Assert.AreEqual(createdMessage.Subject, message.Subject);
                Assert.AreEqual(createdMessage.Attachments, message.Attachments);

            });
            smtpBehaviour.SendMail(createdMessage, null);
        }
        [TestMethod]
        public void EmailTestTo()
        {
            ISmtpBehaviour smtpBehaviour = A.Fake<ISmtpBehaviour>();
            A.CallTo(() => smtpBehaviour.GetClient())
               .Returns(new SmtpClient());
            MailMessageAttachment mailMessageAttachment = new MailMessageAttachment()
            {
                FileName = "SomeFile.txt",
                Base64String = @"SGV5LHlvdSwgbW90aGVyZnVja2VyISE="
            };
            MailMessageAttachment mailMessageAttachment1 = new MailMessageAttachment()
            {
                FileName = "email.txt",
                Base64String = @"Q3JlYXRlIGVtYWlsIG5vdGlmaWNhdGlvbiBhYm91dCBuZXcgb3IgY2hhbmdlZCBldmVu
                                 dC4NCkNyZWF0ZSBuZXcgcHJvamVjdCBmb3IgY29tcG9zaW5nIGFuZCBzZW5kaW5nIGVt
                                 YWlsIG1lc3NhZ2VzLiANCk5leHQgcGFyYW1ldGVycyBuZWVkcyB0byBiZSBzdG9yZWQg
                                 aW4gY29uZmlnIGZpbGU6DQotIHNtdHAgYWRkcmVzcw0KLSBzbXRwIGxvZ2luDQotIHNt
                                 dHAgcGFzc3dvcmQ = "

            };
            MailMessageAttachment mailMessageAttachment2 = new MailMessageAttachment()
            {
                FileName = "imagetext.txt",
                Base64String = File.ReadAllText("..\\..\\..\\TestImage\\imagetext.txt")
            };
            List<MailMessageAttachment> attachments = new List<MailMessageAttachment>() { mailMessageAttachment, mailMessageAttachment1, mailMessageAttachment2 };
            EmailMessage msg = new EmailMessage();
            MailMessage createdMessage = msg.CreateEmail("tanyablin@gmail.com",null, "Test", "This is test e-mail for first test", null, null, attachments);

            ////Mock invocation of method GetAll
            //// Test 2 where To is Null
       
            A.CallTo(() => smtpBehaviour.SendMail(A<MailMessage>.Ignored, A<SmtpClient>.Ignored)).Invokes(x =>
            {
                var message = (MailMessage)x.Arguments[0];
                //asserts
                Assert.IsNull(createdMessage.To);
                Assert.AreEqual(createdMessage.From, message.From);
                Assert.AreEqual(createdMessage.Subject, message.Subject);
                Assert.AreEqual(createdMessage.Attachments, message.Attachments);

            });
            smtpBehaviour.SendMail(createdMessage, null);
        }
        [TestMethod]
        public void EmailTestSubject()
        {
            ISmtpBehaviour smtpBehaviour = A.Fake<ISmtpBehaviour>();
            A.CallTo(() => smtpBehaviour.GetClient())
               .Returns(new SmtpClient());
            MailMessageAttachment mailMessageAttachment = new MailMessageAttachment()
            {
                FileName = "SomeFile.txt",
                Base64String = @"SGV5LHlvdSwgbW90aGVyZnVja2VyISE="
            };
            MailMessageAttachment mailMessageAttachment1 = new MailMessageAttachment()
            {
                FileName = "email.txt",
                Base64String = @"Q3JlYXRlIGVtYWlsIG5vdGlmaWNhdGlvbiBhYm91dCBuZXcgb3IgY2hhbmdlZCBldmVu
                                 dC4NCkNyZWF0ZSBuZXcgcHJvamVjdCBmb3IgY29tcG9zaW5nIGFuZCBzZW5kaW5nIGVt
                                 YWlsIG1lc3NhZ2VzLiANCk5leHQgcGFyYW1ldGVycyBuZWVkcyB0byBiZSBzdG9yZWQg
                                 aW4gY29uZmlnIGZpbGU6DQotIHNtdHAgYWRkcmVzcw0KLSBzbXRwIGxvZ2luDQotIHNt
                                 dHAgcGFzc3dvcmQ = "

            };
            MailMessageAttachment mailMessageAttachment2 = new MailMessageAttachment()
            {
                FileName = "imagetext.txt",
                Base64String = File.ReadAllText("..\\..\\..\\TestImage\\imagetext.txt")
            };
            List<MailMessageAttachment> attachments = new List<MailMessageAttachment>() { mailMessageAttachment, mailMessageAttachment1, mailMessageAttachment2 };
            EmailMessage msg = new EmailMessage();
            MailMessage createdMessage = msg.CreateEmail("tanyablin@gmail.com", "tanyablin@gmail.com", null, "This is test e-mail for first test", null, null, attachments);

            ////Mock invocation of method GetAll
            //// Test 3 where Subject is Null
            A.CallTo(() => smtpBehaviour.SendMail(A<MailMessage>.Ignored, A<SmtpClient>.Ignored)).Invokes(x =>
            {
                var message = (MailMessage)x.Arguments[0];
                //asserts
                Assert.IsNull(createdMessage.Subject);
                Assert.AreEqual(createdMessage.From, message.From);
                Assert.AreEqual(createdMessage.To, message.To);
                Assert.AreEqual(createdMessage.Attachments, message.Attachments);

            });
            smtpBehaviour.SendMail(createdMessage, null);
        }
        



    }
}
