using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float Counter;

    // Start is called before the first frame update
    void Start()
    {
        Counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Counter += Time.deltaTime;
        Debug.Log(Mathf.Ceil(Counter));
    }
}
