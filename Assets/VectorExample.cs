using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class VectorExample : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private Vector3[] points;
    private bool isForward = true;
    private int currentIndex = 0;

    private void Start()
    {
        Vector3 firstPoint = points[0];
    }

    private void Update()
    {
        TransformMoveCheck();
    }

    public void TransformMoveCheck()
    {
        transform.LookAt(points[currentIndex]);

        transform.position = Vector3.MoveTowards(transform.position, points[currentIndex], 
        Time.deltaTime * Speed);

        float distance = Vector3.Distance(transform.position, points[currentIndex]);

        if (distance < 0.1f)
        {
            UpdateCurrentIndex();
        }
    }

    public void UpdateCurrentIndex()
    {
        if(isForward)
        {
            currentIndex++;
            if (currentIndex >= points.Length)
            {
                isForward = false;
                currentIndex = points.Length - 1;
            }
        }
        else
        {
           currentIndex--; 
           if (currentIndex < 0)
           {
                isForward = true;
                currentIndex = 0;
           }
        }
    }
}
