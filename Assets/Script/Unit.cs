using UnityEngine;

public class Unit : MonoBehaviour
{
    private UnitStat _unitStat;

    public void OnInitialize(UnitStat unitStat)
    {
        _unitStat = new UnitStat(unitStat.Health, unitStat.AttackPower, unitStat.DefensePower);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _unitStat.Health--;
        }
    }
}