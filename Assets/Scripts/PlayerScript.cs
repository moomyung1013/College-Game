using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Start!");   
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered!");
        GameManager.Instance.ItemCountInc(other.gameObject);
    }
}
