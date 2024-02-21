using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ADONET_hw_5
{
    internal class Message
    {
        public int MessageId { get; }
        public int UserId { get; }
        public DateTime DateTime { get; }
        public string Text { get; }

        public Message(int messageId, int userId, DateTime dateTime, string text)
        {
            MessageId = messageId;
            UserId = userId;
            DateTime = dateTime;
            Text = text;
        }

        public XElement ToXml() =>
            new XElement("message",
                new XAttribute("id", MessageId),
                new XElement("userId", UserId),
                new XElement("datetime", DateTime),
                new XElement("text", Text));


        public static Message FromXml(XElement node) =>
    new Message(
        (int)node.Attribute("id"),
        (int)node.Element("userId"),
        (DateTime)node.Element("datetime"),
        (string)node.Element("text")
    );

        public override string ToString()
        {
            return $"{DateTime.ToString("HH:mm")} {Text}";
        }

    }




}
