using UnityEngine;

public class TrailClean : MonoBehaviour
{
    [SerializeField] private TrailRenderer _trail;

    private void OnDisable() => _trail.Clear();
}
