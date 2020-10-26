using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This script helps to spawn enemies from random places one after another
public class EnemyManagerScript : MonoBehaviour
{   
     public Transform[] spawnPoints;
     public GameObject Enemyprefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnNewEnemy();
    }

    void OnEnable()
    {
        Bullet.OnEnemyKilled+=SpawnNewEnemy;
    }

    void SpawnNewEnemy(){

        int randomNumber = Mathf.RoundToInt(Random.Range(0f, spawnPoints.Length-1 ));
        Instantiate(Enemyprefab, spawnPoints[randomNumber].transform.position, Quaternion.identity);

    }


}
