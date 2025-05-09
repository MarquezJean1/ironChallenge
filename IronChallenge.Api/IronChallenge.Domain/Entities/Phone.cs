namespace IronChallenge.Domain.Entities
{
    /// <summary>
    /// This class is to store the digit and the list of characters that each digit has.
    /// </summary>
    public class Phone
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
