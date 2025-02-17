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

        public void IncreaseUnitMaxStat()
        {
            var newUnitStat = new UnitStat(100, 0, 0);
            _unitData.IncreaseUnitMaxStat(newUnitStat);
            UpdateView();
        }

        public void UpdateView()
        {
            _view.ChangeStatText(_unitData);
        }
    }
}