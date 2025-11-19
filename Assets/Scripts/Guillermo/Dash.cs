using System.Collections;
using UnityEngine;

public class Dash : MonoBehaviour, ISkill
{
    [SerializeField] private float speedIncrease = 40;
    [SerializeField] private float duration = 1f;

    private MeshRenderer _mesh;
    private Collider _collider;

    private void Awake()
    {
        _mesh = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
    }

    public void OnPickup(MovementCar car)
    {
        _mesh.enabled = false;
        _collider.enabled = false;
    }
    public void ActivateSkill(MovementCar car)
    {
        car.setMoveSpeed(speedIncrease);
        StartCoroutine(DashSequence(car));
    }
    private IEnumerator DashSequence(MovementCar taxi)
    {
        ActivateDash(taxi);
        taxi.isDashing = true;
        
        yield return new WaitForSeconds(duration);

        taxi.isDashing = false;
        Destroy(gameObject);
    }
    private void ActivateDash(MovementCar taxi)
    {
        taxi.setMoveSpeed(speedIncrease);
    }
}