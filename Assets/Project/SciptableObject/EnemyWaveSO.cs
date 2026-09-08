using UnityEngine;

[CreateAssetMenu(menuName = "SO/EnemyWave", fileName = "Wave")]
public class EnemyWaveSO : ScriptableObject
{
    [SerializeField] private Wave[] _waves;

    public Wave[] Waves => _waves;
}

[System.Serializable]
public struct GroupEnemy
{
    [Header("Тип Врага")]
    [SerializeField] private EnemyType _type;
    [Header("Количество врагов")]
    [SerializeField] private int _count;

    public EnemyType Type => _type;
    public int Count => _count;
}

[System.Serializable]
public struct Wave
{
    [SerializeField] private GroupEnemy[] _dataWave;

    public GroupEnemy[] DataWaves => _dataWave;
}