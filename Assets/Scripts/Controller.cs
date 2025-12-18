using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private TMP_Text highscoreUI;
    [SerializeField] private TMP_Text scoreUI;
    [SerializeField] AudioSource SFX;
    [SerializeField] AudioClip scoreSound;
    [SerializeField] AudioClip deathSound;
    [SerializeField] GameObject deathMenu;
    [SerializeField] GameObject UI;
    private int score = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        if (InputManager.Instance != null)
            InputManager.Instance.actions.Player.Jump.performed += DoJump;
    }

    private void OnDisable()
    {
        if (InputManager.Instance != null)
            InputManager.Instance.actions.Player.Jump.performed -= DoJump;
    }

    private void DoJump(InputAction.CallbackContext ctx)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
      if (PlayerPrefs.GetInt("Highscore") < score)
      {
         PlayerPrefs.SetInt("Highscore", score);
         PlayerPrefs.Save();
      }

        if (collider.gameObject.CompareTag("Score"))
        {
            score++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            UI.SetActive(false);
            deathMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }



    private void Update()
    {
        scoreUI.text = score.ToString();
        highscoreUI.text = PlayerPrefs.GetInt("Highscore").ToString();
        if (PlayerPrefs.GetInt("Highscore") < score)
        {
            PlayerPrefs.SetInt("Highscore", score);
            PlayerPrefs.Save();
        }
    }
    private void Start()
    {
        score = 0;
    }
}
