using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insects : MonoBehaviour {

    public List<WeightedDirection> desiredDirections;
    public float speed;
    Vector3 velocity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Respawn();

        desiredDirections = new List<WeightedDirection>();
        BroadcastMessage("DoAIBehaviour", SendMessageOptions.DontRequireReceiver);
        Vector3 direction = Vector3.zero;
        foreach (WeightedDirection wd in desiredDirections)
        {
            direction += wd.direction * wd.weight;
        }

        velocity = Vector3.Lerp(velocity, direction.normalized * speed, Time.deltaTime * 5f);
        transform.Translate(velocity * Time.deltaTime);
	}

    void Respawn()
    {
        if (this.transform.position.y > 10)
        {
            Vector3 position = this.transform.position;
            position.y = -9;
            this.transform.position = position;
        }
        else if (this.transform.position.y < -10)
        {
            Vector3 position = this.transform.position;
            position.y = 9;
            this.transform.position = position;
        }

        if (this.transform.position.y > 15)
        {
            Vector3 position = this.transform.position;
            position.y = -14;
            this.transform.position = position;
        }
        else if (this.transform.position.y < -15)
        {
            Vector3 position = this.transform.position;
            position.y = 14;
            this.transform.position = position;
        }
    }

}
