using System;
using System.Collections.Generic;

namespace Inheritance;

class Program
{
    static void Main()
    {
        StudentMember student =
            new StudentMember("S1", "Ali", "01000000000");

        PremiumMember premium =
            new PremiumMember("P1", "Mona", "01111111111", 20);

        Book book =
            new Book("B1", "Clean Code", 10);

        DVD dvd =
            new DVD("D1", "Inception", 20);

        Magazine magazine =
            new Magazine("M1", "Science Weekly", 5);

        Librarian librarian =
            new Librarian(
                "ST1",
                "Ali",
                "01222222222",
                new DateTime(2025, 1, 1),
                10000);

        Shelver shelver =
            new Shelver(
                "ST2",
                "Omar",
                "01233333333",
                new DateTime(2025, 1, 1),
                8000,
                "Science");

        HeadLibrarian head =
            new HeadLibrarian(
                "ST3",
                "Mona",
                "01244444444",
                new DateTime(2025, 1, 1),
                15000);

        head.GiveRaise(10);

        List<Staff> staffList = new List<Staff>
        {
            librarian,
            shelver,
            head
        };

        foreach (Staff staff in staffList)
        {
            Console.WriteLine(
                staff.FullName + " - " + staff.MonthlyPay);
        }

        Console.WriteLine();

        List<LibraryItem> items = new List<LibraryItem>
        {
            book,
            dvd,
            magazine
        };

        foreach (LibraryItem item in items)
        {
            Console.WriteLine(
                item.Title + " - " +
                item.LoanPeriodDays + " days - " +
                item.DailyLateFee);
        }

        Console.WriteLine();

        Loan premiumLoan =
            premium.Borrow(
                dvd,
                "L1",
                new DateTime(2026, 9, 1, 12, 0, 0));

        librarian.ProcessReturn(
            premiumLoan,
            new DateTime(2026, 9, 13, 12, 0, 0));

        Console.WriteLine(
            "Due date: " + premiumLoan.DueDate);

        Console.WriteLine(
            "Late fee: " + premiumLoan.LateFee);

        Console.WriteLine(
            "Reading points: " + premium.ReadingPoints);

        Console.WriteLine();

        try
        {
            student.Borrow(
                book,
                "L2",
                new DateTime(2026, 9, 1));

            student.Borrow(
                magazine,
                "L3",
                new DateTime(2026, 9, 1));

            student.Borrow(
                dvd,
                "L4",
                new DateTime(2026, 9, 1));

            student.Borrow(
                new Book("B2", "OOP", 10),
                "L5",
                new DateTime(2026, 9, 1));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();

        try
        {
            head.Withdraw(book);

            student.Borrow(
                book,
                "L6",
                new DateTime(2026, 9, 1));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();

        try
        {
            Loan loan = premium.Borrow(
                magazine,
                "L7",
                new DateTime(2026, 9, 1));

            librarian.ProcessReturn(
                loan,
                new DateTime(2026, 9, 2));

            librarian.ProcessReturn(
                loan,
                new DateTime(2026, 9, 3));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();

        try
        {
            Loan loan = premium.Borrow(
                new Book("B3", "Design Patterns", 10),
                "L8",
                new DateTime(2026, 9, 1));

            librarian.ProcessReturn(
                loan,
                new DateTime(2026, 9, 2));

            librarian.MarkAsLost(loan);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Must NOT compile:
        // Person person = new Person("P1", "Test", "010");
        // Member member = new Member("M1", "Test", "010", 3, 0);
        // Staff staff = new Staff("S1", "Test", "010", DateTime.Now, 5000, 0);

        // student.FullName = "New Name";
        // student.Loans.Add(premiumLoan);
        // book.IsOnLoan = true;
    }
}