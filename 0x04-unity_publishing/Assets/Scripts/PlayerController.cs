using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    public Vector3 inputVector;

    private int score = 0;

    public int health = 5;

    Rigidbody rb;

    private bool _canMove = true;

    // UI
    private UiManager ui;

    [SerializeField]
    private CameraController cc;

    //UI HOLBERTON
    public Text scoreText;
    public Text healthText;
    public Text winLoseText;
    public GameObject winLoseContainer;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        ui = FindObjectOfType<UiManager>();

        cc = FindObjectOfType<CameraController>();

        
    }

    void Update(){

        if (_canMove)
        {
            inputVector = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
        }

        if (health == 0) {
            _canMove = false;
            //Debug.Log("Game Over!");
            PlayerLose();
            //ui.Message("Game Over!");
            score = 0;
            health = 5;
            StartCoroutine(LoadScene(3));
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(inputVector);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Pickup"){
            score++;
            //Debug.Log("Score: " + score);
            SetScoreText(score);
            //ui.AddCoins(score);
            Destroy(other.gameObject);
        }
        else if (other.tag == "Trap") {
            health--;
            //ui.HealthCount(health);
            //Debug.Log("Health: " + health);
            SetHealthText(health);
            cc._shaked = true;
        }
        else if (other.tag == "Goal") {
            PlayerWin();
            //Debug.Log("You win!");
            //ui.Message("You Win!");
        }

        
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("maze");
        _canMove = true;
    }

    void SetScoreText(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void SetHealthText(int health)
    {
        healthText.text = "Health: " + health.ToString();
    }

    void PlayerWin()
    {
        winLoseContainer.SetActive(true);
        winLoseText.color = Color.black;
        winLoseContainer.GetComponent<Image>().color = Color.green;
        winLoseText.text = "You Win!";
    }

    void PlayerLose()
    {
        winLoseContainer.SetActive(true);
        winLoseText.color = Color.white;
        winLoseContainer.GetComponent<Image>().color = Color.red;
        winLoseText.text = "Game Over!";
    }

}
