using UnityEngine;
public interface IObjectPoolManager 
{
    GameObject SpawnObject(GameObject pref, Vector2 spawnPoint, Quaternion quaternion);
}
