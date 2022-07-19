using System.Collections.Generic;
using Raylib_cs;


public class MouseService
{
    private Dictionary<string, Raylib_cs.MouseButton> buttons
            = new Dictionary<string, Raylib_cs.MouseButton>() {
        { "left", Raylib_cs.MouseButton.MOUSE_LEFT_BUTTON },
        { "right", Raylib_cs.MouseButton.MOUSE_RIGHT_BUTTON }
    };

    /// <summary>
    /// Gets the current mouse cursor coordinates.
    /// </summary>
    /// <returns>The mouse cursor coordinates.</returns>
    public Point GetCoordinates()
    {
        int x = Raylib.GetMouseX();
        int y = Raylib.GetMouseY();
        return new Point(x, y);
    }

    /// <summary>
    /// Whether or not the given button has been released.
    /// </summary>
    /// <param name="button">The given button.</param>
    public bool IsButtonReleased(string button)
    {
        Raylib_cs.MouseButton raylibButton = buttons[button.ToLower()];
        return Raylib.IsMouseButtonReleased(raylibButton);
    }
}
