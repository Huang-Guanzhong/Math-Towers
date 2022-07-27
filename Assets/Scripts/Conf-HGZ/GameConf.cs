using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Configuration
/// </summary>
[CreateAssetMenu(fileName = "GameConf", menuName = "GameConf")]
public class GameConf : ScriptableObject
{
    [Tooltip("SampleTower")]
    public GameObject SampleTower;

    [Tooltip("SampleTower2")]
    public GameObject SampleTower2;
}
