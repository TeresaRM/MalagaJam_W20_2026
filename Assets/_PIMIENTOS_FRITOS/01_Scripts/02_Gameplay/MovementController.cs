using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 direccion;

    [Header("Translation")]
    [SerializeField] float falloffRate = 0.02f;
    [SerializeField] float MAXImpulse = 600f;
    [SerializeField] float velocityChange = 30f;

    [Header("Rotation")]
    [SerializeField] float _rotationSpeed = 0.7f;
    private TapeRotation tapeRotation;
    public float mouseWheelInput { get; private set;}
    
    private float _impulseCounter = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        tapeRotation = GetComponent<TapeRotation>();
    }

    private void Update()
    {    
        direccion = transform.up;

        ImpulseChecker();
    }

    private void FixedUpdate()
    {
        mouseWheelInput = Input.mouseScrollDelta.y;

        Movement();

        Debug.Log(_rigidbody.linearVelocity.magnitude + " " + _impulseCounter);
    }

    void ImpulseChecker()
    {

        if (mouseWheelInput != 0)
        {
            _impulseCounter += mouseWheelInput * velocityChange;
        }

        if (_impulseCounter > MAXImpulse)
            _impulseCounter = MAXImpulse;

        if (_impulseCounter < 0)
            _impulseCounter = 0;

    }

    void Movement()
    {
        if (Mathf.Abs(_rigidbody.linearVelocity.magnitude) > 0 && Vector2.Dot(direccion.normalized, _rigidbody.linearVelocity) > 0)
        {
            _impulseCounter -= falloffRate;
        }

        _rigidbody.linearVelocity = direccion * _impulseCounter;
    }
}
