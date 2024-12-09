using UnityEngine;

public class Player : MonoBehaviour
{

    private float xInput, yInput;
    [SerializeField]
    float moveSpeed = 1;

    public LevelManager levelManager;

    Rigidbody2D rb;

    private SoundManager soundManager;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();

    }
    private void FixedUpdate() => MovePlayer();

    void GetPlayerInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }

    void MovePlayer()
    {
        //Vector3 moveDirection = new Vector3(xInput, yInput, 0);
        //Vector3 moveDelta = moveDirection.normalized * (moveSpeed * Time.deltaTime);
        //transform.position += moveDelta;

        Vector2 newVelocity = new Vector2(xInput, yInput).normalized * moveSpeed;
        rb.velocity = newVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            PLayerDie();
        }
    }

    private void PLayerDie()
    {
        soundManager.PlayGameOverAudio();
        levelManager.OnPlayerDead();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            LevelComplate();
        }
    }

    private void LevelComplate()
    {
        soundManager.PlayLevelCompleteAudio();
        levelManager.OnLevelComplete();
        gameObject.SetActive(false);
    }
}
