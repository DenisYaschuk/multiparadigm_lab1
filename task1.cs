using System;
using System.IO;

namespace Task1
{
    class task1
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"WriteText.txt");
            int text_length = text.Length;
            int topN = 300;
            int i = 0;
            string current_word = "";
            string[] words_arr = new string[1000000];
            int word_count = 0;
            while_loop:
                if((text[i] >= 65) && (text[i] <= 90) || (text[i] >= 97) && (text[i] <= 122) || text[i] == 45)
                {
                    if ((text[i] >= 65) && (text[i] <= 90))
                    {
                        current_word += (char) (text[i] + 32);
                    }
                    else
                    {
                        current_word += text[i];
                    }
                }
                else
                {                    
                    if (current_word != "" && current_word != null && current_word != "-" && current_word != "no" && current_word != "from" && current_word != "the" && current_word != "by" && current_word != "and" && current_word != "i" && current_word != "in" && current_word != "or" && current_word != "any" && current_word != "for" && current_word != "to" && current_word != "\"" && current_word != "a" && current_word != "on" && current_word != "of" && current_word != "at" && current_word != "is" && current_word != "\n" && current_word != "\r" && current_word != "\r\n" && current_word != "\n\r")
                    {
                        words_arr[word_count] = current_word;
                        word_count++;
                    }
                    current_word = "";
                }
                i++;
                if(i < text_length)
                {
                    goto while_loop;
                }
                else
                {
                    if (current_word != "" && current_word != null && current_word != "-" && current_word != "no" && current_word != "from" && current_word != "the" && current_word != "by" && current_word != "and" && current_word != "i" && current_word != "in" && current_word != "or" && current_word != "any" && current_word != "for" && current_word != "to" && current_word != "\"" && current_word != "a" && current_word != "on" && current_word != "of" && current_word != "at" && current_word != "is" && current_word != "\n" && current_word != "\r" && current_word != "\r\n" && current_word != "\n\r")
                    {
                        words_arr[word_count] = current_word;
                        word_count++;
                    }
                }
            string[] words_only_once_arr = new string[1000000];
            int[] words_once_count_arr = new int[1000000];





            int amount_of_words = words_arr.Length;
            i = 0;
            int insertPos = 0;
            bool shouldInsert = true;
            int j = 0;
            int dubs = 0;
            while_loop_count:
                insertPos = 0;
                shouldInsert = true;
                int current_length = words_only_once_arr.Length;
                j = 0;
                    
                    for_loop:                    
                    if (j < current_length && words_only_once_arr[j]!=null)
                    {
                        if (words_only_once_arr[j] == words_arr[i])
                        {
                            insertPos = j;
                            shouldInsert = false;
                            goto end_for_loop;
                            
                        }
                        j++;
                        goto for_loop;
                    }
                end_for_loop:
                if (shouldInsert)
                {
                    words_only_once_arr[i - dubs] = words_arr[i];
                    words_once_count_arr[i - dubs] = 1;
                }
                else
                {
                    words_once_count_arr[insertPos] += 1;
                    dubs++;
                }                
                i++;
                if (i < amount_of_words && words_arr[i]!=null)
                {
                    
                    goto while_loop_count;
                }
            int length = words_once_count_arr.Length;
            j = 0;
            int inner_i = 0;


        sort_loop:
                if(j < length && words_once_count_arr[j] != 0)
                {
                    inner_i = 0;
                    sort_inner_loop:
                        if(inner_i < length - j - 1 && words_once_count_arr[inner_i] != 0)
                        {
                            if (words_once_count_arr[inner_i] < words_once_count_arr[inner_i + 1])
                            {
                                int temp = words_once_count_arr[inner_i];
                                words_once_count_arr[inner_i] = words_once_count_arr[inner_i + 1];
                                words_once_count_arr[inner_i + 1] = temp;
                                string temp2 = words_only_once_arr[inner_i];
                                words_only_once_arr[inner_i] = words_only_once_arr[inner_i + 1];
                                words_only_once_arr[inner_i + 1] = temp2;
                            }
                            inner_i++;
                            goto sort_inner_loop;
                        }
                        
                    j++;
                    goto sort_loop;
                }
            int k = 0;
            print_loop:
                if (k < length && words_only_once_arr[k] != null && k < topN)
                {
                    Console.WriteLine("{0} - {1}", words_only_once_arr[k], words_once_count_arr[k]);
                    k++;
                    goto print_loop;
                }
        }
    }
}
