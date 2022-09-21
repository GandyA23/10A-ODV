using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAbsoluto : MonoBehaviour
{
    private const float X_MIN = -10, X_MAX = 5, SPEED_BASE = 10;
    private float X, Y, Z, Right, Left;

    // Start is called before the first frame update
    void Start()
    {
        // Posición inicial en su eje X
        Right = Left = X = Y = Z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Right <= X_MAX) 
        {
            Right = X += SPEED_BASE * Time.deltaTime;
        }
        else if (Left >= X_MIN)
        {
            Left = X -= SPEED_BASE * Time.deltaTime;
        } 
        else 
        {
            Right = Left = X;        
        }

        transform.position = new Vector3(X, Y, Z);
    }
}
