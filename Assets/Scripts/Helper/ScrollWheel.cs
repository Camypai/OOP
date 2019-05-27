namespace IgUnity.Helper
{
    public sealed class ScrollWheel
    {
        private int _scrollId;
        private readonly int _scrollMaxId;

        public int ScrollId
        {
            get => _scrollId;
            set
            {
                if (value > _scrollMaxId)
                {
                    _scrollId = 0;
                }
                else if (value < 0)
                {
                    _scrollId = _scrollMaxId;
                }
                else if (value >= 0 & value <= _scrollMaxId)
                {
                    _scrollId = value;
                }

                OnScrollWheelChanged(_scrollId);
            }
        }

        public ScrollWheel(int scrollMaxId)
        {
            _scrollMaxId = scrollMaxId - 1;
        }

        public delegate void ScrollWheelEventHandler(ScrollWheelEventArgs args);

        public event ScrollWheelEventHandler ScrollWheelChanged;

        private void OnScrollWheelChanged(int id)
        {
            ScrollWheelChanged?.Invoke(new ScrollWheelEventArgs(id));
        }
    }
}