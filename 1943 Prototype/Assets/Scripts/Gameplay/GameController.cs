using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Character playerPrefab;
    public EnemiesWave wave;

    Character character;

    public void StartGame()
    {
        character = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        character.OnDeath += OnCharacterDeath;

        wave.StartSpawingEnemiesWaves();
    }

    private void OnCharacterDeath()
    {
        character.OnDeath -= OnCharacterDeath;
        Vector3 pos = character.transform.position;
        StartCoroutine(ReSpawnPlayerAt(pos));
    }

    IEnumerator ReSpawnPlayerAt(Vector3 pos)
    {
        yield return new WaitForSeconds(1);
        character = Instantiate(playerPrefab, pos, Quaternion.identity);
        character.OnDeath += OnCharacterDeath;
    }

    public void Replay()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
}
