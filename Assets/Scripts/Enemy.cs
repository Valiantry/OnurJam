using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Enemy : MonoBehaviour
{
    public static Action OnEndReached;

    [SerializeField] private float moveSpeed = 3f;
    //[SerializeField] private Waypoint waypoint;
    public Waypoint Waypoint { get; set; }
    public float MoveSpeed { get; set; }   
    public EnemyHealth EnemyHealth { get; set; }

<<<<<<< HEAD
    public Vector3 CurrentPointPosition => Waypoint.GetWaypointPosition(currentWaypointIndex);

    int lastWaypointIndex;

    private int currentWaypointIndex;
    private Vector3 _lastPointPosition;

    private EnemyHealth _enemyHealth;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        EnemyHealth = GetComponent<EnemyHealth>();



        currentWaypointIndex = 0;
        moveSpeed = MoveSpeed;
        _lastPointPosition = transform.position;
=======
    public Vector3 CurrentPointPosition => Waypoint.GetWaypointPosition(_currentWaypointIndex);
    public Vector2 dir;
    int lastWaypointIndex;

    private int _currentWaypointIndex;
    private EnemyHealth _enemyHealth;

    private void Start()
    {
        _currentWaypointIndex = 0;
        _enemyHealth = GetComponent<EnemyHealth>();
>>>>>>> 8cc8e7c65b5fe59e8f563e7919a43090b1ab3ef1
    }

    private void Update()
    {
        Move();
        if (CurrentPositionReached())
        {
            UpdateCurrentPointIndex();

        }
        //Debug.Log(lastWaypointIndex);
    }
    private void Move()
    {

        transform.position = Vector3.MoveTowards(transform.position, CurrentPointPosition, moveSpeed * Time.deltaTime);
    }

    private bool CurrentPositionReached()
    {
        float distanceToNextPointPosition = (transform.position - CurrentPointPosition).magnitude;
        if (distanceToNextPointPosition < 0.1f)
        {
            return true;
        }
        return false;
    }

    private void UpdateCurrentPointIndex()
    {
        int lastWaypointIndex = Waypoint.Points.Length - 1;
        if (_currentWaypointIndex < lastWaypointIndex)
        {
            _currentWaypointIndex++;
        }
        else
        {
            EndPointReached();
        }
    }



    private void EndPointReached()
    {
        OnEndReached?.Invoke();
<<<<<<< HEAD
=======
        _enemyHealth.ResetHealth();
>>>>>>> 8cc8e7c65b5fe59e8f563e7919a43090b1ab3ef1
        ObjectPooler.ReturnToPool(gameObject);
    }

    public void ResetEnemy()
    {
        _currentWaypointIndex = 0;
    }
}