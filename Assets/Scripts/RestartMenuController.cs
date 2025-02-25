using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void SceneChanger(string RestartMenu) {
        SceneManager.LoadScene(RestartMenu);
    }
}
