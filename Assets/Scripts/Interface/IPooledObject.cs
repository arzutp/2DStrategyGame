using UnityEngine;

public interface IPooledObject
{
    string GetName();
    Sprite GetImage();
    void OnObjectSpawn(bool isActive);
}
