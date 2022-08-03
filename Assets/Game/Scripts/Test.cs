using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    [SerializeField]
    private Knife knife;

    public void Reload()
    {
        SceneManager.LoadScene("Game");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            knife.Jump();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }
}
