using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevelComp : MonoBehaviour
{
    /// <summary>
    /// Получаем активную сцену и перезапускаем ее
    /// </summary>
    public void ReloadLevel()
    {
       Scene scene= SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
