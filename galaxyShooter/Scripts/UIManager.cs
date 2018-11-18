using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public GameObject[] Fires;

    public Sprite[] LivesImage;
    public Image ImageLiveDisplay;

    GameObject WorldController;

    public Text ScoreText;

    void Start()
    {
        WorldController = GameObject.FindGameObjectWithTag("World"); 
    }

	public void UpdateLives(int Life)
    {
        switch(Life)
        {
            case 10:
            ImageLiveDisplay.sprite = LivesImage[1];
                Fires[1].SetActive(true);
                break;
            case 20:
                ImageLiveDisplay.sprite = LivesImage[2];
                Fires[0].SetActive(true);
                break;
            case 30:
                ImageLiveDisplay.sprite = LivesImage[3];
                Fires[0].SetActive(false);
                Fires[1].SetActive(false);
                break;
            default:
                ImageLiveDisplay.sprite = LivesImage[3];
                break;
            case 0:
                ImageLiveDisplay.sprite = LivesImage[0];
                break;
        }
    }
    public void UpdateScore(int score)
    {   
        score = score + 10;
        ScoreText.text = "Score: " + score;
        WorldController.GetComponent<GameBehaviour>().Score = score;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
