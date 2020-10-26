using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DynamicCrosshair : MonoBehaviour
{
    private RectTransform crosshair;
    public float minSize;
    public float MediumSize;
    public float maxSize;
    public float speed;
    private float currentSize; 

    public Image img1;
    public Color imageColorToBeUsed = Color.green;
    public float currentImageColorAlpha = 0.5f;

    public Camera CamFps;
    public float range = 100f;
    public float damage = 10f;


    void Start()
    {   
        img1 = GetComponent<Image> ();
        crosshair = GetComponent<RectTransform>();
         //Assigning  Color and alpha values to image
        currentImageColorAlpha = img1.color.a;
        img1.color = imageColorToBeUsed;
        
    }


    
    // Update is called once per frame
    void Update()
    {
 
        RaycastHit SeenObj;
        GameObject obj;
        GameObject player;
       
        //Getting th object name seen by player using Raycast method
        if(Physics.Raycast(CamFps.transform.position, CamFps.transform.forward, out SeenObj, range)){

            Debug.Log(SeenObj.transform.name);
            if(SeenObj.transform.name!="Plane")
            {
                obj = GameObject.Find(SeenObj.transform.name);
                player= GameObject.Find("Capsule");
                Debug.Log(obj);
                //Getting the distance between the game object and the player 
                float dist = Vector3.Distance(obj.transform.position, player.transform.position);
                Debug.Log("Distance to object is: " + dist);

                //changing the size of crosshair based on the distance
                if(dist<=10f)
                {
                    currentSize = Mathf.Lerp(currentSize, maxSize, Time.deltaTime * speed );
                }
                else if(dist>10f & dist<=30f)
                {
                    currentSize = Mathf.Lerp(currentSize, MediumSize, Time.deltaTime * speed );
                }
                else
                {
                    currentSize = Mathf.Lerp(currentSize, minSize, Time.deltaTime * speed );
                }


            }

            crosshair.sizeDelta= new Vector2(currentSize, currentSize);
  
            // changing crosshair colour to red if the object is enemy
            EnemyScript enemy1 = SeenObj.transform.GetComponent<EnemyScript>();

            if (enemy1!= null)
            {
                img1.GetComponent<Image>().color = new Color32(255,50,50,250);

            }
            else{
                img1.GetComponent<Image>().color = new Color32(50,250,50,250);
            }


        }        
       
    }
    
}
