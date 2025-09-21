using System;
using System.Collections.Generic;

namespace MyConsoleApps
{
    public class MillionaireGameApp
    {
        static readonly int[] MoneyLadder = new int[]
        {
            100, 200, 300, 500, 1000,      // Level 1–5
            2000, 4000, 8000, 16000, 32000, // Level 6–10
            64000, 125000, 250000, 500000, 1000000 // Level 11–15
        };

static readonly HashSet<int> SafeLevels = new HashSet<int> { 4, 9, 14 }; 
// indices (0-based): ₦1,000, ₦32,000, ₦1,000,000

        public static void Run()
{
    Console.WriteLine("\n=== Who Wants to Be a Millionaire ===");

    List<Question> questions = GetQuestions();

    // Shuffle questions (Fisher-Yates)
    Random rand = new Random();
    for (int i = questions.Count - 1; i > 0; i--)
    {
        int j = rand.Next(i + 1);
        var temp = questions[i];
        questions[i] = questions[j];
        questions[j] = temp;
    }

    bool lifelineUsed = false;
    int currentLevel = 0;
    int safePrize = 0;
    int currentPrize = 0;

    foreach (var q in questions.Take(15))  // play 15 questions only
    {
        Console.WriteLine($"\nQuestion {currentLevel + 1} for ₦{MoneyLadder[currentLevel]:N0}:");
        Console.WriteLine(q.Text);

        for (int i = 0; i < q.Options.Length; i++)
        {
            if (q.Options[i] != null)
                Console.WriteLine($"{(char)('A' + i)}. {q.Options[i]}");
        }

        while (true)
        {
            Console.Write("\nYour answer (A-D, 5050 for lifeline, Q to walk away): ");
            string input = Console.ReadLine().Trim().ToUpper();

            if (input == "5050" && !lifelineUsed)
            {
                lifelineUsed = true;
                q.Use5050();
                Console.WriteLine("\n50-50 lifeline used! Remaining options:");
                for (int i = 0; i < q.Options.Length; i++)
                {
                    if (q.Options[i] != null)
                        Console.WriteLine($"{(char)('A' + i)}. {q.Options[i]}");
                }
            }
            else if (input == "Q")
            {
                Console.WriteLine($"\n🚶 You decided to walk away with ₦{currentPrize:N0}. Well played!");
                return;
            }
            else if (input.Length == 1 && input[0] >= 'A' && input[0] <= 'D')
            {
                int choice = input[0] - 'A';
                if (choice == q.CorrectIndex)
                {
                    currentPrize = MoneyLadder[currentLevel];
                    Console.WriteLine($"✅ Correct! You now have ₦{currentPrize:N0}.");

                    if (SafeLevels.Contains(currentLevel))
                    {
                        safePrize = MoneyLadder[currentLevel];
                        Console.WriteLine($"💰 Congratulations! You’ve reached a safe level: ₦{safePrize:N0} guaranteed.");
                    }

                    currentLevel++;

                    Console.WriteLine("\n👉 Press ENTER to continue to the next question...");
                    Console.ReadLine(); // suspense pause
                    break;
                }
                else
                {
                    Console.WriteLine($"❌ Wrong! The correct answer was {q.Options[q.CorrectIndex]}.");
                    Console.WriteLine($"💸 You leave with ₦{safePrize:N0}.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }
    }

    Console.WriteLine($"\n🎉 Incredible! You are a MILLIONAIRE! You take home ₦{MoneyLadder.Last():N0}!");
}



        static List<Question> GetQuestions()
        {
            return new List<Question>
            {
                // --- General Knowledge & Geography ---
                new Question("What is the capital of France?",
                    new string[] {"Berlin", "Madrid", "Paris", "Rome"}, 2),

                new Question("Which planet is known as the Red Planet?",
                    new string[] {"Earth", "Mars", "Jupiter", "Saturn"}, 1),

                new Question("Which continent is the Sahara Desert located in?",
                    new string[] {"Asia", "Africa", "Australia", "South America"}, 1),

                new Question("What is the largest mammal in the world?",
                    new string[] {"Elephant", "Blue Whale", "Giraffe", "Shark"}, 1),

                new Question("Which ocean is the largest?",
                    new string[] {"Atlantic Ocean", "Indian Ocean", "Pacific Ocean", "Arctic Ocean"}, 2),

                new Question("What is the capital of Japan?",
                    new string[] {"Beijing", "Seoul", "Tokyo", "Kyoto"}, 2),

                new Question("What is the capital of Canada?",
                    new string[] {"Toronto", "Ottawa", "Vancouver", "Montreal"}, 1),

                new Question("What is the capital of Italy?",
                    new string[] {"Milan", "Venice", "Rome", "Naples"}, 2),

                new Question("Which is the longest river in the world?",
                    new string[] {"Amazon River", "Nile River", "Yangtze River", "Mississippi River"}, 1),

                new Question("How many continents are there on Earth?",
                    new string[] {"5", "6", "7", "8"}, 2),

                new Question("What is the national animal of Australia?",
                    new string[] {"Koala", "Kangaroo", "Emu", "Dingo"}, 1),

                new Question("What is the capital of Egypt?",
                    new string[] {"Cairo", "Alexandria", "Giza", "Luxor"}, 0),

                new Question("What is the capital of Russia?",
                    new string[] {"St. Petersburg", "Moscow", "Kiev", "Minsk"}, 1),

                new Question("What is the tallest mountain in the world?",
                    new string[] {"K2", "Everest", "Kilimanjaro", "Makalu"}, 1),

                new Question("Which country gifted the Statue of Liberty to the USA?",
                    new string[] {"England", "France", "Spain", "Germany"}, 1),

                new Question("Which country is known as the Land of the Rising Sun?",
                    new string[] {"China", "Japan", "Thailand", "Korea"}, 1),

                new Question("Which city is known as the Big Apple?",
                    new string[] {"Chicago", "Los Angeles", "New York", "Boston"}, 2),

                new Question("Which desert is the largest in the world?",
                    new string[] {"Sahara", "Gobi", "Kalahari", "Antarctic Desert"}, 3),

                new Question("Which European country has the city of Lisbon?",
                    new string[] {"Spain", "Portugal", "Italy", "France"}, 1),

                new Question("Mount Fuji is located in which country?",
                    new string[] {"China", "Japan", "South Korea", "Thailand"}, 1),

                // --- History ---
                new Question("In which year did World War II end?",
                    new string[] {"1940", "1945", "1939", "1950"}, 1),

                new Question("Who was the first President of the United States?",
                    new string[] {"George Washington", "Thomas Jefferson", "Abraham Lincoln", "John Adams"}, 0),

                new Question("Who discovered America in 1492?",
                    new string[] {"Christopher Columbus", "Vasco da Gama", "Ferdinand Magellan", "Marco Polo"}, 0),

                new Question("Which ancient civilization built the pyramids?",
                    new string[] {"Romans", "Egyptians", "Greeks", "Mayans"}, 1),

                new Question("Who was the first man in space?",
                    new string[] {"Yuri Gagarin", "Neil Armstrong", "Buzz Aldrin", "Michael Collins"}, 0),

                new Question("Who was known as the Iron Lady?",
                    new string[] {"Margaret Thatcher", "Angela Merkel", "Queen Victoria", "Indira Gandhi"}, 0),

                new Question("The Cold War was mainly between the USA and which country?",
                    new string[] {"China", "Germany", "Soviet Union", "Japan"}, 2),

                new Question("Who was assassinated in Dallas in 1963?",
                    new string[] {"Abraham Lincoln", "John F. Kennedy", "Martin Luther King Jr.", "Robert Kennedy"}, 1),

                new Question("The Great Wall of China was built mainly to protect against which group?",
                    new string[] {"Mongols", "Romans", "Japanese", "Russians"}, 0),

                new Question("Who was the British Prime Minister during most of World War II?",
                    new string[] {"Winston Churchill", "Neville Chamberlain", "Clement Attlee", "Tony Blair"}, 0),

                // --- Science ---
                new Question("Which element has the chemical symbol 'O'?",
                    new string[] {"Oxygen", "Gold", "Osmium", "Iron"}, 0),

                new Question("Which is the largest planet in our solar system?",
                    new string[] {"Earth", "Saturn", "Jupiter", "Neptune"}, 2),

                new Question("Which organ in the human body pumps blood?",
                    new string[] {"Liver", "Brain", "Heart", "Lungs"}, 2),

                new Question("Which gas do plants use for photosynthesis?",
                    new string[] {"Oxygen", "Carbon Dioxide", "Nitrogen", "Hydrogen"}, 1),

                new Question("What is the hardest natural substance on Earth?",
                    new string[] {"Gold", "Iron", "Diamond", "Quartz"}, 2),

                new Question("What is H2O commonly known as?",
                    new string[] {"Salt", "Oxygen", "Water", "Hydrogen"}, 2),

                new Question("Which blood type is known as the universal donor?",
                    new string[] {"A", "B", "O Negative", "AB Positive"}, 2),

                new Question("How many bones are in the adult human body?",
                    new string[] {"206", "210", "201", "208"}, 0),

                new Question("What is the chemical symbol for gold?",
                    new string[] {"Au", "Ag", "Gd", "Go"}, 0),

                new Question("Which part of the cell contains genetic material?",
                    new string[] {"Nucleus", "Mitochondria", "Ribosome", "Cytoplasm"}, 0),

                // --- Literature ---
                new Question("Who wrote 'Hamlet'?",
                    new string[] {"Charles Dickens", "William Shakespeare", "Mark Twain", "Tolstoy"}, 1),

                new Question("Who is the author of 'Harry Potter'?",
                    new string[] {"J.K. Rowling", "J.R.R. Tolkien", "George R.R. Martin", "C.S. Lewis"}, 0),

                new Question("Who wrote 'Pride and Prejudice'?",
                    new string[] {"Charlotte Bronte", "Jane Austen", "Emily Bronte", "Mary Shelley"}, 1),

                new Question("Who wrote 'The Odyssey'?",
                    new string[] {"Sophocles", "Plato", "Homer", "Aristotle"}, 2),

                new Question("Who created 'The Lord of the Rings'?",
                    new string[] {"J.K. Rowling", "J.R.R. Tolkien", "C.S. Lewis", "George R.R. Martin"}, 1),

                new Question("Which novel begins with 'Call me Ishmael'?",
                    new string[] {"Moby-Dick", "Oliver Twist", "The Old Man and the Sea", "Dracula"}, 0),

                new Question("Who wrote '1984'?",
                    new string[] {"George Orwell", "Aldous Huxley", "Ray Bradbury", "Arthur C. Clarke"}, 0),

                new Question("Which writer created Sherlock Holmes?",
                    new string[] {"Agatha Christie", "Arthur Conan Doyle", "Bram Stoker", "Charles Dickens"}, 1),

                new Question("Who wrote 'The Divine Comedy'?",
                    new string[] {"Virgil", "Homer", "Dante Alighieri", "Milton"}, 2),

                new Question("Which Shakespeare play features the characters Rosencrantz and Guildenstern?",
                    new string[] {"Hamlet", "Macbeth", "Othello", "King Lear"}, 0),

                // --- Sports ---
                new Question("How many players are on a soccer team (on the field)?",
                    new string[] {"9", "10", "11", "12"}, 2),

                new Question("Which sport uses a shuttlecock?",
                    new string[] {"Tennis", "Badminton", "Table Tennis", "Squash"}, 1),

                new Question("In which country did the Olympic Games originate?",
                    new string[] {"Italy", "Greece", "Egypt", "China"}, 1),

                new Question("How many rings are on the Olympic flag?",
                    new string[] {"4", "5", "6", "7"}, 1),

                new Question("Which country won the FIFA World Cup in 2018?",
                    new string[] {"Germany", "Brazil", "France", "Argentina"}, 2),

                new Question("Which sport is Michael Jordan famous for?",
                    new string[] {"Baseball", "Basketball", "Football", "Golf"}, 1),

                new Question("Which sport has terms like 'love' and 'deuce'?",
                    new string[] {"Badminton", "Tennis", "Squash", "Volleyball"}, 1),

                new Question("What is the national sport of Japan?",
                    new string[] {"Baseball", "Judo", "Sumo Wrestling", "Karate"}, 2),

                new Question("Which sport is played at Wimbledon?",
                    new string[] {"Tennis", "Golf", "Cricket", "Polo"}, 0),

                new Question("How many players are in a basketball team (on the court)?",
                    new string[] {"5", "6", "7", "8"}, 0),

                // --- Pop Culture & Entertainment ---
                new Question("Who played Jack in Titanic?",
                    new string[] {"Leonardo DiCaprio", "Brad Pitt", "Tom Cruise", "Matt Damon"}, 0),

                new Question("Which movie features the quote 'May the Force be with you'?",
                    new string[] {"Star Trek", "Star Wars", "The Matrix", "Avengers"}, 1),

                new Question("Which superhero is also known as Bruce Wayne?",
                    new string[] {"Superman", "Iron Man", "Batman", "Spider-Man"}, 2),

                new Question("Who sang 'Thriller'?",
                    new string[] {"Prince", "Elvis Presley", "Michael Jackson", "Stevie Wonder"}, 2),

                new Question("Which animated film features a talking donkey?",
                    new string[] {"Frozen", "Shrek", "Moana", "Toy Story"}, 1),

                new Question("Who played Harry Potter in the movies?",
                    new string[] {"Elijah Wood", "Daniel Radcliffe", "Rupert Grint", "Tom Felton"}, 1),

                new Question("Which movie won Best Picture at the Oscars in 2020?",
                    new string[] {"Joker", "Parasite", "1917", "Once Upon a Time in Hollywood"}, 1),

                new Question("Which singer is known as the Queen of Pop?",
                    new string[] {"Beyoncé", "Lady Gaga", "Madonna", "Whitney Houston"}, 2),

                new Question("In The Matrix, does Neo take the blue pill or the red pill?",
                    new string[] {"Blue", "Red", "Both", "Neither"}, 1),

                new Question("What is the highest-grossing movie of all time (as of 2025)?",
                    new string[] {"Titanic", "Avatar", "Avengers: Endgame", "Avatar: The Way of Water"}, 3),

                // --- Math & Logic ---
                new Question("What is the square root of 144?",
                    new string[] {"10", "11", "12", "13"}, 2),

                new Question("Which is the smallest prime number?",
                    new string[] {"0", "1", "2", "3"}, 2),

                new Question("What is 15 × 12?",
                    new string[] {"160", "170", "180", "190"}, 2),

                new Question("What is Pi rounded to 2 decimal places?",
                    new string[] {"3.14", "3.16", "3.12", "3.18"}, 0),

                new Question("What is 100 divided by 4?",
                    new string[] {"20", "25", "30", "40"}, 1),

                new Question("If you flip a fair coin, what is the probability of heads?",
                    new string[] {"25%", "50%", "75%", "100%"}, 1),

                new Question("What is 2 to the power of 5?",
                    new string[] {"16", "32", "64", "128"}, 1),

                new Question("What is 9 × 9?",
                    new string[] {"81", "72", "99", "90"}, 0),

                new Question("What is 200% of 50?",
                    new string[] {"50", "75", "100", "150"}, 2),

                new Question("What is 7 squared?",
                    new string[] {"14", "21", "49", "56"}, 2),
            };

        }
    }

    public class Question
    {
        public string Text { get; set; }
        public string[] Options { get; set; }
        public int CorrectIndex { get; set; }

        public Question(string text, string[] options, int correctIndex)
        {
            Text = text;
            Options = options;
            CorrectIndex = correctIndex;
        }

        public void Use5050()
        {
            int removed = 0;
            Random rand = new Random();

            while (removed < 2)
            {
                int i = rand.Next(Options.Length);
                if (i != CorrectIndex && Options[i] != null)
                {
                    Options[i] = null;
                    removed++;
                }
            }
        }
    }
}
//                     CalculatorApp.Run();
//                 }