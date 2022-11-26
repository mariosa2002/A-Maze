using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLights : MonoBehaviour
{

    public GameObject Suelo;

    public GameObject Bolas;
    public GameObject farol;

    void Awake()
    {
        for (int i = 0; i < 100; i++)
        {
            Min = new Vector3(0, 4, 0);
            Max = new Vector3(50, 40, 50);

            _xAxis = UnityEngine.Random.Range(Min.x, Max.x);
            _yAxis = UnityEngine.Random.Range(Min.y, Max.y);
            _zAxis = UnityEngine.Random.Range(Min.z, Max.z);

            randomPosition = new Vector3(_xAxis, _yAxis, _zAxis);

            var una = Instantiate(farol, randomPosition, Quaternion.identity);
        }
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
