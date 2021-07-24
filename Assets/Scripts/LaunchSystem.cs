using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchSystem : MonoBehaviour
{
    public void OpenFinal()
    {
        SceneManager.LoadScene("final", LoadSceneMode.Single);
    }

}
