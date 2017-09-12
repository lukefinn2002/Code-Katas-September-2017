using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RewindSlackerKata
{
    public class ARewindSlackerChatShould
    {
        [TestFixture]
        public class Given_Multiple_Users
        {
            [Test]
            public void When_A_Text_Message_Is_Sent_By_A_User_Then_The_Message_Is_Received_By_The_Other_Users()
            {
                // Arrange
                const string HelloMessage = "Hello";
                var chat = new Chat();
                var user1 = new User();
                var user2 = new User();
                var user3 = new User();
                var textMessage = new TextMessage(HelloMessage);

                // Act
                chat.Register(user1);
                chat.Register(user2);
                chat.Register(user3);
                user1.SendMessage(textMessage);

                // Assert
                Assert.That(user2.Messages, Has.Count.EqualTo(1));
                Assert.That(user2.Messages[0], Is.EqualTo(textMessage));
                Assert.That(user3.Messages, Has.Count.EqualTo(1));
                Assert.That(user3.Messages[0], Is.EqualTo(textMessage));
                Assert.That(textMessage.GetMessage(), Is.EqualTo(HelloMessage));
            }

            [Test]
            public void When_A_Image_Message_Is_Sent_By_A_User_Then_The_Message_Is_Received_By_The_Other_Users()
            {
                //Arrange
                byte[] array = new byte[0];
                var chat = new Chat();
                var user1 = new User();
                var user2 = new User();
                var imageMessage = new ImageMessage(array);

                //act
                chat.Register(user1);
                chat.Register(user2);
                user1.SendMessage(imageMessage);

                //assert
                Assert.That(user2.Messages, Has.Count.EqualTo(1));
                Assert.That(user2.Messages[0], Is.EqualTo(imageMessage));
                Assert.That(imageMessage.GetMessage(), Is.EqualTo(array));
            }
        }
    }

    public class ImageMessage : IMessage
    {
        private readonly byte[] _imageBytes;

        public ImageMessage(byte[] imageBytes)
        {
            _imageBytes = imageBytes;
        }

        public object GetMessage()
        {
            return this._imageBytes;
        }
    }

    public interface IMessage
    {
        object GetMessage();
    }

    public class TextMessage : IMessage
    {
        private readonly string message;

        public TextMessage(string message)
        {
            this.message = message;
        }

        public object GetMessage()
        {
            return this.message;
        }
    }

    public class User
    {
        private Chat chat;
        public List<IMessage> Messages { get; internal set; }

        public User()
        {
            this.Messages = new List<IMessage>();
        }
        public void SetChat(Chat chat)
        {
            this.chat = chat;
        }

        public void SendMessage(IMessage message)
        {
            chat.SendMessage(message);
        }

        public void UserReceivesMessage(IMessage message)
        {
            Messages.Add(message);
        }
    }

    public class Chat
    {
        private List<User> _users;

        public Chat()
        {
            this._users = new List<User>();
        }

        public void SendMessage(IMessage message)
        {
            foreach (var user in this._users)
            {
                user.UserReceivesMessage(message);
            }
        }

        public void Register(User user)
        {
            _users.Add(user);
            user.SetChat(this);
        }
    }
}
