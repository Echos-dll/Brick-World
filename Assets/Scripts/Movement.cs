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
        
        if (transform.position.x > xLimit || transform.position.x < -xLimit)
        {
            GoStraight();
        }
        
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
                GoStraight();
                break;
        }
    }
    
    private void GoLeft()
    {
        _accTime += Time.deltaTime;
        if (_transform.position.x > -xLimit)
        {
            _rigidbody.velocity = Vector3.forward * maxVelocity + Vector3.left * accelerationCurve.Evaluate(_accTime) * maxVelocity;
        }
        else
        {
            GoStraight();
        }
    }

    private void GoRight()
    {
        _accTime += Time.deltaTime;
        if (_transform.position.x < xLimit)
        {
            _rigidbody.velocity = Vector3.forward * maxVelocity + Vector3.right * accelerationCurve.Evaluate(_accTime) * maxVelocity;
        }
        else
        {
            GoStraight();
        }
    }

    private void GoStraight()
    {
        _rigidbody.velocity = Vector3.forward * maxVelocity;
    }
}
