using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public float SpeedMove;
    private GameObject obj;
    public float ResetPosition;
    public float MoveRange;
    public float MinRange;
    public float MaxRange;
    // Start is called before the first frame update
    void Start()
    {
        MinRange = -3;
        MaxRange = 0;
        ResetPosition = 7;
        obj = this.gameObject;
        SpeedMove = 2;

    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(new Vector3(-SpeedMove * Time.deltaTime, 0, 0));
    }
    void OnTriggerEnter2D(Collider2D orther)
    {
        if (orther.gameObject.tag.Equals("ResetTag"))
            obj.transform.position = new Vector3(ResetPosition, Random.Range(MinRange, MaxRange), 0);
    }
}
