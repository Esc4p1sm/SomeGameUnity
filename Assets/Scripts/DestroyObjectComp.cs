using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectComp : MonoBehaviour
{
    [SerializeField] private GameObject _objectToDestroy;
    /// <summary>
    /// Метод для уничтожения объекта
    /// </summary>
    public void DestroySelf()
    {
        Destroy(_objectToDestroy);
    }
}
