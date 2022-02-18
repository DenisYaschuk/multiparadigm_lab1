using System;
using System.Collections.Generic;
using System.IO;

namespace Task2
{
    class task2
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"WriteText.txt");
            int text_length = text.Length;
            int i = 0;
            string current_word = "";
            string[] words_arr = new string[100000];
            string[,] pages_words_arr = new string[10000, 10000];
            int word_count = 0;
            int row_count = 0;
            int page_count = 0;
            int page_word_counter = 0;
        while_loop:
            if ((text[i] >= 65) && (text[i] <= 90) || (text[i] >= 97) && (text[i] <= 122) || text[i] == 45 || text[i] == 234 || text[i] == 225 || text[i] == 224)
            {
                if ((text[i] >= 65) && (text[i] <= 90))
                {
                    current_word += (char)(text[i] + 32);
                }
                else
                {
                    current_word += text[i];
                }
            }
            else
            {
                if (text[i] == '\n')
                {
                    row_count++;
                }
                if (row_count > 45)
                {
                    page_count++;
                    page_word_counter = 0;
                    row_count = 0;
                }
                if (current_word != "" && current_word != null && current_word != "-" && current_word != "no" && current_word != "from" && current_word != "the" && current_word != "by" && current_word != "and" && current_word != "i" && current_word != "in" && current_word != "or" && current_word != "any" && current_word != "for" && current_word != "to" && current_word != "\"" && current_word != "a" && current_word != "on" && current_word != "of" && current_word != "at" && current_word != "is" && current_word != "\n" && current_word != "\r" && current_word != "\r\n" && current_word != "\n\r")
                {
                    
                    words_arr[word_count] = current_word;
                    word_count++;
                    pages_words_arr[page_count, page_word_counter] = current_word;
                    page_word_counter++;
                }
                current_word = "";
            }
            i++;
            if (i < text_length)
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
            string[] words_only_once_arr = new string[100000];
            int[] words_once_count_arr = new int[100000];
            int amount_of_words = words_arr.Length;
            i = 0;
            int insertPos = 0;
            bool shouldInsert = true;
            int j = 0;
            int dubs = 0;
        while_loop_count:
            insertPos = 0;
            int current_length = words_only_once_arr.Length;
            j = 0;
            shouldInsert = true;
        for_loop:
            if (j < current_length && words_only_once_arr[j] != null)
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
            if (i < amount_of_words && words_arr[i] != null)
            {
                goto while_loop_count;
            }
            int length = words_once_count_arr.Length;
            int k = 0;
            string[] words_only_once_arr_less_than_100 = new string[100000];
            int LastInsert = 0;
            less_than_100_loop:
                if (k < length && words_only_once_arr[k] != null )
                {
                    if (words_once_count_arr[k] <= 100)
                    {                        
                        words_only_once_arr_less_than_100[LastInsert] = words_only_once_arr[k];
                        LastInsert++;
                    }                
                    k++;
                    goto less_than_100_loop;
                }
            int write = 0;
            int sort = 0;
            bool toSwapWords = false;
            int counter = 0;
            int word_lenth_cur = 0;
            int word_lenth_next = 0;
            sort_loop:
                if(write< words_only_once_arr_less_than_100.Length && words_only_once_arr_less_than_100[write] != null)
                {
                    sort = 0;
                    inner_sort_loop:
                        if(sort< words_only_once_arr_less_than_100.Length - write - 1 && words_only_once_arr_less_than_100[sort+1] != null)
                        {
                            word_lenth_cur = words_only_once_arr_less_than_100[sort].Length;
                            word_lenth_next = words_only_once_arr_less_than_100[sort + 1].Length;

                            int compare_lenth = word_lenth_cur > word_lenth_next ? word_lenth_next : word_lenth_cur;

                            toSwapWords = false;
                            counter = 0;
                        check_alphabet:

                            if (words_only_once_arr_less_than_100[sort][counter] > words_only_once_arr_less_than_100[sort + 1][counter])
                            {
                                toSwapWords = true;
                                goto check_alphabet_end;
                            }
                            if (words_only_once_arr_less_than_100[sort][counter] < words_only_once_arr_less_than_100[sort + 1][counter])
                            {
                                goto check_alphabet_end;
                            }
                            counter++;
                            if (counter < compare_lenth)
                            {
                                goto check_alphabet;
                            }
                        check_alphabet_end:
                        if (toSwapWords)
                        {
                            string temp = words_only_once_arr_less_than_100[sort];
                            words_only_once_arr_less_than_100[sort] = words_only_once_arr_less_than_100[sort + 1];
                            words_only_once_arr_less_than_100[sort + 1] = temp;
                        }
                            sort++;
                            goto inner_sort_loop;
                        }
                    write++;
                    goto sort_loop; 
                }
                k = 0;
        int less_than_100_length = words_only_once_arr_less_than_100.Length;


            
        print_loop:
                if (k < less_than_100_length && words_only_once_arr_less_than_100[k] != null)
                {
                    Console.Write("{0} - ", words_only_once_arr_less_than_100[k]);
                    int first_dim = 0;
                    int second_dim = 0;
                    int[] word_pages = new int[100];
                    int pageInsert = 0;

                    check_page:
                        if(first_dim< 10000 && pages_words_arr[first_dim,0] != null)
                        {
                            second_dim = 0;
                            check_page_word:
                            if (second_dim < 10000 && pages_words_arr[first_dim, second_dim] != null)
                            {
                                if(pages_words_arr[first_dim, second_dim] == words_only_once_arr_less_than_100[k])
                                {
                                    word_pages[pageInsert] = first_dim + 1;
                                    pageInsert++;
                                    first_dim++;
                                    goto check_page;
                                }
                                second_dim++;
                                goto check_page_word;
                            }

                            first_dim++;
                            goto check_page;
                        }
                    int tired_counte = 0;
                    pagination_loop:
                        if(tired_counte<100 && word_pages[tired_counte] != 0)
                        {
                            if(tired_counte!=99 && word_pages[tired_counte + 1] != 0)
                            {
                                Console.Write("{0}, ", word_pages[tired_counte]);
                            }
                            else
                            {
                                Console.Write("{0}", word_pages[tired_counte]);
                            }
                            tired_counte++;
                            goto pagination_loop;
                        }
                    Console.WriteLine();
                    k++;
                    goto print_loop;
                }
        }
    }
}
