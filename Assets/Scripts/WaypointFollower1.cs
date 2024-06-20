using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaypointFollower1 : MonoBehaviour
{
    [SerializeField] private InputField input;
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    private bool canMove = false;
    private string[] answer =
    {
        "while (true)",
        "{",
        "x += platformSpeed;",
	    "if (x <= leftBound || x >= rightBound)",
		"platformSpeed *= -1;",
        "}",
    };

    [SerializeField] private float speed = 2f;

    private void Update()
    {
        string[] lines = input.text.Split("\n");

        if (lines.Length == 6)
        {
            for (int i = 0; i < answer.Length; i++)
            {
                if (lines[i] == answer[i])
                    canMove = true;
                else
                    canMove = false;
            }

            if (canMove)
            {
                if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
                {
                    currentWaypointIndex++;
                    if (currentWaypointIndex >= waypoints.Length)
                        currentWaypointIndex = 0;
                }
                transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
            }
        }
        
    }
}
