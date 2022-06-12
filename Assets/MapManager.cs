using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{

    public GameObject firstTile;
    public GameObject secondTile;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(secondTile.transform.position.y < 0)
        {
            var translate = new Vector2(0, 107);
            firstTile.transform.position += (Vector3)translate;

            var temp = firstTile;
            firstTile = secondTile;
            secondTile = temp;
        }
    }
}
