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
        if (currentWaypointIndex < lastWaypointIndex)
        {
            currentWaypointIndex++;
        }
        else
        {
            EndPointReached();
        }
    }



    private void EndPointReached()
    {
        OnEndReached?.Invoke();
        ObjectPooler.ReturnToPool(gameObject);
    }

    public void ResetEnemy()
    {
        currentWaypointIndex = 0;
    }
}