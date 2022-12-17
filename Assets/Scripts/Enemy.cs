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

    public Vector3 CurrentPointPosition => Waypoint.GetWaypointPosition(_currentWaypointIndex);
    public Vector2 dir;
    int lastWaypointIndex;

    private int _currentWaypointIndex;
    private EnemyHealth _enemyHealth;

    private void Start()
    {
        _currentWaypointIndex = 0;
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    public void Update()
    {
        Move();
        if (CurrentPositionReached())
        {
            UpdateCurrentPointIndex();
           
        }
        dir = CurrentPointPosition - transform.position;
        //BUNU PUBLIC YAPÇAN

        //Debug.Log();
    }

    public void Move()
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
        _enemyHealth.ResetHealth();
        ObjectPooler.ReturnToPool(gameObject);
    }

    public void ResetEnemy()
    {
        _currentWaypointIndex = 0;
    }
}
