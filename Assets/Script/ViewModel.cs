using System;

public class ViewModel
{
    private readonly UnitData _unitData;

    private Action<UnitData> _onChangedData;

    public ViewModel(UnitData unitData)
    {
        _unitData = unitData;
    }

    public void IncreaseHealth()
    {
        _unitData.IncreaseUnitMaxStat(new UnitStat(100, 0, 0));
        _onChangedData?.Invoke(_unitData);
    }

    public void DecreaseUnitStat(UnitStat unitStat)
    {
        _unitData.DecreaseUnitMaxStat(new UnitStat(-100, 0, 0));
        _onChangedData?.Invoke(_unitData);
    }

    public void Subscribe(Action<UnitData> action)
    {
        _onChangedData += action;
        _unitData.Subscribe(_onChangedData);
    }

    public void UnSubscribe(Action<UnitData> action)
    {
        _onChangedData -= action;
        _unitData.UnSubscribe(_onChangedData);
    }
}