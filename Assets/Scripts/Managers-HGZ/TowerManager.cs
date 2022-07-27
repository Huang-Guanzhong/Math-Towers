using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerType
{
    //Different types of math towers
    SampleTower, SampleTower2
}

public class TowerManager : MonoBehaviour
{
    public static TowerManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public GameObject GetTowerForType(TowerType type)
    {
        switch (type)
        {
            case TowerType.SampleTower:
                return GameManager.instance.GameConf.SampleTower;
            case TowerType.SampleTower2:
                return GameManager.instance.GameConf.SampleTower2;
        }
        return null;
    }
}






