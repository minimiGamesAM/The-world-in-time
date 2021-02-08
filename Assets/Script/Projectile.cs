using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _timeLife = -1.0f;
    private float MAX_LIFE = 5f;

    private Vector3 _currentPoint;

    // Start is called before the first frame update
    void Start()
    {
        _currentPoint = transform.position;
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

    void FixedUpdate()
    {
        // always draw a 5-unit colored line from the origin
        Color color = new Color(0.5f, 0.4f, 1.0f);
        Debug.DrawLine(_currentPoint, transform.position, color, 30);

        _currentPoint = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.name != "Player")
        {
            _timeLife = 0;
            _timeLife += Time.deltaTime;
        }
    }
}
