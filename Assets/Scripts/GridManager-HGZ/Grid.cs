using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    //Corordinate point, (1,0), (0,1)
    public Vector2 Point;

    //WorldPoint
    public Vector2 Position;

    //Whether already have obejct on the grid, if yes, then cannot add another one
    public bool HaveObject;

    public Grid(Vector2 point, Vector2 position, bool haveObject)
    {
        Point = point;
        Position = position;
        HaveObject = haveObject;
    }
}
