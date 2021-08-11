using System;
using System.Collections.Generic;
using System.Text;

namespace Zanlib
{
    public partial class ZandronumRcon
    {
        
        private readonly NetworkHelper networkHelper;

        public ZandronumRcon(string ServerName = "localhost", int Port = 10666)
        {
            networkHelper = new NetworkHelper(ServerName, Port);

            Iwad = new Iwad(networkHelper);
            Limits = new Limits(networkHelper);
            MapName = new MapName(networkHelper);
            MaxPlayers = new MaxPlayers(networkHelper);
            Name = new Name(networkHelper);
            Players = new Players(networkHelper);
            PWads = new Pwads(networkHelper);
            Skill = new Skill(networkHelper);
            Teams = new Teams(networkHelper);
        }

        
        public Iwad Iwad { get; private set; }
        public Limits Limits { get; private set; }
        public MapName MapName { get; private set; }
        public MaxPlayers MaxPlayers { get; private set; }
        public Name Name { get; private set; }
        public Players Players { get; private set; }
        public Pwads PWads { get; private set; }
        public Skill Skill { get; private set; }
        public Teams Teams { get; private set; }
    }

}
