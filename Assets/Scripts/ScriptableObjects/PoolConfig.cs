using UnityEngine;

[CreateAssetMenu(fileName = "NewPoolConfig", menuName = "ScriptableObjects/Pooling/PoolConfig")]
public class PoolConfig : ScriptableObject
{
    [Header("Pool Settings")]
     public PoolObject prefab;
     public int initialSize = 10;
     public int maxSize = 0;
}