namespace EventTracker.Models {
    public class MouseEvent {
        public bool Bubbles { set; get; }
        public bool Cancelable { set; get; }
        public double Detail { set; get; }
        public int ScreenX { set; get; }
        public int ScreenY { set; get; }
        public int ClientX { set; get; }
        public int ClientY { set; get; }
        public int Button { set; get; }
        public int Buttons { set; get; }
        public bool CtrlKey { set; get; }
        public bool ShiftKey { set; get; }
        public bool AltKey { set; get; }
        public bool MetaKey { set; get; }
    }
}