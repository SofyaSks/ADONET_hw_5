using ADONET_hw_5;
using System.Xml.Linq;

/*IReadOnlyList<Message> messages = new[]
{
    new Message(100, 1, new DateTime(2024,02,02, 12,0,0), "всем привет!"),
    new Message(101, 2, new DateTime(2024,02,02, 12,5,0), "здаров")
};

new XElement("messages", messages.Select(message => message.ToXml())).Save("messages.xml");


IReadOnlyList<User> users = new[]
{
    new User(1, "Мария","Никишна"),
    new User(2, "Антон","Степанов")
};

new XElement("users", users.Select(user => user.ToXml())).Save("users.xml");*/


IEnumerable<User> users = XElement.Load("users.xml")
    .Elements("user")
    .Select(userNode => User.FromXml(userNode)).ToList();



IEnumerable<Message> messages = XElement.Load("messages.xml")
    .Elements("message")
    .Select(messageNode => Message.FromXml(messageNode)).ToList();



foreach (Message message in messages)
{
    User user = users.Where(user => user.Id == message.UserId).First();

    Console.WriteLine($"{message.DateTime:HH:mm} {user.FirstName} {user.LastName}: {message.Text}");
}


