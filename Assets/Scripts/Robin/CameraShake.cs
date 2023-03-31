using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.5f;
    public float shakeIntensity = 0.2f;

    private float shakeTimer = 0f;

    void Update()
    {
        if (shakeTimer > 0f)
        {
            float shakeX = Random.Range(-1f, 1f) * shakeIntensity;
            float shakeY = Random.Range(-1f, 1f) * shakeIntensity;
            float noise = Mathf.PerlinNoise(Time.time * 25f, Time.time * 25f) * shakeIntensity;
            shakeX += noise;
            shakeY += noise;

            transform.localPosition = new Vector3(shakeX, shakeY, transform.localPosition.z);

            shakeTimer -= Time.deltaTime;
        }
        else
        {
            transform.localPosition = Vector3.zero;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        shakeTimer = shakeDuration;
    }
}
