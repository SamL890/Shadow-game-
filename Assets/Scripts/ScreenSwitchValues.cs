using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSwitchValues : MonoBehaviour
{

    [Header("Screen Switch Settings")]
    public float switchCooldown = 1.5f;
    public static bool canSwitch;
    public static bool switchDebug;

    private void Awake()
    {
        if (!switchDebug)
        {
            if (FindObjectsByType<ScreenSwitchValues>().Length > 1) //If More than one script exists do:
            {
                Destroy(gameObject);
                return;
            }
            SceneManager.sceneLoaded += TriggerCooldown; // Activate the TriggerCoolodwn
            DontDestroyOnLoad(gameObject);
        }
        else canSwitch = true; // If variable switchDebug is disable cooldown
    }

    private void OnDestroy() => SceneManager.sceneLoaded -= TriggerCooldown; // When destroyed unload the Trigger Cooldown Script

    private void TriggerCooldown(Scene scene, LoadSceneMode loadMode)
    {
        StartCoroutine(TriggerCooldown()); // Start Cooldown
    }

    private IEnumerator TriggerCooldown()
    {
        canSwitch = false;
        yield return new WaitForSeconds(switchCooldown);
        canSwitch = true;
    }
}
