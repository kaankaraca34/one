using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        string notificationChannel = Console.ReadLine();
        if (string.IsNullOrEmpty(notificationChannel)) 
        {
            throw new ArgumentException("notification channel not provided");
        }

        notificationChannel= notificationChannel.ToLower().Trim();
        string to = Console.ReadLine();
        string messageSubject = "sample message title";
        
        var messageContent=new StringBuilder();
        messageContent.Append("sample multi line")
        .Append(" message content.")
        .Append(" regards");

        if (notificationChannel == "email")
        {
            SendEmail(to, messageSubject, messageContent.ToString());
        }
        if (notificationChannel == "sms")
        {
            SendSMS(to, messageContent.ToString());
        }
        if (notificationChannel == "push")
        {
            SendNotification(to, messageContent.ToString());
        }
    }
    public static void SendEmail(string to, string subject, string body)
    {
        Logger("email sender worked");
    }
    public static void SendSMS(string to, string message)
    {
        Logger("sms sender worked");
    }
    public static void SendNotification(string to, string message)
    {
        Logger("push notification sender worked");
    }
    public static void Logger(string log)
    {
        string directory = @"c:\logfile\corp\applications\category5";
        Directory.CreateDirectory(directory);
        var logFilePath = @$"{directory}\sender.log";
        var logFile = new FileStream(logFilePath,
        FileMode.OpenOrCreate,
        FileAccess.Write);
        var writer = new StreamWriter(logFile);
        var satır = DateTime.UtcNow.ToString() + ";" + log;
        writer.WriteLine(satır);
        writer.Flush();
        logFile.Close();
    }
}