using System.Collections;
using System.Collections.Generic;
using static UnityEditorInternal.ReorderableList;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public GameObject Bullet;
    public float BulletSpeed = 100f;

    private bool _isShooting;

    public float distanceToGround = 0.1f;
    public LayerMask GroundLayer;
    private CapsuleCollider _col;
    
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;
    
    private float _vInput;
    private float _hInput;

    public float jumpVelocity = 5f;
    private bool _isJumping;

    private Rigidbody _rb;
    
    void Start()
    {
        _rb= GetComponent<Rigidbody>();
        _col= GetComponent<CapsuleCollider>();
    }
    void Update()
    {
        _isJumping |= Input.GetKeyDown(KeyCode.Space);
        _isShooting |= Input.GetMouseButtonDown(0);
        
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;
        
        this.transform.Translate(Vector3.forward * _vInput * Time.deltaTime);
        
        this.transform.Rotate(Vector3.up * _hInput * Time.deltaTime);
    }
    void FixedUpdate()
    {
        if (_isShooting)
        {
            GameObject newBullet = Instantiate(Bullet, this.transform.position + new Vector3(1, 0, 0), this.transform.rotation);
            Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>();
            BulletRB.velocity = this.transform.forward * BulletSpeed;
            _isShooting = false;
        }

        if (IsGrounded() && _isJumping)
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }
        _isJumping = false;
        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * _vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);
    }
    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, GroundLayer, QueryTriggerInteraction.Ignore);
        return grounded;
    }
}