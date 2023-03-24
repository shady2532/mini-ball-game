using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class smallSphere : MonoBehaviour
{
    

    public static smallSphere instance;

    float rotateX = 1;
    float rotateY = 2;
    float rotateZ = 3;

    private void Awake()
    {
        instance = this;
    }
    
    void Update()
    {
        transform.Rotate(rotateX * Time.fixedDeltaTime, rotateY * Time.fixedDeltaTime, rotateZ * Time.fixedDeltaTime);

    }
}
