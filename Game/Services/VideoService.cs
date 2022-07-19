using System.Collections.Generic;
using Raylib_cs;


/// <summary>
/// <para>Outputs the game state.</para>
/// <para>
/// The responsibility of the class of objects is to draw the game state on the screen. 
/// </para>
/// </summary>
public class VideoService
{
    /// <summary>
    /// Closes the window and releases all resources.
    /// </summary>
    public void CloseWindow()
    {
        Raylib.CloseWindow();
    }

    /// <summary>
    /// Clears the buffer in preparation for the next rendering. This method should be called at
    /// the beginning of the game's output phase.
    /// </summary>
    public void ClearBuffer()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Raylib_cs.Color.BLACK);
    }

    /// <summary>
    /// Draws the given tile's image on the screen.
    /// </summary>
    /// <param name="file, x, y">The Tile to draw, x coordinate, y coordinate.</param>
    public void DrawTile(Texture2D file, int x, int y) 
    {
        Raylib.DrawTexture(file, x, y, Color.GRAY);
    }
    
    /// <summary>
    /// Copies the buffer contents to the screen. This method should be called at the end of
    /// the game's output phase.
    /// </summary>
    public void FlushBuffer()
    {
        Raylib.EndDrawing();
    }

    /// <summary>
    /// Whether or not the window is still open.
    /// </summary>
    /// <returns>True if the window is open; false if otherwise.</returns>
    public bool IsWindowOpen()
    {
        return !Raylib.WindowShouldClose();
    }

    /// <summary>
    /// Opens a new window with the provided title.
    /// </summary>
    public void OpenWindow()
    {
        Raylib.InitWindow(Constants.MAX_X, Constants.MAX_Y, Constants.TITLE);
        Raylib.SetTargetFPS(Constants.FRAME_RATE);
    }
}
