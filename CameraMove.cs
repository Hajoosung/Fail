using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0.0f, 5.0f, -10.0f);
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        transform.position = target.TransformPoint(camOffset);
        transform.LookAt(target);
    }
}