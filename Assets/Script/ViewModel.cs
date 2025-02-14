using UnityEngine;

public class ViewModel
{
    private UnitData _unitData;

    public ViewModel(UnitData unitData)
    {
        _unitData = unitData;
    }

    public void IncreaseHealth()
    {
        Debug.Log("Increase Health");
        _unitData.IncreaseUnitStat(new UnitStat(100, 0, 0));
    }
}