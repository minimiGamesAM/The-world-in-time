using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{

    public Rigidbody rb;

    private void FixedUpdate()
    {
        Attractor[] attractors = FindObjectsOfType<Attractor>();
        foreach(Attractor attractor in attractors)
        {
            if(attractor  != this)
                Attract(attractor);

        }
        
    }
    // Start is called before the first frame update
    void Attract(Attractor objtoAttract)
    {
        Rigidbody rbToAttract = objtoAttract.rb;
        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;
        float forceMagnitude = (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);

        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
        


    }
}
