using UnityEngine;

public enum Directions
{
    Straight,
    Left,
    Right
}

public class Movement : MonoBehaviour
{
    [SerializeField] private AnimationCurve accelerationCurve;
    [SerializeField] private bool touchControls;
    [SerializeField] private float maxVelocity;
    [SerializeField] private float xLimit;

    private Directions _direction; // false means left, true means right
    private Rigidbody _rigidbody;
    private Transform _transform;
    private float _accTime;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (!touchControls)
        {
            if (!Input.anyKey) _direction = Directions.Straight;

            if (Input.GetKey(KeyCode.A)) _direction = Directions.Left;
            
            if (Input.GetKey(KeyCode.D)) _direction = Directions.Right;

        }
        else
        {
            
        }
    }
    
    private void FixedUpdate()
    {
        _accTime += Time.deltaTime;
        _rigidbody.AddForce(Vector3.forward * 10);
        switch (_direction)
        {
            case Directions.Left:
                GoLeft();
                break;
            
            case Directions.Right:
                GoRight();
                break;
            
            case Directions.Straight:
                _accTime = 0;
                break;
        }
        
        if (_rigidbody.velocity.magnitude > maxVelocity)
            _rigidbody.velocity = _rigidbody.velocity.normalized * maxVelocity;
    }
    
    private void GoLeft()
    {
        _accTime += Time.deltaTime;
        if (_transform.position.x > -xLimit)
        {
            _rigidbody.AddForce(Vector3.left * accelerationCurve.Evaluate(_accTime));
        }
        else
        {
            _rigidbody.velocity = Vector3.forward * maxVelocity;
        }
    }

    private void GoRight()
    {
        _accTime += Time.deltaTime;
        if (_transform.position.x < xLimit)
        {
            _rigidbody.AddForce(Vector3.right * accelerationCurve.Evaluate(_accTime));
        }
        else
        {
            _rigidbody.velocity = Vector3.forward * maxVelocity;
        }
    }
}
