namespace Ui_Compact.Models
{
    public class DebugMessage
    {
        public string? Name { get; set; }
        public string? Message { get; set; }
        public bool IsVisible { get; set; }

        public DebugMessage(string? name, string message)
        {
            if (name == null) Name = name;
            else Name = name;
            Message = message;
            IsVisible = true;
        }

        public DebugMessage(string message)
        {
            Name = "ETC";
            Message = message;
            IsVisible = true;
        }

        public DebugMessage(string? name, string message, bool isVisible) : this(name, message)
        {
            IsVisible = isVisible;
        }

        public DebugMessage(string message, bool isVisible) : this(message)
        {
            IsVisible = isVisible;
        }
    }
}
