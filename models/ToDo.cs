using todoDotNet6.Services;

namespace todoDotNet6.models;

    public class ToDo:IToDo
    {
        public Guid ID { get; set; }
        public string? TaskDescription{ get; set; }

        public DateTime CreatedAt { get; } = DateTime.Now;

        public DateTime DueDate{ get; set; }

        public bool Completed{ get; set; } = false;
    }

