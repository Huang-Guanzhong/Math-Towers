using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameConf GameConf { get; private set; }

    private void Awake()
    {
        instance = this;
        GameConf = Resources.Load<GameConf>("GameConf");
    }
}

