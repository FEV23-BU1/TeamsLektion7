﻿namespace Client;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Shared.IConnection connection = Shared.SocketConnection.Connect(
            new byte[] { 127, 0, 0, 1 },
            27800
        );

        connection.Send(new Shared.RegisterUserMessage("Ironman", "stark123"));
        connection.Send(new Shared.LoginMessage("Ironman", "stark123"));
        connection.Send(new Shared.RegisterUserMessage("Ironman", "stark123"));
    }
}
