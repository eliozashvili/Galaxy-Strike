using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootLaser : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] particles;
    [SerializeField] private RectTransform crosshair;
    [SerializeField] private Transform targetPoint;
    [SerializeField] private float targetDistance;

    private bool _isInitialized;
    private Camera _mainCamera;

    private void Awake()
    {
        if (particles == null || particles.Length == 0) return; // Check for particles

        _isInitialized = true; // Flag that information is loaded
    }

    private void Start()
    {
        _mainCamera = Camera.main;
        Cursor.visible = false;
    }

    private void Update()
    {
        var mousePosition = Mouse.current.position.ReadValue();

        MoveCrosshair(mousePosition);
        MoveTargetPoint(mousePosition);
    }

    public void OnShoot(InputValue value)
    {
        if (!_isInitialized) return; // Eliminate unnecessary calls on input if particles are null

        SetEmission(value.isPressed);
    }

    private void SetEmission(bool isLmbHeld)
    {
        foreach (var particle in particles)
        {
            if (!particle) continue;

            var emission = particle.emission;

            if (emission.enabled != isLmbHeld)
                emission.enabled = isLmbHeld;
        }
    }

    private void MoveCrosshair(Vector2 mousePos)
    {
        if (!crosshair) return;
        // Since Mouse.current.position.ReadValue() is Vector2 and .position is Vector3
        // we visibly do conversion
        crosshair.position = new Vector3(mousePos.x, mousePos.y, 0f);
    }

    private void MoveTargetPoint(Vector2 mousePos)
    {
        if (!targetPoint) return;

        var targetPointPosition = new Vector3(mousePos.x, mousePos.y, targetDistance);
        targetPoint.position = _mainCamera.ScreenToWorldPoint(targetPointPosition);
    }

    private void OnValidate()
    {
        if (targetDistance < 150f)
            targetDistance = 200f;

        if (particles != null && particles.Length != 0 && Array.TrueForAll(particles, x => !x)) return;

        particles = GetComponentsInChildren<ParticleSystem>();
    }
}
