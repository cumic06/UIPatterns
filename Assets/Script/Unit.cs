using UnityEngine;

public class Unit : MonoBehaviour
{
    private UnitData _unitData;

    public void OnInitialize(UnitData unitData)
    {
        _unitData = unitData;
        _unitData.OnInitialize();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _unitData.DecreaseUnitStat(new UnitStat(1, 0, 0));
        }
    }
}