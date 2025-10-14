using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlindnessEffect : MonoBehaviour
{
    public Image blindImage; 
    public float blindDuration = 3f;

    private bool isBlinded = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
        yield return new WaitForSeconds(blindDuration);
        blindImage.gameObject.SetActive(false); 
        isBlinded = false;
    }
}
