using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private const float LIMIT = 5;
    private bool Exploto;
    private float Counter;


    // Start is called before the first frame update
    void Start()
    {
        Exploto = false;
        Counter = LIMIT;
        Debug.Log($"La bomba se ha activado, la bomba explotará en {Counter} segundos.");
    }

    // Update is called once per frame
    void Update()
    {
        if (Exploto) 
        {
            return;
        }

        if (Counter > 0)
        {
            Counter -= Time.deltaTime;
            Debug.Log($"Tiempo restante: {Mathf.Ceil(Counter)} seg.");
        }
        else
        {
            Exploto = true;
            Debug.Log("BOOOOOOOOOOOOOOOOOMMMM!!!!!");
        }
    }
}
