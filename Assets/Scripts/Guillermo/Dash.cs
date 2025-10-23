using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField]
    private float speedIncrease = 40;
    private bool dash = false;
    [SerializeField]
    private float duration = 1f;

    [SerializeField]
    private GameObject artDestroy = null;
    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        MovementCar taxi = other.gameObject.GetComponent<MovementCar>();
        if (taxi != null)
        {
            dash = true;
            taxi.isDashing = true;
            StartCoroutine(DashSequence(taxi));
        }
    }

    public IEnumerator DashSequence(MovementCar taxi)
    {
        _collider.enabled = false;
        artDestroy.SetActive(false);

        ActivateDash(taxi);

        yield return new WaitForSeconds(duration);

        DeactivateDash(taxi);
        taxi.isDashing = false;

        Destroy(gameObject);
    }

    private void ActivateDash(MovementCar taxi)
    {
        taxi.setMoveSpeed(speedIncrease);
    }

    private void DeactivateDash(MovementCar taxi)
    {
        taxi.setMoveSpeed(-speedIncrease);
    }
}
