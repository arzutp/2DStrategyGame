using UnityEngine;

public interface IPooledObject
{
    string GetName();
    Sprite GetImage();
    void OnObjectSpawn(string tag, Vector3 position, Quaternion rotation);
}
