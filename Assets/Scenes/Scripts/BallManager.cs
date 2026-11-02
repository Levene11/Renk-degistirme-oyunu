using UnityEngine;
using static Pillars;
public class BallManager : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.5f;
    private Renderer _renderer;
    private Vector3 _startPosition;

    private PillarColors _currentColor;
    private bool _hasColor = false;
    private bool _gameCompleted = false;

    public PillarColors CurrentColor
    {
        get { return _currentColor; }
    }

    public bool HasColor
    {
        get { return _hasColor; }
    }


    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _startPosition = transform.position;
    }

    private void Update()
    {
        if (!_gameCompleted)
        {
            Movement();
        }
    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        transform.Translate(direction * (moveSpeed * Time.deltaTime), Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bir nesneye carpti!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Red"))
        {
            ChangeColor(PillarColors.red, Color.red);
            Debug.Log("Oyuncu Kirmizi oldu!");
        }
        else if (other.CompareTag("Blue"))
        {
            ChangeColor(PillarColors.blue, Color.blue);
            Debug.Log("Oyuncu Mavi oldu!");
        }
        else if (other.CompareTag("Yellow"))
        {
            ChangeColor(PillarColors.yellow, Color.yellow);
            Debug.Log("Oyuncu Sari oldu!");
        }
        else if (other.CompareTag("Green"))
        {
            ChangeColor(PillarColors.green, Color.green);
            Debug.Log("Oyuncu Yesil oldu!");
        }
        else if (other.CompareTag("LevelEnd"))
        {
            CompleteGame();
        }
    }

    private void ChangeColor(PillarColors newColor, Color color)
    {
        _currentColor = newColor;
        _hasColor = true;

        _renderer.material.color = color;
    }

    public void ResetPlayer()
    {
        transform.position = _startPosition;
        _renderer.material.color = Color.white;
        _hasColor = false;
        Debug.Log("Yanlis Renk! Basa Donuldu");
    }

    public void CompleteGame()
    {
        _gameCompleted = true;
        Debug.Log("Level Completed!");
    }
}
