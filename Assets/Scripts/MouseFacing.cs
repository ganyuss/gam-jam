using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFacing : MonoBehaviour
{
     void Update()
    {
        faceMouse();        
    }
 
    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
 
        Vector2 direction = new Vector2(
            mousePosition.z - transform.position.z,
            mousePosition.y - transform.position.y
        );
 
        transform.up = direction;
    }
}
