using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform goalPoint1;
    [SerializeField] Transform goalPoint2;
    [SerializeField] float moveSpeed;

    bool isMovingTowardGoalPoint1 = true;

    private void Update() 
    {
        // Move our position a step closer to the target.
        var step =  moveSpeed * Time.deltaTime; // calculate distance to move

        if (isMovingTowardGoalPoint1)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, goalPoint1.position, step);

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, goalPoint1.position) <= step)
            {
                isMovingTowardGoalPoint1 = !isMovingTowardGoalPoint1;
            }
        } 

        else
        {
            this.transform.position = Vector3.MoveTowards(transform.position, goalPoint2.position, step);

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, goalPoint2.position) <= step)
            {
                isMovingTowardGoalPoint1 = !isMovingTowardGoalPoint1;
            }
        }
    }


}
