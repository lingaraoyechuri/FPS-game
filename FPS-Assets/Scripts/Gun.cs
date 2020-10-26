using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script helps to release the bullet from gun with velocity and sound
public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public AudioSource audioSource;
    public ParticleSystem GunParticles;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Objectpool.SharedInstance.GetPooledObject();
            newBullet.transform.position = transform.position + transform.up;
            newBullet.GetComponent<Rigidbody>().velocity = transform.up*30;
            newBullet.SetActive(true);
            Instantiate(GunParticles, transform.position, Quaternion.identity);
            audioSource.Play();

        }

    }
}
