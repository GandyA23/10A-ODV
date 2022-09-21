using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
	[SerializeField] private GameObject platform;
	[SerializeField] private Vector2 scaleRange;
	[SerializeField] private float offset;

    void Start () 
    {
        StartCoroutine("SpawnPlatforms");
    }	

    public IEnumerator SpawnPlatforms () 
    {
        while (true)
        {
            // Espera N segundos antes de continuar con la secuencia
            yield return new WaitForSeconds(1);
            
            // Crea un nuevo objeto de platform en el punto de la izquierda con la rotación normal
            // Retorna el GameObject de la copia
            GameObject instance = Instantiate(platform, Vector3.left * offset, Quaternion.identity);

            // Crea plataformas de diferentes tamaños
            instance.transform.localScale = new Vector3(
                Random.Range(scaleRange.x, scaleRange.y),
                instance.transform.localScale.y,
                instance.transform.localScale.z
            );

            // Aumenta en 2% la velocidad del tiempo para la dificultad
            Time.timeScale *= 1.02f;
        }
    }
}
