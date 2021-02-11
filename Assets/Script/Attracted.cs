using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attracted : MonoBehaviour
{
    private Rigidbody _rb;
    public List<Rigidbody> _atractorsRb;
        
    public static float G = 0.00000667f;

    void FixedUpdate()
    {

        Attract();

    }

    void Attract()
    {
        foreach(Rigidbody rbAttractor in _atractorsRb)
        {
            Vector3 direction = _rb.position - rbAttractor.position;
            float distance = direction.magnitude;
            float forceMagnitud = G * _rb.mass * rbAttractor.mass / Mathf.Pow(distance, 2);
            Vector3 force = -direction.normalized * forceMagnitud;
            _rb.AddForce(force);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        _rb = GetComponent<Rigidbody>();
        _atractorsRb = new List<Rigidbody>();

        GameObject[] earthObj = GameObject.FindGameObjectsWithTag("earth");

        foreach(GameObject gObject in earthObj)
        {
            _atractorsRb.Add(gObject.GetComponent<Rigidbody>());
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
