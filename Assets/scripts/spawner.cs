using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

public class spawner : MonoBehaviour
{
    public GameObject cube;
    public GameObject sphere;
    public static spawner instance;
    private void Awake()
    {
        instance = this; 
    }
    
    void Start()
    {
        StartCoroutine(delay(1f));
        StartCoroutine(specialSpawn(10f));
    }
    void spawn(GameObject x)
    {
        Vector3 position = new Vector3(Random.Range(-9, 9), 0.707f, Random.Range(-9, 9));
        Vector3 angle = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));

        GameObject newGameObject = (GameObject)Instantiate(x, position, Quaternion.Euler(angle));
        newGameObject.transform.parent = transform;
    }
    public IEnumerator delay(float time)
    {
        yield return new WaitForSeconds(time);
        spawn(cube);
    }
    public IEnumerator specialSpawn(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            spawn(sphere);
            yield return new WaitForSeconds(3f);
            Destroy(GameObject.FindWithTag("specialCoin"));
        }
    }
}