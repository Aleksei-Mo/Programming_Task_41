// Задача 41. Пользователь вводит с клавиатуры М чисел (разделитль используется произвольный). Посчитайте, сколько чисел больше 0 ввел пользователь.
Console.Clear();
Console.WriteLine("This program get numbers from console and find all numders that greater than zero.");
Console.Write("Enter your numbers: ");
string? newString = Console.ReadLine();
//int [] newArray = ParseString(newString);
int [] resultArray=ParseStringToIntArray(newString);
int numberGreaterZero=0;
for (int index=0; index<resultArray.Length; index++)
    {
      if (resultArray[index]>0)
         {
           numberGreaterZero++;
         }
    }
Console.WriteLine($"Number of positive numbers is: {numberGreaterZero}");



//***************************************************//
int [] ParseStringToIntArray (string newString)// function finds all digits and puts them to integer array
{
 char [] alphabet = {'1','2','3','4','5','6','7','8','9','0'};
 string bufferInt=string.Empty;//storage digit in string format
 string buffer=string.Empty;//storage parsed string
 int watchDog=0;//if entered string without digits
 
 if(newString.Length<1)
  {
  Console.WriteLine("You entered the empty string. Try again!");
  }
  else
  {
   for (int index=0; index < newString.Length; index++)
     {
       for (int j=0; j < alphabet.Length; j++)// check current element: number or symbol
          {
            if(newString[index] != alphabet[j] && (j==alphabet.Length-1) && (index!=newString.Length-1))// if current simbol is not digit so replace it with ","
              {
                buffer=buffer+",";
                watchDog++;   // how many no digits in the newString
              }

            if (newString[index] == alphabet[j] || newString[index]=='-')
              {
                buffer=buffer+newString[index];
                break;
              }
          }
     }
  }
  
  int [] digitsArray = new int[buffer.Length-watchDog];// array size = buffer length - all commas

  if (watchDog!=(newString.Length-1))// if there are any digits in "buffer"
     {
       
       int index2=0;
       Console.WriteLine($"You entered the folowing numbers: {buffer}");
      
       for (int index=0; index < buffer.Length; index++)
           {
            if ((buffer[index]!=',')|| index==(buffer.Length-1) )// if current symbol are not equal to "," or it is the last symbol;
              {
                bufferInt=bufferInt+buffer[index];
              }
            if((buffer[index]==',')|| index==(buffer.Length-1))
              {
                digitsArray[index2]=Convert.ToInt32(bufferInt);
                bufferInt=string.Empty;
                index2++;
               }
            }
     }
  else
     {
       Console.WriteLine("There are no any digits in the entered string! Please check and try again!");
     }
  return digitsArray;
 }
//***************************************************//