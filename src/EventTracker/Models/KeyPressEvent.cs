namespace EventTracker.Models {
    public class KeyPressEvent {
        public string Type { set; get; }
        public bool Bubbles { set; get; }
        public bool Cancelable { set; get; }
        public double Detail { set; get; }
        public string Char { set; get; }
        public string Key { set; get; }
        public string Code { set; get; }
        public int KeyCode { set; get; }
        public int Which { set; get; }
        public double Location { set; get; }
        public bool Repeat { set; get; }
        public string Locale { set; get; }
        public bool CtrlKey { set; get; }
        public bool ShiftKey { set; get; }
        public bool AltKey { set; get; }
        public bool MetaKey { set; get; }
    }
}