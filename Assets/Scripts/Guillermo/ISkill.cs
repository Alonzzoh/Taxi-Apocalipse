using UnityEngine;

public interface ISkill
{
    void OnPickup(MovementCar car);
    void ActivateSkill(MovementCar car);
}