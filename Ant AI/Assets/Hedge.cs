using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hedge : MonoBehaviour {

    // Use this for initialization

    public bool dropped;
	void Start () {
        dropped = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Food"))
        {
            dropped = true;
            Destroy(coll.gameObject);
        }   
    }
}
