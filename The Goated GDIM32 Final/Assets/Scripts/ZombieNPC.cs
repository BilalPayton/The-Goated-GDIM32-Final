using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.AI;

public class ZombieNPC : MonoBehaviour
{
    private enum ZombieState
    {
        Wandering,
        Chasing
    }

    [SerializeField] private LayerMask _lineOfSightLayers;
    [SerializeField] private float _wanderTimeMax = 5.0f;
    [SerializeField] private float _obstacleCheckDistance = 1.0f;
    [SerializeField] private float _obstactleCheckRadius = 1.0f;
    [SerializeField] private float _stopDistance = 1.2f;
    [SerializeField] private float _walkSpeed = 2f;
    [SerializeField] private float _rotateSpeed = 2f;
    [SerializeField] private float _lineOfSightMaxDistance = 6f;
    [SerializeField] private Vector3 _raycastStartOffSet = new Vector3(0f, 1f, 0f);
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private float _interactDistance = 5.0f;
    [SerializeField] private float _runDistance = 2.0f;
    [SerializeField] private NavMeshAgent _navAgent;
    [SerializeField] private Animator _animator;

    private Transform _playerTransform;
    private string _playerTag = "Player";
    private ZombieState _state;
    private float _wanderTime;
    private Vector3 _wanderDirection;

    // Added missing fields
    private Vector3 _meToPlayer;
    private bool _hasLineOfSightToPlayer;
    private Vector3 _raycastHitLocation;
    private Vector3 _spherecastHitLocation;

    public delegate void playChaseMusic();
    public delegate void stopChaseMusic();

    public event playChaseMusic chaseMusicEvent;
    public event stopChaseMusic stopChaseMusicEvent;
    void Start()
    {
        if (_navAgent == null)
        {
            _navAgent = GetComponent<NavMeshAgent>();
        }

        if(_navAgent != null)
        {
            _navAgent.speed = _walkSpeed;
            _navAgent.stoppingDistance = _stopDistance;
        }

        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            _playerTransform = playerObj.transform;
        }
        else
        {
            Debug.LogError("ZombieNPC: No GameObject with tag 'Player' found.");
        }

        _wanderTime = _wanderTimeMax;
        GetNewWanderDirection();


        if(_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        if (_playerTransform == null)
        {
            return;
        }

        UpdateState();
        RunState();
        UpdateAnimation();
    }

    private void UpdateState()
    {
        if (IsPlayerWithinRunDistance() && HasLineOfSightToPlayer())
        {
            _state = ZombieState.Chasing;
            chaseMusicEvent?.Invoke();
        }
        else
        {
            _state = ZombieState.Wandering;
            stopChaseMusicEvent?.Invoke();
        }
    }

    private void RunState()
    {
        switch (_state)
        {
            case ZombieState.Wandering:
                RunWanderState();
                break;

            case ZombieState.Chasing:
                RunChaseState();
                break;

            default:
                Debug.LogError("Unhandled state " + _state);
                break;
        }
    }

    private void RunWanderState()
    {
      if(_navAgent == null)
        {
            return;
        }

        _wanderTime -= Time.deltaTime;

        if(_wanderTime <= 0.0f || _navAgent.remainingDistance <= _stopDistance)
        {
            _wanderTime = _wanderTimeMax;
            GetNewWanderDirection();

            Vector3 targetPosition = transform.position + (_wanderDirection * 3f);
            _navAgent.isStopped = false;
            _navAgent.SetDestination(targetPosition);
        }

        
    }

    private void GetNewWanderDirection()
    {
        Vector3 randomDirection = new Vector3(
            Random.Range(-1f, 1f),
            0f,
            Random.Range(-1f, 1f)
        );

        _wanderDirection = randomDirection.normalized;
    }

    private bool HasClosedObstacles()
    {
        RaycastHit hitInfo;
        Vector3 raycastStart = transform.position + _raycastStartOffSet;

        bool hasObstacles = Physics.SphereCast(
            raycastStart,
            _obstactleCheckRadius,
            _wanderDirection,
            out hitInfo,
            _obstacleCheckDistance
        );

        if (hasObstacles)
        {
            _spherecastHitLocation = hitInfo.point;
        }

        return hasObstacles;
    }

    private void RunChaseState()
    {
       if(_navAgent == null || _playerTransform == null)
        {
            return;
        }

        _navAgent.isStopped = false;
        _navAgent.speed = _walkSpeed;
        _navAgent.SetDestination(_playerTransform.position);
        
    }

    //private void RotateTowards(Vector3 direction)
    //{
        //if (direction == Vector3.zero) return;

       // Vector3 currentForward = new Vector3(transform.forward.x, 0, transform.forward.z);
       // Vector3 newForward = Vector3.RotateTowards(currentForward, direction, _rotateSpeed * Time.deltaTime, 0f);
       // transform.forward = newForward;
    //}
    

    //private void WalkTowards(Vector3 point)
    //{
       // Vector3 me = new Vector3(transform.position.x, 0, transform.position.z);

       // if (Vector3.Distance(me, point) <= _stopDistance)
       // {
       //     return;
       // }

       // Vector3 meToTarget = point - me;
       // meToTarget = meToTarget.normalized;

       // transform.Translate(meToTarget * _walkSpeed * Time.deltaTime, Space.World);
   // }

    private bool HasLineOfSightToPlayer()
    {
        _hasLineOfSightToPlayer = false;

        if (_playerTransform == null)
        {
            return false;
        }

        RaycastHit hitInfo;

        Vector3 raycastStart = transform.position + _raycastStartOffSet;
        Vector3 raycastDirection = (_playerTransform.position - raycastStart).normalized;

        if (Physics.Raycast(raycastStart, raycastDirection, out hitInfo, _lineOfSightMaxDistance, _lineOfSightLayers))
        {
            _raycastHitLocation = hitInfo.point;

            if (hitInfo.collider.CompareTag(_playerTag))
            {
                _hasLineOfSightToPlayer = true;
            }
        }

        return _hasLineOfSightToPlayer;
    }

    private bool IsPlayerWithinRunDistance()
    {
        if(_playerTransform == null)
        {
            return false;
        }
        return Vector3.Distance(transform.position, _playerTransform.position) <= _runDistance;
    }

    private void UpdateAnimation()
    {
        if(_animator == null || _navAgent == null)
        {
            return;
        }

        bool isMoving = _navAgent.velocity.magnitude > 0.1f;
        _animator.SetBool("IsMoving", isMoving);
    }
}
