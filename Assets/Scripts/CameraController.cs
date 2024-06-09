using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private int shiftX = 5;
    [SerializeField] private int shiftY = 0;

    private void Update()
    {
        transform.position = new Vector3(player.position.x + shiftX, player.position.y + shiftY, transform.position.z);
    }

}
