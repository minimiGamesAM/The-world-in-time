using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rb;
    public GameObject _atractorGameObject;
    private Vector3 _moveVelocityDir;

    public float _playerSpeed = 10;

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

        _moveVelocityDir = Vector3.forward * verticalMovement + Vector3.right * horizontalMovement;
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + transform.TransformDirection(_moveVelocityDir * _playerSpeed * Time.fixedDeltaTime));
    }
}
