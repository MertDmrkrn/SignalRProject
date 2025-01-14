namespace SignalRWebUI.ViewModel
{
    public class ApiValidationErrorResponse
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Mail { get; set; }

        public int PersonCount { get; set; }

        public Dictionary<string, List<string>> Errors { get; set; }

        public DateTime Date { get; set; }
    }
}
