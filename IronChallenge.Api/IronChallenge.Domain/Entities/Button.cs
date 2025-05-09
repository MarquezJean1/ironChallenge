namespace IronChallenge.Domain.Entities
{
    /// <summary>
    /// This class is to store the digit and list of characters that each button on the phone's keypad has.
    /// </summary>
    public class Button
    {
        /// <summary>
        /// The identifier of each character list.
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// The list of characters.
        /// </summary>
        public List<string> Letters { get; set; } = [];
    }
}
