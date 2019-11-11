using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//referenced https://www.youtube.com/watch?v=28JTTXqMvOU
public class MinimapScript : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        Vector3 newPos = player.position;
        newPos.y = transform.position.y;
        transform.position = newPos;

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }


}
