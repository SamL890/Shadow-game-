using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using NaughtyAttributes;

public class ScreenSwitchScript : MonoBehaviour
{
    [Header("Scene Settings")]
    [Scene] public string switchTo;

    public void OnSwitchScene(InputAction.CallbackContext context)
    {
        if (context.performed && ScreenSwitchValueScript.CanSwitch)
        {
            SceneManager.LoadScene(switchTo);
        }
    }
}
