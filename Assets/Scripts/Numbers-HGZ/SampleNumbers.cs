using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleNumbers : MonoBehaviour
{
    private Grid currGrid;
    //Determin how many seconds to walk one grid
    private float speed = 6;

    // Start is called before the first frame update
    void Start()
    {
        GetGridByVerticalNum(0);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    /// <summary>
    /// Numbers Movement
    /// </summary>
    private void Move()
    {
        if (currGrid == null) return;       
        transform.Translate((new Vector2(-1.33f, 0) * (Time.deltaTime / 1)) / speed);
    }

    /// <summary>
    /// Get a grid, determine which row to appear
    /// </summary>
    /// <param name="verticalNum"></param>
    private void GetGridByVerticalNum(int verticalNum)
    {
        currGrid = GridManager.Instance.GetGridByVerticalNum(verticalNum);
        transform.position = new Vector3(transform.position.x, currGrid.Position.y);
    }
}

