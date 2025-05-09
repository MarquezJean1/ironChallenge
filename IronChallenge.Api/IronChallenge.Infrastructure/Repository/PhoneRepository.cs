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
                List<Button> PhoneKeypad = ListButtons();
                List<ButtonDto> buttonDtos = [];
                List<string> NumberToCode = PhoneKeypad.Select(btn => $"{btn.Number}").ToList();

                var listInputs = input.Split(' ');

                foreach (var _input in listInputs)
                {
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

                foreach (var buttonDto in buttonDtos)
                {
                    var letersCount = PhoneKeypad.Where(chr => $"{chr.Number}" == buttonDto.Character).Select(chr => chr.Letters).FirstOrDefault();
                    var total = buttonDto.TotalRepition;
                    if (letersCount != null)
                        while (total > 0)
                        {
                            if (total > letersCount.Count)
                            {
                                decoder += letersCount.OrderDescending().FirstOrDefault();
                                total -= letersCount.Count;
                            }
                            else
                            {
                                decoder += letersCount.ElementAt(total - 1);
                                total = 0;
                            }
                        }
                }

                return (200, decoder);

            }
            catch (Exception ex)
            {
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
