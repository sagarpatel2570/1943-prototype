using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesWave : MonoBehaviour
{
    public List<WaveInfo> waves;

    int numberOfEnemiesPerSetLeft;
    int numberOfSetsPerWaveLeft;

    private void Start()
    {
        StartCoroutine(SpawnEnemiesWave());
    }

    IEnumerator SpawnEnemiesWave()
    {
        for (int i = 0; i < waves.Count; i++)
        {
            WaveInfo currentWaveInfo = waves[i];
            numberOfEnemiesPerSetLeft = currentWaveInfo.numberOfEnemiesPerSet;
            numberOfSetsPerWaveLeft = currentWaveInfo.numberOfSet;
            List<PathInfo> pathToTake = new List<PathInfo>(currentWaveInfo.pathCreator.paths);
            pathToTake.Shuffle();
            int numberOfPathToConsider = Random.Range(1, pathToTake.Count);
            List<GameObject> enemiesPrefab = new List<GameObject>();
            for (int k = 0; k < numberOfPathToConsider; k++)
            {
                enemiesPrefab.Add(currentWaveInfo.enemies[Random.Range(0, currentWaveInfo.enemies.Count)]);
            }
            while (numberOfSetsPerWaveLeft > 0)
            {
                numberOfSetsPerWaveLeft--;
                numberOfEnemiesPerSetLeft = currentWaveInfo.numberOfEnemiesPerSet;
                while (numberOfEnemiesPerSetLeft > 0)
                {
                    for (int j = 0; j < numberOfPathToConsider; j++)
                    {
                        GameObject g = SimplePool.Spawn(enemiesPrefab[j], Vector3.zero, Quaternion.identity);
                        g.transform.SetParent(transform);
                        g.GetComponent<ICharacterMovement>().Init(pathToTake[j]);
                        numberOfEnemiesPerSetLeft--;
                        yield return new WaitForSeconds(currentWaveInfo.timeBetweenEnemiesSpawn);
                    }
                }
                yield return new WaitForSeconds(currentWaveInfo.timeBetweenSet);
            }
        }
        Debug.LogError("Waves Finished ");
    }

}

[System.Serializable]
public class WaveInfo
{
    public PathCreator pathCreator;
    public List<GameObject> enemies;
    public int numberOfEnemiesPerSet;
    public int numberOfSet;
    public float timeBetweenSet;
    public float timeBetweenEnemiesSpawn;
    public int nextWaveTime;
}
