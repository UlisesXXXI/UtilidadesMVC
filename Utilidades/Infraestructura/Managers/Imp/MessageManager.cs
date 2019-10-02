using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utilidades.Infraestructura.Managers.Imp
{

    public enum MessageType
    {
        Error,
        Aviso,
        Normal
    }
    public class Message{
        public string message { get;set;}
        public MessageType MessageType { get; set; }
    }
    

    public class MessageManager
    {
        private List<Message> _messages;
        public bool HasMessages { get { return _messages.Count() > 0 ? true : false; } }
        public List<Message> Messages { get { return _messages; } }

        public MessageManager()
        {
            _messages = new List<Message>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageType"></param>
        public void SetMessage(string message, MessageType messageType)
        {
            if (_messages == null) _messages = new List<Message>();

            _messages.Add(new Message { message = message, MessageType = messageType });

        }

        public void ClearMessages()
        {
            _messages = new List<Message>();
        }



       
    }
}