using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    // Start is called before the first frame update

    public static GamePlayController instance; //dung ten scripts.instance roi truy xuat cac phuong thuc duoi dang public

    [HideInInspector] public int playerScore = 0;

    [SerializeField] private Text scoreText, endScoreText;

    public GameObject[] enemies;

    void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if(instance == null) //neu khong co GamePlayController
        {
            instance = this; //thi se tro toi lop gan nhat la GamePlayController
        }
    }

    void Start()
    {
        scoreText.text = "" + playerScore;
    }

    void Update()
    {
        UpdateGamePlayController();
    }

    void UpdateGamePlayController()
    {
        scoreText.text = "" + playerScore;
    }

    [SerializeField]
    private GameObject pausePanel, gameOverPanel;

    public void PauseGameButton()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeButton()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OptionButton()
    {
        Application.LoadLevel("MainMenu1");
    }

    public void RestartButton()
    {
        gameOverPanel.SetActive(false);
        Application.LoadLevel("GamePlay");
    }

    public void PlayerDiedShowPanel()
    {
        gameOverPanel.SetActive(true);
        endScoreText.text = "" + playerScore;
        //scoreText.text = endScoreText.text;
    }

    public void MenuButton()
    {
        pausePanel.SetActive(false);
        Application.LoadLevel("MainMenu1");
    }

    public void Bomb()
    {
        if (Input.GetKey(KeyCode.Delete))
        {
            GameObject[] gameObjects;
            gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
                Destroy(target.gameObject);
                explosionEnemy = (GameObject)Instantiate(explosionEnemy, target.transform.position, Quaternion.identity);
                Destroy(explosionEnemy, 1);
                //GamePlayController.instance.playerScore++; //cong diem
                AudioSource.PlayClipAtPoint(explosionEnemyClip, target.transform.position);
        }
    }
}
