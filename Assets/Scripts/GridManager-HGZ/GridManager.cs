using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    private List<Vector2> pointList = new List<Vector2>();
    [SerializeField]
    private List<Grid> gridList = new List<Grid>();


    private void Awake()
    {
        Instance = this;
        CreateGridBaseGrid();
    }
    void Start()
    {
        //CreateGridsBaseColl();
        //CreateGridsBasePointList();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(GetGridPointByMouse());
        }

    }

    // Using Collider to build the grid
    private void CreateGridsBaseColl()
    {
        //Create a prefab grid
        GameObject prefabGrid = new GameObject();
        prefabGrid.AddComponent<BoxCollider2D>().size = new Vector2(1, 1.5f);
        prefabGrid.transform.SetParent(transform);
        prefabGrid.transform.position = transform.position;
        prefabGrid.name = 0 + "-" + 0;

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                GameObject grid = GameObject.Instantiate<GameObject>(prefabGrid, new Vector2(1.33f * i, 1.63f * j), Quaternion.identity, transform);
                grid.name = i + "-" + j;
            }
        }
    }
    
    //Using coordinate list to build the grid
    private void CreateGridsBasePointList()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                pointList.Add(transform.position + new Vector3(1.33f * i, 1.63f * j));
            }
        }
    }

    public Vector2 GetGridPointByMouse()
    {
        return GetGridPointByWorldPos(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    //Using Worldpoint to get the coordinate of the grid
    public Vector2 GetGridPointByWorldPos(Vector2 worldPos)
    {
        return GetGridByWorldPos(worldPos).Position;
    }

    public Grid GetGridByWorldPos(Vector2 worldPos)
    {
        float dis = 10000000;
        Grid grid = null;
        for (int i = 0; i < gridList.Count; i++)
        {
            if (Vector2.Distance(worldPos, gridList[i].Position) < dis)
            {
                dis = Vector2.Distance(worldPos, gridList[i].Position);
                grid = gridList[i];
            }
        }
        return grid;
    }

    //Using Grid Scipts to Create Grid

    private void CreateGridBaseGrid()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                gridList.Add(new Grid(new Vector2(i, j), transform.position + new Vector3(1.33f * i, 1.63f * j), false));
            }
        }
    }

    /// <summary>
    /// By Axix-Y to find a grid, bottom to up, start from o
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    public Grid GetGridByVerticalNum(int verticalNum)
    {
        for (int i = 0; i < gridList.Count; i++)
        {
            if (gridList[i].Point == new Vector2(9, verticalNum))
            {
                return gridList[i];
            }
        }
        return null;
    }
}
  


