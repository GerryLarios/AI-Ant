using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHome : MonoBehaviour {

    Grab grab;
    public float radius;
    public LayerMask searchLayers;
    public string tagToLookFor;
    public Collider2D closest;

    // Use this for initialization
    void Start () {
        grab = GetComponent<Grab>();
    }
	
	// Update is called once per frame
	void DoAIBehaviour() {
		if(grab.grabbed == true && this.transform.childCount == 2)
        {
            Detecting();

            Vector3 direction = closest.transform.position - this.transform.position;
            WeightedDirection wd = new WeightedDirection(direction, 5);
            GetComponent<Insects>().desiredDirections.Add(wd);
        }
	}

    void Detecting()
    {
        var objectsHit = Physics2D.OverlapCircleAll(this.transform.position,radius,searchLayers);
        float dist = Mathf.Infinity;
        closest = null;
        foreach (var item in objectsHit)
        {
            if (item.CompareTag(tagToLookFor))
            {
                float d = Vector3.Distance(this.transform.position, item.transform.position);
                if ((closest == null) || d < dist)
                {
                    closest = item;
                    dist = d;
                }
            }
        }
    }
}
