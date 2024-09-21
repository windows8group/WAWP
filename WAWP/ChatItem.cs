using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAWP
{
    /// <summary>
    /// Class representing an user account.
    /// </summary>
    public class ChatItem
    {
        public string ImageUri { get; set; }
        public string Name { get; set; }
        public string LastMessage { get; set; }
        public bool isRead { get; set; }
    }

    /// <summary>
    /// Class representing a message.
    /// </summary>
    public class Message
    {
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; }
        public ChatItem Author { get; set; }
        public bool IsFromSelf { get; set; }
    }

    public class MessageCollection: ObservableCollection<Message>
    { }
}
