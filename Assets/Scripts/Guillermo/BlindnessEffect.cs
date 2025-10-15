using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlindnessEffect : MonoBehaviour
{
    public Image blindImage;

    public float fadeInTime;  
    public float blindTime;      
    public float fadeOutTime;

    private bool isBlinded = false;
    public void TriggerBlind()
    {
        if (!isBlinded)
        {
            StartCoroutine(BlindRoutine());
        }
    }

    private IEnumerator BlindRoutine()
    {
        isBlinded = true;
        blindImage.gameObject.SetActive(true);

        Color color = blindImage.color;
        color.a = 0;
        blindImage.color = color;

        // 🔹 Fade In (aparece la tinta)
        float t = 0;
        while (t < fadeInTime)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, t / fadeInTime);
            blindImage.color = color;
            yield return null;
        }

        // 🔹 Mantener pantalla negra
        yield return new WaitForSeconds(blindTime);

        // 🔹 Fade Out (se desvanece la tinta)
        t = 0;
        while (t < fadeOutTime)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, t / fadeOutTime);
            blindImage.color = color;
            yield return null;
        }

        blindImage.gameObject.SetActive(false);
        isBlinded = false;
    }
}
