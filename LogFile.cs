using System.Collections.Generic;
using System.IO;

namespace pa2_sdaudet_ua_1
{
    public class LogFile
    {
        public static void Write(Character player,Character computer,Character winner,List<string> gameplayLog, string filename){
            StreamWriter outFile = new StreamWriter(filename+".txt");
            outFile.WriteLine($"Player Stats: {player.GetDetails()}");
            outFile.WriteLine($"\nComputer Stats: {computer.GetDetails()}");
            outFile.WriteLine($"\n{winner.name} won this game with {(winner.health/100).ToString("P1")} health remaining\n");
            foreach(string round in gameplayLog){
                outFile.WriteLine(round);
            }
            outFile.Close();
        }
    }
}