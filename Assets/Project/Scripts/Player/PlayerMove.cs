using UnityEngine;
using Zenject;

public class PlayerMove : MonoBehaviour, IMovable
{
    [SerializeField] private float speed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    [Inject] private IInputPlayer _input;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    void Update()
    {
        // Получаем ввод с WASD/Стрелок/Геймпада
        moveInput = _input.GetAxisRaw();
        moveInput.Normalize(); // Чтобы по диагонали не бежать быстрее
    }

    void FixedUpdate() => Move(moveInput);

    public void Move(Vector2 vectorMove) => rb.velocity = vectorMove * speed;
    
}
