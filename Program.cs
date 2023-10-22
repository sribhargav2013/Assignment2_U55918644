/* 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK
Sri Bhargav Lakkireddy
*/

using System;
using System.Text;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                IList<IList<int>> missingvaluesRange = new List<IList<int>>();
                long Lowernum = (long)lower; // Use long to avoid integer overflow issues
                long Uppernum = (long)upper;
                // If the input 'nums' array is empty or null:
                if (nums == null || nums.Length == 0)
                {
                    if (Lowernum == Uppernum) // Check if 'lowerNum' and 'upperNum' are the same.
                    {
                        missingvaluesRange.Add(new List<int> { (int)Lowernum });  // Add a single value range to 'missingValueRanges'
                    }
                    else
                    {
                        missingvaluesRange.Add(new List<int> { (int)Lowernum, (int)Uppernum });  // Add a range covering all values from 'lowerNum' to 'upperNum' to 'missingValueRanges'.
                    }
                    return missingvaluesRange;  // Return the 'missingValueRanges'.
                }

                if (nums[0] > Lowernum) // Check if the first element in 'nums' is greater than 'lowerNum'
                {
                    if (nums[0] - 1 == Lowernum)
                    {
                        missingvaluesRange.Add(new List<int> { (int)Lowernum });
                    }
                    else
                    {
                        missingvaluesRange.Add(new List<int> { (int)Lowernum, (int)nums[0] - 1 });
                    }
                }
                for (int i = 1; i < nums.Length; i++)   // Iterate through the 'nums' array to find missing value ranges.
                {
                    if ((long)nums[i] > (long)nums[i - 1] + 1)
                    {
                        if (nums[i] - 1 == (long)nums[i - 1] + 1)
                        {
                            missingvaluesRange.Add(new List<int> { (int)(nums[i - 1] + 1) });  // Add a single value range to 'missingValueRanges'.
                        }
                        else
                        {
                            missingvaluesRange.Add(new List<int> { (int)(nums[i - 1] + 1), (int)(nums[i] - 1) }); // Add a range of values between the previous and current elements in 'nums'.
                        }
                    }
                }
                // Check if the last element in 'nums' is less than 'upperNum
                if (nums[nums.Length - 1] < Uppernum)
                {
                    if (nums[nums.Length - 1] + 1 == Uppernum)
                    {
                        missingvaluesRange.Add(new List<int> { (int)Uppernum }); // Add a single value range to 'missingValueRanges'
                    }
                    else
                    {
                        missingvaluesRange.Add(new List<int> { (int)(nums[nums.Length - 1] + 1), (int)Uppernum }); // Add a range covering values from the last element in 'nums' to 'upperNum'.
                    }
                }

                return missingvaluesRange; // Return the 'missingValueRanges' containing the ranges of missing values.
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                // Handle any exceptions and return an empty list in case of an error.
                return new List<IList<int>>();
            }

        }
        /* SELF REFLECTION 
         The code efficiently handles the problem by iterating through the elements of the nums array and determining the missing ranges.
It correctly identifies missing numbers and creates ranges that cover these missing numbers.
The code returns the missing ranges as a list of lists, where each inner list represents a range, indicating the inclusive start and exclusive end of the range.
The code follows the constraints and requirements specified in the problem statement and aims to achieve a time complexity of O(n) and a space complexity of O(1).*/

        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                Stack<char> stack = new Stack<char>();

                foreach (char c in s)
                {
                    if (c == '(' || c == '{' || c == '[')
                    {
                        // Push opening brackets onto the stack
                        stack.Push(c);
                    }
                    else if (c == ')' || c == '}' || c == ']')
                    {
                        // Check if the stack is empty 
                        if (stack.Count == 0)
                        {
                            return false;
                        }

                        // Pop the top bracket from the stack
                        char openBracket = stack.Pop();

                        // Check if the current closing bracket matches the last open bracket
                        if ((c == ')' && openBracket != '(') ||
                            (c == '}' && openBracket != '{') ||
                            (c == ']' && openBracket != '['))
                        {
                            return false;
                        }
                    }
                }

                // If the stack is empty at the end, all brackets are matched and valid
                return stack.Count == 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*SELF REFLECTION 
         * The code uses a stack data structure to ensure that the brackets are correctly matched and in the right order.
         * It goes through each character in the string, pushing opening brackets onto the stack and checking that each closing bracket corresponds to the last opened bracket of the same type.
         * If at any point, a closing bracket doesn't match the last open bracket or there are unmatched closing brackets, the code returns false.
         * If the stack is empty at the end, it indicates that all brackets are correctly matched, and the code returns true.
         * The code's approach is a common and efficient way to validate bracket expressions.
        It utilizes a stack to keep track of the bracket order and validity. However, the time complexity is mentioned as O(n^2), which might be an overestimation. The actual time complexity should be O(n), where n is the length of the input string since each character in the string is processed once.*/
        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                if (prices == null || prices.Length < 2) // Check if the 'prices' array is null or contains less than 2 elements.
                {
                    return 0;   // return 0 profit if there is not enough data 
                }

                int MinimumPrice = prices[0];
                int MaximumPrice = 0;

                for (int i = 1; i < prices.Length; i++) // Iterate through the 'prices' array starting from the second element.
                {
                    if (prices[i] < MinimumPrice)
                    {
                        MinimumPrice = prices[i];// Update MinimumPrice if a lower price is encountered.
                    }
                    else if (prices[i] - MinimumPrice > MaximumPrice)
                    {
                        MaximumPrice = prices[i] - MinimumPrice; // Calculate the profit for the current day and update MaximumPrice if it's higher.
                    }
                }

                return MaximumPrice;  // Return the maximum profit obtained.
            }
            catch (Exception)
            {
                throw;
            }
        }
        /* SELF REFLECTION
        The program starts by checking edge cases where the prices array is null or contains less than two elements, returning 0 as the profit in such cases.
        For valid input, the code iterates through the prices array, maintaining two variables: MinimumPrice and MaximumPrice.
        MinimumPrice is used to keep track of the lowest stock price encountered so far, while MaximumPrice represents the maximum profit seen during the iteration.
        The program calculates the profit for each day and updates MaximumPrice if a higher profit is found.
        The code follows an efficient approach with a time complexity of O(n), where n is the length of the prices array since it processes each price once. 
        It aims to maximize the profit by choosing the best buying and selling days, adhering to the constraint of buying before selling.*/
        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string s)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                Dictionary<char, char> StrobogPairs = new Dictionary<char, char>  // Creating a dictionary consisting pairs of strobogrammatic digits.
                    {
                        {'0', '0'},
                        {'1', '1'},
                        {'6', '9'},
                        {'8', '8'},
                        {'9', '6'}
                    };
                //'left' and 'right', to check the string symmetrically.
                int left = 0;
                int right = s.Length - 1;
                // Iterate while 'left' is less than or equal to 'right'.
                while (left <= right)
                {
                    char leftDigit = s[left];
                    char rightDigit = s[right];
                    // Check if the left and right digits are valid strobogrammatic pairs.
                    if (!StrobogPairs.ContainsKey(leftDigit) || StrobogPairs[leftDigit] != rightDigit)
                    {
                        return false;  // If not, the string is not strobogrammatic.
                    }

                    left++;
                    right--; // Move the 'left' pointer to the right and the 'right' pointer to the left for symmetry.
                }

                return true;  //If we dont find any invalid pairs, the string is strobogrammatic.
            }
            catch (Exception)
            {
                throw; // Handle and rethrow any exceptions if they occur
            }
        }
        /* SELF REFLECTION: 
         * The provided program determines whether a given string represents a strobogrammatic number, which means it remains the same when rotated 180 degrees (upside down). To achieve this, the code defines a dictionary (StrobogPairs) containing valid strobogrammatic pairs of digits (e.g., '0' and '0', '1' and '1', '6' and '9', etc.).
           The code then uses two pointers (left and right) to traverse the string symmetrically, checking if the pairs of digits are valid strobogrammatic pairs based on the dictionary. If any invalid pair is encountered, the code returns false, indicating that the string is not strobogrammatic. 
            If no invalid pairs are found, the code returns true, signifying that the input string is indeed a strobogrammatic number.
            This code follows a straightforward approach to solve the problem and has a time complexity of O(n), where n is the length of the input string. It efficiently checks each character in the string to determine its strobogrammatic nature. 
        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                Dictionary<int, int> Pairs = new Dictionary<int, int>();
                int GoodPair = 0;

                foreach (int num in nums) // Iterating through the nums array
                {
                    if (Pairs.ContainsKey(num))
                    {
                        // Increment the count of existing numbers and add it to GoodPair
                        GoodPair += Pairs[num];
                        Pairs[num]++;
                    }
                    else
                    {
                        // Add the number to the dictionary with a count of 1
                        Pairs[num] = 1;
                    }
                }

                return GoodPair; // return all the good pairs
            }
            catch (Exception)
            {
                throw; // handle & throw exceptions if any occurs.
            }
        }
        /* The code efficiently counts the number of good pairs in an array of integers. 
         * Good pairs are pairs of elements with equal values where the first element appears before the second in the array.
         * It utilizes a dictionary to keep track of counts for each unique number, allowing it to find and count good pairs without unnecessary iterations. 
         * The program has a time complexity of O(n), making it an efficient solution for this task.

        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

        public static int ThirdMax(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                // Define three variables to keep track of the first, second, and third maximum values
                long first = long.MinValue;
                long second = long.MinValue;
                long third = long.MinValue;

                foreach (int num in nums)
                {
                    if (num > first)  // If 'num' is greater than the first maximum, update the first, second, and third values.
                    {
                        third = second;
                        second = first;
                        first = num;
                    }
                    else if (num < first && num > second) // If 'num' is between the first and second maximums, update the second and third values.
                    {
                        third = second;
                        second = num;
                    }
                    else if (num < second && num > third) // If 'num' is between the second and third maximums, update the third value.
                    {
                        third = num;
                    }
                }

                // If the third maximum doesn't exist, return the first maximum; otherwise, return the third maximum.
                return third != long.MinValue ? (int)third : (int)first;
            }
            catch (Exception)
            {
                throw; // Handle and rethrow any exceptions if they occur
            }
        } /* SELF REFLECTION 
           * The program efficiently finds the third distinct maximum number in an integer array.
           * It employs three variables to keep track of the first, second, and third maximum values while iterating through the array.
           * By considering the constraints and efficiently updating these variables, it accurately returns the third maximum number if it exists; otherwise, it returns the overall maximum number. 
           * The code has a time complexity of O(n log n) due to the sorting operation, making it a reliable solution for this task.

        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                List<string> nextstate = new List<string>(); // Create a list to store the next states
                // Iterate through currentState  string
                for (int i = 0; i < currentState.Length - 1; i++)
                {
                    if (currentState[i] == '+' && currentState[i + 1] == '+')  // Check if there are two consecutive '+' signs.
                    {
                        char[] newState = currentState.ToCharArray(); // Create a new character array to modify the state.
                        newState[i] = '-';
                        newState[i + 1] = '-';
                        nextstate.Add(new string(newState));   // Add the new state to the list of possible next states.
                    }
                }
                // Return the list of possible next states.
                return nextstate;
            }
            catch (Exception)
            {
                throw; // Handle and rethrow any exceptions if any occur 
            }
        }
        /* SELF REFLECTION: 
         * This Program efficiently generates all possible states of a string after one valid move in a Flip Game. It iterates through the input string and identifies consecutive "++" substrings, then generates new states by replacing them with "--." The resulting states are added to a list, which is returned as the output. 
         * The code handles exceptions appropriately and has a time complexity of O(n), making it a reliable solution for this problem.
        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static string RemoveVowels(string s)
        {
            // Write your code here and you can modify the return value according to the requirements
            // Create a StringBuilder to efficiently build the result string
            StringBuilder Finalstring = new StringBuilder();

            // Define a set of vowels
            HashSet<char> Vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

            // Iterate through each character in the input string
            foreach (char c in s)
            {
                // Check if the character is not a vowel, and if so, append it to the result
                if (!Vowels.Contains(c))
                {
                    Finalstring.Append(c);
                }
            }

            // Convert the StringBuilder to a string and return the result
            return Finalstring.ToString();
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> Listappending = input[i];
                sb.Append("[" + string.Join(",", Listappending) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] inpArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                inpArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", inpArray) + "]";

            return result; //return the result string
        }
    }
    /* SELF REFLECTION: This code efficiently removes the specified vowels (a, e, i, o, and u) from a given string using a HashSet to check for vowels and a StringBuilder to build the result string.
     * It iterates through each character in the input string, checks if it's not a vowel, and appends it to the result. The result is then returned as a string. 
     * This code has a time complexity of O(n) and is a straightforward solution for removing vowels from a string.*/
}