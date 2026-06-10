using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private float xRange;
    [SerializeField] private float yRange;

    [SerializeField] private float controlRotationFactor;

    private Vector2 _movement;

    private void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    public void OnMovement(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }

    private void ProcessTranslation()
    {
        var xOffset = Time.deltaTime * speed * _movement.x;
        var rawXPos = xOffset + transform.localPosition.x;
        var xClampPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        var yOffset = Time.deltaTime * speed * _movement.y;
        var rawYPos = yOffset + transform.localPosition.y;
        var yClampPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(xClampPos, yClampPos, 0f);
    }

    private void ProcessRotation()
    {
        var pitch = -controlRotationFactor * _movement.y;
        var roll = -controlRotationFactor * _movement.x;

        var targetRotation = Quaternion.Euler(pitch, 0f, roll);

        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, 1f - Mathf.Exp(-rotationSpeed * Time.deltaTime));
    }
}
