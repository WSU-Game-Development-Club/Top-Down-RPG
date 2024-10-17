using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

//This is the statemachine class, of which all the states should be children.
public class EnemySM : MonoBehaviour {

    [SerializeField] private float _defaultMovementSpeed;
    public float DefaultMovementSpeed {
        get {
            return _defaultMovementSpeed;
        }
    }
    [SerializeField] private float _defaultMovementForce;
    public float DefaultMovementForce {
        get {
            return _defaultMovementForce;
        }
    }

    private Rigidbody2D _rb;
    public Rigidbody2D RB {
        get {
            return _rb;
        }
    }
    private CircleCollider2D _collider;
    public CircleCollider2D Collider {
        get {
            return _collider;
        }
    }

    //This is what the movement function actually uses to figure out where to go and how fast
    private EnemyMovementParameters _movementParameters;
    public EnemyMovementParameters MovementParameters {
        get {
            return _movementParameters;
        }
        set {
            _movementParameters = value;
        }
    }
    private Vector2 _target;
    public Vector2 Target {
        get {
            return _target;
        }
        set {
            _target = value;
        }
    }

    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CircleCollider2D>();
        ResetMovementParameters();
    }
    [SerializeField] private EnemyState _defaultState;
    private void Start() {
        SwitchState(_defaultState);
    }



    /// <summary>
    /// Disables the siblings of the current state, then enables the new state
    /// </summary>
    /// <param name="newState">the new state to enable</param>
    /// <param name="caller">the EnemyState that called the function</param>
    /// <returns>void</returns>
    public void SwitchState(EnemyState newState) {
        Transform parent = newState.transform.parent;

        EnemyState[] states = parent.gameObject.GetComponentsInChildren<EnemyState>(true);
        foreach (EnemyState state in states) {
            if (state.transform != parent) {
                state.gameObject.SetActive(false);
            }

        }
        ResetMovementParameters();
        newState.gameObject.SetActive(true);
    }

    /// <summary>
    /// Moves the character around with physics
    /// </summary>
    /// <returns>void</returns>
    private void HandleMovement() {
        Vector2 pos = transform.position;
        Vector2 movementDirection = _movementParameters.Target - pos;
        if (movementDirection.magnitude > 1f) {
            movementDirection.Normalize();
        }

        Vector2 desiredV = movementDirection * _movementParameters.Speed;
        Vector2 differenceV = desiredV - _rb.velocity;


        float differenceFactor = differenceV.magnitude / Mathf.Max(_movementParameters.Speed, 1f);

        _rb.AddForce(differenceV.normalized * differenceFactor * _movementParameters.Force);
    }

    private void Update() {
        HandleMovement();
    }

    //Sets the speed and force to default for the character, and the goal destionation to the current position (stop moving)
    public void ResetMovementParameters() {
        _movementParameters = new EnemyMovementParameters();
        _movementParameters.Target = transform.position;
        _movementParameters.Speed = _defaultMovementSpeed;
        _movementParameters.Force = _defaultMovementForce;
    }

}
public struct EnemyMovementParameters {
    public EnemyMovementParameters(Vector2 target, float speed, float force) {
        Target = target;
        Speed = speed;
        Force = force;
    }
    public Vector2 Target;
    public float Speed;
    public float Force;
}