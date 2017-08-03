using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchFor : MonoBehaviour {

    public float radius;
    public LayerMask searchLayers;
    public string tagToLookFor;
    public Collider2D closest;
    Grab grab;

    void Start()
    {
        grab = GetComponent<Grab>();
    }

    void DoAIBehaviour()
    {
        Detecting();

        if (closest == null)
        {
            return; //We have nothing to eat;
        }
        else
        {
            if(this.gameObject.tag == "Ant")
                grab.setClosest(closest.transform);

            Vector3 direction = closest.transform.position - this.transform.position;
            WeightedDirection wd = new WeightedDirection(direction, 1);
            GetComponent<Insects>().desiredDirections.Add(wd);
        }
    }

    void Detecting()
    {
        var objectsHit = Physics2D.OverlapCircleAll(this.transform.position, radius, searchLayers);
        closest = null;
        float distance = Mathf.Infinity;
        foreach (var item in objectsHit)
        {
            if (item.CompareTag(tagToLookFor))
            {
                float d = Vector3.Distance(this.transform.position, item.transform.position);
                if ((closest == null) || d < distance)
                {
                    closest = item;
                    distance = d;
                }
            }
        }
    }

    public Transform getClosest()
    {
        return closest.transform;
    }

    public bool JourneyDone()
    {
        if(Vector3.Distance(this.transform.position, closest.transform.position) == 0)
             return true;

        return false;
    }

    public void setClosestToNull()
    {
        closest = null;
    }
}
