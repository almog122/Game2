using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollowPlayer : MonoBehaviour
{

    public Transform Player;
    private float distance = -10f;
    private float CameraX = 1.42f;
    private float CameraY = 2.73f;

   
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.position.x + CameraX, Player.position.y + CameraY, Player.position.z + distance);
    }
}
