using Avalonia.Controls;
using Management.Models;
using Management.Models.DTO;
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

            SelectedStaff.ItemsSource = StaticActions.staff.Where(s => s.Departmentid == (ShowDepartments.SelectedItem as DepartmentDTO).Id).ToList();
        }
    }
}