using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _timeLife = -1.0f;
    private float MAX_LIFE = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_timeLife > 0)
        {
            _timeLife += Time.deltaTime;
        }

        if (_timeLife > MAX_LIFE)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name != "Player")
        {
            if (_timeLife < 0)
            {
                _timeLife = 0;
                _timeLife += Time.deltaTime;
            }
        }
    }
}
