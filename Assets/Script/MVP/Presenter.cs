namespace MVP
{
    public class Presenter
    {
        private UnitData _unitData;
        private View _view;

        public Presenter(UnitData unitData, View view)
        {
            _unitData = unitData;
            _view = view;
            UpdateView();
        }

        public void IncreaseUnitMaxStat()// UnitData(Model)의 함수 실행
        {
            var newUnitStat = new UnitStat(100, 0, 0);
            _unitData.IncreaseUnitMaxStat(newUnitStat);
            UpdateView();
        }

        public void UpdateView()//UnitData(Model)에 값이 바뀌면 View의 함수도 호출
        {
            _view.ChangeStatText(_unitData);
        }
    }
}