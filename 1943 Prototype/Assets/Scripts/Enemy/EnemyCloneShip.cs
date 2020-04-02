using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloneShip : MonoBehaviour
{
    public PathInfo leftPath;
    public PathInfo rightPath;
    public Character enemeyPrefab; 
    public float delayBetweenShipSpawn;

    public void StartCloningShip()
    {
        StopCloningShip();
        StartCoroutine(CloneEnemyShip());
    }

    IEnumerator CloneEnemyShip()
    {
        while(true)
        {
            EnemyMovement enemyLeft = SimplePool.Spawn(
                enemeyPrefab.gameObject, transform.position, Quaternion.identity).GetComponent<EnemyMovement>();
            enemyLeft.Init(leftPath);

            EnemyMovement enemyRight = SimplePool.Spawn(
                enemeyPrefab.gameObject, transform.position, Quaternion.identity).GetComponent<EnemyMovement>();
            enemyRight.Init(rightPath);

            yield return new WaitForSeconds(delayBetweenShipSpawn);
        }
    }

    public void StopCloningShip()
    {
        StopAllCoroutines();
    }

    private void OnDrawGizmos()
    {
        if(leftPath != null)
        {
            leftPath.DrawGizmos();
        }

        if (rightPath != null)
        {
            rightPath.DrawGizmos();
        }
    }
}
