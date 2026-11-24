using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using NaughtyAttributes;

public class ScreenSwitch : MonoBehaviour
{
    [Header("Scene Settings")]
    [Scene] public string switchTo;

    public void OnSwitchScene(InputAction.CallbackContext context)
    {
        if (context.performed && ScreenSwitchValues.canSwitch)
        {
            SceneManager.LoadScene(switchTo);
        }
    }
}
