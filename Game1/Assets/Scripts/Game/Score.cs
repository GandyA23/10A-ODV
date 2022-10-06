using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    public static float ScoreTime { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        ScoreTime = 0f;
        textComponent = GetComponent<TextMeshProUGUI>();   
    }

    private void Update()
    {
        ScoreTime += Time.deltaTime;
        textComponent.text = Mathf.Floor(ScoreTime).ToString();
    }
}
