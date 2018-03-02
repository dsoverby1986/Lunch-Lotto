using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LunchLotto
{
    public static class LunchLotto
    {
        private static List<string> Participants { get; } = new List<string>();
        private static string Winner { get; set; }

        public static void GetParticipants()
        {
            Console.Clear();
            DisplayParticipantList();
            GetParticipantName();
        }

        private static void DisplayParticipantList()
        {
            if (Participants.Any())
            {
                Console.WriteLine("Participants");
                Console.WriteLine("------------");
                foreach (string participant in Participants)
                {
                    Console.WriteLine(participant);
                    if (participant == Participants.Last())
                        Console.WriteLine();
                }
            }
        }

        private static void GetParticipantName()
        {
            Console.WriteLine("Enter participant name...\n");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("\nInvalid input. Try again.\n");
                GetParticipantName();
            }
            else if (Participants.Contains(name))
            {
                Console.WriteLine($"\n{name} is already included as a participant.");
                CheckForMoreParticipants();
            }
            else
            {
                Participants.Add(name);
                CheckForMoreParticipants();
            }
        }

        private static void CheckForMoreParticipants()
        {
            Console.WriteLine("\nWould you like to add another participant? (y/n)\n");
            string answer = Console.ReadLine().ToLower();
            if (Regex.IsMatch(answer, "^y(es)?$"))
                GetParticipants();
            else if (Regex.IsMatch(answer, "^n(o)?$"))
                return;
            else
            {
                Console.WriteLine("\nInvalid input. Try again.");
                CheckForMoreParticipants();
            }
        }

        public static void Run()
        {
            Random rdm = new Random();
            Winner = Participants[rdm.Next(0, Participants.Count)];
        }

        public static void DisplayWinner()
        {
            Console.Clear();
            DisplayParticipantList();
            Console.WriteLine("And the winner of this week's Lunch Lotto is...");
            AddSuspense();
            Console.WriteLine("Drum roll please...");
            AddSuspense();
            Console.WriteLine($"\n{Winner}!\n\n");
            Console.WriteLine($"Congratulations {Winner}!\n\n");
            Console.WriteLine("Don't disappoint us!");
            Console.SetCursorPosition(0, 0);
            Console.ReadKey();
        }

        private static void AddSuspense()
        {
            for (int i = 0; i < 20; i++)
                Console.WriteLine((i == 19 ? "v" : "|").PadLeft(6, ' '));
        }
    }
}
