using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchFade : MonoBehaviour
{
    [Header("Fade in/out settings")]
    [SerializeField] CanvasGroup canGroup;
    [SerializeField] float fadeDur = 0.5f;
    public static SwitchFade Instance;
    public ScreenSwitchValues sC;

    void FixedUpdate()
    {
        if (sC.canFadeIn == true) fadeIn();
    }

    async Task Fade(float targetTrans)
    {
        float start = canGroup.alpha, t = 0; // Creates float that is equal to the Canvasgroups alpha, and to a variable named "t"
        while(t < fadeDur)
        {
            t += Time.deltaTime;
            canGroup.alpha = Mathf.Lerp(start, targetTrans, t / fadeDur); // Change from start to the target trans by FadeDur
            await Task.Yield();
        }
        canGroup.alpha = targetTrans;
    }
    public async Task fadeIn() => await Fade(0); // Change Target trans to 2

}
