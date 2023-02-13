using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Raycast))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] private int startLives = 3;
    [SerializeField] private float jumpForce = 10f;

    public int Lives { get; private set; }
    public int Score { get; private set; }

    private Rigidbody2D rb;
    private Raycast raycast;

    private void Start()
    {
        Instance = this;
        Lives = startLives;
        Score = 0;

        rb = GetComponent<Rigidbody2D>();
        raycast = GetComponent<Raycast>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && raycast.IsGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        if (Lives <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PointSprite"))
        {
            if (DayNightChange.Instance.IsDay())
            {
                Score++;
            }
            else
            {
                Lives--;
            }

            UIScript.Instance.UpdateText();
        }
    }
}