using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectmove : MonoBehaviour
{
    public float MoveRange;
    public float SpeedMove;

    private Vector3 firstPosition;
    private GameObject obj;
    
    // Start is called before the first frame update
    void Start()
    {
        MoveRange = 15;
        obj = this.gameObject;
        firstPosition = obj.transform.position;
        SpeedMove = 2;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(new Vector3(-SpeedMove * Time.deltaTime, 0, 0));
        if (Vector3.Distance(firstPosition, obj.transform.position) > MoveRange)
            obj.transform.position = firstPosition;
    }
}
