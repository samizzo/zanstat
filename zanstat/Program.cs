using System;

namespace Zanstat
{
    class Program
    {
        static void Main(string[] args)
        {
            Zanlib.Huffman.Init();

            var hostname = "localhost";
            var port = 10666;

            for (var i = 0; i < args.Length; i++)
            {
                if (args[i] == "-runtests")
                {
                    Tests.TestUncompressed();
                    Tests.TestCompressed();
                    Console.ReadKey();
                    return;
                }
                else if (args[i] == "-server")
                {
                    if (i < args.Length)
                    {
                        var server = args[i + 1];
                        var colon = server.IndexOf(':');
                        if (colon >= 0)
                        {
                            hostname = server.Substring(0, colon);
                            port = int.Parse(server.Substring(colon + 1));
                        }
                        else
                        {
                            hostname = server;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Must specify a server!");
                        return;
                    }
                }
            }

            Console.WriteLine($"Connecting to {hostname}:{port}");
            for (var i = 0; i < args.Length; i++)
            {
                if (args[i] == "-getname")
                {
                    var serverName = Zanlib.Name.Get(hostname, port);
                    Console.WriteLine($"Server name: {serverName}");
                }
                else if (args[i] == "-getmapname")
                {
                    var mapName = Zanlib.MapName.Get(hostname, port);
                    Console.WriteLine($"Current map: {mapName}");
                }
                else if (args[i] == "-getmaxplayers")
                {
                    var maxPlayers = Zanlib.MaxPlayers.Get(hostname, port);
                    Console.WriteLine($"Max players: {maxPlayers}");
                }
                else if (args[i] == "-getpwads")
                {
                    var pwads = Zanlib.Pwads.Get(hostname, port);
                    Console.WriteLine("PWADS:");
                    foreach (var pwad in pwads)
                        Console.WriteLine($"  {pwad}");
                }
                else if (args[i] == "-getiwad")
                {
                    var iwad = Zanlib.Iwad.Get(hostname, port);
                    Console.WriteLine($"IWAD: {iwad}");
                }
                else if (args[i] == "-getskill")
                {
                    var skill = Zanlib.Skill.Get(hostname, port);
                    Console.WriteLine($"Skill: {skill}");
                }
                else if (args[i] == "-getlimits")
                {
                    var limits = Zanlib.Limits.Get(hostname, port);
                    Console.WriteLine($"Limits: {limits}");
                }
                else if (args[i] == "-getplayers")
                {
                    var players = Zanlib.Players.Get(hostname, port);
                    Console.WriteLine("Players:");
                    foreach (var player in players)
                        Console.WriteLine($"  {player}");
                }
                else if (args[i] == "-getteams")
                {
                    var teams = Zanlib.Teams.Get(hostname, port);
                    Console.WriteLine("Teams:");
                    foreach (var team in teams)
                        Console.WriteLine($"  {team}");
                }
            }
        }
    }
}
