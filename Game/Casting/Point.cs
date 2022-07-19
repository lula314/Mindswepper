/// <summary>
/// <para>A distance from a relative origin (0, 0).</para>
/// <para>
/// The responsibility of Point is to hold and provide information about itself. Point has a few 
/// convenience methods for scaling and comparing them.
/// </para>
/// </summary>
public class Point
{
    private int x;
    private int y;

    /// <summary>
    /// Constructs a new instance of Point using the given x and y values.
    /// </summary>
    /// <param name="x">The given x value.</param>
    /// <param name="y">The given y value.</param>
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    /// <summary>
    /// Whether or not this Point is equal to the given one.
    /// </summary>
    /// <param name="other">The point to compare.</param>
    /// <returns>True if both x and y are equal; false if otherwise.</returns>
    public bool Equals(Point other)
    {
        return this.x == other.GetX() && this.y == other.GetY();
    }

    /// <summary>
    /// Gets the value of the x coordinate.
    /// </summary>
    /// <returns>The x coordinate.</returns>
    public int GetX()
    {
        return x;
    }

    /// <summary>
    /// Gets the value of the y coordinate.
    /// </summary>
    /// <returns>The y coordinate.</returns>
    public int GetY()
    {
        return y;
    }
    
    /// <summary>
    /// Snaps the point to a grid by factor.
    /// </summary>
    /// <param name="factor">The grid factor (cell size).</param>
    /// <returns>A snapped instance of Point.</returns>
    public Point Snap(int factor)
    {
        int x = (this.x / factor) * factor;
        int y = (this.y / factor) * factor;
        return new Point(x, y);
    }
}
