using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSwitchValueScript : MonoBehaviour
{
    public static bool CanSwitch;
    public float switchCooldown = 1.5f;
    public bool switchDebug;

    private void Awake()
    {
        if (FindObjectsByType<ScreenSwitchValueScript>().Length > 1 && !switchDebug)
        {
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += TriggerCooldown;
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy() => SceneManager.sceneLoaded -= TriggerCooldown;

    private void TriggerCooldown(Scene scene, LoadSceneMode loadMode)
    {
        StartCoroutine(TriggerCooldown());
    }

    private IEnumerator TriggerCooldown()
    {
        CanSwitch = false;
        yield return new WaitForSeconds(switchCooldown);
        CanSwitch = true;
    }
}
