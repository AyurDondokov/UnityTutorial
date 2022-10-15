
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] Sprite circleSprite;
    [SerializeField] Sprite boxSprite;
    [SerializeField] Transform groundCheckTransform;
    [SerializeField] LayerMask groundLayer;

    public float Speed;
    public float JumpForce;

    private Rigidbody2D _rb;
    private CapsuleCollider2D _collider;
    private SpriteRenderer _spriteRenderer;
    private float _radiusGrCheck = 0.3f;

    private enum State
    {
        Stay,
        Move,
        inJump
    }
    private State _state
    {
        get {
            if (_isGrounded)
                return _movementVector != Vector2.zero ? State.Move : State.Stay;
            else
                return State.inJump;
        }
    }
    private bool _isGrounded
    {
        get{//создаем невидимую физическую капсулу и проверяем не пересекает ли она обьект который относится к полу
            return Physics2D.OverlapCircle(groundCheckTransform.position, _radiusGrCheck, groundLayer);
        }
    }
    private Vector2 _movementVector
    {
        get {
            var Horizontal = Input.GetAxis("Horizontal");
            var Vertical = Input.GetAxis("Vertical");

            return new Vector2(Horizontal, Vertical);
        }
    }
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    void Update()
    {
        _spriteRenderer.sprite = (int)_state == 2 ? circleSprite : boxSprite;

        JumpLogic();
    }

    private void FixedUpdate()
    {
        MoveLogic();
    }
    private void MoveLogic() {
        _rb.AddForce(_movementVector*Speed, ForceMode2D.Impulse);
    }
    private void JumpLogic() {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            _rb.AddForce(Vector3.up * JumpForce, ForceMode2D.Impulse);
    }
}
