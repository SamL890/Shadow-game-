using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class screeanswic1jh : MonoBehaviour
{
    [Header("Scene Settings")]
    public string test = "scene2";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public void OnSwitchScene(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SceneManager.LoadScene(test);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
