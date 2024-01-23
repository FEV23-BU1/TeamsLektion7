---
author: Lektion 7
---

# Teams lektion 7

Hej och välkommen!

## Agenda

1. Svar på frågor
2. Repetition
3. ~~Genomgång av inlämnade övningar~~
4. Testning
5. Tips för sockets
6. Handledning

---

# Fråga

Hur lägger man in ett meddelande som är hårdkodat före en `ReadLine` som ska skickas med sockets?

# Svar

Konkatenera meddelandet eller kör `Send` två gånger. Tänk på att meddelandet kan läggas ihop till en `Receive`.

---

# Fråga

Går det att använda `string.Replace("jag", "du")` för att lösa sträng övning 10?

# Svar

Ja, men tänk på att en enda `Replace` bara byter plats åt ena hållet.

```c#
string input = "Hej, jag gillar glass. Vad gillar du?";
string first = input.Replace("jag", "{1}");
string second = first.Replace("du", "{2}");
string finalReplace = second.Replace("{2}", "jag").Replace("{1}", "du");
Console.WriteLine(finalReplace);
```

---

# Fråga

Finns det smidigare sätt att dela upp chattrum än ett per server?

# Svar

Ja. Följande pseudokod kanske ger någon idé:

```c#
public class Room {
    public string Name { get; set; }
    public List<Connection> Connections { get; set; }
}

public class Connection {
    public Socket Socket { get; set; }
    public Room? Room { get; set; }

    public void SendMessage(string message) { ... }
}

public class Program {
    public static void Main() { ... }

    public static void SendMessage(Connection connection, string message) {
        if (connection.Room == null) return;

        foreach (Connection other in connection.Room.Connections) {
            other.SendMessage(message);
        }
    }
}
```

