using System;


public class Parallel
{
    public enum Visibility
    {
        Hidden,
        Visible,
        Flagged
    }

    static public Visibility [,] parallel = new Visibility [Constants.ROWS + 2, Constants.COLUMNS + 2];

    public Parallel()
    { 
    }

    /// <summary>
    /// sets given parallel position value of hidden
    /// </summary>
    public void SetHidden(int x, int y)
    {
        parallel[y, x] = Visibility.Hidden;
    }
    
    /// <summary>
    /// sets given parallel position value of hidden visible
    /// </summary> 
    public void SetVisible(int x, int y)
    {
        parallel[y, x] = Visibility.Visible;
    }

    /// <summary>
    /// sets given parallel position value of hidden flagged
    /// </summary>
    public void SetFlagged(int x, int y)
    {
        parallel[y, x] = Visibility.Flagged;
    }
}
