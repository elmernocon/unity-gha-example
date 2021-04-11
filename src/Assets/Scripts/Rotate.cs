using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _minDuration = 0f;
    [SerializeField] private float _maxDuration = 1f;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;

        _minDuration = Mathf.Max(0f, _minDuration);
        _maxDuration = Mathf.Max(_minDuration, _maxDuration);
    }

    private IEnumerator Start()
    {
        while (enabled)
        {
            var duration = Random.Range(_minDuration, _maxDuration);
            var to = Random.rotationUniform;
            yield return RotateTo(to, duration);
        }
    }

    private IEnumerator RotateTo(Quaternion to, float duration)
    {
        var elapsed = 0f;
        var wait = new WaitForFixedUpdate();
        var start = _transform.localRotation;

        while (elapsed < duration)
        {
            yield return wait;
            elapsed += Time.fixedDeltaTime;
            var normalizedTime = Mathf.Clamp01(elapsed / duration);
            var newRotation = Quaternion.Lerp(start, to, normalizedTime);
            _transform.localRotation = newRotation;
        }
    }
}
