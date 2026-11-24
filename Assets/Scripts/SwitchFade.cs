using System.Threading.Tasks;
using UnityEngine;

public class SwitchFade : MonoBehaviour
{
    [Header("Fade in/out settings")]
    [SerializeField] CanvasGroup canGroup;
    [SerializeField] float fadeDur = 0.5f;
    public static SwitchFade Instance;


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

    public async Task fadeOut() => await Fade(1); // Change Target trans to 1
    public async Task fadeIn() => await Fade(0); // Change Target trans to 2

}
