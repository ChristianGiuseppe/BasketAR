using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private Button startButton;
    private Button scoreButton; 
    private Button exitButton;
    private void OnEnable()
    {
        var rootElements = GetComponent<UIDocument>().rootVisualElement;
        startButton = rootElements.Q<Button>("start-button");
        scoreButton = rootElements.Q<Button>("score-button");
        exitButton = rootElements.Q<Button>("quit-button");

        startButton.clicked += StartButton_clicked;
        scoreButton.clicked += ScoreButton_clicked;
        exitButton.clicked += QuitButton_clicked;
    }

    private void ScoreButton_clicked()
    {
        Debug.Log("Score: ");
        SceneManager.LoadScene("Score");
    }

    private void StartButton_clicked()
    {
        Debug.Log("Start: ");
        SceneManager.LoadScene("BasketAR");
    }


    private void QuitButton_clicked()
    {
        Debug.Log("Quit: ");
        Application.Quit();
    }


    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
