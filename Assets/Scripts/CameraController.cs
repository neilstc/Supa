using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    private float cameraOffset = 5;
    private Vector3 targetPosition;
    private float smoothing = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
        if (target.transform.localScale.x > 0f)
        {
            targetPosition = new Vector3(targetPosition.x + cameraOffset, targetPosition.y, targetPosition.z);
        }
        else if(target.transform.position.x < 0f){
            targetPosition = new Vector3(targetPosition.x - cameraOffset, targetPosition.y, targetPosition.z);
        }
        //if (target.transform.position.y > 0f)
        //{
        //    target.transform.position = new Vector3(targetPosition.x, targetPosition.y + cameraOffset, targetPosition.z);
        //}
        //else if (target.transform.position.y < 0f)
        //{
        //    targetPosition = new Vector3(targetPosition.x, targetPosition.y - cameraOffset, targetPosition.z);
        //}

        //transform.position = targetPosition;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing* Time.deltaTime); // how long it taked from one frame to another (fps).

    }
}
