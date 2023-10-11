using Lab_5_2910;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Markup;
using static System.Net.WebRequestMethods;

namespace Lab_5_2910
{ 
    public class Program
    {
        public static string Exlusion = " "; // This will hold what the user decides to exclude
        public static int NumOfData = 0; // This will hold the total number of "persons" the users want to generate.
        public static string Gender = " "; // This will hold the gender specified by the user.
        public static string PasswordParameters = ""; // This will hold the wanted charsets that the user wants generated.
        public static string PasswordParameters2 = ""; // This will hold the wanted range(s) that the user wants generated.
        public static string WantedNat = " "; // This will hold the wanted nationality(ies) that the user wants generated.

        public static string GlobalHttp = "https://randomuser.me/api/1.4/"; // This string will hold the http since the beginning.
        public static string UserHttp = " "; // This will hold the user's created http (all the added calls) by using string.Concat.

        public static async Task Main(string[] args)
        {
            //Introduction.
            Console.ForegroundColor = ConsoleColor.Red;
            string ascii = (Convert.ToChar(19)).ToString();
            string message = $"{ascii} {ascii} {ascii} {ascii} {ascii} {ascii} {ascii} {ascii} HIDE YOUR IDENTITY {ascii} {ascii} {ascii} {ascii} {ascii} {ascii} {ascii} {ascii}";
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.CursorTop);
            Console.WriteLine(message);
            Console.Write("\n\nPress [ENTER] to continue...");
            Console.ReadLine();
            Console.Clear();

