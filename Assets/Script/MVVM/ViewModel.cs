using System;

namespace MVVM
{
    public class ViewModel
    {
        private readonly UnitData _unitData;

        private Action<UnitData> _onChangedData;//데이터 변경시 실행 할 액션 (View에서 모델의 값 변경 시)

        public ViewModel(UnitData unitData)
        {
            _unitData = unitData;//UnitData(Model) 할당
        }

        public void IncreaseHealth()
        {
            _unitData.IncreaseUnitMaxStat(new UnitStat(100, 0, 0));
            _onChangedData?.Invoke(_unitData);
        }

        public void DecreaseUnitStat()
        {
            _unitData.DecreaseUnitMaxStat(new UnitStat(-100, 0, 0));
            _onChangedData?.Invoke(_unitData);
        }

        public void Subscribe(Action<UnitData> action)//액션 구독 
        {
            _onChangedData += action;
            _unitData.Subscribe(_onChangedData);// UnitData(Model)에서 값이 변경돼도 View로 바인딩되게 액션 구독
            
            _onChangedData?.Invoke(_unitData);//첫 실행 시 View에 바로 바인딩되게 
        }

        public void UnSubscribe(Action<UnitData> action)
        {
            _onChangedData -= action;
            _unitData.UnSubscribe(_onChangedData);
        }
    }
}