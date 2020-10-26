using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This script helps to destroy enemys and to remove bullets from game after 3 seconds of launch.
public class Bullet : MonoBehaviour
{

    float timeAlive = 0f;
    public delegate void enemyKilled();
    public static event enemyKilled OnEnemyKilled;
    public ParticleSystem deathParticles;

    // Update is called once per frame
    void Update()
    {
        timeAlive+=Time.deltaTime;
        if(timeAlive>3)
        {
            gameObject.SetActive(false);
            timeAlive=0f;
        }

    }  

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemypre(Clone)")
        {   
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);

            if(OnEnemyKilled != null)
            {
                OnEnemyKilled();
            }
        }

    }


}
