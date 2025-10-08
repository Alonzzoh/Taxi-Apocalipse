using UnityEngine;

public class SplashZombie : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BlindnessEffect blind = collision.gameObject.GetComponent<BlindnessEffect>();
            if (blind != null)
            {
                blind.TriggerBlind();
            }

            Debug.Log("Jugador cegado por el zombie!");
        }
    }
}
