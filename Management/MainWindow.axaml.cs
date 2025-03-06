using Avalonia.Controls;
using Management.Models;
using Management.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Management
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowDepartments.ItemsSource = StaticActions.departments.ToList();
        }

        private void TreeView_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {

            int departmentId = (int)(ShowDepartments.SelectedItem as DepartmentDTO)?.Id;
            List<int> departmentsIds = StaticActions.dependents.Where(d => d.Masterdepartmentid == departmentId).Select(d => d.Juniordepartmentid).ToList();
            departmentsIds.Add(departmentId);
            SelectedStaff.ItemsSource = StaticActions.staff.Where(s => departmentsIds.Contains(s.Departmentid)).ToList();
        }

        private void AddWorker(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            new StaffCard().ShowDialog(this);
        }

        private void ListBox_SelectionChanged_1(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {

        }

        private void Border_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            if ((SelectedStaff.SelectedItem as Staff) != null)
                new StaffCard((SelectedStaff.SelectedItem as Staff).Id).ShowDialog(this);
            StaticActions.staff = StaticActions.DBContext.Staff.Include(s => s.Position).Include(s => s.Cabinet).Include(s => s.Department).ToList();

            int departmentId = (int)(ShowDepartments.SelectedItem as DepartmentDTO)?.Id;
            List<int> departmentsIds = StaticActions.dependents.Where(d => d.Masterdepartmentid == departmentId).Select(d => d.Juniordepartmentid).ToList();
            departmentsIds.Add(departmentId);
            SelectedStaff.ItemsSource = StaticActions.staff.Where(s => departmentsIds.Contains(s.Departmentid)).ToList();
        }
    }
}