using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenreButtonHandler : MonoBehaviour {

    public Button genre1;
    public Button genre2;
    public Button genre3;
    public Button genre4;
    public Button genre5;
    public Button genre6;
    public Button all;

    public Color disabledColor;
    public Color abledColor;

    public Color selectedHighlight;
    public Color unselectedHighlight;

    private bool selected1 = false;
    private bool selected2 = false;
    private bool selected3 = false;
    private bool selected4 = false;
    private bool selected5 = false;
    private bool selected6 = false;

    public GameObject line1;
    public GameObject line2;
    public GameObject line3;
    public GameObject line4;
    public GameObject line5;
    public GameObject line6;

    // Use this for initialization
    void Start () {
        all.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!selected1 && !selected2 && !selected3 && !selected4 && !selected5 && !selected6)
        {
            all.interactable = false;
        }
	}

    public void onGenre1()
    {
        if (selected1 == false)
        {
            ColorBlock cb1 = genre1.colors;
            cb1.normalColor = disabledColor;
            //cb1.highlightedColor = selectedHighlight;
            genre1.colors = cb1;
            line1.SetActive(true);

            all.interactable = true;
            selected1 = true;
        } else
        {
            ColorBlock cb1 = genre1.colors;
            cb1.normalColor = abledColor;
            //cb1.highlightedColor = unselectedHighlight;
            genre1.colors = cb1;
            selected1 = false;
            line1.SetActive(false);
        }
    }

    public void onGenre2()
    {
        if (selected2 == false)
        {
            ColorBlock cb2 = genre2.colors;
            cb2.normalColor = disabledColor;
            //cb2.highlightedColor = selectedHighlight;
            genre2.colors = cb2;
            line2.SetActive(true);

            all.interactable = true;
            selected2 = true;
        }
        else
        {
            ColorBlock cb2 = genre2.colors;
            cb2.normalColor = abledColor;
            //cb2.highlightedColor = unselectedHighlight;
            genre2.colors = cb2;
            selected2 = false;
            line2.SetActive(false);
        }
    }

    public void onGenre3()
    {
        if (selected3 == false)
        {
            ColorBlock cb3 = genre3.colors;
            cb3.normalColor = disabledColor;
            //cb3.highlightedColor = selectedHighlight;
            genre3.colors = cb3;
            line3.SetActive(true);

            all.interactable = true;
            selected3 = true;
        }
        else
        {
            ColorBlock cb3 = genre3.colors;
            cb3.normalColor = abledColor;
            //cb3.highlightedColor = unselectedHighlight;
            genre3.colors = cb3;
            selected3 = false;
            line3.SetActive(false);
        }
    }

    public void onGenre4()
    {
        if (selected4 == false)
        {
            ColorBlock cb4 = genre4.colors;
            cb4.normalColor = disabledColor;
            //cb4.highlightedColor = selectedHighlight;
            genre4.colors = cb4;
            line4.SetActive(true);

            all.interactable = true;
            selected4 = true;
        }
        else
        {
            ColorBlock cb4 = genre4.colors;
            cb4.normalColor = abledColor;
            //cb4.highlightedColor = unselectedHighlight;
            genre4.colors = cb4;
            selected4 = false;
            line4.SetActive(false);
        }
    }

    public void onGenre5()
    {
        if (selected5 == false)
        {
            ColorBlock cb5 = genre5.colors;
            cb5.normalColor = disabledColor;
            //cb5.highlightedColor = selectedHighlight;
            genre5.colors = cb5;
            line5.SetActive(true);

            all.interactable = true;
            selected5 = true;
        }
        else
        {
            ColorBlock cb5 = genre5.colors;
            cb5.normalColor = abledColor;
            //cb5.highlightedColor = unselectedHighlight;
            genre5.colors = cb5;
            selected5 = false;
            line5.SetActive(false);
        }
    }

    public void onGenre6()
    {
        if (selected6 == false)
        {
            ColorBlock cb6 = genre6.colors;
            cb6.normalColor = disabledColor;
            //cb6.highlightedColor = selectedHighlight;
            genre6.colors = cb6;
            line6.SetActive(true);

            all.interactable = true;
            selected6 = true;
        }
        else
        {
            ColorBlock cb6 = genre6.colors;
            cb6.normalColor = abledColor;
            //cb6.highlightedColor = unselectedHighlight;
            genre6.colors = cb6;
            selected6 = false;
            line6.SetActive(false);
        }
    }

    public void onAll()
    {
        ColorBlock cb1 = genre1.colors;
        cb1.normalColor = abledColor;
        genre1.colors = cb1;

        ColorBlock cb2 = genre2.colors;
        cb2.normalColor = abledColor;
        genre2.colors = cb2;

        ColorBlock cb3 = genre3.colors;
        cb3.normalColor = abledColor;
        genre3.colors = cb3;

        ColorBlock cb4 = genre4.colors;
        cb4.normalColor = abledColor;
        genre4.colors = cb4;

        ColorBlock cb5 = genre5.colors;
        cb5.normalColor = abledColor;
        genre5.colors = cb5;

        ColorBlock cb6 = genre6.colors;
        cb6.normalColor = abledColor;
        genre6.colors = cb6;

        all.interactable = false;

        line1.SetActive(false);
        line2.SetActive(false);
        line3.SetActive(false);
        line4.SetActive(false);
        line5.SetActive(false);
        line6.SetActive(false);

        selected1 = false;
        selected2 = false;
        selected3 = false;
        selected4 = false;
        selected5 = false;
        selected6 = false;
    }
}
