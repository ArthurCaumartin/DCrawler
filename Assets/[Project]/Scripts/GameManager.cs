using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool _isKayboard = false;

    void Start()
    {
    }


    public void YAA(PlayerInput input)
    {
        print(input);
    }




    void Awake()
    {
        instance = this;
        GetComponent<PlayerInput>().onControlsChanged += YAA;

    }

    public void ResetGame()
    {
        StartCoroutine(Resetcoroutine());
        IEnumerator Resetcoroutine()
        {
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
