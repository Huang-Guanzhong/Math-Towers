using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{
    //public string op = null;
    public string num = null;
    public Sprite[] towers;

    void Start() {
        //gameObject.GetComponent<SpriteRenderer>().sprite = towers[0];
    }

    void OnMouseDown() {
        gameObject.GetComponent<SpriteRenderer>().sprite = towers[1];
    }
}
