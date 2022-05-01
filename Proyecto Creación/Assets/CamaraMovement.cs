using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform Target;
    public Vector3 Offset;
    public float Smoothing = 5;



    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {


        if (transform.position != Target.position)
        {
            transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y);

            transform.position = Vector3.Lerp(transform.position, Target.position, Smoothing * Time.fixedDeltaTime) + Offset;
        }
    }
}
