using UnityEngine;

public class LookAtAwake : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Awake()
    {
        if (_target == null) return;

        transform.LookAt(_target);
    }
}
