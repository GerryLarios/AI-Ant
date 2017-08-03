using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour {

    public Transform holdPoint;
    SearchFor searchFor;
    public Transform closest;

    public float grabRange;
    public bool grabbed;

	// Use this for initialization
	void Start () {

        grabbed = false;
        searchFor = GetComponent<SearchFor>();
	}
	
	// Update is called once per frame
	void DoAIBehaviour() {

        if(this.transform.childCount == 1)
        {
            grabbed = false;
        }

        if (closest == null)
        {
            if (searchFor.getClosest() == null)
                return;
            else
                closest = searchFor.getClosest();
        }
        else if ((closest != null) && (this.transform.childCount < 2) && (grabbed == false))
        {
            if (Vector3.Distance(this.transform.position, closest.transform.position) <= grabRange)
                GrabObject();
        }
    }

    void GrabObject()
    {
        closest.parent = this.transform;
        closest.position = holdPoint.position;
        grabbed = true;
    }

    public void setClosest(Transform _closest)
    {
        this.closest = _closest;
    }
}
