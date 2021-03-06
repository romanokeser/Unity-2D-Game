using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenShake : MonoBehaviour
{
    // Transform of the GameObject you want to shake
    private Transform transform;

    // Desired duration of the shake effect
    private float shakeDuration;

    // A measure of magnitude for the shake. Tweak based on your preference
    [SerializeField] private float shakeMagnitude = 0.7f;

    // A measure of how quickly the shake effect should evaporate
    [SerializeField] private float dampingSpeed = 1.0f;

    // The initial position of the GameObject
    Vector3 initialPosition;

    private bool _isShakig;
    private bool _gameOver;

    void Awake()
    {
        if (transform == null)
        {
            transform = GetComponent(typeof(Transform)) as Transform;

        }
    }

    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {

        transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

        shakeDuration -= Time.deltaTime * dampingSpeed;

    }

    public void Shake()
    {
        //_isShakig = true;
        //StartCoroutine(shakeMagnitude);
    }
    public void TriggerShake()
    {
        shakeDuration = 2.0f;
    }
}
