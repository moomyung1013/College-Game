using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;

    private float y;
    void Start()
    {
        y = player.transform.localPosition.y+5.0f;
    }
    
    void Update()
    {
        transform.localPosition = new Vector3(player.transform.localPosition.x, y, -10);
    }
}
