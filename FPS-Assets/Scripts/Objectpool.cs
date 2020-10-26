using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectpool : MonoBehaviour
{
    // Start is called before the first frame update
    public static Objectpool SharedInstance;
    public List<GameObject> pooledobjects;
    public GameObject ObjectTopool;
    public int amountToPool;
    private void Awake()
    {
        SharedInstance = this;
    }
    void Start()
    {
        pooledobjects = new List<GameObject>();
        for(int i=0; i<amountToPool; i++){
            GameObject obj = (GameObject)Instantiate(ObjectTopool);
            obj.SetActive(false);
            pooledobjects.Add(obj);
        }
        
    }
    public GameObject GetPooledObject()
    {
        for (int i=0;i<pooledobjects.Count; i++){
            if(!pooledobjects[i].activeInHierarchy){
                return pooledobjects[i];
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
