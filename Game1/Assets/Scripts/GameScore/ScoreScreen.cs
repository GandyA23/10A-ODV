using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreScreen : MonoBehaviour
{
    private TextMeshProUGUI textComponent;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();   
    }

    // Update is called once per frame
    void Update()
    {
        textComponent.text = $"Score: {Mathf.Floor(Score.ScoreTime).ToString()}";

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Insert)) 
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
