using IronChallenge.Domain.Interface;
using IronChallenge.Infrastructure.Repository;

namespace IronChallenge.Test
{
    /// <summary>
    /// MSTest, for unit testing, allows you to see errors that are not visible with a simple view.
    /// </summary>
    [TestClass]
    public class PhoneTest
    {
        private  IPhoneRepository _phoneRepository;
        [TestInitialize]
        public void Setup()
        {
            _phoneRepository = new PhoneRepository();
        }


        [TestMethod]
        public void FirtsItem()
        {
            string result = "E";
            string outPut = _phoneRepository.OldPhonePad("33#").Item2.ToUpper();
            Assert.AreEqual(result, outPut);
        }

        [TestMethod]
        public void SecondItem()
        {
            string result = "B";//IS? => BP
            string outPut = _phoneRepository.OldPhonePad("227*#").Item2.ToUpper();
            Assert.AreEqual(result, outPut);
        }

        [TestMethod]
        public void ThirdItem()
        {
            string result = "HELLO";
            string outPut = _phoneRepository.OldPhonePad("4433555 555666#").Item2.ToUpper();
            Assert.AreEqual(result, outPut);
        }
        [TestMethod]
        public void FourtItem()
        {
            string result = "TURIGON";
            string outPut = _phoneRepository.OldPhonePad("8 88777444666*664#").Item2.ToUpper();
            Assert.AreEqual(result, outPut); 
        }
        [TestMethod]
        public void ExtraItem()
        {
            string result = "ironsoftware";
            string outPut = _phoneRepository.OldPhonePad("44477766666 7777 666 333 89277733#").Item2;
            Assert.AreEqual(result, outPut);
        }
    }
}
