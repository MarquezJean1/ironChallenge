using IronChallenge.Domain.Dtos;
using IronChallenge.Domain.Entities;
using IronChallenge.Domain.Interface;
using System.Collections.Generic;

namespace IronChallenge.Infrastructure.Repository
{
    public class PhoneRepository: IPhoneRepository
    {
        public (int, string) OldPhonePad(string input)
        {
            try
            {
                ///List button (number) with your list Character
                List<Button> PhoneKeypad = ListButtons();
                
                List<ButtonDto> buttonDtos = [];
                //Used for get the numbers and clear the character not permited in the string input
                List<string> NumberToCode = PhoneKeypad.Select(btn => $"{btn.Number}").ToList();

                //Separe string 
                var listInputs = input.Split(' ');

                foreach (var _input in listInputs)
                {
                    // Get number and count repetition
                    buttonDtos.AddRange( _input
                        .Where(chr => NumberToCode.Contains($"{chr}"))
                        .GroupBy(chr => chr)
                        .Select(chr => new ButtonDto
                        {
                            Character = $"{chr.First()}",
                            TotalRepition = chr.Count()
                        })
                        .ToList());
                }
                var decoder = "";

                //decodified string input
                foreach (var buttonDto in buttonDtos)
                {
                    var listLetters = PhoneKeypad.Where(chr => $"{chr.Number}" == buttonDto.Character).Select(chr => chr.Letters).FirstOrDefault();
                    var totalRepetition = buttonDto.TotalRepition;
                    if (listLetters != null)
                        while (totalRepetition > 0)
                        {
                            if (totalRepetition > listLetters.Count)
                            {
                                decoder += listLetters.OrderDescending().FirstOrDefault();
                                totalRepetition -= listLetters.Count;
                            }
                            else
                            {
                                decoder += listLetters.ElementAt(totalRepetition - 1);
                                totalRepetition = 0;
                            }
                        }
                }
                //IS OK
                return (200, decoder);

            }
            catch (Exception ex)
            {
                // IS BADREQUEST
                return (400, ex.Message);
            }
            
        }

        /// <summary>
        /// List of characters that each button on the phone's keypad has.
        /// </summary>
        /// <returns></returns>
        private static List<Button> ListButtons() => new()
        {
            /*new ()
            {
                Number = 0,
                Letters = [" "]
            },
            new ()
            {
                Number = 1,
                Letters = ["&","'","("]
            },*/
            new ()
            {
                Number = 2,
                Letters = ["a","b","c"]
            },
            new ()
            {
                Number = 3,
                Letters = ["d","e","f"]
            },
            new ()
            {
                Number = 4,
                Letters = ["g","h","i"]
            },
            new ()
            {
                Number = 5,
                Letters = ["j","k","l"]
            },
            new ()
            {
                Number = 6,
                Letters = ["m","n","o"]
            },
            new ()
            {
                Number = 7,
                Letters = ["p","q","r","s"]
            },
            new ()
            {
                Number = 8,
                Letters = ["t","u","v"]

            },
            new ()
            {
                Number = 9,
                Letters = ["w","x","y","z"]

            }

        };
    }
}
