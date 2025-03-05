using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Management.Models;
using System;
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
    }
    public StaffCard(int Id)
    {
        this.Id = Id;
        InitializeComponent();
        DepartamentCB.ItemsSource = StaticActions.RawDepartments.ToList();
        PositionCB.ItemsSource = StaticActions.DBContext.Positions.ToList();
        CaninetCB.ItemsSource = StaticActions.DBContext.Cabinets.ToList();

        Staff staff = StaticActions.staff.FirstOrDefault(s => s.Id == Id);
        Surname.Text = staff.Name;
        Name.Text = staff.Name;
        Patronimic.Text = staff.Patronymic;
        BDay.SelectedDate = new DateTimeOffset(staff.Birthday.ToDateTime(new TimeOnly())) ;
        Phone.Text = staff.Phone;
        Email.Text = staff.Email;
        DepartamentCB.SelectedItem = staff.Department;
        PositionCB.SelectedItem = staff.Position;
        CaninetCB.SelectedItem = staff.Cabinet;
    }
}