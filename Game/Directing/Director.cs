using System;


public class Director
{
    Matrix matrix = new Matrix();
    Parallel parallel = new Parallel();
    static Board board = new Board();
    static VideoService videoService = new VideoService();
    
    // for my own entertainment
    string fish = "dead";
    int taco = 8;

    /// <summary>
    /// Begins game play and displays game board
    /// </summary>
    static public void StartGame()
    {
        board.PrintBoard();
    }

    /// <summary>
    /// Adjusts gameCheck upon game loss
    /// </summary>
    /// <param name="gameCheck">bool determines if game play continues</param>
    static public bool LoseGame(bool gameCheck)
    {
        return gameCheck = false;
    }

    /// <summary>
    /// Adjusts gameCheck upon game win
    /// </summary>
    /// <param name="gameCheck">bool determines if game play continues</param>
    static public bool WinGame(bool gameCheck)
    {
        return gameCheck = false;
    }
}
