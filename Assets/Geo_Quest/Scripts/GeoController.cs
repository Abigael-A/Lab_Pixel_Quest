using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoController : MonoBehaviour
{
    int food = 3;
    int var1 = 100;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello world");

        int variabledos = 25;

        print(var1 + variabledos);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(food);

        food++;
    }
}
