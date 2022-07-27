using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// The Base Category of the tower
/// </summary>
public abstract class TowerBase : MonoBehaviour
{
    //protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    protected Grid currGrid;

    /// <summary>
    /// FInd relative components
    /// </summary>
    protected void Find()
    {
        //animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Initialization When Creating
    /// </summary>
    public void InitForCreate(bool inGrid)
    {
        Find();
        //animator.speed = 0;
        if (inGrid)
        {
            spriteRenderer.sortingOrder = -1;
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            spriteRenderer.sortingOrder = 1;
        }
    }
    /// <summary>
    /// Initialization When Placing
    /// </summary>
    /// <returns></returns>
    public void InitForPlace(Grid grid)
    {
        //animator.speed = 1;
        currGrid = grid;
        currGrid.CurrTowerBase = this;
        transform.position = grid.Position;
        spriteRenderer.sortingOrder = 0;
        OnInitForPlace();
    }

    protected virtual void OnInitForPlace() 
    {

    }


}
