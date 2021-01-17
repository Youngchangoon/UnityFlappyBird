using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class LevelData
{
    public float spawnIntervalSec;
    public float scrollSpeed;
    public float holeSize;
}


[CreateAssetMenu(fileName = "GameSetting", menuName = "BirdGame/Setting", order = 1)]
public class GameSetting : ScriptableObject
{
    public LevelData levelData;
    public float jumpPower;
}