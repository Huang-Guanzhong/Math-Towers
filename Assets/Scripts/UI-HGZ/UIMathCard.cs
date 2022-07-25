using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIMathCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    // Mask Image
    private Image maskImg;

    //Cooldown Time: Seconds betwwen putting each math card
    public float CDTime;

    //CurrentTime: Using for calculating the CD
    private float currTimeForCD;

    //Whether to be able to put the math card
    private bool canPlace;

    //Whether needed to place the tower
    private bool wantPlace;

    //The real tower
    private GameObject tower;

    //The transparent tower in grid
    private GameObject towerInGrid;

    void Start()
    {
        maskImg = transform.Find("Mask").GetComponent<Image>();
        CanPlace = false;
    }

    private void Update()
    {
        //If Want to place the tower and the tower is not empty
        if (WantPlace && tower != null)
        {
            //Let tower follow the mouse
            Vector3 mousepoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tower.transform.position = new Vector3(mousepoint.x, mousepoint.y, 0);

            //If it is close to a grid, a transparent tower should be created
            if (Vector2.Distance(mousepoint, GridManager.Instance.GetGridPointByMouse()) < 1.5f)
            {
                if (towerInGrid == null)
                {
                    towerInGrid = GameObject.Instantiate<GameObject>(tower, GridManager.Instance.GetGridPointByMouse(),Quaternion.identity, TowerManager.Instance.transform);
                    towerInGrid.GetComponent<SampleTowers>().InitForCreate(true);
                }
                else
                {
                    towerInGrid.transform.position = GridManager.Instance.GetGridPointByMouse();
                }

            }

            else
            {
                if (towerInGrid != null)
                {
                    Destroy(towerInGrid.gameObject);
                    towerInGrid = null;
                }
                
            }

            //Click Mouse left key to place the tower
            if (Input.GetMouseButtonDown(0))
            {
                tower.transform.position = GridManager.Instance.GetGridPointByMouse();
                tower.GetComponent<SampleTowers>().InitForPlace();
                tower = null;
                Destroy(towerInGrid.gameObject);
                towerInGrid = null;
                wantPlace = false; 
            }
        }
    }

    public bool CanPlace { get => canPlace;
        set { 
            canPlace = value;
            //Cannot be placed
            if (!canPlace)
            {
                //Full Mask means cannot plant
                maskImg.fillAmount = 1;
                //Start cooling down
                CDEnter();
            }
            else
            {
                maskImg.fillAmount = 0;
            }
        }
    }

    public bool WantPlace  { get => wantPlace;
        set
        {
            wantPlace = value;
            if (wantPlace)
            {
                GameObject prefab = TowerManager.Instance.GetTowerForType(TowerType.SampleTower);
                tower = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity, TowerManager.Instance.transform);
                tower.GetComponent<SampleTowers>().InitForCreate(false);
            }
            else
            {
                if (tower != null)
                {
                    Destroy(tower.gameObject);
                    tower = null;
                }              
            }
        }
    }

    /// <summary>
    /// Enter CD period
    /// </summary>
    private void CDEnter()
    {
        //After full mask, start calculate CD
        StartCoroutine(CalCD());
        
    }

    /// <summary>
    /// Calculate CD Time
    /// </summary>
    /// <returns></returns>
    IEnumerator CalCD()
    {

        float calCD = (1 / CDTime) * 0.1f;
        currTimeForCD = CDTime;
        while (currTimeForCD >= 0)
        {
            yield return new WaitForSeconds(0.1f);
            maskImg.fillAmount -= calCD;
            currTimeForCD -= 0.1f;
        }

        //Cool Down is over
        CanPlace = true;

    }

    // Mouse move in
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector2(1.1f, 1.1f);
    }

    //Mouse Move out
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector2(1f, 1f);
    }

    public void OnPointerClick(PointerEventData eventdata)
    {
        if (!CanPlace) return;
        if (!WantPlace)
        {
            WantPlace = true;
        }
    }

}
