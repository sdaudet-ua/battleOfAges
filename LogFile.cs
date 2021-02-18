using System.Collections.Generic;
using System.IO;

namespace pa2_sdaudet_ua_1
{
    public class LogFile
    {
        public static void Write(Character player,Character computer,Character winner,List<string> gameplayLog, string filename){
            StreamWriter outFile = new StreamWriter(filename+".txt");//Use filename provided by user. 
            outFile.WriteLine($"Player Stats: {player.GetDetails()}");//Print player details to txt file. 
            outFile.WriteLine($"\nComputer Stats: {computer.GetDetails()}");//Print computer character details to txt file. 
            outFile.WriteLine($"\n{winner.name} won this game with {(winner.health/100).ToString("P1")} health remaining\n");//Print the winner information before printing game log. 
            foreach(string round in gameplayLog){//Print each round's details to a text file. 
                outFile.WriteLine(round);
            }
            outFile.Close();//Close the file. 
        }
    }
}