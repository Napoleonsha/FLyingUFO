using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 5f;
    private int score;

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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Score"))
        {
            score++;
        }
    }
}
