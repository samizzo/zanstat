using System;
using Zanlib;

namespace Zanstat
{
    class Program
    {
        static string hostname = "localhost";
        static int port = 10666;

        static int Main(string[] args)
        {
            try
            {
               

                return new Program().QueryZandronumServer(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 1;
            }
        }

        public int QueryZandronumServer(string[] args)
        {
            for (var i = 0; i < args.Length; i++)
            {
                if (args[i] == "-runtests")
                    return RunTests();

                if (args[i] == "-server")
                {
                    if (!GetServerArg(i, args))
                        return 1;
                }
            }

            Console.WriteLine($"Connecting to {hostname}:{port} ... ");

            ZandronumRcon Zanlib = new ZandronumRcon(hostname, port);

            for (var i = 0; i < args.Length; i++)
            {
                if (args[i] == "-getname")
                {
                    var serverName = Zanlib.Name.Get();
                    Console.WriteLine($"Server name: {serverName}");
                }
                else if (args[i] == "-getmapname")
                {
                    var mapName = Zanlib.MapName.Get();
                    Console.WriteLine($"Current map: {mapName}");
                }
                else if (args[i] == "-getmaxplayers")
                {
                    var maxPlayers = Zanlib.MaxPlayers.Get();
                    Console.WriteLine($"Max players: {maxPlayers}");
                }
                else if (args[i] == "-getpwads")
                {
                    var pwads = Zanlib.PWads.Get();
                    Console.WriteLine("PWADS:");
                    foreach (var pwad in pwads)
                        Console.WriteLine($"  {pwad}");
                }
                else if (args[i] == "-getiwad")
                {
                    var iwad = Zanlib.Iwad.Get();
                    Console.WriteLine($"IWAD: {iwad}");
                }
                else if (args[i] == "-getskill")
                {
                    var skill = Zanlib.Skill.Get();
                    Console.WriteLine($"Skill: {skill}");
                }
                else if (args[i] == "-getlimits")
                {
                    var limits = Zanlib.Limits.Get();
                    Console.WriteLine($"Limits: {limits}");
                }
                else if (args[i] == "-getplayers")
                {
                    var players = Zanlib.Players.Get();
                    Console.WriteLine("Players:");
                    foreach (var player in players)
                        Console.WriteLine($"  {player}");
                }
                else if (args[i] == "-getteams")
                {
                    var teams = Zanlib.Teams.Get();
                    Console.WriteLine("Teams:");
                    foreach (var team in teams)
                        Console.WriteLine($"  {team}");
                }
                else if (args[i] == "-getdata")
                {
                    var serverName = Zanlib.Name.Get();
                    Console.WriteLine($"Server name: {serverName}");

                    Console.WriteLine("waiting 10 secs...");
                    System.Threading.Thread.Sleep(10000);

                    var players = Zanlib.Players.Get();
                    Console.WriteLine("Teams:");
                    foreach (var player in players)
                        Console.WriteLine($"  {player}");

                    

                    
                }
            }

            return 0;
        }


        private static int RunTests()
        {
            Tests.TestUncompressed();
            Tests.TestCompressed();
            Console.ReadKey();
            return 0;
        }

        private static bool GetServerArg(int i, string[] args)
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
                return true;
            }
            else
            {
                Console.WriteLine("Must specify a server!");
                return false;
            }
        }

    }
}
