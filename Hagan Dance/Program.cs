using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    private const int Plague = 3500;
    private const int Eruption = 6000;
    private const int PlayerStartPoints = 18500;
    private const int HaganStartPoints = 3000000;
    private const int PlayerStartRow = 15 / 2;
    private const int PlayerStartCol = 15 / 2;
    private const int MatrixRows = 15;
    private const int MatrixCols = 15;

    public static void Main()
    {
        double damageToHagan = double.Parse(Console.ReadLine());
        double playerCurrentPoints = PlayerStartPoints;
        double haganCurrentPoints = HaganStartPoints;
        int playerCurrentRow = PlayerStartRow;
        int playerCurrentCol = PlayerStartCol;
        int plagueHitsCount = 2;
        string playerDeathBy = string.Empty;

        while (playerCurrentPoints > 0 && haganCurrentPoints > 0)
        {

            if (plagueHitsCount == 1)
            {
                playerCurrentPoints -= Plague;
                plagueHitsCount = 2;
                playerDeathBy = "Plague Cloud";

                if (playerCurrentPoints <= 0) { haganCurrentPoints -= damageToHagan; break; }
            }

            haganCurrentPoints -= damageToHagan;

            if(haganCurrentPoints <= 0) { break; }

            string[] inputLines = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            string spell = inputLines[0];
            int hitRow = int.Parse(inputLines[1]);
            int hitCol = int.Parse(inputLines[2]);

            if (IsPlayerInDamageArea(playerCurrentRow, playerCurrentCol, hitRow, hitCol))
            {
                string move = TryMovePlayer(playerCurrentRow, playerCurrentCol, MatrixRows, MatrixCols, hitRow, hitCol);

                if (move != string.Empty)
                {
                    switch (move)
                    {
                        case "up":
                            --playerCurrentRow;
                          //haganCurrentPoints -= damageToHagan;
                            break;
                        case "right":
                            ++playerCurrentCol;
                           //haganCurrentPoints -= damageToHagan;
                            break;
                        case "down":
                            ++playerCurrentRow;
                           //haganCurrentPoints -= damageToHagan;
                            break;
                        case "left":
                            --playerCurrentCol;
                          //haganCurrentPoints -= damageToHagan;
                            break;
                    }
                }
                else
                {
                   //haganCurrentPoints -= damageToHagan;

                    if (haganCurrentPoints > 0)
                    {
                        if (spell == "Cloud")
                        {
                            playerCurrentPoints -= Plague;
                            plagueHitsCount--;
                            playerDeathBy = "Plague Cloud";
                        }
                        else
                        {
                            playerCurrentPoints -= Eruption;
                            playerDeathBy = "Eruption";
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                //haganCurrentPoints -= damageToHagan;
            }
        }

        if (playerCurrentPoints <= 0)
        {
            Console.WriteLine($"Heigan: {haganCurrentPoints:f2}" + Environment.NewLine + $"Player: Killed by {playerDeathBy}" + Environment.NewLine + $"Final position: {playerCurrentRow}, {playerCurrentCol}");
        }
        else if (haganCurrentPoints <= 0)
        {
            Console.WriteLine($"Heigan: Defeated!" + Environment.NewLine + $"Player: {playerCurrentPoints}" + Environment.NewLine + $"Final position: {playerCurrentRow}, {playerCurrentCol}");
        }
        else if (haganCurrentPoints <= 0 && playerCurrentPoints <= 0)
        {
            Console.WriteLine($"Heigan: Defeated!" + Environment.NewLine + $"Player: Killed by {playerDeathBy}" + Environment.NewLine + $"Final position: {playerCurrentRow}, {playerCurrentCol}");
        }


    }

    private static string TryMovePlayer(int playerCurrentRow, int playerCurrentCol, int MatrixRows, int MatrixCols, int hitRow, int hitCol)
    {
        string move = string.Empty;

        if (playerCurrentRow - 1 >= 0 && playerCurrentRow - 1 < hitRow - 1) { move = "up"; }
        else if (playerCurrentCol + 1 <= MatrixCols - 1 && playerCurrentCol + 1 > hitCol + 1) { move = "right"; }
        else if (playerCurrentRow + 1 <= MatrixRows - 1 && playerCurrentRow + 1 > hitRow + 1) { move = "down"; }
        else if (playerCurrentCol - 1 >= 0 && playerCurrentCol - 1 < hitCol - 1) { move = "left"; }

        return move;
    }


    private static bool IsPlayerInDamageArea(int playerCurrentRow, int playerCurrentCol, int hitRow, int hitCol)
    {
        return ((playerCurrentRow >= hitRow - 1 && playerCurrentRow <= hitRow + 1) && (playerCurrentCol >= hitCol - 1 && playerCurrentCol <= hitCol + 1));
    }
}

