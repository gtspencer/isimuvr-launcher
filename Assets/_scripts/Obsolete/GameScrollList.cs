using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameItem
{
    public string gameName;
    public Sprite image;
}

public class GameScrollList : MonoBehaviour {

    public List<GameItem> gameList;
    public Transform contentPanel;

    public SimpleObjectPool buttonObjectPool;

    public PrefabButton prefabButton;

	// Use this for initialization
	void Start () {
        RefreshDisplay();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RefreshDisplay()
    {
        AddButtons();
    }

    private void AddButtons()
    {
        for (int i = 0; i < gameList.Count; i++)
        {
            GameItem game = gameList[i];

            PrefabButton newButton = Instantiate(prefabButton);
            newButton.transform.SetParent(contentPanel);
            


            /**
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);

            PrefabButton sampleButton = newButton.GetComponent<PrefabButton>();
            sampleButton.Setup(game, this);
    */
        }
    }
}