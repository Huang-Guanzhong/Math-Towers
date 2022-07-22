using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerType
{
    SampleTower
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
            default:
                break;
        }
        return null;
    }
}






