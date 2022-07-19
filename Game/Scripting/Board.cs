using System;
using Raylib_cs;


// Raylib.InitWindow(1044, 812, "Mindswepper");
// Raylib.SetTargetFPS(60);
// Raylib_cs.Texture2D tile = Raylib.LoadTexture("Assets/Tile.png");

// while (!Raylib.WindowShouldClose())
// {
//     Raylib.BeginDrawing();
//     Raylib.ClearBackground(Color.WHITE);
//     // Raylib.DrawRectangle(100, 100, 300, 300, Color.RED);
//     Raylib.DrawTexture(tile, 0, 0, Color.WHITE);
//     Raylib.EndDrawing();
// }

public class Board
{
    VideoService videoService = new VideoService();
    MouseService mouseService = new MouseService();

    bool gameCheck = true;
    int unflagged;

    /// <summary>
    /// Watches for mouse input
    /// </summary>
    public void Input()
    {
        // when left mouse button is released
        if (mouseService.IsButtonReleased("left"))
        {
            Point coordinates = mouseService.GetCoordinates();
            Point snappedCoordinates = coordinates.Snap(Constants.CELL_SIZE);
            int posX = snappedCoordinates.GetX() / Constants.CELL_SIZE + 1;
            int posY = snappedCoordinates.GetY() / Constants.CELL_SIZE + 1;
            UpdateParallel("left", posX, posY);
        }
        // when right mouse button is released
        else if (mouseService.IsButtonReleased("right"))
        {
            Point coordinates = mouseService.GetCoordinates();
            Point snappedCoordinates = coordinates.Snap(Constants.CELL_SIZE);
            int posX = snappedCoordinates.GetX() / Constants.CELL_SIZE + 1;
            int posY = snappedCoordinates.GetY() / Constants.CELL_SIZE + 1;
            UpdateParallel("right", posX, posY);
        }
    }

    /// <summary>
    /// Adjusts tile visibility upon mouse click
    /// </summary>
    /// <param name="button, posX, posY">which mouse button was clicked, x coordinate, y coordinate.</param>
    public void UpdateParallel(string button, int posX, int posY)
    {
        // adjust visibility of tile upon left click
        if (button == "left")
        {
            if (Parallel.parallel[posY, posX] == Parallel.Visibility.Hidden)
            {
                Parallel.parallel[posY, posX] = Parallel.Visibility.Visible;
                // if (Matrix.matrix[posY, posX] == 0)
                // {
                //     RevealZero(posX, posY);
                // }
            }
            // if bomb is left clicked end game
            if (Matrix.matrix[posY, posX] == -1)
            {
                gameCheck = Director.LoseGame(gameCheck);
            }
        }
        // adjust visibility of tile upon right click
        else if (button == "right")
        {
            switch(Parallel.parallel[posY, posX])
            {
                case Parallel.Visibility.Visible:
                    break;
                case Parallel.Visibility.Hidden:
                    Parallel.parallel[posY, posX] = Parallel.Visibility.Flagged;
                    break;
                case Parallel.Visibility.Flagged:
                    Parallel.parallel[posY, posX] = Parallel.Visibility.Hidden;
                    break;
            }
        }
    }

