using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeCharacteristics : MonoBehaviour
{
    public static cubeCharacteristics instance;
    private void Awake()
    {
        instance = this; 
    }
    
    float rotateX=1;
    float rotateY=2;
    float rotateZ=3;

    Color first = Color.green;
    Color second = Color.yellow;
    float duration = 1f;
    Renderer rend;
    
    float amplitude = 0.15f;
    float freq = 1.2f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    void Start()
    {
        rend=GetComponent<Renderer>();
        
        posOffset=transform.position;
    }
    void Update()
    {
        transform.Rotate(rotateX*Time.fixedDeltaTime,rotateY*Time.fixedDeltaTime,rotateZ*Time.fixedDeltaTime);

        float lerp = Mathf.PingPong(Time.time, duration)/duration ;
        rend.material.color=Color.Lerp(first,second,lerp);

        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.time * Mathf.PI * freq) * amplitude;
        transform.position=tempPos;
    }
    
}
