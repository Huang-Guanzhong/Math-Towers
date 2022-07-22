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
}
