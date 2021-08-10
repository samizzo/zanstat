Zandronum server query library and command-line test program.

Usage:

zanstat <-server hostname:port> [command]

where [command] is one of:

   -getname       Print server name
   -getmapname    Print current map name
   -getmaxplayers Print max players
   -getpwads      Print pwads in use
   -getiwad       Print iwad in use
   -getskill      Print skill setting
   -getlimits     Print various server limits
   -getplayers    Print players currently on the server
   -getteams      Print teams

`-server hostname:port` is required!

Notes:
   * -getteams doesn't currently work! My server returns no data for this command.
   * You may only query the server every `sv_queryignoretime` seconds. If you query too
     frequently, the server will return an error code and the library will throw an
     exception.
