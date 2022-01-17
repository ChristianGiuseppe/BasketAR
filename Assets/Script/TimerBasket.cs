using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerBasket : MonoBehaviour
{
    private Label section;
    public float timerStart;
    public GameObject scoreGO;
    private Boolean activeTimer = false;
    private DataStorageManager dataStorage;
    void Update()
    {
        if (activeTimer)
        {
            timerStart -= Time.deltaTime;
            section.text = Mathf.Round(timerStart).ToString();
            if (timerStart <= 0)
            {
                section.text = "Tempo scaduto!";

                // richiamare script per il salvataggio dello score
                int score = Scoring.Score;
                Debug.Log("Value: "+ score);
                EndGame(score);
                SceneManager.LoadScene("Menu");
            }
        }
    }


    private void OnEnable()
    {
        var rootElements = GetComponent<UIDocument>().rootVisualElement;
        section = rootElements.Q<Label>("timerText");
    }

    public void timStart()
    {
        activeTimer = true;
    }

    public void EndGame(int score)
    {
        DataStorageManager.Save(score);
    }

}
