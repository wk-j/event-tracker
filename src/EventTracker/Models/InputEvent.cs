namespace EventTracker.Models {
    public class Event {
        public bool Bubbles { set; get; }
        public bool CancelBubble { set; get; }
        public bool Cancelable { set; get; }
        public bool Composed { set; get; }
        public bool DefaultPrevented { set; get; }
        public int Detail { set; get; }
        public int EventPhase { set; get; }
        public bool IsComposing { set; get; }
        public bool IsTrusted { set; get; }
        public int LayerX { set; get; }
        public int LayerY { set; get; }
        public int PageX { set; get; }
        public int PageY { set; get; }
        public int RangeOffSet { set; get; }
        public int TimeStamp { set; get; }
        public int Which { set; get; }
    }
}