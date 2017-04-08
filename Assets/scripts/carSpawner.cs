using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpawner : MonoBehaviour {

    public GameObject[] cars;
    int carNo;
    public float maxPos = 2.2f;
    public uiManager ui;
    public float delay;
    float timer;
	// Use this for initialization
	void Start () {
        delay = 0.8f;   
        timer = delay;
	}
	 
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
          
        if( timer <= 0)
        {
            Vector3 carPos = new Vector3(Random.Range(-2.2f, 2.2f), transform.position.y, transform.position.z);
            carNo = Random.Range(0,5);
            Instantiate(cars[carNo], carPos, transform.rotation);
            timer = delay;
            
        }    
    }
    void updatelevel()
    {
        ui.levelup();
    }
}
