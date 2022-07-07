using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreateGridsBaseColl();
    }

    // Using Collider to build the grid
    private void CreateGridsBaseColl()
    {
        //Create a prefab grid
        GameObject PrefabGrid = new GameObject();
        PrefabGrid.AddComponent<BoxCollider2D>().size = new Vector2(1, 1.5f);
        PrefabGrid.transform.SetParent(transform);
        PrefabGrid.transform.position = transform.position;
        PrefabGrid.name = 0 + "-" + 0;
    }
}
