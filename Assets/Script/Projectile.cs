using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _timeLife = -1.0f;
    private float MAX_LIFE = 3f;

    private Vector3 _currentPoint;
    private Attracted _scriptAttracted;
    private Vector3 _minClosestAttractorDir;
    private Rigidbody _rigid;

    private bool _break = false;

    // Start is called before the first frame update
    void Start()
    {
        _currentPoint = transform.position;
        _scriptAttracted = GetComponent<Attracted>();
        _minClosestAttractorDir = new Vector3();
        _rigid = GetComponent<Rigidbody>();
    }

    void getClosestAttractorPos()
    {
        float minDistance = float.MaxValue;
    
        foreach (Rigidbody rbAttractor in _scriptAttracted._atractorsRb)
        {
            var d = rbAttractor.position - transform.position;
            if (d.sqrMagnitude < minDistance)
            {
               minDistance = d.sqrMagnitude;
              _minClosestAttractorDir = d;
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        getClosestAttractorPos();
        
        Vector3 targetDir = _minClosestAttractorDir.normalized;
        Quaternion rotTarget = Quaternion.LookRotation(targetDir);        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTarget, 50 * Time.deltaTime); 

        if (_timeLife > 0)
        {
            _timeLife += Time.deltaTime;
        }
                
        if (_timeLife > MAX_LIFE)
        {
            Destroy(gameObject);
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
            _break = true;
        }
    }

    void FixedUpdate()
    {
        // always draw a 5-unit colored line from the origin
        Color color = new Color(0.5f, 0.4f, 1.0f);
        Debug.DrawLine(_currentPoint, transform.position, color, 30);

        _currentPoint = transform.position;

        if(_break)
        {
            Vector3 dirMovement = _rigid.velocity.normalized;
            _rigid.AddForce(-dirMovement * 100);
            //print("break " + name);
            _break = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.name != "Player")
        {
            if(_timeLife < 0)
            {
                _timeLife = 0;
                _timeLife += Time.deltaTime;
            }
        }
    }
}
