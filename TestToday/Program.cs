/*
// Have the fucntion HistogramArea(arr) read the array of non negative integers stored in arr which will represent the heights of bars on the graph(where each bar width is 1) For example: if arr is [2,1,3,4,1] then this looks like the fllowing. Largest area under the grapgh is covered by the the x's. The area of that space is equal to 6 bcz the entire width is 2 and maximum height is 3, therefore 2*3=6. Your program should return 6. The array will always contain atleast 1 element. the logic having formula: (space= Max height* Entire width)


using System;

class MainClass
{
    public static int HistogramArea(int[] arr)
    {
        int n = arr.Length;
        int maximumAreaOfHisto = 0;

        for (int i = 0; i < n; i++)
        {
                                                    // Finding the manuimum height
            int minimumHeight = arr[i];

                                                    // Calculate area for finding maximum width
            for (int j = i; j < n; j++)
            {
                                                    // Update min Height to the minimum height found 
                minimumHeight = Math.Min(minimumHeight, arr[j]);

                                                    // Calculate the area with current min Height and width 
                int CurrentAreaOfHisto = minimumHeight * (j - i + 1);

                                                    // Updating maximum Area if currentArea is greater
                maximumAreaOfHisto = Math.Max(maximumAreaOfHisto, CurrentAreaOfHisto);
            }
        }

        return maximumAreaOfHisto;
    }

    public static void Main(string[] args)
    {
    
        int[] arr = { 2, 1, 3, 4, 1 };
        Console.WriteLine(HistogramArea(arr));
        int[] arr2 = { 6, 3, 1, 4, 12, 4 };
        Console.WriteLine(HistogramArea(arr2));
    }
}
*/

// Have the fucntion PairSeraching(num) take the num parameter being passed and perform the following steps. First take all single digits of the input number(which will alaways be positive integer greater than 1) and add each of them in them into a list. tHen take the input number and multiply it by any one of its own  integers, then take this new number and append each of the digits onto the original list. Continue the process until an adjacent pair of the same number appears in the the list. Your program should return the least number of  multiplications it took to find an adjacent pair of duplicate numbers. For example if the num is 134 then first it append each integers into list[1,3,4]. Now if we take 134 and multiply it by 3(whix=ch is one of its own integers), we got 402. Now if we append each of these new integers into the list we got [1,3,4,4,0,2]. WE found adjacent pair of duplicate numbers, namely 4 and 4. So for this input your program should return 1 bcz it only took 1 multiplication to find this pair. c sharp code using lists and loops (logic could be step1: seperate the number by commas using split function. step 2: Take 2 loops starting from index to lrngth of list . next from index+1  to length  and multiply the pairs and check if any of the pair number makes duplicate or not.

/*using System;

class MainClass
{
    public static int PairSearching(int num)
    {
        string ThisNumber = num.ToString();
        int NoOfIterations = 0;

        while (true)
        {
            
            if (HasAdjacentDuplicateDigits(ThisNumber))  // Check if current Number has adjacent duplicate digits
            {
                return NoOfIterations;
            }

            
            int[] digits = GetDigits(ThisNumber);   // Generating  new number by multiplying num with each of its digits by iterating over it
            int SmallNumber = int.MaxValue;

            foreach (int digit in digits)
            {
                int NewNumber = num * digit;
                if (NewNumber < SmallNumber)
                {
                    SmallNumber = NewNumber;
                }
            }

            
            ThisNumber = SmallNumber.ToString();  // Updating current Number to the smallest new number found

            NoOfIterations++;
        }
    }

    
    public static int[] GetDigits(string Number)   //Function getting digits of a number and storing them in an array
    {
        int[] Digits = new int[Number.Length];
        for (int i = 0; i < Number.Length; i++)
        {
            Digits[i] = Number[i] - '0';
        }
        return Digits;
    }

  
    public static bool HasAdjacentDuplicateDigits(string str)  // Checking for the duplicates of the number
    {
        for (int i = 0; i < str.Length - 1; i++)
        {
            if (str[i] == str[i + 1])
            {
                return true;
            }
        }
        return false;
    }

    public static void Main(string[] args)
    {
        
        int num = 134;
        Console.WriteLine(PairSearching(num));
        int num1 = 46;
        Console.WriteLine(PairSearching(num1));
    }
}
*/

using System;

class MainClass
{
    public static int PairSearching(int num)
    {
        string ThisNumber = num.ToString();
        int NoOfIterations = 0;

        while (true)
        {
            // Check if current Number has adjacent duplicate digits
            if (HasAdjacentDuplicateDigits(ThisNumber))
            {
                return NoOfIterations;
            }

            // Generate new numbers by multiplying num with each of its digits
            int[] digits = GetDigits(ThisNumber);
            int SmallNumber = int.MaxValue;

            foreach (int digit in digits)
            {
                int NewNumber = num * digit;
                if (NewNumber < SmallNumber)
                {
                    SmallNumber = NewNumber;
                }
            }

            // Update current Number to the smallest new number found
            ThisNumber = SmallNumber.ToString();

            NoOfIterations++;
        }
    }

    // Function to get digits of a number and store them in an array
    public static int[] GetDigits(string Number)
    {
        int[] Digits = new int[Number.Length];
        for (int i = 0; i < Number.Length; i++)
        {
            Digits[i] = Number[i] - '0';
        }
        return Digits;
    }

    // Function to check if a string contains adjacent duplicate digits
    public static bool HasAdjacentDuplicateDigits(string str)
    {
        for (int i = 0; i < str.Length - 1; i++)
        {
            if (str[i] == str[i + 1])
            {
                return true;
            }
        }
        return false;
    }

    public static void Main(string[] args)
    {
        // Example usage:
        int num = 134;
        Console.WriteLine(PairSearching(num)); // Output: 1

        int num1 = 46;
        Console.WriteLine(PairSearching(num1)); // Output: 0
    }
}
