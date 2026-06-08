using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector2 _movement;

    private void Update()
    {
        PlayerMovement();
    }

    public void OnMovement(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }

    private void PlayerMovement()
    {
        var xOffset = (Time.deltaTime * speed * _movement.x) + transform.localPosition.x;
        var yOffset = (Time.deltaTime * speed * _movement.y) + transform.localPosition.y;

        transform.localPosition = new Vector3(xOffset, yOffset, 0f);
    }
}
