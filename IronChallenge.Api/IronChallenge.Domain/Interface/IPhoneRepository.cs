namespace IronChallenge.Domain.Interface
{
    public  interface IPhoneRepository
    {
        /// <summary>
        /// Accepts a set of characters and returns its equivalent in letters 
        /// </summary>
        /// <param name="input"></param>
        /// <returns> leters or '' if has not number the input</returns>
        public (int,string) OldPhonePad(string input);

    }
}
