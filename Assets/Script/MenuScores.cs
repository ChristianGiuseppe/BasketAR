using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuScores : MonoBehaviour
{
    private void OnEnable()
    {
        var dataManager = new DataStorageManager();
        var rootElements = GetComponent<UIDocument>().rootVisualElement;
        VisualElement section = rootElements.Q<VisualElement>("wrap-list");
        // Create a list of data. In this case, numbers from 1 to 1000.

        ScoresData dataScore = DataStorageManager.Load();
        if (dataScore != null)
        {

            // The "makeItem" function is called when the
            // ListView needs more items to render.
            Func<VisualElement> makeItem = () => new Label();

            // As the user scrolls through the list, the ListView object
            // recycles elements created by the "makeItem" function,
            // and invoke the "bindItem" callback to associate
            // the element with the matching data item (specified as an index in the list).
            Action<VisualElement, int> bindItem = (e, i) =>
            {
                Label label = (e as Label);
                label.text = "Score: " + dataScore.getScores()[i].score;
                label.style.display = DisplayStyle.Flex;
                label.style.alignContent = Align.Center;
                label.style.color = new Color(255, 255, 255);
                label.style.alignItems = Align.Center;
                label.style.height = 32;
                label.style.fontSize = 18;
                label.style.marginLeft = 16;
            };

            // Provide the list view with an explict height for every row
            // so it can calculate how many items to actually display
            const int itemHeight = 16;

            var listView = new ListView(dataScore.getScores(), itemHeight, makeItem, bindItem);

            listView.selectionType = SelectionType.Multiple;

            listView.onItemsChosen += objects => Debug.Log(objects);
            listView.onSelectionChange += objects => Debug.Log(objects);

            listView.style.flexGrow = 1.0f;

            section.Add(listView);
        }
    }

        private void Update()
        {
            BackButtonPressed();
        }

        private void BackButtonPressed()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
           

                SceneManager.LoadScene("Menu");
            }
        }

    
}

