using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesWave : MonoBehaviour
{
    public List<WaveInfo> waves;

    public Character bossPrefab;
    public PathInfo bossPath;

    public bool debug;

    int numberOfEnemiesPerSetLeft;
    int numberOfSetsPerWaveLeft;

    private void Start()
    {
        if (debug)
        {
            StartCoroutine(SpawnEnemiesWave());
        }
    }

    public void StartSpawingEnemiesWaves()
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
            
            while (numberOfSetsPerWaveLeft > 0)
            {
                int numberOfPathToConsider = Random.Range(1, pathToTake.Count);
                if (currentWaveInfo.chooseAllPath)
                {
                    numberOfPathToConsider = pathToTake.Count;
                }
                List<GameObject> enemiesPrefab = new List<GameObject>();
                for (int k = 0; k < numberOfPathToConsider; k++)
                {
                    enemiesPrefab.Add(currentWaveInfo.enemies[Random.Range(0, currentWaveInfo.enemies.Count)]);
                }

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
        yield return new WaitForSeconds(5);
        EnemyMovement boss = SimplePool.Spawn(
               bossPrefab.gameObject, transform.position, Quaternion.identity).GetComponent<EnemyMovement>();
        boss.Init(bossPath);

        boss.gameObject.GetComponent<Character>().OnDeath += OnBossDead;

    }

    private void OnBossDead()
    {
        GUIPanelController.Instance.ChangeState(PanelType.GAMEWINPANEL);
    }

    private void OnDrawGizmos()
    {
        if (bossPath != null)
        {
            bossPath.DrawGizmos();
        }
    }

}

[System.Serializable]
public class WaveInfo
{
    public PathCreator pathCreator;
    public List<GameObject> enemies;
    public bool chooseAllPath;
    public int numberOfEnemiesPerSet;
    public int numberOfSet;
    public float timeBetweenSet;
    public float timeBetweenEnemiesSpawn;
    public int nextWaveTime;
}
