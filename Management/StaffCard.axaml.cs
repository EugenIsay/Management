using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using HarfBuzzSharp;
using Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Management;

public partial class StaffCard : Window
{
    int Id = -1;
    public StaffCard()
    {
        InitializeComponent();
        DepartamentCB.ItemsSource = StaticActions.RawDepartments.ToList();
        PositionCB.ItemsSource = StaticActions.DBContext.Positions.ToList();
        CaninetCB.ItemsSource = StaticActions.DBContext.Cabinets.ToList();
        StaffGrid.IsEnabled = true;
        RedactB.IsEnabled = false;
        ReadyB.IsEnabled = true;
    }
    public StaffCard(int Id)
    {
        this.Id = Id;
        InitializeComponent();
        Tab.SelectedIndex = 0;
        DepartamentCB.ItemsSource = StaticActions.RawDepartments.ToList();
        PositionCB.ItemsSource = StaticActions.DBContext.Positions.ToList();
        CaninetCB.ItemsSource = StaticActions.DBContext.Cabinets.ToList();

        Staff staff = StaticActions.staff.FirstOrDefault(s => s.Id == Id);
        Surname.Text = staff.Surname;
        Name.Text = staff.Name;
        Patronimic.Text = staff.Patronymic;
        BDay.SelectedDate = new DateTimeOffset(staff.Birthday.ToDateTime(new TimeOnly()));
        Phone.Text = staff.Phone;
        Email.Text = staff.Email;
        DepartamentCB.SelectedItem = staff.Department;
        PositionCB.SelectedItem = staff.Position;
        CaninetCB.SelectedItem = staff.Cabinet;
    }

    private void Redact(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        StaffGrid.IsEnabled = true;
        RedactB.IsEnabled = false;
        ReadyB.IsEnabled = true;
    }

    private void Comfirm(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Staff staff;
        if (Id != -1)
        {
            staff = new Staff();
        }
        else
        {
            staff = StaticActions.DBContext.Staff.FirstOrDefault(s => s.Id == Id);
        }
        staff.Surname = Surname.Text;
        staff.Name = Name.Text;
        staff.Patronymic = Patronimic.Text;
        staff.Birthday = DateOnly.FromDateTime(BDay.SelectedDate.Value.Date);
        staff.Phone = Phone.Text;
        staff.Email = Email.Text;
        staff.Department = DepartamentCB.SelectedItem as Department;
        staff.Position = PositionCB.SelectedItem as Position;
        staff.Cabinet = CaninetCB.SelectedItem as Cabinet;
        if (Id != -1)
        {
            StaticActions.DBContext.Staff.Add(staff);
            StaticActions.DBContext.SaveChanges();
            Id = StaticActions.DBContext.Staff.OrderBy(s => s.Id).Last().Id;
            Tab.SelectedIndex = 0;
        }
        else
        {
            StaticActions.DBContext.Staff.Update(staff);
            StaticActions.DBContext.SaveChanges();
        }

        StaffGrid.IsEnabled = false;
        RedactB.IsEnabled = true;
        ReadyB.IsEnabled = false;
    }

    private void TabControl_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        List<Staffstatus> dates = StaticActions.DBContext.Staffstatuses.Where(d => d.Staffid == Id).ToList();
        if (Tab != null)
        switch (Tab.SelectedIndex)
        {
            case 0:
                List<Staffstatus> oldDates = dates.Where(d => d.Day < DateOnly.FromDateTime(DateTime.Now)).ToList();
                lessonsLB.ItemsSource = oldDates.Where(d => d.Statusid == 7);
                TimeOff.ItemsSource = oldDates.Where(d => d.Statusid == 3);
                Vacations.ItemsSource = oldDates.Where(d => d.Statusid == 4);
                break;
            case 1:
                List<Staffstatus> nowDates = dates.Where(d => d.Day >= DateOnly.FromDateTime(DateTime.Now) && d.Day < DateOnly.FromDateTime(DateTime.Now).AddDays(7)).ToList();
                lessonsLB.ItemsSource = nowDates.Where(d => d.Statusid == 7);
                TimeOff.ItemsSource = nowDates.Where(d => d.Statusid == 3);
                Vacations.ItemsSource = nowDates.Where(d => d.Statusid == 4);
                break;
            case 2:
                List <Staffstatus> futureDates = dates.Where(d => d.Day >= DateOnly.FromDateTime(DateTime.Now).AddDays(7)).ToList();
                lessonsLB.ItemsSource = futureDates.Where(d => d.Statusid == 7);
                TimeOff.ItemsSource = futureDates.Where(d => d.Statusid == 3);
                Vacations.ItemsSource = futureDates.Where(d => d.Statusid == 4);
                break;
        }
    }
}