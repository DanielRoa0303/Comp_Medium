#include <stdio.h>
#include <stdlib.h>
#include <time.h>

/*
IMPORTANT INFO TO MAKE THE PROGRAM
6 seats
Menu: Your program should display the following menu of alternatives:
Initialize all the elements of the array to 0 = that all seats are empty.
Please type 1 for "first class"     1-3
Please type 2 for "economy"         4-6
Seat is assigned randomly

Create a function named search_seat to assign passenger's seat
Create a function named print_boarding_pass to print passenger's boarding info.

Print boarding pass indicating the person's seat number and whether it’s in the
first class or economy section of the plane.
One-dimensional array to represent the plane’s seating chart
As each seat is assigned, set the corresponding element of the array to 1 to 
indicate that the seat is no longer available.
When the first-class section is full, your program should ask the person if 
it’s acceptable to be placed in the economy section (and vice versa).
If yes, then make the appropriate seat assignment. If no, then print the
message, "Next flight leaves in 3 hours."
Once you assign the seat for one passenger, ask user if there are more
passenger waiting.

*/

int main()
{
    system("cls");

    // We define the variables that we are going to use in main.
    int morePassengers = 1;
    int classes;
    int seat_num;
    int class_change;
    int seats[6] = {0};
    // random number generator every time the program is run.
    srand(time(NULL));
    do
    {
        printf("%s", "Please type 1 for \"first class\"\n");
        printf("%s", "Please type 2 for \"economy class\"\n");
        scanf("%d", &classes);

        // We call the function that checks if all the seats are full.
        if (all_seats_full(seats, 6))
        {
            printf("Next flight leaves in 3 hours. All of our"
             "seats are taken.\n");
        }

        else
        {
            if (classes == 1)
            {
                // We call the search seats function, with the parameters of 
                // the array, initial seat in position 0 and final seat in 
                // position 2 (according to the class).
                seat_num = search_seat(seats, 0, 2);
                if (seat_num == -1)
                {
                    printf("No seat available in first class, do you want a "
                    "seat in economy class? 1=yes | 0=no: ");
                    scanf("%d", &class_change);
                    if (class_change == 1)
                    {
                        seat_num = search_seat(seats, 3, 5);
                        if (seat_num != -1)
                        {
                            // seat_num is added 1 because seat_num is the 
                            // index, but the seat number is +1
                            // Number 2 is class. First = 1, economic = 2
                            print_boarding_pass(seat_num + 1, 2);
                        }
                        else
                        {
                            printf("Next flight leaves in 3 hours.\n");
                        }
                    }
                    else
                    {
                        printf("Next flight leaves in 3 hours.\n");
                    }
                }

                else
                {
                    print_boarding_pass(seat_num + 1, 1);
                }
            }

            // Copy paste of class 1 is repeated but changing the search_seat 
            // parameters to accommodate the corresponding class//
            else if (classes == 2)
            {
                // We call the search seats function, with the array parameters
                // initial seat in position 0 and final seat in position 2.
                seat_num = search_seat(seats, 3, 5);
                if (seat_num == -1)
                {
                    printf("No seat available in economy class, do you want a"
                    " seat in first class? 1=yes | 0=no: ");
                    scanf("%d", &class_change);
                    if (class_change == 1)
                    {
                        seat_num = search_seat(seats, 0, 2);
                        if (seat_num != -1)
                        {
                            print_boarding_pass(seat_num + 1, 1);
                        }
                        else
                        {
                            printf("Next flight leaves in 3 hours.\n");
                        }
                    }
                    else
                    {
                        printf("Next flight leaves in 3 hours.\n");
                    }
                }

                else
                {
                    print_boarding_pass(seat_num + 1, 2);
                }
            }
        }
        printf("Does everyone boarded? 0=no | 1=yes: ");
        scanf("%d", &morePassengers);
    } while (morePassengers == 0);
}

// Function to check if all seats are full
int all_seats_full(int seats[], int size)
{
    for (int i = 0; i < size; i++)
    {
        if (seats[i] == 0)
        {
            // If there is at least one seat available
            return 0;
        }
    }
    // All seats are full
    return 1;
}

int search_seat(int seats[], int first, int last)
{
    // Array with the available seats. Since there are only 3 seats per class, 
    // the array only has 3 spaces
    int seats_available[3];
    // counter that checks how many seats have been found available. It 
    // increases when a free seat is found.
    int count = 0;
    int random_index;
    int selected_seat;

    // for loop that checks seats from first to last to see which one 
    // is available
    for (int i = first; i <= last; i++)
    {
        // if seat x "at position i" is available, then...
        if (seats[i] == 0)
        {
            // count add 1
            seats_available[count++] = i;
        }
    }
    // If there are no seats available, return -1
    if (count == 0)
    {
        return -1;
    }

    // Taking into account the number of available seats determined by the 
    // count variable, we choose a random seat.
    random_index = rand() % count;
    selected_seat = seats_available[random_index];

    // Mark the seat as assigned
    seats[selected_seat] = 1;
    return selected_seat;
}

// Function that prints boarding passes, taking information about seats 
// and classes.
void print_boarding_pass(int seat, int classes)
{
    if (classes == 1)
    {
        printf("Your seat is assigned to first class seat %d \n", seat);
    }
    if (classes == 2)
    {
        printf("Your seat is assigned to economy class seat %d \n", seat);
    }
}


/*
COP3223 Fall 2024 <Assignment2.3>
Copyright 2024 Roa Navarro Daninel Felipe
*/