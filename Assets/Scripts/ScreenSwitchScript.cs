using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class ScreenSwitchScript : MonoBehaviour
{
    [Header("Scene Settings")]
    public string switchTo = "";
    public PlayerMovement pM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnSwitchScene(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            pM.justSwitched = true;
            SceneManager.LoadScene(switchTo);
        }
    }

}