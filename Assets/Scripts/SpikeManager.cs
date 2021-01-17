using UnityEngine;
using System.Collections;

public class SpikeManager : MonoBehaviour
{
    [SerializeField] private GameSetting gameSetting;

    public Spike spikePrefab;
    //public float spawnInterval;
    //public float scrollSpeed;
    //public float holeSize;

    private float _birdPosX;
    private LevelData _levelData;


    public void Init()
    {
        _levelData = gameSetting.levelData;
        _birdPosX = GameObject.Find("Bird").transform.position.x;

        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while(true)
        {
            CreateSpike();
            yield return new WaitForSeconds(_levelData.spawnIntervalSec);
        }
    }

    private void CreateSpike()
    {
        var newSpike = Instantiate(spikePrefab, transform);
        newSpike.transform.localPosition = new Vector3(10f, 0f);
        newSpike.Init(_levelData.holeSize, _levelData.scrollSpeed, _birdPosX);
    }
}
