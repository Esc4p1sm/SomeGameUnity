using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevelComp : MonoBehaviour
{
    /// <summary>
    /// �������� �������� ����� � ������������� ��
    /// </summary>
    public void ReloadLevel()
    {
       Scene scene= SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
