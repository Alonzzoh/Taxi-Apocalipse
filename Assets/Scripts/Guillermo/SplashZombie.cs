using UnityEngine;

public class SplashZombie : MonoBehaviour
{
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
