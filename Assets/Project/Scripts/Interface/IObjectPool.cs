using UnityEngine;

public interface IObjectPool 
{
    void Initialize(GameObject pref, int startSize);
    void CreatePart(GameObject gm);
    GameObject SpawnObject( Vector2 spawnPosition, Quaternion quaternion);
    void DeactivateObject(GameObject gm);
}
