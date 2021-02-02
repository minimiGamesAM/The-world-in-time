using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rb;
    public GameObject _atractorGameObject;
    private Vector3 _moveVelocityDir;

    public float _playerSpeed = 10;

    public float _fireSpeed = 10;
    public float _fireAngle = 45;
    public float _orientationSensitivity = 100;

    public GameObject _myPrefab;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDir = (_atractorGameObject.transform.position - transform.position).normalized;
        transform.rotation = Quaternion.FromToRotation(transform.up, targetDir) * transform.rotation;

        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        _moveVelocityDir = Vector3.forward * verticalMovement + Vector3.left * horizontalMovement;

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * _orientationSensitivity);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fireObject();
        }
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + transform.TransformDirection(_moveVelocityDir * _playerSpeed * Time.fixedDeltaTime));
    }

    private void fireObject()
    {
        _myPrefab = Instantiate(_myPrefab, transform.position - transform.TransformDirection(Vector3.up), Quaternion.identity);

        Rigidbody rb = _myPrefab.GetComponent<Rigidbody>();

        rb.velocity = Quaternion.Euler(0, -30, 0) * (transform.forward * _fireSpeed);
    }
}
