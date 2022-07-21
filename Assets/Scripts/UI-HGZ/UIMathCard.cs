using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIMathCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Mask Image
    private Image maskImg;

    //Cooldown Time: Seconds betwwen putting each math card
    public float CDTime;

    //CurrentTime: Using for calculating the CD
    private float currTimeForCD;

    //Whether to be able to put the math card
    private bool canPlace;

    void Start()
    {
        maskImg = transform.Find("Mask").GetComponent<Image>();
        CanPlace = false;
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



}