            //Asking if user wants to exlude certain things.
            List<string> selectedChoices = new List<string>(); // This list will store the selected choices.
            string answer = "";
            bool loop = false;
            while (!loop)
            {
                Console.Write("\nDo you want to exclude any fields? Press \" N \" for NO or \" Y \" for YES. ");
                answer = Console.ReadLine();

                if (answer.ToUpper() == "Y")
                {
                    List<string> options = new List<string> // List of options.
                    {
                        "gender", "name", "location", "email", "login", "dob", "phone", "cell", "id", "nat"
                    };

                    List<string> values = new List<string>(); // This list will serve as what to add to the link.

                    Console.WriteLine("\nPlease select multiple options (enter the number, separated by spaces):");
                    for (int i = 0; i < options.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {options[i]}");
                    }
                    Console.Write("\nENTER HERE: ");
                    string input = Console.ReadLine();
                    string[] inputChoices = input.Split(' ');

                    foreach (string choice in inputChoices)
                    {
                        if (int.TryParse(choice, out int index) && index >= 1 && index <= options.Count)
                        {
                            selectedChoices.Add(options[index - 1]); // Valid choicees are added to the selectedChoices list.
                        }
                        else
                        {
                            Console.WriteLine($"\tINVALID CHOICE: {choice}");
                        }
                    }

                    Exlusion = string.Join(",", selectedChoices); // This will be used to add to the html
                    string selected = string.Join(", ", selectedChoices); 
                    Console.Write($"\tVALID CHOICES: {selected}");

                    Console.Write("\n\nPress [ENTER] to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    await Exclusion();

                    Console.Write("\n\nPress [ENTER] to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    loop = true;
                }
                else if (answer.ToUpper() == "N")
                {
                    Console.Clear();
                    await NoExclusion();

                    Console.Write("\n\nPress [ENTER] to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    loop = true;
                }
                else
                {
                    Console.WriteLine("\tERROR: ENTER ACCEPTABLE INPUT.");
                }
            }

            //Asking if the user wants the fake data to be parameterized.
            string answer2 = "";
            bool loop2 = false;
            while (!loop2)
            {
                Console.Write("\nDo you want the fake data to have specific parameters? Press \" N \" for NO or \" Y \" for YES. ");
                answer2 = Console.ReadLine();

                if (answer2.ToUpper() == "Y")
                {
                    Console.Write("\n\nPress [ENTER] to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    loop2 = true;
                }
                else if (answer2.ToUpper() == "N")
                {
                    Console.Write("\n\nPress [ENTER] to continue...");
                    Console.ReadLine();
                    Console.Clear();

                    string user = " ";
                    bool input = false;
                    while (!input)
                    {
                        Console.Write("\nWould you like me to generate more than one of the same type of data? Press \" N \" for NO or \" Y \" for YES. ");
                        user = Console.ReadLine();

                        if(user.ToUpper() == "Y")
                        {
                            bool input2 = false;
                            while (!input2)
                            {
                                Console.Write("\nI may generate 5000 people at a time. Enter a value equal to or less than 5000. ");
                                string user2 = Console.ReadLine();

                                if (int.TryParse(user2, out NumOfData) && NumOfData <= 5000)
                                {
                                    Console.Write("\n\nPress [ENTER] to continue...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    await RetrievingMoreThanOne();

                                    Console.WriteLine("GOODBYE!");
                                    Environment.Exit(0);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("ERROR: ENTER ACCEPTABLE INPUT");
                                }
                            }
                        }
                        else if (user.ToUpper() == "N")
                        {
                            Console.WriteLine("GOODBYE!");
                            Environment.Exit(0);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\tERROR: ENTER ACCEPTABLE INPUT.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\tERROR: ENTER ACCEPTABLE INPUT.");
                }
            }

            // This will not let the user specify parameters based on what they excluded.
            string search1 = "gender";
            string search2 = "login";
            string search3 = "nat";

            if (selectedChoices.Contains(search1) && selectedChoices.Contains(search2) && selectedChoices.Contains(search3))
            {
                Console.WriteLine("Can not specifcy parameters because of exluceded fields.");
                Console.Write("\n\nPress [ENTER] to continue...");
                Console.ReadLine();
                Console.Clear();
            }

            if (!selectedChoices.Contains(search1))
            {
                await SpecGender(); // Made these into methods in order to reduce any error and keep code clean
            }

            if (!selectedChoices.Contains(search2))
            {
                await SpecPassword();
            }

            Console.Write("\n\nPress [ENTER] to continue...");
            Console.ReadLine();
            Console.Clear();

            if (!selectedChoices.Contains(search3))
            {
                await SpecNationality();
            }

            Console.Write("\n\nPress [ENTER] to continue...");
            Console.ReadLine();
            Console.Clear();
            // Asking if user wants to generate more of the same type
            string user3 = " ";
            bool loop3 = false;
            while (!loop3)
            {
                Console.Write("\nWould you like me to generate more than one of the same type of data? Press \" N \" for NO or \" Y \" for YES. ");
                user3 = Console.ReadLine();

                if (user3.ToUpper() == "Y")
                {
                    bool input2 = false;
                    while (!input2)
                    {
                        Console.Write("\nI may generate 5000 people at a time. Enter a value equal to or less than 5000. ");
                        string user4 = Console.ReadLine();

                        if (int.TryParse(user4, out NumOfData) && NumOfData <= 5000)
                        {
                            Console.Write("\n\nPress [ENTER] to continue...");
                            Console.ReadLine();
                            Console.Clear();
                            await RetrievingMoreThanOne();

                            Console.WriteLine("GOODBYE!");
                            Environment.Exit(0);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("ERROR: ENTER ACCEPTABLE INPUT");
                        }
                    }
                }
                else if (user3.ToUpper() == "N")
                {
                    Console.WriteLine("GOODBYE!");
                    Environment.Exit(0);
                    break;
                }
                else
                {
                    Console.WriteLine("\tERROR: ENTER ACCEPTABLE INPUT.");
                }
            }
            Console.ReadLine();
        }

        public static async Task NoExclusion()
        {
            //sending requestion to https://randomuser.me/api/1.4/
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{GlobalHttp}");
            UserHttp = GlobalHttp;
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            RandomPerson p = JsonSerializer.Deserialize<RandomPerson>(json, options);
            Console.WriteLine(p + "\n");
        }

        public static async Task Exclusion()
        {
            //sending request to 
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{GlobalHttp}?exc={Exlusion}");
            UserHttp = string.Concat(GlobalHttp, "?exc=", Exlusion);
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            RandomPerson p = JsonSerializer.Deserialize<RandomPerson>(json, options);
            Console.WriteLine(p + "\n");
        }

        public static async Task SpecifyGender()
        {
            if (UserHttp.Length > 30)
            {
                UserHttp = string.Concat(UserHttp, "&&gender=", Gender);
            }
            else
            {
                UserHttp = string.Concat(UserHttp, "?gender=", Gender);

            }

            Console.Write(UserHttp);
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{UserHttp}");
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            RandomPerson p = JsonSerializer.Deserialize<RandomPerson>(json, options);
            Console.WriteLine(p + "\n");

        }

        public static async Task SpecifyPassword()
        {
            //PasswordParameters
            if (PasswordParameters.Length > 0 && PasswordParameters2.Length > 0)
            {
                if (UserHttp.Length > 30)
                {
                    UserHttp = string.Concat(UserHttp, "&&password=");
                }
                else
                {
                    UserHttp = string.Concat(UserHttp, "?password=");
                }
            }

            if (PasswordParameters.Length == 0)
            {
                UserHttp = string.Concat(UserHttp, PasswordParameters2);
            }
            else if (PasswordParameters.Length > 0)
            {
                UserHttp = string.Concat(UserHttp, PasswordParameters, ",", PasswordParameters2);
            }

            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{UserHttp}");
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            RandomPerson p = JsonSerializer.Deserialize<RandomPerson>(json, options);
            Console.WriteLine(p + "\n");
        }

        public static async Task SpecifyNationality()
        {
            //WantedNat
            if (WantedNat.Length > 0)
            {
                if (UserHttp.Length > 30)
                {
                    UserHttp = string.Concat(UserHttp, "&&nat=", WantedNat);
                }
                else
                {
                    UserHttp = string.Concat(UserHttp, "?nat=", WantedNat);
                }
            }

            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{UserHttp}");
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            RandomPerson p = JsonSerializer.Deserialize<RandomPerson>(json, options);
            Console.WriteLine(p + "\n");
        }

        public static async Task RetrievingMoreThanOne()
        {
            if (UserHttp.Length > 30)
            {
                UserHttp = string.Concat(UserHttp, "&&results=", NumOfData);
            }
            else
            {
                UserHttp = string.Concat(UserHttp, "?results=", NumOfData);

            }

            Console.Write(UserHttp);
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{UserHttp}");
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            RandomPerson p = JsonSerializer.Deserialize<RandomPerson>(json, options);
            Console.WriteLine(p + "\n");
        }

        // Methods without client requests
        private static async Task SpecGender()
        {
            //Asking if the user wants to specify the gender.
            string answer3 = "";
            bool loop3 = false;
            while (!loop3)
            {
                Console.Write("\nDo you want to specify the gender to either female or male? Press \" N \" for NO or \" Y \" for YES. ");
                answer3 = Console.ReadLine();

                if (answer3.ToUpper() == "Y")
                {
                    bool input2 = false;
                    while (!input2)
                    {
                        Console.Write("\nPress \" M \" for MALE or \" F \" for FEMALE. ");
                        string user2 = Console.ReadLine();

                        if (user2.ToUpper() == "M")
                        {
                            string male = "male";
                            Gender = male;

                            await SpecifyGender();
                            Console.Write("\n\nPress [ENTER] to continue...");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        else if (user2.ToUpper() == "F")
                        {
                            string female = "female";
                            Gender = female;

                            await SpecifyGender();

                            Console.Write("\n\nPress [ENTER] to continue...");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("ERROR: ENTER ACCEPTABLE INPUT");
                        }
                        break;
                    }
                }
                else if (answer3.ToUpper() == "N")
                {
                    Console.Write("\n\nPress [ENTER] to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("ERROR: ENTER ACCEPTABLE INPUT");
                }

            }
        }

        private static async Task SpecPassword()
        {
            List<string> selectedChoices = new List<string>(); // This list will store the selected choices.
            //Asking if the user wants to specify the gender.
            string answer3 = "";
            bool loop3 = false;
            while (!loop3)
            {
                Console.Write("\nDo you want to specify the password you want me to generate? Press \" N \" for NO or \" Y \" for YES. ");
                answer3 = Console.ReadLine();

                if (answer3.ToUpper() == "Y")
                {
                    List<string> options = new List<string> // List of options.
                    {
                        "special", "upper", "lower", "number"
                    };

                    List<string> values = new List<string>(); // This list will serve as what to add to the link.

                    Console.Write("\n\nPress [ENTER] to continue...");
                    Console.ReadLine();
                    Console.Clear();


                    Console.WriteLine("\nSelect option(s) (enter the number, separated by spaces) that you want the password to include:");
                    Console.WriteLine("NOTE: \tspecial: !\"#$%&'()*+,- ./:;<=>?@[\\]^_`{|}~" +
                        "\n\tupper: ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                        "\n\tlower: abcdefghijklmnopqrstuvwxyz" +
                        "\n\tnumber: 0123456789\n");

                    for (int i = 0; i < options.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {options[i]}");
                    }

                    string input = "";
                    bool loop10 = false;
                    while (!loop10)
                    {
                        Console.Write("\nENTER HERE: ");
                        input = Console.ReadLine();

                        if (input == "1" || input == "2" || input == "3" || input == "4")
                        {
                            loop10 = true;
                        }
                        else
                        {
                            Console.WriteLine("\nERROR: ENTER ACCEPTABLE INPUT");
                        }
                    }

                    string[] inputChoices = input.Split(' ');

                    foreach (string choice in inputChoices)
                    {
                        if (int.TryParse(choice, out int index) && index >= 1 && index <= options.Count)
                        {
                            selectedChoices.Add(options[index - 1]); // Valid choicees are added to the selectedChoices list.
                        }
                        else
                        {
                            Console.WriteLine($"\tINVALID CHOICE: {choice}");
                        }
                    }

                    PasswordParameters = string.Join(",", selectedChoices); // This will be used to add to the html.
                    string selected = string.Join(", ", selectedChoices);
                    Console.Write($"\tVALID CHOICES: {selected}");
                    Console.Write("\n\nPress [ENTER] to continue...");
                    Console.ReadLine();
                    Console.Clear();

                    string answer4 = " ";
                    bool loop4 = false;
                    while (!loop4)
                    {
                        Console.Clear();
                        Console.Write("\nCHOOSE AN OPTION: \n\ta: MAX LENGTH of characters \n\tb: MINIMUM LENGTH and MAXIMUM LENGTH of character \n\tc: NONE, set it to the default, which will be between 8 - 64 characters long. \n\nOPTION: ");
                        answer4 = Console.ReadLine();
                        Console.Write("\n\nPress [ENTER] to continue...");
                        Console.ReadLine();
                        Console.Clear();

                        string answer9 = "";
                        if (answer4.ToLower() == "a")
                        {
                            int answer5 = 0;
                            bool loop5 = false;
                            while (!loop5)
                            {
                                Console.Write("\nEnter a number for the MAXMIMUM length: ");
                                string answer6 = Console.ReadLine();

                                if (int.TryParse(answer6, out answer5) && answer5 >= 1)
                                {
                                    PasswordParameters2 = string.Concat(answer6);
                                    loop5 = true;
                                }
                                else
                                {
                                    Console.WriteLine("ERROR: ENTER ACCEPTABLE INPUT");
                                }
                            }

                            Console.Write("\n\nPress [ENTER] to continue...");
                            Console.ReadLine();
                            Console.Clear();
                            await SpecifyPassword();

                            loop3 = true;
                            break;
                        }
                        else if (answer4.ToLower() == "b")
                        {
                            int answer5 = 0;
                            bool loop5 = false;
                            while (!loop5)
                            {
                                Console.Write("\nEnter a number for the MINIMUM length: ");
                                answer9 = Console.ReadLine();

                                if (int.TryParse(answer9, out answer5) && answer5 >= 1)
                                {
                                    loop5 = true;
                                }
                                else
                                {
                                    Console.WriteLine("ERROR: ENTER ACCEPTABLE INPUT");
                                }
                            }

                            int answer8 = 0;
                            bool loop6 = false;
                            while (!loop6)
                            {
                                Console.Write("\nEnter a number for the MAXIMUM length: ");
                                string answer7 = Console.ReadLine();

                                if (int.TryParse(answer7, out answer8) && answer8 >= 1)
                                {
                                    PasswordParameters2 = string.Concat(answer9, "-", answer7);
                                    loop6 = true;
                                }
                                else
                                {
                                    Console.WriteLine("ERROR: ENTER ACCEPTABLE INPUT");
                                }
                            }

                            Console.Write("\n\nPress [ENTER] to continue...");
                            Console.ReadLine();
                            Console.Clear();

                            await SpecifyPassword();
                            loop3 = true;
                            break;
                        }
                        else if (answer4.ToLower() == "c")
                        {
                            Console.Write("\n\nPress [ENTER] to continue...");
                            Console.ReadLine();
                            Console.Clear();

                            await SpecifyPassword();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nERROR: ENTER ACCEPTABLE INPUT");
                        }
                        loop3 = true;
                    }
                }
                else if (answer3.ToUpper() == "N")
                {
                    Console.Write("\n\nPress [ENTER] to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    loop3 = true;
                }
                else
                {
                    Console.WriteLine("\nERROR: ENTER ACCEPTABLE INPUT");
                }
            }
        }

        private static async Task SpecNationality()
        {
            List<string> selectedChoices = new List<string>(); // This list will store the selected choices.
            string answer = "";
            bool loop = false;
            while (!loop)
            {
                Console.Write("\nDo you want to specify the nationality you want me to generate? Press \" N \" for NO or \" Y \" for YES. ");
                answer = Console.ReadLine();

                if (answer.ToUpper() == "Y")
                {
                    List<string> options = new List<string> // List of options.
                    {
                        "AU", "BR", "CA", "CH", "DE", "DK", "ES", "FI", "FR", "GB", "IE", "IN", "IR", "MX", "NL", "NO", "NZ", "RS", "TR", "UA", "US"
                    };

                    List<string> values = new List<string>(); // This list will serve as what to add to the link.

                    Console.WriteLine("\nSelect option(s) (enter the number, separated by spaces):");
                    for (int i = 0; i < options.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {options[i]}");
                    }
                    Console.Write("\nENTER HERE: ");
                    string input = Console.ReadLine();
                    string[] inputChoices = input.Split(' ');

                    foreach (string choice in inputChoices)
                    {
                        if (int.TryParse(choice, out int index) && index >= 1 && index <= options.Count)
                        {
                            selectedChoices.Add(options[index - 1]); // Valid choicees are added to the selectedChoices list.
                        }
                        else
                        {
                            Console.WriteLine($"\tINVALID CHOICE: {choice}");
                        }
                    }

                    WantedNat = string.Join(",", selectedChoices); // This will be used to add to the html
                    string selected = string.Join(", ", selectedChoices);
                    Console.Write($"\tVALID CHOICES: {selected}");

                    Console.Write("\n\nPress [ENTER] to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    await SpecifyNationality();
                    loop = true;
                }
                else if (answer.ToUpper() == "N")
                {
                    loop = true;
                }
                else
                {
                    Console.WriteLine("\tERROR: ENTER ACCEPTABLE INPUT.");
                }
            }
        }
    }
}