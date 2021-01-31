using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attracted : MonoBehaviour
{
    private Rigidbody _rb;
    private Rigidbody _atractorRb;
   
    public static float G = 0.00000667f;

    void FixedUpdate()
    {

        Attract(_atractorRb);

    }

    void Attract(Rigidbody rbAttractor)
    {
        Vector3 direction = _rb.position - rbAttractor.position;
        float distance = direction.magnitude;
        float forceMagnitud = G * _rb.mass * rbAttractor.mass / Mathf.Pow(distance, 2);
        Vector3 force = -direction.normalized * forceMagnitud;
        _rb.AddForce(force);
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        GameObject[] earthObj = GameObject.FindGameObjectsWithTag("earth");
        _atractorRb = earthObj[0].GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
