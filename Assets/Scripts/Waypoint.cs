using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    [SerializeField] private Vector3[] points;
    public Vector3[] Points => points;
    private Vector3 currentPosition;
    public Vector3 CurrentPosition => currentPosition;
    bool gameStarted;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = true;
        currentPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 GetWaypointPosition(int index)
    {
        return currentPosition + points[index];
    }
    
    private void OnDrawGizmos()
    {

        if (!gameStarted && transform.hasChanged)
        {
            currentPosition = transform.position;
        }

        for (int i = 0; i < points.Length; i++)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(center: points[i] + currentPosition, radius: 0.5f);

            if (i < points.Length - 1)
            {
                Gizmos.color = Color.grey;
                Gizmos.DrawLine(points[i] + currentPosition, points[i + 1] + currentPosition);
            }

        }
    }

    
}