    /// <summary>
    /// Iterates through each grid tile and determines which tile to display
    /// </summary>
    public void Output()
    {
        unflagged = 0;
        for (int x = 1; x <= Constants.COLUMNS; x++)
        {
            for (int y = 1; y <= Constants.ROWS; y++)
            {
                int posX = (x - 1) * Constants.CELL_SIZE;
                int posY = (y - 1) * Constants.CELL_SIZE;
                Texture2D file = Tile.tile;
                // draw blank tile for parallel hidden
                if (Parallel.parallel[y, x] == Parallel.Visibility.Hidden)
                {
                    file = Tile.tile;
                }
                // draw flag tile for parallel flagged
                else if (Parallel.parallel[y, x] == Parallel.Visibility.Flagged)
                {
                    file = Tile.tileF;
                }
                // draw appropriate value tile for parallel visible
                else if (Parallel.parallel[y, x] == Parallel.Visibility.Visible)
                {
                    if (Matrix.matrix[y, x] >= 0)
                    {
                        unflagged++;
                    }
                    switch(Matrix.matrix[y, x])
                    {
                        case -1:
                            file = Tile.tileB;
                            break;
                        case 0:
                            file = Tile.tile0;
                            break;
                        case 1:
                            file = Tile.tile1;
                            break;
                        case 2:
                            file = Tile.tile2;
                            break;
                        case 3:
                            file = Tile.tile3;
                            break;
                        case 4:
                            file = Tile.tile4;
                            break;
                        case 5:
                            file = Tile.tile5;
                            break;
                        case 6:
                            file = Tile.tile6;
                            break;
                        case 7:
                            file = Tile.tile7;
                            break;
                        case 8:
                            file = Tile.tile8;
                            break;
                    }
                }
                videoService.DrawTile(file, posX, posY);
            }
        }
        // if all non bomb tiles are visible end game
        if (unflagged == Constants.GRID - Constants.BOMBS)
        {
            gameCheck = Director.WinGame(gameCheck);
        }
    }

    /// <summary>
    /// Reveal all tiles surrounding visible zeros (still buggy)
    /// </summary>
    /// <param name="posX, posY">x position of clicked tile, y position of clicked tile</param>
    public void RevealZero(int posX, int posY)
    {
        if (Matrix.matrix[posY-1, posX-1] == 0 && Parallel.parallel[posY-1, posX-1] == Parallel.Visibility.Hidden)
        {
            Parallel.parallel[posY-1, posX-1] = Parallel.Visibility.Visible;
            RevealZero(posX-1, posY-1);
        }
        else if (Matrix.matrix[posY-1, posX] == 0 && Parallel.parallel[posY-1, posX] == Parallel.Visibility.Hidden)
        {
            Parallel.parallel[posY-1, posX] = Parallel.Visibility.Visible;
            RevealZero(posX, posY-1);
        }
        else if (Matrix.matrix[posY-1, posX+1] == 0 && Parallel.parallel[posY-1, posX+1] == Parallel.Visibility.Hidden)
        {
            Parallel.parallel[posY-1, posX+1] = Parallel.Visibility.Visible;
            RevealZero(posX+1, posY-1);
        }
        else if (Matrix.matrix[posY, posX+1] == 0 && Parallel.parallel[posY, posX+1] == Parallel.Visibility.Hidden)
        {
            Parallel.parallel[posY, posX+1] = Parallel.Visibility.Visible;
            RevealZero(posX+1, posY);
        }
        else if (Matrix.matrix[posY+1, posX+1] == 0 && Parallel.parallel[posY+1, posX+1] == Parallel.Visibility.Hidden)
        {
            Parallel.parallel[posY+1, posX+1] = Parallel.Visibility.Visible;
            RevealZero(posX+1, posY+1);
        }
        else if (Matrix.matrix[posY+1, posX] == 0 && Parallel.parallel[posY+1, posX] == Parallel.Visibility.Hidden)
        {
            Parallel.parallel[posY+1, posX] = Parallel.Visibility.Visible;
            RevealZero(posX, posY+1);
        }
        else if (Matrix.matrix[posY+1, posX-1] == 0 && Parallel.parallel[posY+1, posX-1] == Parallel.Visibility.Hidden)
        {
            Parallel.parallel[posY+1, posX-1] = Parallel.Visibility.Visible;
            RevealZero(posX-1, posY+1);
        }
        else if (Matrix.matrix[posY, posX-1] == 0 && Parallel.parallel[posY, posX-1] == Parallel.Visibility.Hidden)
        {
            Parallel.parallel[posY, posX-1] = Parallel.Visibility.Visible;
            RevealZero(posX-1, posY);
        }
    }

    /// <summary>
    /// Uses Raylib to display game board (buggy but works)
    /// </summary>
    public void PrintBoard()
    {
        videoService.OpenWindow();
        while (videoService.IsWindowOpen())
        {
            while (gameCheck)
            {
                videoService.ClearBuffer();
                Input();
                Output();
                videoService.FlushBuffer();
            }
            videoService.FlushBuffer();
        }
        videoService.CloseWindow();
    }
}