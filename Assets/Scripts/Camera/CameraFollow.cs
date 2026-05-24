using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float followSpeed=5f;
    void Start()
    {
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
         Vector3 targetPosition=new Vector3(target.position.x,target.position.y,-10f);
        transform.position = Vector3.Lerp(transform.position,targetPosition,followSpeed * Time.deltaTime);
    }
}
